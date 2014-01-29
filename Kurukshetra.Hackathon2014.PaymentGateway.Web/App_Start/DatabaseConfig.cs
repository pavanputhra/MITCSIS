using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kurukshetra.Hackathon2014.PaymentGateway.Store;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web
{
    public class DatabaseConfig
    {
        public static void Init()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PaymentGatewayDbContext>());
        }
    }
}