using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Visitors> GetAllVisitors()
        {
            return _visitorsDal.GetList();
        }

        public Visitors GetById(int id)
        {
            return _visitorsDal.Get(x => x.Kayit_No == id);
        }

        public Visitors UpdateVisitor(Visitors visitors)
        {
            return _visitorsDal.Update(visitors);
        }

        public List<ZiyaretciRaporList> GetZiyaretciListesi()
        {
            //TODO:Koşullar yazılacak
            return _visitorsDal.GetZiyaretciListesi().ToList();
        }
    }
}
