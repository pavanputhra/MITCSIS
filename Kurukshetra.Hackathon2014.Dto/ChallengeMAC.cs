using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.Dto
{
    public class ChallengeMAC
    {
        public long EpochTime{get;set;}
        public string PID { get; set; }
        public string HMAC { get; set; }

    }
}
