namespace iDent.ModelLibrary.Models.Local
{
    public class IdentityRequest
    {
        public string? IdentityNumber { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime DOB { get; set; } = DateTime.Now;
        public string? Address { get; set; }
    }

    public class UpdateIdentityRequest : IdentityRequest
    {
        public int Id { get; set; }
    }
}