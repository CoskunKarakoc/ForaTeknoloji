using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBRolesManager : IDBRolesService
    {
        private IDBRolesDal _dBRolesDal;
        public DBRolesManager(IDBRolesDal dBRolesDal)
        {
            _dBRolesDal = dBRolesDal;
        }
        public DBRoles AddDBRoles(DBRoles dBRoles)
        {
            return _dBRolesDal.Add(dBRoles);
        }

        public void DeleteDBRoles(DBRoles dBRoles)
        {
            _dBRolesDal.Delete(dBRoles);
        }

        public List<DBRoles> GetAllDBRoles(Expression<Func<DBRoles, bool>> filter = null)
        {
            return filter == null ? _dBRolesDal.GetList() : _dBRolesDal.GetList(filter);
        }

        public DBRoles GetById(int YetkiTipi)
        {
            return _dBRolesDal.Get(x => x.Yetki_Tipi == YetkiTipi);
        }

        public DBRoles UpdateDBRoles(DBRoles dBRoles)
        {
            return _dBRolesDal.Update(dBRoles);
        }
    }
}
