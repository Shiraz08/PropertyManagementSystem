using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PropertyContextConnection") ?? throw new InvalidOperationException("Connection string 'PropertyContextConnection' not found.");
builder.Services.AddDbContext<TapPaymentIntegrationContext>(options =>options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<TapPaymentIntegrationContext>();
builder.Services.AddDbContext<TapPaymentIntegrationContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add other services
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
// Configure Ajax settings
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
// Add Hangfire services
//builder.Services.AddHangfire(configuration => configuration
//    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//    .UseSimpleAssemblyNameTypeSerializer()
//    .UseRecommendedSerializerSettings()
//    .UseSqlServerStorage(builder.Configuration.GetConnectionString("TapPaymentIntegrationContextConnection"), new SqlServerStorageOptions
//    {
//        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
//        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
//        QueuePollInterval = TimeSpan.Zero,
//        UseRecommendedIsolationLevel = true,
//        DisableGlobalLocks = true
//    }));

// Add the processing server as IHostedService
//builder.Services.AddHangfireServer();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



builder.Services.AddAuthentication()
    .AddGoogle("google", opt =>
    {
        var googleAuth = builder.Configuration.GetSection("Authentication:Google");
        opt.ClientId = googleAuth["ClientId"];
        opt.ClientSecret = googleAuth["ClientSecret"];
        opt.SignInScheme = IdentityConstants.ExternalScheme;

    });
// Session
builder.Services.AddMvc();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromHours(60);
});
//email sender override class
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromHours(2));
builder.Services.AddTransient<IEmailSender, EmailSender>();
// LOgot user by admin 
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});
// Ajax Setting
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await StaticRoles.SeedRolesAsync(userManager, roleManager);
    await StaticRoles.SeedSuperAdminAsync(userManager, roleManager);

}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
    endpoints.MapControllers();
    //endpoints.MapHangfireDashboard();
});
app.Run();


app.UseExceptionHandler("/Home/Error");
app.UseHsts();