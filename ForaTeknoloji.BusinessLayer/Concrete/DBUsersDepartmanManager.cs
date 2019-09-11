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
    public class DBUsersDepartmanManager : IDBUsersDepartmanService
    {
        private IDBUsersDepartmanDal _dBUsersDepartmanDal;
        public DBUsersDepartmanManager(IDBUsersDepartmanDal dBUsersDepartmanDal)
        {
            _dBUsersDepartmanDal = dBUsersDepartmanDal;
        }
        public DBUsersDepartman AddDBUsersDepartman(DBUsersDepartman dBUsersDepartman)
        {
            return _dBUsersDepartmanDal.Add(dBUsersDepartman);
        }

        public void DeleteDBUsersDepartman(DBUsersDepartman dBUsersDepartman)
        {
            _dBUsersDepartmanDal.Delete(dBUsersDepartman);
        }

        public List<DBUsersDepartman> GetAllDBUsersDepartman(Expression<Func<DBUsersDepartman, bool>> filter = null)
        {
            return filter == null ? _dBUsersDepartmanDal.GetList() : _dBUsersDepartmanDal.GetList(filter);
        }

        public DBUsersDepartman GetById(int id)
        {
            return _dBUsersDepartmanDal.Get(x => x.Kayit_No == id);
        }

        public DBUsersDepartman UpdateDBUsersDepartman(DBUsersDepartman dBUsersDepartman)
        {
            return _dBUsersDepartmanDal.Update(dBUsersDepartman);
        }
    }
}
