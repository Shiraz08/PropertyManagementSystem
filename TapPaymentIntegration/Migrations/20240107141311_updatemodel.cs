using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementSystem.Migrations
{
    public partial class updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apt_Villa_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Building_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Builiding_Name",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Complex_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Pro_Detail_Datetime",
                table: "Tbl_Property_Detail");

            migrationBuilder.RenameColumn(
                name: "Water_Acc_NO",
                table: "Tbl_Property_Detail",
                newName: "Basic_Water_Acc_NO");

            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "Tbl_Property_Detail",
                newName: "Basic_Elec_Water_Acc_No");

            migrationBuilder.RenameColumn(
                name: "PropertyDetailStatus",
                table: "Tbl_Property_Detail",
                newName: "Basic_Complex_No");

            migrationBuilder.RenameColumn(
                name: "Elec_Water_Acc_No",
                table: "Tbl_Property_Detail",
                newName: "Basic_Apt_Villa_No");

            migrationBuilder.AlterColumn<int>(
                name: "LanLoadrd_Id",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Address1",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Address2",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Locality",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Region",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Asset_data_AliasProperty",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Asset_data_Typeasset",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Asset_status_PropertyDetailStatus",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Assetnotes_Annotations",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Basic_Building_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Basic_Builiding_Name",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Basic_PostalCode",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Basic_PropertyType",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Cadastralreference",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Cadastralvalue",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Constructiondate",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Currency",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Saleprice",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Squaremeters",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Targetrentalprice",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cadastraldata_Usefulmeters",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Energycertificate_Consumption",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expenses_Communityexpenses",
                table: "Tbl_Property_Detail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Expenses_Communityexpensesdate",
                table: "Tbl_Property_Detail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Expenses_IBIexpenses",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expenses_IBIexpensescostsdate",
                table: "Tbl_Property_Detail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Expenses_Purchaseexpenses",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Expenses_Purchaseexpensesdate",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_Description",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_Name",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Address1",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Address_Address2",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Address_Locality",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Address_Region",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Asset_data_AliasProperty",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Asset_data_Typeasset",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Asset_status_PropertyDetailStatus",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Assetnotes_Annotations",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_Building_No",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_Builiding_Name",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_PostalCode",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Basic_PropertyType",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Cadastralreference",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Cadastralvalue",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Constructiondate",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Currency",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Saleprice",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Squaremeters",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Targetrentalprice",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Cadastraldata_Usefulmeters",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Energycertificate_Consumption",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Expenses_Communityexpenses",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Expenses_Communityexpensesdate",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Expenses_IBIexpenses",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Expenses_IBIexpensescostsdate",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Expenses_Purchaseexpenses",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Expenses_Purchaseexpensesdate",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Inventory_Description",
                table: "Tbl_Property_Detail");

            migrationBuilder.DropColumn(
                name: "Inventory_Name",
                table: "Tbl_Property_Detail");

            migrationBuilder.RenameColumn(
                name: "Basic_Water_Acc_NO",
                table: "Tbl_Property_Detail",
                newName: "Water_Acc_NO");

            migrationBuilder.RenameColumn(
                name: "Basic_Elec_Water_Acc_No",
                table: "Tbl_Property_Detail",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "Basic_Complex_No",
                table: "Tbl_Property_Detail",
                newName: "PropertyDetailStatus");

            migrationBuilder.RenameColumn(
                name: "Basic_Apt_Villa_No",
                table: "Tbl_Property_Detail",
                newName: "Elec_Water_Acc_No");

            migrationBuilder.AlterColumn<int>(
                name: "LanLoadrd_Id",
                table: "Tbl_Property_Detail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Apt_Villa_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Building_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Builiding_Name",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complex_No",
                table: "Tbl_Property_Detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Pro_Detail_Datetime",
                table: "Tbl_Property_Detail",
                type: "datetime2",
                nullable: true);
        }
    }
}
