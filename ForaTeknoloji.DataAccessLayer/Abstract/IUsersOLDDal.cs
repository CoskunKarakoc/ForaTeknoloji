using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUsersOLDDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IUsersOLDDal : IEntityRepository<UsersOLD>
    {
        List<ComplexUserOld> GetAllUserOLDWithOuther(Expression<Func<ComplexUserOld, bool>> filter = null);
    }
}
