using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IVisitorsService
    {
        List<Visitors> GetAllVisitors();
        Visitors GetById(int id);
        Visitors AddVisitor(Visitors visitors);
        void DeleteVisitor(Visitors visitors);
        Visitors UpdateVisitor(Visitors visitors);
        List<ZiyaretciRaporList> GetZiyaretciListesi();

    }
}
