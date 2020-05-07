using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDBUsersBolumService
    {
        List<DBUsersBolum> GetAllDBUsersBolum(Expression<Func<DBUsersBolum, bool>> filter = null);
        DBUsersBolum GetById(int Kayit_No);
        DBUsersBolum GetByBolumNo(int Bolum_No);
        DBUsersBolum AddDBUsersBolum(DBUsersBolum dBUsersBolum);
        void DeleteDBUsersBolum(DBUsersBolum dBUsersBolum);
        void DeleteAll();
        void DeleteAllWithUserName(string KullaniciAdi);
        DBUsersBolum UpdateDBUsersBolum(DBUsersBolum dBUsersBolum);
    }
}
