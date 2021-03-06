﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Kurukshetra.Hackathon2014.PaymentGateway.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Store
{
    public class PaymentGatewayDbContext : DbContext, Kurukshetra.Hackathon2014.PaymentGateway.Store.IPaymentGatewayRepository
    {
        public PaymentGatewayDbContext()
            : base("DefaultConnection")
        { }

        public PaymentGatewayDbContext(string connectionName) :
            base(connectionName)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> Transactions { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<AuthenticationChallenge> AuthenticationChallenges { get; set; }
        public DbSet<PaymentChallenge> PaymentChallenges { get; set; }
        public DbSet<Merchant> Merchants { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Account>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<AccountTransaction>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Credentials>().HasKey(t => t.UserName);
            modelBuilder.Entity<AuthenticationChallenge>().HasKey(t => new { t.UserName, t.EpochTime });
            modelBuilder.Entity<PaymentChallenge>().HasKey(t => new { t.MerchantId, t.OrderReferenceNo, t.EpochTime });
            modelBuilder.Entity<Merchant>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
