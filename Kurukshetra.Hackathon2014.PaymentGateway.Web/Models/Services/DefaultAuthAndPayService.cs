using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Kurukshetra.Hackathon2014.PaymentGateway.Store;
using Kurukshetra.Hackathon2014.PaymentGateway.Domain;
using Kurukshetra.Hackathon2014.Dto;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public class DefaultAuthAndPayService : IAuthAndPayService
    {
        ICryptoService cryptoService;
        public DefaultAuthAndPayService(ICryptoService cryptoService)
        {
            this.cryptoService = cryptoService;
        }

        public string GetSecretOfUser(string username)
        {
            using (PaymentGatewayDbContext dbContext = new PaymentGatewayDbContext())
            {
                var result = dbContext.Credentials.SingleOrDefault(p => p.UserName == username);
                if (result != null && (result.CreatedDate > DateTimeOffset.Now.AddMinutes(-15)))
                {
                    string secret = Base32.Base32Encoder.Encode(result.SecretKey);
                    return secret;
                }
                throw new ApplicationException("No Key");
            }
        }

        public string GenerateAuthChallenge(string userName,out long epoachTime)
        {
            using (PaymentGatewayDbContext dbContext = new PaymentGatewayDbContext())
            {
                var previousAuthChallenge = dbContext.
                    AuthenticationChallenges.
                    Where(p => p.UserName == userName && p.ExpireDate > DateTimeOffset.Now);
                if (previousAuthChallenge.Count() > 0)
                {
                    var first = previousAuthChallenge.FirstOrDefault();
                    epoachTime = first.EpochTime;
                    return Base32.Base32Encoder.Encode(first.Challenge);

                }
                else
                {
                    epoachTime = DateTimeOffset.Now.EpochTime();
                    byte[] challenge = cryptoService.GenerateRandomByte(512);
                    var Challenge = new AuthenticationChallenge
                    {
                        UserName = userName,
                        EpochTime = epoachTime,
                        Challenge = challenge,
                        ExpireDate = DateTimeOffset.Now.AddMinutes(15)
                    };
                    dbContext.AuthenticationChallenges.Add(Challenge);
                    dbContext.SaveChanges();
                    return Base32.Base32Encoder.Encode(challenge);
                }
            }
        }

        public string GetAuthChallenge(string username, long epochTime)
        {
            using (PaymentGatewayDbContext dbContext = new PaymentGatewayDbContext())
            {
                var result = dbContext.AuthenticationChallenges.Where(p => (p.UserName == username && p.EpochTime == epochTime)).SingleOrDefault();
                if (result != null)
                {
                    string challenge = Base32.Base32Encoder.Encode(result.Challenge);
                    return challenge;
                }
                throw new ApplicationException("No Challenge for this user");
            }
        }


        public bool IsValidChallengeResponse(string customerId, long epochTime, string response)
        {
            string challenge = GetAuthChallenge(customerId,epochTime);
            string secret = GetSecretOfUser(customerId);
            List<byte> array = new List<byte>();
            string input = String.Format("{0}/{1}/{2}/{3}", "00", epochTime,challenge,customerId);
            string hash = cryptoService.CalculateHmac(secret, challenge);
            return (response != null && response.Equals(hash));
        }

        public bool IsValidPaymentToken(long merchantId, long orderReferenceNo, long epochTime, string token)
        {
            throw new NotImplementedException();
        }

        public bool IsPaymentComplete(long merchantId, long orderReferenceNo, long epochTime)
        {
            throw new NotImplementedException();
        }
    }
}