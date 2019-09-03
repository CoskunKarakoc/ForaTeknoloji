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
    public class SirketManager : ISirketService
    {
        private ISirketDal _sirketDal;
        public SirketManager(ISirketDal sirketDal)
        {
            _sirketDal = sirketDal;
        }
        public Sirketler AddSirket(Sirketler sirket)
        {
            return _sirketDal.Add(sirket);
        }

        public void DeleteSirket(Sirketler sirket)
        {
            _sirketDal.Delete(sirket);
        }

        public List<Sirketler> GetAllSirketler(Expression<Func<Sirketler, bool>> filter = null)
        {
            return filter == null ? _sirketDal.GetList() : _sirketDal.GetList(filter);
        }

        public Sirketler GetById(int id)
        {
            return _sirketDal.Get(x => x.Sirket_No == id);
        }

        public Sirketler UpdateSirket(Sirketler sirket)
        {
            return _sirketDal.Update(sirket);
        }
    }
}
