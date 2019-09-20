using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfVisitorsDal;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class VisitorsManager : IVisitorsService
    {
        private IVisitorsDal _visitorsDal;
        public VisitorsManager(IVisitorsDal visitorsDal)
        {
            _visitorsDal = visitorsDal;
        }
        public Visitors AddVisitor(Visitors visitors)
        {
            return _visitorsDal.Add(visitors);
        }

        public void DeleteVisitor(Visitors visitors)
        {
            _visitorsDal.Delete(visitors);
        }

        public List<Visitors> GetAllVisitors(Expression<Func<Visitors, bool>> filter = null)
        {
            return _visitorsDal.GetList(filter);
        }

        public Visitors GetById(int id)
        {
            return _visitorsDal.Get(x => x.Kayit_No == id);
        }

        public Visitors UpdateVisitor(Visitors visitors)
        {
            return _visitorsDal.Update(visitors);
        }

    }
}
