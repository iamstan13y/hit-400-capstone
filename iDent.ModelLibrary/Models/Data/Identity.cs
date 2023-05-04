namespace iDent.ModelLibrary.Models.Data
{
    public class Identity
    {
        public int Id { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}