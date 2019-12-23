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
    public class UnvanManager : IUnvanService
    {
        private IUnvanDal _unvanDal;
        public UnvanManager(IUnvanDal unvanDal)
        {
            _unvanDal = unvanDal;
        }

        public Unvan AddUnvan(Unvan unvan)
        {
            return _unvanDal.Add(unvan);
        }

        public void DeleteAll()
        {
            _unvanDal.DeleteAll();
        }

        public void DeleteUnvan(Unvan unvan)
        {
            _unvanDal.Delete(unvan);
        }

        public List<Unvan> GetAllUnvan(Expression<Func<Unvan, bool>> filter = null)
        {
            return filter == null ? _unvanDal.GetList() : _unvanDal.GetList(filter);
        }

        public Unvan GetById(int Unvan_No)
        {
            return _unvanDal.Get(x => x.Unvan_No == Unvan_No);
        }

        public Unvan UpdateUnvan(Unvan unvan)
        {
            return _unvanDal.Update(unvan);
        }
    }
}
