using Microsoft.EntityFrameworkCore;
using PayCard.Infrastructure.Database.Models;
using System.Reflection;

namespace PayCard.Infrastructure.Database
{
    public class PayCardContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<PersonalInformation> PersonalInformation => Set<PersonalInformation>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\MSSQLSERVER02;database=PayCardDb;Encrypt=false;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("PayCard.Infrastructure"));
        }
    }
}
