using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class AuthenticationChallenge
    {
        public AuthenticationChallenge()
        {
            AuthWindow = TimeSpan.Zero;
        }
        [Required]
        public string UserName { get; set; }

        [Required]
        public long EpochTime { get; set; }

        [Required]
        public byte[] Challenge { get; set; }

        [Required]
        public DateTimeOffset ExpireDate { get; set; }

        public TimeSpan AuthWindow { get; set; }
    }
}
