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

        private ICryptoService cryptoService;
        private IAuthAndPayService authAndPayService;

        public SecurityController(ICryptoService cryptoService,IAuthAndPayService authAndPayService)
        {
            this.cryptoService = cryptoService;
            this.authAndPayService = authAndPayService;
        }

        [AllowAnonymous]
        public ActionResult SecretKey(string id)
        {
            try
            {
                string secret = cryptoService.GetSecretOfUser(id);
                string result = String.Format(@"00/{0}", secret);
                QRConverter converter = new QRConverter();
                BitMatrix bitMatrix = converter.GetQR(result);
                return new QRImageResult(bitMatrix);
            }
            catch
            {
                return new HttpStatusCodeResult(401);
            }
            
        }

        [AllowAnonymous]
        public ActionResult AuthChallenge(string id,long time)
        {
            try
            {
                string secret = authAndPayService.GetAuthChallenge(id, time);
                string result = String.Format(@"01/{0}/{1}", time,secret);
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
