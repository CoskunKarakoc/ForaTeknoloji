using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class ProgInitManager : IProgInitService
    {
        private IProgInitDal _progInitDal;
        public ProgInitManager(IProgInitDal progInitDal)
        {
            _progInitDal = progInitDal;
        }


        public ProgInit AddProgInit(ProgInit progInit)
        {
            return _progInitDal.Add(progInit);
        }

        public void DeleteProgInit(ProgInit progInit)
        {
            _progInitDal.Delete(progInit);
        }

        public List<ProgInit> GetAllProgInit(Expression<Func<ProgInit, bool>> filter = null)
        {
            return filter == null ? _progInitDal.GetList() : _progInitDal.GetList(filter);
        }

        public ProgInit GetById(int Kayit_No)
        {
            return _progInitDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public ProgInit UpdateProgInit(ProgInit progInit)
        {
            return _progInitDal.Update(progInit);
        }
    }
}
