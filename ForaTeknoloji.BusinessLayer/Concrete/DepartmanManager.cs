using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        private IDepartmanDal _departmanDal;
        private IDBUsersDepartmanDal _dBUsersDepartmanDal;
        public DepartmanManager(IDepartmanDal departmanDal, IDBUsersDepartmanDal dBUsersDepartmanDal)
        {
            _departmanDal = departmanDal;
            _dBUsersDepartmanDal = dBUsersDepartmanDal;
        }
        public Departmanlar AddDepartman(Departmanlar departman)
        {
            return _departmanDal.Add(departman);
        }

        public void DeleteDepartmanlar(Departmanlar departman)
        {
            _departmanDal.Delete(departman);
        }

        public List<Departmanlar> GetAllDepartmanlar(Expression<Func<Departmanlar, bool>> filter = null)
        {
            return filter == null ? _departmanDal.GetList() : _departmanDal.GetList(filter);
        }

        public Departmanlar GetById(int id)
        {
            return _departmanDal.Get(x => x.Departman_No == id);
        }

        public Departmanlar UpdateDepartman(Departmanlar departman)
        {
            return _departmanDal.Update(departman);
        }

        public List<Departmanlar> GetByKullaniciAdi(string kullaniciAdi)
        {
            List<int?> liste = _dBUsersDepartmanDal.GetList(x => x.Kullanici_Adi == kullaniciAdi).Select(x => x.Departman_No).ToList();
            return _departmanDal.GetList(x => liste.Contains(x.Departman_No));
        }

        public Departmanlar GetByDepartmanAdi(string departmanAdi)
        {
            return _departmanDal.Get(x => x.Adi == departmanAdi);
        }

        public void DeleteAll()
        {
            _departmanDal.DeleteAll();
        }
    }
}
