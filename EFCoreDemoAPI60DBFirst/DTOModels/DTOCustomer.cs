namespace EFCoreDemoAPI60DBFirst.DTOModels
{
    public class DTOCustomer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }

        public DTOCustomer(Models.Customer dbcustomer)
        {
            Addresses = new List<Address>();
            EmailAddresses = new List<EmailAddress>();

            Id = dbcustomer.Id;
            FirstName = dbcustomer.FirstName;
            LastName = dbcustomer.LastName;
            Age = dbcustomer.Age;
            EmailAddresses = dbcustomer.EmailAddresses;
            Addresses = dbcustomer.Addresses;
        }
    }
}
