using Core.CrossCuttingConcerns.Security.Web;
using Core.Utilities.Mvc.Infrastructure;
using FluentValidation.Mvc;
using Northwind.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Uygulama Business üzerinden iþler
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new AutoMapperModule()));

            //Uygulama Wcf üzerinden iþler
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ServiceModule(), new AutoMapperModule()));
            ModelValidatorProviders.Providers.Clear();
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidatorFactory(new ValidationModule());
                provider.AddImplicitRequiredValidator = false;

            });
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encTicket))
                {
                    return;
                }
                var ticket = FormsAuthentication.Decrypt(encTicket);
                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormAuthTicketToIdentity(ticket);
                var principle = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principle;
                Thread.CurrentPrincipal = principle;
            }
            catch
            {
                ;
            }
        }
    }
}
