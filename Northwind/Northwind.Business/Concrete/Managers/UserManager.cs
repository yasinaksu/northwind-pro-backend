using Core.Aspects.PostSharp.ValidationAspects;
using Northwind.Business.Abstract;
using Northwind.Business.ServiceAdapters;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.ComplexTypes;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IKpsService _kpsService;
        public UserManager(IUserDal userDal, IKpsService kpsService)
        {
            _userDal = userDal;
            _kpsService = kpsService;
        }

        [FluentValidationAspect(typeof(UserValidator))]
        public User Add(User user)
        {
            CheckUserValidOrNotFromKps(user);
            CheckUserNameIsExists(user);
            CheckEmailIsExists(user);
            return _userDal.Add(user);
        }

        private void CheckUserValidOrNotFromKps(User user)
        {
            if (!_kpsService.ValidateUser(user))
            {
                throw new Exception("Kullanıcı mernis kimlik doğrulamasından geçemedi.");
            }
        }

        private void CheckUserNameIsExists(User user)
        {
            if (_userDal.Get(x => x.UserName == user.UserName) != null)
            {
                throw new Exception("Bu kullanıcı adı ile daha önce kayıt yapılmış");
            }
        }
        private void CheckEmailIsExists(User user)
        {
            if (_userDal.Get(x => x.Email == user.Email) != null)
            {
                throw new Exception("Bu email adresi ile daha önce kayıt yapılmış");
            }
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(x => x.UserName == userName && x.Password == password);
        }

        public List<UserRoleDto> GetRolesByUser(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
