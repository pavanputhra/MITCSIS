using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class Merchant
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Account Account { get; set; }
    }
}
