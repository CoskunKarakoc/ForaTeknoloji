using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DBUsersManager : IDBUsersService
    {
        private IDBUsersDal _dBUsersDal;
        public DBUsersManager(IDBUsersDal dBUsersDal)
        {
            _dBUsersDal = dBUsersDal;
        }
        public DBUsers AddDBUsers(DBUsers dBUsers)
        {
            return _dBUsersDal.Add(dBUsers);
        }

        public void DeleteDBUsers(DBUsers dBUsers)
        {
            _dBUsersDal.Delete(dBUsers);
        }

        public List<DBUsers> GetAllDBUsers(Expression<Func<DBUsers, bool>> filter = null)
        {
            return filter == null ? _dBUsersDal.GetList() : _dBUsersDal.GetList(filter);
        }

        public DBUsers GetById(string kullaniciAdi)
        {
            return _dBUsersDal.Get(x => x.Kullanici_Adi == kullaniciAdi);
        }

        public DBUsers UpdateDBUsers(DBUsers dBUsers)
        {
            return _dBUsersDal.Update(dBUsers);
        }


        public DBUsers LoginUsers(LoginViewModel model)
        {
            DBUsers user = _dBUsersDal.Get(x => x.Kullanici_Adi == model.Username && x.Sifre == model.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public DBUsers GetBySifre(string Sifre)
        {
            return _dBUsersDal.Get(x => x.Sifre == Sifre);
        }
    }
}
