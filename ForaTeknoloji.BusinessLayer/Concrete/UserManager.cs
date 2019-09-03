using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Users> GetAllUsers()
        {
            return _userDal.GetList();
        }

        public Users GetById(int id)
        {
            return _userDal.Get(x => x.ID == id);
        }

        public Users UpdateUsers(Users users)
        {
            return _userDal.Update(users);
        }
    }
}
