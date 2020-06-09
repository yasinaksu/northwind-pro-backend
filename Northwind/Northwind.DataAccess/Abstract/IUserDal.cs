using Core.DataAccess;
using Northwind.Entities.ComplexTypes;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleDto> GetUserRoles(User user);
    }
}
