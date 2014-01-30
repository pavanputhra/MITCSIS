using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class PaymentChallenge
    {
        public PaymentChallenge()
        {
            IsPaymentComplet = false;
        }

        [Required]
        public long MerchantId { get; set; }

        [Required]
        public long OrderReferenceNo { get; set; }

        [Required]
        public long EpochTime { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool IsPaymentComplet { get; set; }

    }
}
