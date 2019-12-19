using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class ProgRelay2Manager : IProgRelay2Service
    {
        private IProgRelay2Dal _progRelay2Dal;
        public ProgRelay2Manager(IProgRelay2Dal progRelay2Dal)
        {
            _progRelay2Dal = progRelay2Dal;
        }

        public ProgRelay2 AddProgRelay2(ProgRelay2 progRelay2)
        {
            return _progRelay2Dal.Add(progRelay2);
        }

        public void DeleteProgRelay2(ProgRelay2 progRelay2)
        {
            _progRelay2Dal.Delete(progRelay2);
        }

        public List<ProgRelay2> GetAllProgRelay2(Expression<Func<ProgRelay2, bool>> filter = null)
        {
            return filter == null ? _progRelay2Dal.GetList() : _progRelay2Dal.GetList(filter);
        }

        public ProgRelay2 GetById(int Kayit_No)
        {
            return _progRelay2Dal.Get(x => x.Kayit_No == Kayit_No);
        }

        public ProgRelay2 UpdateProgRelay2(ProgRelay2 progRelay2)
        {
            return _progRelay2Dal.Update(progRelay2);
        }
    }
}
