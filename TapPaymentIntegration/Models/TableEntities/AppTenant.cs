using System.ComponentModel.DataAnnotations;

namespace PropertyManagementSystem.Models.TableEntities
{
    public class AppTenant : BaseEntities
    {
        [Key]
        public string TenantId { get; set; }
        public string TenantName { get; set; }
        public string TenantPropertyName { get; set; }
    }
}
