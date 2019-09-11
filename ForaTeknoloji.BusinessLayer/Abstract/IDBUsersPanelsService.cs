using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersPanelsService
    {
        List<DBUsersPanels> GetAllDBUsersPanels(Expression<Func<DBUsersPanels, bool>> filter = null);
        DBUsersPanels GetById(int id);
        DBUsersPanels AddDBUsersPanels(DBUsersPanels dBUsersPanels);
        void DeleteDBUsersPanels(DBUsersPanels dBUsersPanels);
        DBUsersPanels UpdateDBUsersPanels(DBUsersPanels dBUsersPanels);
    }
}
