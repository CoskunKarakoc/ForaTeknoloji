using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserService
    {

        List<Users> GetAllUsers(Expression<Func<Users, bool>> filter = null);
        Users GetById(int id);
        Users AddUsers(Users users);
        void DeleteUsers(Users users);
        Users UpdateUsers(Users users);
        List<ComplexUser> GetAllUsersWithOuther();
    }
}
