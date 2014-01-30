using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.
using Kurukshetra.Hackathon2014.Dto;

namespace Kurukshetra.Hackathon2014.Client.Core
{
    public class AuthenticateChallenge
    {
        public ChallengeMAC ParseAuthChallenge(string input, string userName)
        {
            char[] seps={'/'};
            String [] values = input.Split(seps);
            byte[] array = Encoding.UTF8.GetBytes(input);
            ChallengeMAC cmac = new ChallengeMAC
            {
                EpochTime = Convert.ToInt64 ( values[1]),
                PID = userName,
                HMAC = 

        }
        }
    }
}
