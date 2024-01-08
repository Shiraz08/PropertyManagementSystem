using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property_Management_Sys.Models
{
    public class Tbl_Property_Detail : BaseEntities
    {
        [Key]
        public int Pro_Detail_Id { get; set; }


        [Required(ErrorMessage = "Building No is required")]
        [Display(Name = "Building No")]
        public string Basic_Building_No { get; set; }


        [Required(ErrorMessage = "Builiding Name is required")]
        [Display(Name = "Builiding Name")]
        public string Basic_Builiding_Name { get; set; }



        [Display(Name = "Apt Villa No")]
        public string Basic_Apt_Villa_No { get; set; }


        [Display(Name = "Complex No")]
        public string Basic_Complex_No { get; set; }


        [Display(Name = "Elec Acc No")]
        public string Basic_Elec_Water_Acc_No { get; set; }


        [Required(ErrorMessage = "Lanlord Name is required")]
        public Nullable<int> LanLoadrd_Id { get; set; }


        [Display(Name = "Landlord Name")]
        public string LanLoadrd_Name { get; set; }


        [Display(Name = "Water Acc No")]
        public string Basic_Water_Acc_NO { get; set; }


        [Required(ErrorMessage = "Property Type is required")]
        [Display(Name = "Property Type")]
        public string Basic_PropertyType { get; set; }


        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public string Asset_status_PropertyDetailStatus { get; set; }


        [Required(ErrorMessage = "Alias of the property is required")]
        [Display(Name = "Alias of the property")]
        public string Asset_data_AliasProperty { get; set; }



        [Required(ErrorMessage = "Type asset is required")]
        [Display(Name = "Type Asset")]
        public string Asset_data_Typeasset { get; set; }


        [Required(ErrorMessage = "Address line 1 is required")]
        [Display(Name = "Address line 1")]
        public string Address_Address1 { get; set; }


        [Required(ErrorMessage = "Address line 2 is required")]
        [Display(Name = "Address line 2")]
        public string Address_Address2 { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public string Address_Country { get; set; }


        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public string Address_Region { get; set; }


        [Required(ErrorMessage = "Locality is required")]
        [Display(Name = "Locality")]
        public string Address_Locality { get; set; }


        [Required(ErrorMessage = "PostalCode is required")]
        [Display(Name = "PostalCode")]
        public string Basic_PostalCode { get; set; }


        [Required(ErrorMessage = "Consumption is required")]
        [Display(Name = "Consumption")]
        public string Energycertificate_Consumption { get; set; }



        [Required(ErrorMessage = "Annotations is required")]
        [Display(Name = "Annotations")]
        public string Assetnotes_Annotations { get; set; }


        //Data and expenses
        [Required(ErrorMessage = "Cadastral reference is required")]
        [Display(Name = "Cadastral reference")]
        public string Cadastraldata_Cadastralreference { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [Display(Name = "Currency")]
        public string Cadastraldata_Currency { get; set; }


        [Required(ErrorMessage = "Cadastral value is required")]
        [Display(Name = "Cadastral value")]
        public string Cadastraldata_Cadastralvalue { get; set; }


        [Required(ErrorMessage = "Square meters is required")]
        [Display(Name = "Square meters")]
        public string Cadastraldata_Squaremeters { get; set; }

        [Required(ErrorMessage = "Useful meters is required")]
        [Display(Name = "Useful meters")]
        public string Cadastraldata_Usefulmeters { get; set; }


        [Required(ErrorMessage = "Construction date is required")]
        [Display(Name = "Construction date")]
        public string Cadastraldata_Constructiondate { get; set; }


        [Required(ErrorMessage = "Sale price is required")]
        [Display(Name = "Sale price")]
        public string Cadastraldata_Saleprice { get; set; }


        [Required(ErrorMessage = "Target rental price is required")]
        [Display(Name = "Target rental price")]
        public string Cadastraldata_Targetrentalprice { get; set; }




        [Required(ErrorMessage = "Purchase expenses is required")]
        [Display(Name = "Purchase expenses")]
        public string Expenses_Purchaseexpenses { get; set; }

        [Required(ErrorMessage = "Purchase expenses date is required")]
        [Display(Name = "Purchase expenses date")]
        public string Expenses_Purchaseexpensesdate { get; set; }


        [Required(ErrorMessage = "IBI expenses is required")]
        [Display(Name = "IBI expenses")]
        public string Expenses_IBIexpenses { get; set; }


        [Required(ErrorMessage = "IBI expenses costs date is required")]
        [Display(Name = "IBI expenses costs date")]
        public DateTime Expenses_IBIexpensescostsdate { get; set; }


        [Required(ErrorMessage = "Community expenses is required")]
        [Display(Name = "Community expenses")]
        public DateTime Expenses_Communityexpenses { get; set; }


        [Required(ErrorMessage = "Community expenses date is required")]
        [Display(Name = "Community expenses date")]
        public DateTime Expenses_Communityexpensesdate { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Documents is required")]
        [Display(Name = "Documents")]
        public IFormFile DocumentsFile { set; get; }



        [Required(ErrorMessage = "Inventory Name is required")]
        [Display(Name = "Inventory Name")]
        public int Inventory_Name { get; set; }


        [Required(ErrorMessage = "Inventory Description is required")]
        [Display(Name = "Inventory Description")]
        public int Inventory_Description { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Inventory file is required")]
        [Display(Name = "Inventory file")]
        public IFormFile InventoryFile { set; get; }
    }
}
