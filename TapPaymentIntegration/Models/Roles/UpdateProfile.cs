using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models.Roles
{
    public class UpdateProfile
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
