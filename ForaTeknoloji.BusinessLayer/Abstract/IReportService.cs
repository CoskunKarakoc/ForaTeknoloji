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
        List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail, int? GlobalBolgeNo, int? Daire, string Plaka = null);
        List<ReportPersonelList> GetReportPersonelLists(List<string> Kapi, bool? Günlük, bool? Tümü, bool? TümKullanici, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Visitors, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kayit = null);
        List<ReportPersonelList> GetReportPersonelListsEski(List<string> Kapi, bool? Günlük, bool? Tümü, bool? TümKullanici, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Visitors, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kayit = null);
        List<AccessDatasComplex> GetTanimsizListesi(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon);


        List<DigerGecisRaporList> GetDigerGecisListesi(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, int Tetikleme, string KapiYon);
        List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, int Tetikleme, string KapiYon);




        List<IcerdeDisardaPersonel> GetIcerdeDisardaPersonels(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis);
        List<IcerdeDısardaZiyaretci> GetIcerdeDısardaZiyaretci(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis);
        List<IcerdeDısardaTümü> GetIcerdeDısardaTümü(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis);



        List<GelenGelmeyen_Gelmeyen> GelenGelmeyen_Gelmeyens(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih);
        List<GelenGelmeyen_Gelenler> GelenGelmeyen_Gelenlers(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih);
        List<GelenGelmeyen_PasifKullanici> GelenGelmeyen_PasifKullanicis(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih, double? Fark);
        List<GelenGelmeyen_ToplamIcerdeKalma> GelenGelmeyen_ToplamIcerdeKalmas(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? UserID, DateTime? Tarih1, DateTime? Tarih2);
        List<GelenGelmeyen_IlkGirisSonCikis> GelenGelmeyen_IlkGirisSonCikis(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? UserID, DateTime? Tarih1, DateTime? Tarih2);


        List<WatchEntityComplex> GetWatch(WatchParameters watchParameters);
        WatchEntityComplex LastRecordWatch(int? Kayit_No);

        void Guncelle(List<int> KayitNo);
        void GetPanelList(DBUsers user);
        void GetSirketList(DBUsers users);

    }
}
