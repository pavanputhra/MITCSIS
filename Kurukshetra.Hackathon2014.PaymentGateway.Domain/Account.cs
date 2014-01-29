using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    class Account
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public List<AccountTransaction> Transactions { get; set; }
    }
}
