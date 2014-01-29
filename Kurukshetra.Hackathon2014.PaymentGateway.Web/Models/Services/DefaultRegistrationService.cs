using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kurukshetra.Hackathon2014.PaymentGateway.Store;
using Kurukshetra.Hackathon2014.PaymentGateway.Domain;
using System.Security.Cryptography;
using System.Text;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public class DefaultRegistrationService : IRegistrationService
    {
        private ICryptoService criptoService;

        public DefaultRegistrationService(ICryptoService criptoService)
        {
            this.criptoService = criptoService;
        }

        public bool RegisterMerchant(ViewModels.MerchantRegisterModel model)
        {
            using (var dbContext = new PaymentGatewayDbContext())
            {
                var merchant = new Merchant
                {
                    Name = model.MerchantName,
                    Account = new Account { Balance = model.InitialDeposit }
                };
                dbContext.Merchants.Add(merchant);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool RegisterCustomer(ViewModels.CustomerRegisterModel model)
        {
            using (var dbContext = new PaymentGatewayDbContext())
            {
                var customer = new Person
                {
                    FullName = model.FullName,
                    DoB = model.DoB
                };
                customer.Accounts.Add(new Account { Balance = model.InitialDeposit });

                
                var credential = new Credentials
                {
                    UserName = model.UserName,
                    Person = customer,
                    CreatedDate = DateTimeOffset.Now,
                    SecretKey = criptoService.GenerateRandomByte(512)
                };

                using (SHA512 shasum = SHA512.Create())
                {
                    credential.HashedPassword = shasum.ComputeHash(Encoding.Default.GetBytes(model.Password));
                }
                dbContext.Credentials.Add(credential);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}