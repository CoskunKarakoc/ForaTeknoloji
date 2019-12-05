using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersSirketService
    {
        List<DBUsersSirket> GetAllDBUsersSirket(Expression<Func<DBUsersSirket, bool>> filter = null);
        DBUsersSirket GetById(int id);
        DBUsersSirket AddDBUsersSirket(DBUsersSirket dBUsersSirket);
        void DeleteDBUsersSirket(DBUsersSirket dBUsersSirket);
        DBUsersSirket UpdateDBUsersSirket(DBUsersSirket dBUsersSirket);
        DBUsersSirket GetByQuery(Expression<Func<DBUsersSirket, bool>> filter = null);
        void DeleteAllWithUserName(string UserName);
    }
}
