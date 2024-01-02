using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    public partial class addtenanti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Landlord_Generate_Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Landlord",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Agreement_Period",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "Tbl_Agreement_Form",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TenantPropertyName",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenantName",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppTenantId",
                table: "AppTenant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Tenant");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Landlord_Generate_Invoice");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Landlord");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Invoices");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Agreement_Period");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "Tbl_Agreement_Form");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "AppTenant");

            migrationBuilder.AlterColumn<string>(
                name: "TenantPropertyName",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenantName",
                table: "AppTenant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
