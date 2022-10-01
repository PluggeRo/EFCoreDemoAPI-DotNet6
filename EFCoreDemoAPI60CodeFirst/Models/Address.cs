namespace EFCoreDemoAPI60CodeFirst.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

    }
}
