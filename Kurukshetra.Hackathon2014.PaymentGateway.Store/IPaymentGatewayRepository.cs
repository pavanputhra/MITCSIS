using System;
namespace Kurukshetra.Hackathon2014.PaymentGateway.Store
{
    public interface IPaymentGatewayRepository
    {
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.Account> Accounts { get; set; }
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.AuthenticationChallenge> AuthenticationChallenges { get; set; }
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.Credentials> Credentials { get; set; }
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.Merchant> Merchants { get; set; }
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.PaymentChallenge> PaymentChallenges { get; set; }
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.Person> Persons { get; set; }
        System.Data.Entity.DbSet<Kurukshetra.Hackathon2014.PaymentGateway.Domain.AccountTransaction> Transactions { get; set; }
    }
}
