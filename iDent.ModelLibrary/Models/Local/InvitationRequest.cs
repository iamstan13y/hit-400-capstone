namespace iDent.ModelLibrary.Models.Local
{
    public class InvitationRequest
    {
        public int IdentityId { get; set; }
        public int BankId { get; set; }
        public string? Reason { get; set; }
    }
}