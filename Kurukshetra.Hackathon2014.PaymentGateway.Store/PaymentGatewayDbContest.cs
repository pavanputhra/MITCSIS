using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Kurukshetra.Hackathon2014.PaymentGateway.Domain;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Store
{
    public class PaymentGatewayDbContest : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> Transactions { get; set; }
        public DbSet<Credentials> Credentials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Credentials>().HasKey(t => t.UserName);
        }
    }
}
