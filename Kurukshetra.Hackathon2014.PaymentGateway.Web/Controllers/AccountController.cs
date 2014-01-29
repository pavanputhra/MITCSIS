using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.ViewModels;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private IRegistrationService registrationService;

        public AccountController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterMerchant()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterMerchant(MerchantRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                registrationService.RegisterMerchant(model);
                return RedirectToAction("RegisterMerchantSuccess");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterMerchantSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterCustomer(CustomerRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                registrationService.RegisterCustomer(model);
                return RedirectToAction("RegisterCustomerSuccess", new { id = model.UserName });
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterCustomerSuccess(string id)
        {
            return View("RegisterCustomerSuccess",(object)id);
        }

    }
}
