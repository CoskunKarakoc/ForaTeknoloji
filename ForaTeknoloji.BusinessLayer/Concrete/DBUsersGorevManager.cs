using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBUsersGorevManager : IDBUsersGorevService
    {
        private IDBUsersGorevDal _dBUsersGorevDal;
        public DBUsersGorevManager(IDBUsersGorevDal dBUsersGorevDal)
        {
            _dBUsersGorevDal = dBUsersGorevDal;
        }


        public DBUsersGorev AddDBUsersGorev(DBUsersGorev dBUsersGorev)
        {
            return _dBUsersGorevDal.Add(dBUsersGorev);
        }

        public void DeleteAllWithUserName(string UserName)
        {
            _dBUsersGorevDal.DeleteAllWithUserName(UserName);
        }

        public void DeleteDBUsersGorev(DBUsersGorev dBUsersGorev)
        {
            _dBUsersGorevDal.Delete(dBUsersGorev);
        }

        public List<DBUsersGorev> GetAllDBUsersDepartman(Expression<Func<DBUsersGorev, bool>> filter = null)
        {
            return filter == null ? _dBUsersGorevDal.GetList() : _dBUsersGorevDal.GetList(filter);
        }

        public DBUsersGorev GetById(int id)
        {
            return _dBUsersGorevDal.Get(x => x.Gorev_No == id);
        }

        public DBUsersGorev UpdateDBUsersGorev(DBUsersGorev dBUsersGorev)
        {
            return _dBUsersGorevDal.Update(dBUsersGorev);
        }
    }
}
