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
    public class DBUsersBolumManager : IDBUsersBolumService
    {

        private IDBUsersBolumDal _dBUsersBolumDal;
        public DBUsersBolumManager(IDBUsersBolumDal dBUsersBolumDal)
        {
            _dBUsersBolumDal = dBUsersBolumDal;
        }
        public DBUsersBolum AddDBUsersBolum(DBUsersBolum dBUsersBolum)
        {
            return _dBUsersBolumDal.Add(dBUsersBolum);
        }

        public void DeleteAll()
        {
            _dBUsersBolumDal.DeleteAll();
        }

        public void DeleteAllWithUserName(string KullaniciAdi)
        {
            _dBUsersBolumDal.DeleteAllWithUserName(KullaniciAdi);
        }

        public void DeleteDBUsersBolum(DBUsersBolum dBUsersBolum)
        {
            _dBUsersBolumDal.Delete(dBUsersBolum);
        }

        public List<DBUsersBolum> GetAllDBUsersBolum(Expression<Func<DBUsersBolum, bool>> filter = null)
        {
            return filter == null ? _dBUsersBolumDal.GetList() : _dBUsersBolumDal.GetList(filter);
        }

        public DBUsersBolum GetById(int Kayit_No)
        {
            return _dBUsersBolumDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public DBUsersBolum GetByBolumNo(int Bolum_No)
        {
            return _dBUsersBolumDal.Get(x => x.Bolum_No == Bolum_No);
        }


        public DBUsersBolum UpdateDBUsersBolum(DBUsersBolum dBUsersBolum)
        {
            return _dBUsersBolumDal.Update(dBUsersBolum);
        }
    }
}
