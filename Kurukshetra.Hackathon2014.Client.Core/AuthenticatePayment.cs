using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurukshetra.Hackathon2014.Dto;
using Kurukshetra.Hackathon2014.Client.Core;

namespace Kurukshetra.Hackathon2014.Client.Core
{
    class AuthenticatePayment
    {
        public PaymentResponse ParsePaymentChallenge(string input, string userName, string key)
        {
            char[] seps = { '/' };//For Epoche Time
            String[] values = input.Split(seps);//For Epoche Time

            AuthenticateChallenge ac = new AuthenticateChallenge();
            string op = ac.CalculateHMAC(input, userName, key);

            PaymentResponse pay = new PaymentResponse
            {
                EpochTime = Convert.ToInt64(values[1]),
                MerchantID=values[2],
                OrderID=Convert.ToInt64(values[3]),
                HMAC = op
            };
            return pay;
        }
    }
}
