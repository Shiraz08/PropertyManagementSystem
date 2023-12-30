using PropertyManagementSystem.Models.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models
{
    public class Tbl_Agreement_Period : BaseEntities
    {
        [Key]
        public int Agreement_Period_Id { get; set; }
        public Nullable<System.DateTime> Agreement_Period_From_DateTime { get; set; }
        public Nullable<System.DateTime> Agreement_Period_To_DateTime { get; set; }
        public string Rent_Amount { get; set; }
        public string Security_Desposit { get; set; }
        public string Payment_Term { get; set; }
        public Nullable<System.DateTime> Agreement_Period_DateTime { get; set; }
    }
}
