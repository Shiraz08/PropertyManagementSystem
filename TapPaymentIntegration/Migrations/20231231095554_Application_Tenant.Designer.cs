﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property_Management_Sys.Data;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    [DbContext(typeof(TapPaymentIntegrationContext))]
    [Migration("20231231095554_Application_Tenant")]
    partial class Application_Tenant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Property_Management_Sys.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Agreement_Form", b =>
                {
                    b.Property<int>("Agreement_Form_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Agreement_Form_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Agreement_Form_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Agreement_Period_From_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Agreement_Period_To_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apt_Villa_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Builiding_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complex_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elec_Water_Acc_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Invoice_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Landlord_EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Landlord_Id")
                        .HasColumnType("int");

                    b.Property<string>("Landlord_Identiy_Card_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Unique_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Whatsapp_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_Term")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pro_Detail_Id")
                        .HasColumnType("int");

                    b.Property<string>("Rent_Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Security_Desposit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tenant_Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Tenant_Id")
                        .HasColumnType("int");

                    b.Property<string>("Tenant_Identity_Card")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Water_Acc_NO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Agreement_Form_Id");

                    b.ToTable("Tbl_Agreement_Form");
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Agreement_Period", b =>
                {
                    b.Property<int>("Agreement_Period_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Agreement_Period_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Agreement_Period_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Agreement_Period_From_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Agreement_Period_To_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_Term")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rent_Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Security_Desposit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Agreement_Period_Id");

                    b.ToTable("Tbl_Agreement_Period");
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Invoices", b =>
                {
                    b.Property<int>("Invoice_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Invoice_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Agreement_Form_Id")
                        .HasColumnType("int");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Invoice_Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Invoice_Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Invoice_Paid")
                        .HasColumnType("bit");

                    b.Property<bool?>("Invoice_Paid_To_Landlord")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Landlord_Id")
                        .HasColumnType("int");

                    b.Property<string>("Landlord_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rent_Ammount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Tenant_Id")
                        .HasColumnType("int");

                    b.Property<string>("Tenant_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Invoice_Id");

                    b.ToTable("Tbl_Invoices");
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Landlord", b =>
                {
                    b.Property<int>("Landlord_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Landlord_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Landlord_Datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Landlord_EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Identiy_Card_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Unique_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Whatsapp_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Landlord_Id");

                    b.ToTable("Tbl_Landlord");
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Landlord_Generate_Invoice", b =>
                {
                    b.Property<int>("Landlord_Generate_Invoice_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Landlord_Generate_Invoice_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Landlord_Generate_Invoice_Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Landlord_Generate_Invoice_Datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Landlord_Generate_Invoice_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Generate_Invoice_Extra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landlord_Generate_Invoice_Total")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Landlord_Generate_Invoice_Id");

                    b.ToTable("Tbl_Landlord_Generate_Invoice");
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Property_Detail", b =>
                {
                    b.Property<int>("Pro_Detail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pro_Detail_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apt_Villa_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Builiding_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complex_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elec_Water_Acc_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LanLoadrd_Id")
                        .HasColumnType("int");

                    b.Property<string>("LanLoadrd_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Pro_Detail_Datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PropertyDetailStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Water_Acc_NO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pro_Detail_Id");

                    b.ToTable("Tbl_Property_Detail");
                });

            modelBuilder.Entity("Property_Management_Sys.Models.Tbl_Tenant", b =>
                {
                    b.Property<int>("Tenant_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tenant_Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tenant_Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Tenant_Datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tenant_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_Identity_Card")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tenant_Id");

                    b.ToTable("Tbl_Tenant");
                });

            modelBuilder.Entity("PropertyManagementSystem.Models.TableEntities.AppTenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppTenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenantIdextra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantId");

                    b.ToTable("AppTenant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Property_Management_Sys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Property_Management_Sys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Property_Management_Sys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Property_Management_Sys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
