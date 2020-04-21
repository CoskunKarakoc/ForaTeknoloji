using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBUsersKapiManager : IDBUsersKapiService
    {
        private IDBUsersKapiDal _dBUsersKapiDal;
        public DBUsersKapiManager(IDBUsersKapiDal dBUsersKapiDal)
        {
            _dBUsersKapiDal = dBUsersKapiDal;
        }

        public DBUsersKapi AddDBUsersKapi(DBUsersKapi dBUsersKapi)
        {
            return _dBUsersKapiDal.Add(dBUsersKapi);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteByUserName(string Kullanici_Adi)
        {
            _dBUsersKapiDal.DeleteByUserName(Kullanici_Adi);
        }

        public void DeleteDBUsersKapi(DBUsersKapi dBUsersKapi)
        {
            _dBUsersKapiDal.Delete(dBUsersKapi);
        }

        public List<DBUsersKapi> GetAllDBUsersKapi(Expression<Func<DBUsersKapi, bool>> filter = null)
        {
            return filter == null ? _dBUsersKapiDal.GetList() : _dBUsersKapiDal.GetList(filter);
        }

        public DBUsersKapi GetById(int Kayit_No)
        {
            return _dBUsersKapiDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public DBUsersKapi GetByKullaniciAdi(string Kullanici_Adi)
        {
            return _dBUsersKapiDal.Get(x => x.Kullanici_Adi == Kullanici_Adi);
        }

        public List<DBUsersKapi> GetByKullaniciAdiReturnList(string Kullanici_Adi)
        {
            return _dBUsersKapiDal.GetList(x => x.Kullanici_Adi == Kullanici_Adi);
        }


        public DBUsersKapi UpdateDBUsersKapi(DBUsersKapi dBUsersKapi)
        {
            return _dBUsersKapiDal.Update(dBUsersKapi);
        }
    }
}
