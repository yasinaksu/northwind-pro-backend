using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ServiceAdapters
{
    public interface IKpsService
    {
        bool ValidateUser(User user);
    }
}
