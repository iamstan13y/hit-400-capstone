namespace iDent.ModelLibrary.Models.Data
{
    public class Bank
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LogoUrl { get; set; }
        public Account? Account { get; set; }
    }
}