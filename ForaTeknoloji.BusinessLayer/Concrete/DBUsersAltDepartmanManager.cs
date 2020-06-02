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
    public class DBUsersAltDepartmanManager : IDBUsersAltDepartmanService
    {
        private IDBUsersAltDepartmanDal _dBUsersAltDepartmanDal;
        public DBUsersAltDepartmanManager(IDBUsersAltDepartmanDal dBUsersAltDepartmanDal)
        {
            _dBUsersAltDepartmanDal = dBUsersAltDepartmanDal;
        }


        public DBUsersAltDepartman AddDBUsersAltDepartman(DBUsersAltDepartman dBUsersAltDepartman)
        {
            return _dBUsersAltDepartmanDal.Add(dBUsersAltDepartman);
        }

        public void DeleteAll()
        {
            _dBUsersAltDepartmanDal.DeleteAll();
        }

        public void DeleteDBUsersAltDepartman(DBUsersAltDepartman dBUsersAltDepartman)
        {
            _dBUsersAltDepartmanDal.Delete(dBUsersAltDepartman);
        }

        public void DeleteAllWithUserName(string KullaniciAdi)
        {
            _dBUsersAltDepartmanDal.DeleteAllWithUserName(KullaniciAdi);
        }


        public List<DBUsersAltDepartman> GetAllDBUsersAltDepartman(Expression<Func<DBUsersAltDepartman, bool>> filter = null)
        {
            return filter == null ? _dBUsersAltDepartmanDal.GetList() : _dBUsersAltDepartmanDal.GetList(filter);
        }

        public DBUsersAltDepartman GetByQuery(Expression<Func<DBUsersAltDepartman, bool>> filter = null)
        {
            return filter == null ? null : _dBUsersAltDepartmanDal.Get(filter);
        }

        public DBUsersAltDepartman GetById(int Kayit_No)
        {
            return _dBUsersAltDepartmanDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public DBUsersAltDepartman UpdateDBUsersAltDepartman(DBUsersAltDepartman dBUsersAltDepartman)
        {
            return _dBUsersAltDepartmanDal.Update(dBUsersAltDepartman);
        }

        public void DeleteAllWithUserNameAndDepartmanNo(string UserName, int DepartmanNo)
        {
            _dBUsersAltDepartmanDal.DeleteAllWithUserNameAndDepartmanNo(UserName, DepartmanNo);
        }

        public void DeleteAllWithUserNameAndDepartmanNoAndAltDepartman(string UserName, int DepartmanNo, int AltDepartmanNo)
        {
            _dBUsersAltDepartmanDal.DeleteAllWithUserNameAndDepartmanNoAndAltDepartman(UserName, DepartmanNo, AltDepartmanNo);
        }

    }
}
