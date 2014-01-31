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
            char[] seps={'/'};
            String [] values = input.Split(seps);
            byte[] array = Encoding.UTF8.GetBytes(input+"/"+userName);
            byte[] output =new byte[512];

            Sha512Digest s = new Sha512Digest();
            IDigest dig = DigestUtilities.GetDigest("SHA1");
            HMac hm = new HMac(dig);
            hm.BlockUpdate(array, 0, array.Length);
            hm.Init(new KeyParameter(array, 1, 34));
            int len = hm.DoFinal(output, 0);


            ChallengeResponse cmac = new ChallengeResponse
            {
                EpochTime = Convert.ToInt64 ( values[1]),
                UserName = userName,
                HMAC = Base32Encoder.Encode(output)
            };
            return cmac;
        }
    }
}
