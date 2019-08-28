using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IVisitorsService
    {
        List<Visitors> GetAllVisitors(Expression<Func<Visitors, bool>> filter = null);
        Visitors GetById(int id);
        Visitors AddVisitor(Visitors visitors);
        void DeleteVisitor(Visitors visitors);
        Visitors UpdateVisitor(Visitors visitors);
        List<ZiyaretciRaporList> GetZiyaretciListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, int? Global_Bolge_Adi, int? Groupsdetail, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Kayit = "", string KapiYon = "");
      
    }
}
