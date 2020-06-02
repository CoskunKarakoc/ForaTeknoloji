using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        DBUsersDepartman GetByQuery(Expression<Func<DBUsersDepartman, bool>> filter = null);
    }
}
