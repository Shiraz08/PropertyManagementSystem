namespace PropertyManagementSystem.Models.TableEntities
{
    public class BaseEntities
    {
        public string AppTenantPropertyName { get; set; } 
        public string AppTenantId { get; set; }
        public string AppTenantName { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
