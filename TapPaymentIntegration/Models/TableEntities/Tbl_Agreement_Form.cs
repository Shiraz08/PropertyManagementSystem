using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public class Tbl_Agreement_Form : BaseEntities
    {
        [Key]
        public int Agreement_Form_Id { get; set; }

        [Display(Name = "Period From Date")]
        public Nullable<System.DateTime> Agreement_Period_From_DateTime { get; set; }


        [Display(Name = "Period To Date")]
        public Nullable<System.DateTime> Agreement_Period_To_DateTime { get; set; }

        [Display(Name = "Rent Amount")]
        public string Rent_Amount { get; set; }

        [Display(Name = "Security Desposit")]
        public string Security_Desposit { get; set; }

        [Display(Name = "Payment Term")]
        public string Payment_Term { get; set; }

        [Display(Name = "Landlord Id")]
        public Nullable<int> Landlord_Id { get; set; }

        [Display(Name = "Landlord Name")]
        public string Landlord_Name { get; set; }

        [Display(Name = "Landlord Whatsapp Number")]
        public string Landlord_Whatsapp_number { get; set; }

        [Display(Name = "Landlord Email Id")]
        public string Landlord_EmailId { get; set; }

        [Display(Name = "Landlord Identiy Card No")]
        public string Landlord_Identiy_Card_No { get; set; }
        [Display(Name = "Landlord Unique No")]
        public string Landlord_Unique_No { get; set; }
        [Display(Name = "Pro_Detail_Id")]
        public Nullable<int> Pro_Detail_Id { get; set; }
        [Display(Name = "Building No")]
        public string Building_No { get; set; }
        [Display(Name = "Builiding Name")]
        public string Builiding_Name { get; set; }
        [Display(Name = "Apt Villa No")]
        public string Apt_Villa_No { get; set; }
        [Display(Name = "Complex No")]
        public string Complex_No { get; set; }
        [Display(Name = "Elec Acc No")]
        public string Elec_Water_Acc_No { get; set; }
        [Display(Name = "Tenant_Id")]
        public Nullable<int> Tenant_Id { get; set; }
        [Display(Name = "Tenant Name")]
        public string Tenant_Name { get; set; }

        [Display(Name = "Tenant Contact")]
        public string Tenant_Contact { get; set; }

        [Display(Name = "Tenant Email")]
        public string Tenant_Email { get; set; }


        [Display(Name = "Tenant Identity Card")]
        public string Tenant_Identity_Card { get; set; }
        [Display(Name = "Form DateTime")]
        public Nullable<System.DateTime> Agreement_Form_DateTime { get; set; }
        [Display(Name = "Invoice No")]
        public string Invoice_No { get; set; }
        [Display(Name = "Water Acc No")]
        public string Water_Acc_NO { get; set; }

    }
}
