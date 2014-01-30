using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class Credentials
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public long PersonId { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public byte[] HashedPassword { get; set; }

        [Required]
        public byte[] SecretKey { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
