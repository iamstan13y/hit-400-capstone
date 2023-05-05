namespace iDent.ModelLibrary.Models.Data
{
    public class Identity
    {
        public string? IdentityNumber { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public int Status { get; set; } = 1;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}