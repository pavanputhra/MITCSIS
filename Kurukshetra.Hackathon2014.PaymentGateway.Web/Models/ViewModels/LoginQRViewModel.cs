using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.ViewModels
{
    public class LoginQRViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
    }
}