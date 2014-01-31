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
        public ChallengeResponse ParseAuthChallenge(string input, string userName)
        {
            char[] seps={'/'};
            String [] values = input.Split(seps);
            byte[] array = Encoding.UTF8.GetBytes(input);
            ChallengeResponse cmac = new ChallengeResponse
            {
                EpochTime = Convert.ToInt64 ( values[1]),
                UserName = userName,
                HMAC = "testing"
            };
            return cmac;
        }
    }
}
