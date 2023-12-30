using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public class Tbl_Invoices : BaseEntities
    {
        [Key]
        public int Invoice_Id { get; set; }
        public Nullable<int> Landlord_Id { get; set; }
        public Nullable<int> Tenant_Id { get; set; }
        [Display(Name = "Invoice Created Date")]
        public Nullable<System.DateTime> Invoice_Created_Date { get; set; }
        [Display(Name = "Invoice Paid")]
        public Nullable<bool> Invoice_Paid { get; set; }
        [Display(Name = "Tenant Name")]
        public string Tenant_Name { get; set; }
        [Display(Name = "LandLord Name")]
        public string Landlord_Name { get; set; }
        [Display(Name = "Rent Amount")]
        public string Rent_Ammount { get; set; }
        public Nullable<int> Agreement_Form_Id { get; set; }
        [Display(Name = "Invoice Date")]
        public Nullable<System.DateTime> Invoice_Date { get; set; }
        [Display(Name = "Invoice Paid To Landlord")]
        public Nullable<bool> Invoice_Paid_To_Landlord { get; set; }
    }
}
