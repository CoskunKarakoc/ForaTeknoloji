using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfVisitorsDal;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IVisitorsService
    {
        List<Visitors> GetAllVisitors(Expression<Func<Visitors, bool>> filter = null);
        Visitors GetById(int id);
        Visitors AddVisitor(Visitors visitors);
        void DeleteVisitor(Visitors visitors);
        Visitors UpdateVisitor(Visitors visitors);
       
    }
}
