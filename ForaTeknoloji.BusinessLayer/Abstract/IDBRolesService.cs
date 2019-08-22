using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBRolesService
    {
        List<DBRoles> GetAllDBRoles();
        DBRoles GetById(int id);
        DBRoles AddDBRole(DBRoles dBRoles);
        void DeleteDBRole(DBRoles dBRoles);
        DBRoles UpdateDBRole(DBRoles dBRoles);
    }
}
