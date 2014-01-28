using System.Web;
using System.Web.Mvc;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}