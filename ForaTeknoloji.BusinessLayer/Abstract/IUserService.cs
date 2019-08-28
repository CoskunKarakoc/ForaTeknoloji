using ForaTeknoloji.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail,int? GlobalBolgeNo, int? Daire, string Plaka = null);
        List<GelenGelmeyenRaporList> GetGelenGelmeyenLists(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? Visitors, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tipler = null);
        List<ReportPersonelList> GetReportPersonelLists(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Günlük, bool? Tümü, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kullanici = null, string Kayit = null);
    }
}
