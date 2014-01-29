﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Domain
{
    public class Account
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public List<AccountTransaction> Transactions { get; set; }
    }
}
