namespace iDent.ModelLibrary.Models.Data
{
    public class AuditTrail
    {
        public int Id { get; set; }
        public int IdentityId { get; set; }
        public string? Operation { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Identity? Identity { get; set; }
    }
}