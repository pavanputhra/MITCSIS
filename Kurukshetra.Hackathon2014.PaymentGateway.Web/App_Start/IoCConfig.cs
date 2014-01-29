using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services;
using System.Web.Mvc;
using Unity.Mvc4;
using Kurukshetra.Hackathon2014.PaymentGateway.Store;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web
{
    public class IoCConfig
    {
        public static void Configure()
        {
            var container = ConfigDependency();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static IUnityContainer ConfigDependency()
        {
            var container = new UnityContainer();

            container.RegisterType<IRegistrationService, DefaultRegistrationService>();
            container.RegisterType<ICryptoService, DefaultCryptoService>();

            return container;
        }
    }
}