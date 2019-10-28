using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBRolesService
    {
        List<DBRoles> GetAllDBRoles(Expression<Func<DBRoles, bool>> filter = null);
        DBRoles GetById(int YetkiTipi);
        DBRoles AddDBRoles(DBRoles dBRoles);
        void DeleteDBRoles(DBRoles dBRoles);
        DBRoles UpdateDBRoles(DBRoles dBRoles);
    }
}
