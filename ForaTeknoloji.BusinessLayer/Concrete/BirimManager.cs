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
    public class BirimManager : IBirimService
    {

        private IBirimDal _birimDal;
        public BirimManager(IBirimDal birimDal)
        {
            _birimDal = birimDal;
        }

        public Birim AddBirim(Birim birim)
        {
            return _birimDal.Add(birim);
        }

        public List<ComplexBirim> ComplexBirim(Expression<Func<ComplexBirim, bool>> filter = null)
        {
            return filter == null ? _birimDal.ComplexBirim() : _birimDal.ComplexBirim(filter);
        }

        public void DeleteAll()
        {
            _birimDal.DeleteAll();
        }

        public void DeleteBirim(Birim birim)
        {
            _birimDal.Delete(birim);
        }

        public List<Birim> GetAllBirim(Expression<Func<Birim, bool>> filter = null)
        {
            return filter == null ? _birimDal.GetList() : _birimDal.GetList(filter);
        }

        public Birim GetById(int Birim_No)
        {
            return _birimDal.Get(x => x.Birim_No == Birim_No);
        }

        public Birim UpdateBirim(Birim birim)
        {
            return _birimDal.Update(birim);
        }
    }
}
