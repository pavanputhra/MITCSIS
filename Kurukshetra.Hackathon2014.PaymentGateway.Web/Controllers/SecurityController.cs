using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Infrastructure;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services;
using ZXing.Common;
using Kurukshetra.Hackathon2014.QRCodeLib;

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

        [AllowAnonymous]
        public ActionResult SecretKey(string id)
        {
            try
            {
                string secret = cryptoService.GetSecretOfUser(id);
                string result = String.Format(@"00/{0}/{1}", id, secret);
                QRConverter converter = new QRConverter();
                BitMatrix bitMatrix = converter.GetQR(result);
                return new QRImageResult(bitMatrix);
            }
            catch
            {
                return new HttpStatusCodeResult(401);
            }
            
        }

    }
}
