using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTenant",
                columns: table => new
                {
                    TenantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTenant", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Agreement_Form",
                columns: table => new
                {
                    Agreement_Form_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agreement_Period_From_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Agreement_Period_To_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rent_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Security_Desposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Id = table.Column<int>(type: "int", nullable: true),
                    Landlord_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Whatsapp_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Identiy_Card_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Unique_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pro_Detail_Id = table.Column<int>(type: "int", nullable: true),
                    Building_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Builiding_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apt_Villa_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complex_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elec_Water_Acc_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Id = table.Column<int>(type: "int", nullable: true),
                    Tenant_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Identity_Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agreement_Form_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invoice_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water_Acc_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Agreement_Form", x => x.Agreement_Form_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Agreement_Period",
                columns: table => new
                {
                    Agreement_Period_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agreement_Period_From_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Agreement_Period_To_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rent_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Security_Desposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agreement_Period_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Agreement_Period", x => x.Agreement_Period_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Invoices",
                columns: table => new
                {
                    Invoice_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Landlord_Id = table.Column<int>(type: "int", nullable: true),
                    Tenant_Id = table.Column<int>(type: "int", nullable: true),
                    Invoice_Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invoice_Paid = table.Column<bool>(type: "bit", nullable: true),
                    Tenant_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rent_Ammount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agreement_Form_Id = table.Column<int>(type: "int", nullable: true),
                    Invoice_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invoice_Paid_To_Landlord = table.Column<bool>(type: "bit", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Invoices", x => x.Invoice_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Landlord",
                columns: table => new
                {
                    Landlord_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Landlord_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Whatsapp_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Identiy_Card_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Unique_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Landlord", x => x.Landlord_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Landlord_Generate_Invoice",
                columns: table => new
                {
                    Landlord_Generate_Invoice_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Landlord_Generate_Invoice_Datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Landlord_Generate_Invoice_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Generate_Invoice_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Generate_Invoice_Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landlord_Generate_Invoice_Extra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Landlord_Generate_Invoice", x => x.Landlord_Generate_Invoice_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Property_Detail",
                columns: table => new
                {
                    Pro_Detail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Builiding_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apt_Villa_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complex_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elec_Water_Acc_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pro_Detail_Datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanLoadrd_Id = table.Column<int>(type: "int", nullable: true),
                    LanLoadrd_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water_Acc_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyDetailStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Property_Detail", x => x.Pro_Detail_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Tenant",
                columns: table => new
                {
                    Tenant_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Identity_Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_Datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppTenantPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tenant", x => x.Tenant_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTenant");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tbl_Agreement_Form");

            migrationBuilder.DropTable(
                name: "Tbl_Agreement_Period");

            migrationBuilder.DropTable(
                name: "Tbl_Invoices");

            migrationBuilder.DropTable(
                name: "Tbl_Landlord");

            migrationBuilder.DropTable(
                name: "Tbl_Landlord_Generate_Invoice");

            migrationBuilder.DropTable(
                name: "Tbl_Property_Detail");

            migrationBuilder.DropTable(
                name: "Tbl_Tenant");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
