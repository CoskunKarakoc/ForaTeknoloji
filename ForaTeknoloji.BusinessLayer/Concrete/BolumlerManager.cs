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
    public class BolumlerManager : IBolumlerService
    {
        private IBolumlerDal _bolumlerDal;
        public BolumlerManager(IBolumlerDal bolumlerDal)
        {
            _bolumlerDal = bolumlerDal;
        }


        public Bolumler AddBolum(Bolumler bolum)
        {
            return _bolumlerDal.Add(bolum);
        }

        public void DeleteAll()
        {
            _bolumlerDal.DeleteAll();
        }

        public void DeleteBolum(Bolumler bolum)
        {
            _bolumlerDal.Delete(bolum);
        }

        public List<Bolumler> GetAllBolumler(Expression<Func<Bolumler, bool>> filter = null)
        {
            return filter == null ? _bolumlerDal.GetList() : _bolumlerDal.GetList();
        }

        public Bolumler GetByBolumAdi(string BolumAdi)
        {
            return _bolumlerDal.Get(x => x.Adi == BolumAdi);
        }

        public Bolumler GetById(int id)
        {
            return _bolumlerDal.Get(x => x.Bolum_No == id);
        }

        public Bolumler UpdateBolum(Bolumler bolum)
        {
            return _bolumlerDal.Update(bolum);
        }
    }
}
