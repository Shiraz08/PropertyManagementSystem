using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    public partial class tenantupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Tenant");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Tenant");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Tenant");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Landlord_Generate_Invoice");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Landlord_Generate_Invoice");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Landlord_Generate_Invoice");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Landlord");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Landlord");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Landlord");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Invoices");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Invoices");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Invoices");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Agreement_Period");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Agreement_Period");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Agreement_Period");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Agreement_Form");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "Tbl_Agreement_Form");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "Tbl_Agreement_Form");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "AppTenant");

            migrationBuilder.DropColumn(
                name: "AppTenantName",
                table: "AppTenant");

            migrationBuilder.DropColumn(
                name: "AppTenantPropertyName",
                table: "AppTenant");

            migrationBuilder.DropColumn(
                name: "TenantIdextra",
                table: "AppTenant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Tenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Tenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Tenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Landlord_Generate_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Landlord_Generate_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Landlord_Generate_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Landlord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Landlord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Landlord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Agreement_Period",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Agreement_Period",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Agreement_Period",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "Tbl_Agreement_Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "Tbl_Agreement_Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "Tbl_Agreement_Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantName",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantPropertyName",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantIdextra",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
