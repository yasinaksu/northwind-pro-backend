using Northwind.Business.KpsServiceReference;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ServiceAdapters
{
    public class KpsServiceAtapter : IKpsService
    {
        public bool ValidateUser(User user)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
            var tcKn = Convert.ToInt64("12365478923");
            return client.TCKimlikNoDogrula(tcKn, user.FirstName.ToUpper(), user.LastName.ToUpper(), DateTime.Now.AddYears(-18).Year);
        }
    }
}
