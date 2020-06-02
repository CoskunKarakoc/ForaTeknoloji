using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersKapiService
    {
        List<DBUsersKapi> GetAllDBUsersKapi(Expression<Func<DBUsersKapi, bool>> filter = null);
        DBUsersKapi GetById(int Kayit_No);
        DBUsersKapi GetByKullaniciAdi(string Kullanici_Adi);
        List<DBUsersKapi> GetByKullaniciAdiReturnList(string Kullanici_Adi);
        DBUsersKapi AddDBUsersKapi(DBUsersKapi dBUsersKapi);
        void DeleteDBUsersKapi(DBUsersKapi dBUsersKapi);
        DBUsersKapi UpdateDBUsersKapi(DBUsersKapi dBUsersKapi);
        void DeleteAll();
        void DeleteByUserName(string Kullanici_Adi);
        DBUsersKapi GetByQuery(Expression<Func<DBUsersKapi, bool>> filter = null);
    }
}
