using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.ViewModels
{
    public class MerchantRegisterModel
    {
        [Required]
        [MaxLength(40)]
        [Display(Name="Merchant Name")]
        public string MerchantName { get; set; }

        [Required]
        [Range(0,1000000)]
        [Display(Name="Initial Deposit")]
        public decimal InitialDeposit { get; set; }
    }
}