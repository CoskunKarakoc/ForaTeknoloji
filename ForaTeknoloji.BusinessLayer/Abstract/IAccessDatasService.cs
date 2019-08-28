using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessDatasService
    {
        List<AccessDatas> GetAllAccessDatas();
        AccessDatas GetById(int id);
        List<AccessDatas> GetByKod(int kod);
        List<int?> GetGecisTipi();
        AccessDatas AddAccessData(AccessDatas accessDatas);
        void DeleteAccessData(AccessDatas accessDatas);
        AccessDatas UpdateAccessData(AccessDatas accessDatas);
        List<AccessDatas> GetTanimsizListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2,string KapiYon);
        List<DigerGecisRaporList> GetDigerGecisListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon);
        List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon);
    }
}
