using ForaTeknoloji.BusinessLayer.Abstract;
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
        private IDBUsersGorevService _dBUsersGorevService;
        public DBUsersGorevManager(IDBUsersGorevService dBUsersGorevService)
        {
            _dBUsersGorevService = dBUsersGorevService;
        }


        public DBUsersGorev AddDBUsersGorev(DBUsersGorev dBUsersGorev)
        {
            return _dBUsersGorevService.AddDBUsersGorev(dBUsersGorev);
        }

        public void DeleteAllWithUserName(string UserName)
        {
            _dBUsersGorevService.DeleteAllWithUserName(UserName);
        }

        public void DeleteDBUsersGorev(DBUsersGorev dBUsersGorev)
        {
            _dBUsersGorevService.DeleteDBUsersGorev(dBUsersGorev);
        }

        public List<DBUsersGorev> GetAllDBUsersDepartman(Expression<Func<DBUsersGorev, bool>> filter = null)
        {
            return filter == null ? _dBUsersGorevService.GetAllDBUsersDepartman() : _dBUsersGorevService.GetAllDBUsersDepartman(filter);
        }

        public DBUsersGorev GetById(int id)
        {
            return _dBUsersGorevService.GetById(id);
        }

        public DBUsersGorev UpdateDBUsersGorev(DBUsersGorev dBUsersGorev)
        {
            return _dBUsersGorevService.UpdateDBUsersGorev(dBUsersGorev);
        }
    }
}
