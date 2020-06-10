using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            IKernel _kernel = new StandardKernel(new BusinessModule(), new AutoMapperModule());
            return _kernel.TryGet<T>();
        }
    }
}
