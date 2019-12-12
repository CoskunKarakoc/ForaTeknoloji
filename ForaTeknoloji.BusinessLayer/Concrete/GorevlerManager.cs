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
    public class GorevlerManager : IGorevlerService
    {
        private IGorevlerDal _gorevlerDal;
        public GorevlerManager(IGorevlerDal gorevlerDal)
        {
            _gorevlerDal = gorevlerDal;
        }

        public Gorevler AddGorev(Gorevler gorev)
        {
            return _gorevlerDal.Add(gorev);
        }

        public void DeleteAll()
        {
            _gorevlerDal.DeleteAll();
        }

        public void DeleteGorev(Gorevler gorev)
        {
            _gorevlerDal.Delete(gorev);
        }

        public List<Gorevler> GetAllGorevler(Expression<Func<Gorevler, bool>> filter = null)
        {
            return filter == null ? _gorevlerDal.GetList() : _gorevlerDal.GetList(filter);
        }

        public Gorevler GetByGorevAdi(string GorevAdi)
        {
            return _gorevlerDal.Get(x => x.Adi == GorevAdi);
        }

        public Gorevler GetById(int id)
        {
            return _gorevlerDal.Get(x => x.Gorev_No == id);
        }

        public Gorevler UpdateGorev(Gorevler gorev)
        {
            return _gorevlerDal.Update(gorev);
        }
    }
}
