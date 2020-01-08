using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Users AddUsers(Users users)
        {
            return _userDal.Add(users);
        }

        public void DeleteUsers(Users users)
        {
            _userDal.Delete(users);
        }

        public List<Users> GetAllUsers(Expression<Func<Users, bool>> filter = null)
        {
            return filter == null ? _userDal.GetList() : _userDal.GetList(filter);
        }

        public Users GetById(int id)
        {
            return _userDal.Get(x => x.ID == id);
        }

        public Users UpdateUsers(Users users)
        {
            return _userDal.Update(users);
        }

        public List<ComplexUser> GetAllUsersWithOuther(Expression<Func<ComplexUser, bool>> filter = null)
        {

            return filter == null ? _userDal.GetAllUsersWithOuther() : _userDal.GetAllUsersWithOuther(filter);
        }

        public Users GetByKayitNo(int? Kayit_No)
        {
            return _userDal.Get(x => x.Kayit_No == Kayit_No);
        }


        public void DeleteAllUsers()
        {
            _userDal.DeleteAllUsers();
        }

        public List<ComplexUser> GetAllUsersWithOutherOnlyUser(Expression<Func<ComplexUser, bool>> filter = null)
        {
            return filter == null ? _userDal.GetAllUsersWithOutherOnlyUser() : _userDal.GetAllUsersWithOutherOnlyUser(filter);
        }

        public bool FastGroupAdd(FastGroupParameters parameters)
        {
            bool result = false;
            if (parameters.Unvan_No != null && parameters.User_Grup != null && parameters.Grup_No != null)
            {
                foreach (var user in _userDal.GetList(x => x.Unvan_No == parameters.Unvan_No))
                {
                    if (parameters.User_Grup == 1)
                    {
                        user.Grup_No = parameters.Grup_No;
                        _userDal.Update(user);
                        result = true;
                    }
                    else if (parameters.User_Grup == 2)
                    {
                        user.Grup_No_1 = parameters.Grup_No;
                        _userDal.Update(user);
                        result = true;
                    }
                    else if (parameters.User_Grup == 3)
                    {
                        user.Grup_No_2 = parameters.Grup_No;
                        _userDal.Update(user);
                        result = true;
                    }
                    else if (parameters.User_Grup == 4)
                    {
                        user.Grup_No_3 = parameters.Grup_No;
                        _userDal.Update(user);
                        result = true;
                    }
                }
            }
            return result;
        }




    }
}
