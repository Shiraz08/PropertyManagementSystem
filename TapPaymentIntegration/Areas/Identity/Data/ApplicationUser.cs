using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Property_Management_Sys.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    public string Password { get; set; }
    public string FullName { get; set; }
    [Required]
    public string UserType { get; set; }
    public string PropertyName { get; set; }
    public string AppTenantName { get; set; }
    public string AppTenantId { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }

    public DateTime AddedDate { get; set; }
    public string AddedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }

}

