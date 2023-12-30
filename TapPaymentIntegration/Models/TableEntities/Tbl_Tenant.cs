using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public class Tbl_Tenant : BaseEntities
    {
        [Key]
        public int Tenant_Id { get; set; }
        [Display(Name = "Tenant Name")]
        public string Tenant_Name { get; set; }

        [Display(Name = "Tenant Contact")]
        public string Tenant_Contact { get; set; }

        [Display(Name = "Tenant Email")]
        public string Tenant_Email { get; set; }


        [Display(Name = "Tenant Identity Card")]
        public string Tenant_Identity_Card { get; set; }
        [Display(Name = "Datetime")]
        public Nullable<System.DateTime> Tenant_Datetime { get; set; }
    }
}
