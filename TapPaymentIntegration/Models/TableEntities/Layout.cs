using System;
using System.Collections.Generic;
using System.Linq;
using Property_Management_Sys.Models;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Property_Management_Sys.Areas.Identity.Data;

namespace Property_Management_Sys.Models
{ 
    public class Layout
    {
        public IEnumerable<Tbl_Agreement_Form> Tbl_Agreement_Forms { get; set; }
        public IEnumerable<Tbl_Agreement_Period> Tbl_Agreement_Period { get; set; }
        public IEnumerable<Tbl_Landlord> Tbl_Landlords { get; set; }
        public IEnumerable<Tbl_Property_Detail> Tbl_Property_Details { get; set; }
        public IEnumerable<Tbl_Tenant> Tbl_Tenants { get; set; }
        public IEnumerable<ApplicationUser> Tbl_Users { get; set; }
        public IEnumerable<ApplicationUser> Tbl_UserTypes2 { get; set; } 
        public IEnumerable<Tbl_Invoices> Total_Invoices { get; set; }
        public IEnumerable<Tbl_Invoices> Total_Invoices_Paid { get; set; }
        public IEnumerable<Tbl_Invoices> Total_Invoices_Unpaid { get; set; }
        public IEnumerable<Tbl_Invoices> Total_Invoices_Paid_to_Landlord { get; set; }
        public IEnumerable<Tbl_Invoices> Total_Invoices_Unpaid_to_Landlord { get; set; }
    }
}