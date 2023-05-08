namespace iDent.ModelLibrary.Models.Data
{
    public class Invitation
    {
        public int Id { get; set; }
        public int IdentityId { get; set; }
        public int BankId { get; set; }
        public string? Reason { get; set; }
        public int Status { get; set; } = 3;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public Identity? Identity { get; set; }
        public Bank? Bank { get; set; }
    }
}