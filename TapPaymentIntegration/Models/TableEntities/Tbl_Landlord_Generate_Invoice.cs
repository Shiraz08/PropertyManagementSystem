using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public  class Tbl_Landlord_Generate_Invoice : BaseEntities
    {
        [Key]
        public int Landlord_Generate_Invoice_Id { get; set; }
        [Display(Name = "Landlord Invoice")]
        public Nullable<System.DateTime> Landlord_Generate_Invoice_Datetime { get; set; }
        [Display(Name = "Landlord Invoice Amount")]
        public string Landlord_Generate_Invoice_Amount { get; set; }
        [Display(Name = "Landlord Invoice Description")]
        public string Landlord_Generate_Invoice_Description { get; set; }
        [Display(Name = "Landlord Invoice Total")]
        public string Landlord_Generate_Invoice_Total { get; set; }
        public string Landlord_Generate_Invoice_Extra { get; set; }
    }

}

