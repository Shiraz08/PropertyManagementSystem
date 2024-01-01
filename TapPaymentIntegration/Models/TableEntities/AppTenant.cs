using System.ComponentModel.DataAnnotations;

namespace PropertyManagementSystem.Models.TableEntities
{
    public class AppTenant : BaseEntities
    {
        [Key]
        public int TenantId { get; set; }
        [Required]
        public string TenantName { get; set; }
        [Required]
        public string TenantPropertyName { get; set; }
    }
}
