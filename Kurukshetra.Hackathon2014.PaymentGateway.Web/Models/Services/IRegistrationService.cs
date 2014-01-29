using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.ViewModels;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public interface IRegistrationService
    {
        bool RegisterMerchant(MerchantRegisterModel model);

        bool RegisterCustomer(CustomerRegisterModel model);
    }
}
