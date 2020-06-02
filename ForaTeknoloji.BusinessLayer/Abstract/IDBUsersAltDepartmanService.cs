using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersAltDepartmanService
    {
        List<DBUsersAltDepartman> GetAllDBUsersAltDepartman(Expression<Func<DBUsersAltDepartman, bool>> filter = null);
        DBUsersAltDepartman GetById(int Kayit_No);
        DBUsersAltDepartman AddDBUsersAltDepartman(DBUsersAltDepartman dBUsersAltDepartman);
        void DeleteDBUsersAltDepartman(DBUsersAltDepartman dBUsersAltDepartman);
        void DeleteAll();
        void DeleteAllWithUserName(string KullaniciAdi);
        DBUsersAltDepartman UpdateDBUsersAltDepartman(DBUsersAltDepartman dBUsersAltDepartman);
        DBUsersAltDepartman GetByQuery(Expression<Func<DBUsersAltDepartman, bool>> filter = null);
        void DeleteAllWithUserNameAndDepartmanNo(string UserName, int DepartmanNo);
        void DeleteAllWithUserNameAndDepartmanNoAndAltDepartman(string UserName, int DepartmanNo, int AltDepartmanNo);
    }
}
