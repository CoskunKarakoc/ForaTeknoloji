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

        public List<DBUsersSirket> GetAllDBUsersSirket(Expression<Func<DBUsersSirket, bool>> filter = null)
        {
            return filter == null ? _dBUsersSirketDal.GetList() : _dBUsersSirketDal.GetList(filter);
        }

        public DBUsersSirket GetById(int id)
        {
            return _dBUsersSirketDal.Get(x => x.Kayit_No == id);
        }

        public DBUsersSirket GetByQuery(Expression<Func<DBUsersSirket,bool>> filter=null)
        {
            return filter == null ? null : _dBUsersSirketDal.Get(filter);
        }

        public DBUsersSirket UpdateDBUsersSirket(DBUsersSirket dBUsersSirket)
        {
            return _dBUsersSirketDal.Update(dBUsersSirket);
        }
    }
}
