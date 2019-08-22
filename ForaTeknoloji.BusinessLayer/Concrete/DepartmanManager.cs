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
        public DepartmanManager(IDepartmanDal departmanDal)
        {
            _departmanDal = departmanDal;
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
    }
}
