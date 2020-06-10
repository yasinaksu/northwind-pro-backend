using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Common
{
    public class WcfProxy<T>
    {
        //http://localhost:51476/{0}.svc
        //http://localhost:51476/ProductService.svc
        public static T CreateChannel()
        {
            var baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            var address = string.Format(baseAddress, typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
