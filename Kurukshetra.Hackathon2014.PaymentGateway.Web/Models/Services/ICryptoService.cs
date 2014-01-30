using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public interface ICryptoService
    {
        string GetSecretOfUser(string username);

        byte[] GenerateRandomByte(int bits);

        bool IsValidChallengeResponse(long customerId, long epochTime, string response);

        bool IsValidPaymentToken(long merchantId, long orderReferenceNo, long epochTime);

        bool IsPaymentComplete(long merchantId, long orderReferenceNo, long epochTime);
    }
}
