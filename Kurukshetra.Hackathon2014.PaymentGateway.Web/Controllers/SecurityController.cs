using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Infrastructure;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services;
using ZXing.Common;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Controllers
{
    public class SecurityController : Controller
    {
        //
        // GET: /Security/

        ICryptoService cryptoService;

        public SecurityController(ICryptoService cryptoService)
        {
            this.cryptoService = cryptoService;
        }

        public ActionResult SecretKey(string id)
        {
            try
            {
                string secret = cryptoService.GetSecretOfUser(id);

                return new QRImageResult(new BitMatrix(350,350));
            }
            catch
            {
                return new HttpStatusCodeResult(401);
            }
            
        }

    }
}
