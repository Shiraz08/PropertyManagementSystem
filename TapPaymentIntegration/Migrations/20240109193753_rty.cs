using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    public partial class rty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Asset_data_Typeasset",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DocumentsFileName",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryFileName",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentsFileName",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "InventoryFileName",
                table: "Tbl_Property_Detail");

            migrationBuilder.AlterColumn<string>(
                name: "Asset_data_Typeasset",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
