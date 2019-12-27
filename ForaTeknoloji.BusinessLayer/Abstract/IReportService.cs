using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReportService
    {
        List<ZiyaretciRaporList> GetZiyaretciListesi(VisitorReportParameters parameters);
        List<PersonelList> GetPersonelLists(PersonelListReportParameters parameters);
        List<ReportPersonelList> GetReportPersonelLists(ActiveUserReportParameters parameters);
        List<ReportPersonelList> GetReportPersonelListsEski(ActiveUserReportParameters parameters);
        List<AccessDatasComplex> GetTanimsizListesi(TanimsizReportParameters parameters);


        List<DigerGecisRaporList> GetDigerGecisListesi(OutherReportParameters parameters);
        List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(OutherReportParameters parameters);




        List<IcerdeDisardaPersonel> GetIcerdeDisardaPersonels(IcerdeDisardaReportParameters parameters);
        List<IcerdeDısardaZiyaretci> GetIcerdeDısardaZiyaretci(IcerdeDisardaReportParameters parameters);
        List<IcerdeDısardaTümü> GetIcerdeDısardaTümü(IcerdeDisardaReportParameters parameters);


        /// <summary>
        /// Gelen gelmeyen raporlarında ki gelmeyenlerin listesini gönderiyor.
        /// </summary>
        /// <param name="parameters">Şirket,Departman,Global Kapı Bölgesi,Geçiş Grubu,Başlangıç ve Bitiş Tarihleri,Gün Bazında Fark,Kullanıcı</param>
        /// <returns>Geriye pasif kullanıcıların listesi dönüyor.</returns>
        List<GelenGelmeyen_Gelmeyen> GelenGelmeyen_Gelmeyens(GelenGelmeyenReportParameters parameters);

        /// <summary>
        /// Gelen gelmeyen raporlarında ki gelenlerin listesi gönderiyor.
        /// </summary>
        /// <param name="parameters">Şirket,Departman,Global Kapı Bölgesi,Geçiş Grubu,Başlangıç ve Bitiş Tarihleri,Gün Bazında Fark,Kullanıcı</param>
        /// <returns>Geriye pasif kullanıcıların listesi dönüyor.</returns>
        List<GelenGelmeyen_Gelenler> GelenGelmeyen_Gelenlers(GelenGelmeyenReportParameters parameters);


        /// <summary>
        /// Gelen gelmeyen raporlarında ki pasif kullanıcıların listesini gönderiyor.
        /// </summary>
        /// <param name="parameters">Şirket,Departman,Global Kapı Bölgesi,Geçiş Grubu,Başlangıç ve Bitiş Tarihleri,Gün Bazında Fark,Kullanıcı</param>
        /// <returns>Geriye pasif kullanıcıların listesi dönüyor.</returns>
        List<GelenGelmeyen_PasifKullanici> GelenGelmeyen_PasifKullanicis(GelenGelmeyenReportParameters parameters);



        /// <summary>
        /// Gelen gelmeyen kullanıcıların toplam içerde kalma sürelerini gönderiyor.
        /// </summary>
        /// <param name="parameters">Şirket,Departman,Global Kapı Bölgesi,Geçiş Grubu,Başlangıç ve Bitiş Tarihleri,Gün Bazında Fark,Kullanıcı</param>
        /// <returns>Geriye toplam içiride geçirilen sürelin listesi dönüyor.</returns>
        List<GelenGelmeyen_ToplamIcerdeKalma> GelenGelmeyen_ToplamIcerdeKalmas(GelenGelmeyenReportParameters parameters);

        /// <summary>
        /// Gelen gelmeyen raporlarında ki toplam içerde kalma sürelerini veren parametreli sorgu.
        /// </summary>
        /// <param name="parameters">Şirket,Departman,Global Kapı Bölgesi,Geçiş Grubu,Başlangıç ve Bitiş Tarihleri,Gün Bazında Fark,Kullanıcı</param>
        /// <returns>Geriye ilk giriş son çıkışların listesi dönüyor.</returns>
        List<GelenGelmeyen_IlkGirisSonCikis> GelenGelmeyen_IlkGirisSonCikis(GelenGelmeyenReportParameters parameters);

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

        /// <summary>
        /// Kullanıcının yetkilerine göre panel listesi gönderiyor.
        /// </summary>
        /// <param name="dBUsers">Sisteme giriş yapan kullanıcı.</param>
        /// <returns></returns>
        List<PanelSettings> PanelListesi(DBUsers dBUsers);

        /// <summary>
        /// Kullanıcının yetkilerine göre departman listesi gönderiyor.
        /// </summary>
        /// <param name="dBUsers">Sisteme giriş yapan kullanıcı.</param>
        /// <returns></returns>
        List<Departmanlar> DepartmanListesi(DBUsers dBUsers);

        /// <summary>
        /// Kullanıcının yetkilerine göre şirket listesi gönderiyor.
        /// </summary>
        /// <param name="dBUsers">Sisteme giriş yapan kullanıcı.</param>
        /// <returns></returns>
        List<Sirketler> SirketListesi(DBUsers dBUsers);

        List<YemekhaneComplex> YemekhaneRaporu(RefectoryParameters parameters);
        List<YemekhaneComplexTotal> YemekhaneRaporuTotal(RefectoryParameters parameters);


        List<WatchEntityComplex> MonitorWatch(SpotMonitorSettings parameters);
    }
}
