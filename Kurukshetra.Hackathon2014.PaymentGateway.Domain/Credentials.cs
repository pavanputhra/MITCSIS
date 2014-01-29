using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    class Credentials
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public Guid PersonId { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public string SecretKey { get; set; }
    }
}
