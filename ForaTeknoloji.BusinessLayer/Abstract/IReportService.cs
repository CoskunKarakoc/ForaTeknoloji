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

        /// <summary>
        /// Sondan başlayarak geriye complex geçiş verileri gönderiyor.
        /// </summary>
        /// <param name="watchParameters">İzleme parametrelerine göre kriter uyguluyor.</param>
        /// <returns></returns>
        List<WatchEntityComplex> GetWatch(WatchParameters watchParameters);


        /// <summary>
        /// Giriş yapan son kullanıcının bilgileri dönüyor.
        /// Session'da ki kullanıcı bilgilerine göre Şirket,Departman ve Panel kriterleri uygulanıyor.
        /// </summary>
        /// <param name="Kayit_No">Gönderilen 'Kayit No'suna göre kullanıcı gönderiyor.</param>
        /// <returns></returns>
        WatchEntityComplex LastRecordWatch(int? Kayit_No);

        void Guncelle(List<int> KayitNo);

        /// <summary>
        /// Kullanıcı adına göre 'panelListesi' değişkenine id'leri sıralıyor.
        /// Eğer kullanıcı admin ise panel listesindeki geçerli panellerin tümü ekleniyor.
        /// </summary>
        /// <param name="user">UI Katmanında ki Session'da saklanan kullanıcının bilgileri ile filtreleniyor.</param>
        void GetPanelList(DBUsers user);

        /// <summary>
        /// Kullanıcı adına göre 'sirketListesi' değişkenine id'leri sıralıyor.
        /// Eğer kullanıcı admin ise şirket listesindeki geçerli şirketlerin tümü ekleniyor.
        /// </summary>
        /// <param name="users">UI Katmanında ki Session'da saklanan kullanıcının bilgileri ile filtreleniyor.</param>
        void GetSirketList(DBUsers users);

        /// <summary>
        /// Kullanıcı adına göre 'departmanListesi' değişkenine id'leri sıralıyor.
        /// Eğer kullanıcı admin ise departman listesindeki geçerli departmanların tümü ekleniyor.
        /// </summary>
        /// <param name="users">UI Katmanında ki Session'da saklanan kullanıcının bilgileri ile filtreleniyor.</param>
        void GetDepartmanList(DBUsers users);



    }
}
