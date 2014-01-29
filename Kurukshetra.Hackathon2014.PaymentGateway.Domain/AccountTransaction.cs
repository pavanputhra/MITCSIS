using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class AccountTransaction
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public Account Account { get; set; }

        [Required]
        public long AccountId { get; set; }

        [Required]
        public DateTimeOffset DateTime { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
