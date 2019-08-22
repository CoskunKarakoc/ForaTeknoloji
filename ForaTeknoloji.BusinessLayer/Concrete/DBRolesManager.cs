using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBRolesManager : IDBRolesService
    {
        private IDBRolesDal _dBRolesDal;
        public DBRolesManager(IDBRolesDal dBRolesDal)
        {
            _dBRolesDal = dBRolesDal;
        }
        public DBRoles AddDBRole(DBRoles dBRoles)
        {
            return _dBRolesDal.Add(dBRoles);
        }

        public void DeleteDBRole(DBRoles dBRoles)
        {
            _dBRolesDal.Delete(dBRoles);
        }

        public List<DBRoles> GetAllDBRoles()
        {
            return _dBRolesDal.GetList();
        }

        public DBRoles GetById(int id)
        {
            return _dBRolesDal.Get(x => x.Yetki_Tipi == id);
        }

        public DBRoles UpdateDBRole(DBRoles dBRoles)
        {
            return _dBRolesDal.Update(dBRoles);
        }
    }
}
