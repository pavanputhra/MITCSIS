using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raksha.Crypto.Macs;
using Raksha.Crypto.Digests;
using Raksha.Crypto;
using Raksha.Crypto.Parameters;
using Raksha.Security;
using Kurukshetra.Hackathon2014.Dto;
using Base32;

namespace Kurukshetra.Hackathon2014.Client.Core
{
    public class AuthenticateChallenge
    {
        public ChallengeResponse ParseAuthChallenge(string input, string userName,string key)
        {
            char[] seps={'/'};//For Epoche Time
            String [] values = input.Split(seps);//For Epoche Time

           string op =  CalculateHMAC(input, userName, key);

            ChallengeResponse cmac = new ChallengeResponse
            {
                EpochTime = Convert.ToInt64 ( values[1]),
                UserName = userName,
                HMAC = op
            };
            return cmac;
        }

        public string CalculateHMAC(string iPut, string uName,string HMACKey)
        {
            byte[] array = Encoding.UTF8.GetBytes(iPut + "/" + uName);
            byte[] output = new byte[256];

            IDigest dig = DigestUtilities.GetDigest("SHA256");
            HMac hm = new HMac(dig);
            byte[] keyArray = Base32Encoder.Decode(HMACKey);
            hm.BlockUpdate(array, 0, array.Length);
            hm.Init(new KeyParameter(keyArray, 0, keyArray.Length));
            int len = hm.DoFinal(output, 0);
            return Base32Encoder.Encode(output);
        }
    }
}
