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
    public class DBUsersManager : IDBUsersService
    {
        private IDBUsersDal _dBUsersDal;
        public DBUsersManager(IDBUsersDal dBUsersDal)
        {
            _dBUsersDal = dBUsersDal;
        }
        public DBUsers AddDBUser(DBUsers dBUsers)
        {
            return _dBUsersDal.Add(dBUsers);
        }

        public void DeleteDBUser(DBUsers dBUsers)
        {
            _dBUsersDal.Delete(dBUsers);
        }

        public List<DBUsers> GetAllDBUsers()
        {
            return _dBUsersDal.GetList();
        }

        public DBUsers GetById(string kullaniciAdi)
        {
            return _dBUsersDal.Get(x => x.Kullanici_Adi == kullaniciAdi);
        }

        public DBUsers UpdateDBUser(DBUsers dBUsers)
        {
            return _dBUsersDal.Update(dBUsers);
        }
    }
}
