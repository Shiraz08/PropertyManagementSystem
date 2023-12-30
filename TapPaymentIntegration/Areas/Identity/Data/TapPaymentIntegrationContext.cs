using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Models;
using PropertyManagementSystem.Models.TableEntities;

namespace Property_Management_Sys.Data;

public class TapPaymentIntegrationContext : IdentityDbContext<ApplicationUser>
{
    public TapPaymentIntegrationContext(DbContextOptions<TapPaymentIntegrationContext> options)
        : base(options)
    {
    }
    public DbSet<Tbl_Agreement_Form> Tbl_Agreement_Form { get; set; }
    public DbSet<Tbl_Agreement_Period> Tbl_Agreement_Period { get; set; }
    public DbSet<Tbl_Invoices> Tbl_Invoices { get; set; }
    public DbSet<Tbl_Landlord> Tbl_Landlord { get; set; } 
    public DbSet<Tbl_Landlord_Generate_Invoice> Tbl_Landlord_Generate_Invoice { get; set; } 
    public DbSet<Tbl_Property_Detail> Tbl_Property_Detail { get; set; } 
    public DbSet<Tbl_Tenant> Tbl_Tenant { get; set; } 
    public DbSet<AppTenant> AppTenant { get; set; }  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


    }
}
