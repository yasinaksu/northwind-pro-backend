using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = GetId(ticket),
                Name = GetName(ticket),
                Email = GetEmail(ticket),
                Roles = GetRoles(ticket),
                FirstName = GetFirstName(ticket),
                LastName = GetLastName(ticket),
                AuthenticationType = GetAuthType(),
                IsAuthenticated = GetIsAuthenticated()
            };

            return identity;
        }

        private bool GetIsAuthenticated()
        {
            return true;
        }

        private string GetAuthType()
        {
            return "Forms";
        }

        private string GetLastName(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[3];
        }

        private string GetFirstName(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[2];
        }

        private string[] GetRoles(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            var roles = data[1].Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string GetEmail(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[0];
        }

        private string GetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private int GetId(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return Convert.ToInt32(data[4]);
        }
    }
}
