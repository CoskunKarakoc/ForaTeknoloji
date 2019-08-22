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
    public class DBUsersSirketManager : IDBUsersSirketService
    {
        private IDBUsersSirketDal _dBUsersSirketDal;
        public DBUsersSirketManager(IDBUsersSirketDal dBUsersSirketDal)
        {
            _dBUsersSirketDal = dBUsersSirketDal;
        }
        public DBUsersSirket AddDBUsersSirket(DBUsersSirket dBUsersSirket)
        {
            return _dBUsersSirketDal.Add(dBUsersSirket);
        }

        public void DeleteDBUsersSirket(DBUsersSirket dBUsersSirket)
        {
            _dBUsersSirketDal.Delete(dBUsersSirket);
        }

        public List<DBUsersSirket> GetAllDBUsersSirket()
        {
            return _dBUsersSirketDal.GetList();
        }

        public DBUsersSirket GetById(int id)
        {
            return _dBUsersSirketDal.Get(x=>x.Kayit_No==id);
        }

        public DBUsersSirket UpdateDBUsersSirket(DBUsersSirket dBUsersSirket)
        {
            return _dBUsersSirketDal.Update(dBUsersSirket);
        }
    }
}
