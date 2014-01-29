using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.ViewModels
{
    public class CustomerRegisterModel
    {
        [Required]
        [Display(Name="Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name="Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name="Data of Birth")]
        public DateTime DoB { get; set; }

        [Required]
        [Range(0,100000)]
        [Display(Name="Initial Deposit")]
        public decimal InitialDeposit { get; set; }

        [Required]
        [Display(Name="Choose Password")]
        public string Password { get; set; }
    }
}