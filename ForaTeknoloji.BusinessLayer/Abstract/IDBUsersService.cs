using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersService
    {
        List<DBUsers> GetAllDBUsers();
        DBUsers GetById(string kullaniciAdi);
        DBUsers AddDBUser(DBUsers dBUsers);
        void DeleteDBUser(DBUsers dBUsers);
        DBUsers UpdateDBUser(DBUsers dBUsers);
    }
}
