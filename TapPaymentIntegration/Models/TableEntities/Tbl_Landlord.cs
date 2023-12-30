using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public class Tbl_Landlord : BaseEntities
    {
        [Key]
        public int Landlord_Id { get; set; }
        public string Landlord_Name { get; set; }
        public string Landlord_Whatsapp_number { get; set; }
        public string Landlord_EmailId { get; set; }
        public string Landlord_Identiy_Card_No { get; set; }
        public string Landlord_Unique_No { get; set; }
        public Nullable<System.DateTime> Landlord_Datetime { get; set; }
    }
}
