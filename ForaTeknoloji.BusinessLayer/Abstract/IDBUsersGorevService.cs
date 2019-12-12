using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersGorevService
    {
        List<DBUsersGorev> GetAllDBUsersDepartman(Expression<Func<DBUsersGorev, bool>> filter = null);
        DBUsersGorev GetById(int id);
        DBUsersGorev AddDBUsersGorev(DBUsersGorev dBUsersGorev);
        void DeleteDBUsersGorev(DBUsersGorev dBUsersGorev);
        DBUsersGorev UpdateDBUsersGorev(DBUsersGorev dBUsersGorev);
        void DeleteAllWithUserName(string UserName);
    }
}
