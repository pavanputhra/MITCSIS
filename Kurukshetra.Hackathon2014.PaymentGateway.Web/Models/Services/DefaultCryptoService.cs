using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Kurukshetra.Hackathon2014.PaymentGateway.Store;
using Base32;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public class DefaultCryptoService : ICryptoService
    {
        public byte[] GenerateRandomByte(int bits)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[bits/8];
                rng.GetBytes(key);
                return key;
            }
        }

        public bool IsValidChallengeResponse(long customerId, long epochTime, string response)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPaymentToken(long merchantId, long orderReferenceNo, long epochTime)
        {
            throw new NotImplementedException();
        }

        public bool IsPaymentComplete(long merchantId, long orderReferenceNo, long epochTime)
        {
            throw new NotImplementedException();
        }

        public string GetSecretOfUser(string username)
        {
            using (PaymentGatewayDbContext dbContext = new PaymentGatewayDbContext())
            {
                var result = dbContext.Credentials.SingleOrDefault(p => p.UserName == username);
                if (result != null && (result.CreatedDate > DateTimeOffset.Now.AddMinutes(-15)))
                {
                    string secret = Base32Encoder.Encode(result.SecretKey);
                    return secret;
                }
                throw new Exception("No Key");
            }
        }
    }
}