using Core.CrossCuttingConcerns.Security;
using Northwind.Business.Abstract;
using Northwind.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Northwind.WebApi.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                var data = Convert.FromBase64String(token);
                var decodedString = Encoding.UTF8.GetString(data);
                var tokenValues = decodedString.Split(':');
                var userName = tokenValues[0];
                var password = tokenValues[1];
                AuthenticateUser(userName, password);
            }
            catch
            {

            }
            return base.SendAsync(request, cancellationToken);
        }

        private void AuthenticateUser(string userName, string password)
        {
            var userService = InstanceFactory.GetInstance<IUserService>();
            var user = userService.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                var userRoles = userService.GetRolesByUser(user).Select(x => x.RoleName).ToArray();
                var identity = new Identity
                {
                    AuthenticationType = "Token",
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    IsAuthenticated = true,
                    LastName = user.LastName,
                    Name = user.UserName,
                    Roles = userRoles
                };
                var principal = new GenericPrincipal(identity, identity.Roles);

                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
        }
    }
}