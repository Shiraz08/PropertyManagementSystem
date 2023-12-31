using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PropertyManagementSystem.Models
{
    public class ExternalLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ProviderDisplayName { get; set; }
        public ClaimsPrincipal Principal { get; set; }
    }
}
