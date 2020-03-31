using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserService
    {

        List<Users> GetAllUsers(Expression<Func<Users, bool>> filter = null);
        Users GetById(int id);
        Users AddUsers(Users users);
        string AddUserWithCheckCardId(Users users);
        void DeleteUsers(Users users);
        Users UpdateUsers(Users users);
        string UpdateWithCheckCardId(Users users);
        List<ComplexUser> GetAllUsersWithOuther(Expression<Func<ComplexUser, bool>> filter = null);
        List<ComplexUser> GetAllUsersWithOutherOnlyUser(Expression<Func<ComplexUser, bool>> filter = null);
        Users GetByKayitNo(int? Kayit_No);
        void DeleteAllUsers();
        bool FastGroupAdd(FastGroupParameters parameters);
        List<int> GetUserOnlyUserID();
    }
}
