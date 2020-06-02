using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IVisitorsService
    {
        List<Visitors> GetAllVisitors(Expression<Func<Visitors, bool>> filter = null);
        Visitors GetById(int id);
        Visitors AddVisitor(Visitors visitors);
        void DeleteVisitor(Visitors visitors);
        Visitors UpdateVisitor(Visitors visitors);
        Visitors GetByKartId(string Kart_ID);
    }
}
