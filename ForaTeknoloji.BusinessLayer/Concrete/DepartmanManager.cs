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

        public List<Departmanlar> GetAllDepartmanlar()
        {
            return _departmanDal.GetList();
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
    }
}
