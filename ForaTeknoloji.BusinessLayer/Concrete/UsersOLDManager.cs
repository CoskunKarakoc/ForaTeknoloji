using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUsersOLDDal;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class UsersOLDManager : IUsersOLDService
    {
        private IUsersOLDDal _usersOLDDal;
        public UsersOLDManager(IUsersOLDDal usersOLDDal)
        {
            _usersOLDDal = usersOLDDal;
        }
        public UsersOLD AddUsersOLD(UsersOLD usersOLD)
        {
            return _usersOLDDal.Add(usersOLD);
        }

        public void DeleteUsersOLD(UsersOLD usersOLD)
        {
            _usersOLDDal.Delete(usersOLD);
        }

        public List<UsersOLD> GetAllUsersOLD(Expression<Func<UsersOLD, bool>> filter = null)
        {
            return filter == null ? _usersOLDDal.GetList() : _usersOLDDal.GetList(filter);
        }

        public UsersOLD GetById(int id)
        {
            return _usersOLDDal.Get(x => x.ID == id);
        }

        public UsersOLD UpdateUsersOLD(UsersOLD usersOLD)
        {
            return _usersOLDDal.Update(usersOLD);
        }

        public List<ComplexUserOld> GetAllUserOLDWithOuther(Expression<Func<ComplexUserOld, bool>> filter = null)
        {

            return filter == null ? _usersOLDDal.GetAllUserOLDWithOuther() : _usersOLDDal.GetAllUserOLDWithOuther(filter);
        }
    }
}
