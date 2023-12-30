using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public class Tbl_Property_Detail : BaseEntities
    {
        [Key]
        public int Pro_Detail_Id { get; set; }
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
        [Display(Name = "Project Datetime")]
        public Nullable<System.DateTime> Pro_Detail_Datetime { get; set; }
        public Nullable<int> LanLoadrd_Id { get; set; }
        [Display(Name = "Landlord Name")]
        public string LanLoadrd_Name { get; set; }
        [Display(Name = "Water Acc No")]
        public string Water_Acc_NO { get; set; }
        [Display(Name = "Status")]
        public string PropertyDetailStatus { get; set; }
        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }
    }
}
