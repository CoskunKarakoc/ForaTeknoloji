using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersService
    {
        List<DBUsers> GetAllDBUsers(Expression<Func<DBUsers, bool>> filter = null);
        DBUsers GetById(string kullaniciAdi);
        DBUsers AddDBUsers(DBUsers dBUsers);
        void DeleteDBUsers(DBUsers dBUsers);
        DBUsers UpdateDBUsers(DBUsers dBUsers);
        DBUsers LoginUsers(LoginViewModel model);
        DBUsers GetBySifre(string Sifre);
    }
}
