using System.ComponentModel.DataAnnotations;

namespace Property_Management_Sys.Models.Roles
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
