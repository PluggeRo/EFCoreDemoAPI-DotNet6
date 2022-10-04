using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFCoreDemoAPI60CodeFirst.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        //The DbSet is creating the table in the DB
        //Name of the table is the name of the DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
    }
}
