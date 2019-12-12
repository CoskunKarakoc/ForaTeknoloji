using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersDepartmanService
    {
        List<DBUsersDepartman> GetAllDBUsersDepartman(Expression<Func<DBUsersDepartman, bool>> filter = null);
        DBUsersDepartman GetById(int id);
        DBUsersDepartman AddDBUsersDepartman(DBUsersDepartman dBUsersDepartman);
        void DeleteDBUsersDepartman(DBUsersDepartman dBUsersDepartman);
        DBUsersDepartman UpdateDBUsersDepartman(DBUsersDepartman dBUsersDepartman);
        void DeleteAllWithUserName(string UserName);
    }
}
