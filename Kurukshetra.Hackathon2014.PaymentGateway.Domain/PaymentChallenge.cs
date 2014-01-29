using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    class PaymentChallenge
    {
        [Required]
        public string MerchantId { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public long EpochTime { get; set; }

        [Required]
        public decimal Amount { get; set; }

    }
}
