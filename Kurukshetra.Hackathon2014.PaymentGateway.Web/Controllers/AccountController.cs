﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.ViewModels;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services;
using System.Web.Security;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private IRegistrationService registrationService;
        private IAuthAndPayService authAndPayService;

        public AccountController(IRegistrationService registrationService,IAuthAndPayService authAndPayService)
        {
            this.registrationService = registrationService;
            this.authAndPayService = authAndPayService;
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
        [HttpPost]
        public ActionResult Login(LoginQRViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    long epochTime;
                    string challenge = authAndPayService.GenerateAuthChallenge(model.UserName, out epochTime);
                    return RedirectToAction("Authenticate", new { id = model.UserName, time = epochTime });
                }
                catch (InvalidOperationException exp)
                {
                    ModelState.AddModelError("", "Invalid Username");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Authenticate(string id,long time)
        {
            AuthViewModel vm = new AuthViewModel { UserName = id, Time = time };
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult Autheticated(string id, long time)
        {
            var result = authAndPayService.IsUserAuthenticated(id, time);
            if (result)
            {
                authAndPayService.InvalidateAuthToken(id, time);
                FormsAuthentication.SetAuthCookie(id, false);
                return RedirectToAction("Index", "Home");
            }
            return View("Authenticate");
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
