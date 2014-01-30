using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class Person
    {

        public Person()
        {
            Accounts = new List<Account>();
        }

        [Required]
        public long Id { get; set; }

        [Required]
        public String FullName { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
