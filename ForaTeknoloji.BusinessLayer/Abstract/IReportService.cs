using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReportService
    {
        List<ZiyaretciRaporList> GetZiyaretciListesi(List<string> Kapi, bool? Tümü, int? Visitors, int? Global_Bolge_Adi, int? Groupsdetail, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Kayit = "", string KapiYon = "");
        List<GelenGelmeyenRaporList> GetGelenGelmeyenLists(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? Visitors, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tipler = null);
        List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail, int? GlobalBolgeNo, int? Daire, string Plaka = null);
        List<ReportPersonelList> GetReportPersonelLists(List<string> Kapi, bool? Günlük, bool? Tümü, bool? TümKullanici, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Visitors, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kullanici = null, string Kayit = null);
        List<AccessDatas> GetTanimsizListesi(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon);
        List<DigerGecisRaporList> GetDigerGecisListesi(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon);
        List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon);
        List<IcerdeDisardaPersonel> GetIcerdeDisardaPersonels();
        List<IcerdeDısardaZiyaretci> GetIcerdeDısardaZiyaretci();
        List<IcerdeDısardaTümü> GetIcerdeDısardaTümü();
        List<GelenGelmeyen_Gelmeyen> GelenGelmeyen_Gelmeyens(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? Visitors, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tipler = null);
    }
}
