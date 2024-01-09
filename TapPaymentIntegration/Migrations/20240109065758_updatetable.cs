using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basic_Apt_Villa_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_Complex_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_Elec_Water_Acc_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_Water_Acc_NO",
                table: "Tbl_Property_Detail");

            migrationBuilder.AlterColumn<string>(
                name: "Inventory_Name",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Inventory_Description",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Inventory_Name",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_Description",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Basic_Apt_Villa_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Basic_Complex_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Basic_Elec_Water_Acc_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Basic_Water_Acc_NO",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
