using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class BolumManager : IBolumService
    {
        private IBolumDal _bolumDal;
        public BolumManager(IBolumDal bolumDal)
        {
            _bolumDal = bolumDal;
        }

        public Bolum AddBolum(Bolum bolum)
        {
            return _bolumDal.Add(bolum);
        }

        public List<ComplexBolum> ComplexBolums(Expression<Func<ComplexBolum, bool>> filter = null)
        {
            return filter == null ? _bolumDal.ComplexBolum() : _bolumDal.ComplexBolum(filter);
        }

        public void DeleteAll()
        {
            _bolumDal.DeleteAll();
        }

        public void DeleteBolum(Bolum bolum)
        {
            _bolumDal.Delete(bolum);
        }

        public List<Bolum> GetAllBolum(Expression<Func<Bolum, bool>> filter = null)
        {
            return filter == null ? _bolumDal.GetList() : _bolumDal.GetList(filter);
        }

        public Bolum GetById(int Bolum_No)
        {
            return _bolumDal.Get(x => x.Bolum_No == Bolum_No);
        }

        public Bolum UpdateBolum(Bolum bolum)
        {
            return _bolumDal.Update(bolum);
        }
    }
}
