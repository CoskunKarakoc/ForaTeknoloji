using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IUserDal : IEntityRepository<Users>
    {
        void DeleteAllUsers();
        List<ComplexUser> GetAllUsersWithOuther(Expression<Func<ComplexUser, bool>> filter = null);
        List<ComplexUser> GetAllUsersWithOutherOnlyUser(Expression<Func<ComplexUser, bool>> filter = null);
        List<int> GetListOnlyUserID();
    }
}
