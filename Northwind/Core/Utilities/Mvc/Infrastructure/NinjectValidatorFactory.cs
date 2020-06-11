using FluentValidation;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mvc.Infrastructure
{
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;
        public NinjectValidatorFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            return validatorType == null ? null : (IValidator)_kernel.TryGet(validatorType);
        }
    }
}
