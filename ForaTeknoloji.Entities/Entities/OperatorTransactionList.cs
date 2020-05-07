using ForaTeknoloji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("OperatorTransactionList")]
    public partial class OperatorTransactionList : IEntity
    {
        [Key]
        [Column("Kullanici Adi Yonetim Listesi")]
        [StringLength(50)]
        public string Kullanici_Adi_Yonetim_Listesi { get; set; }

        [Column("Canli Izleme")]
        public bool? Canli_Izleme { get; set; }

        [Column("Panel Ekleme")]
        public bool? Panel_Ekleme { get; set; }

        [Column("Panel Guncelleme")]
        public bool? Panel_Guncelleme { get; set; }

        [Column("Panel Ayar Gonderme")]
        public bool? Panel_Ayar_Gonderme { get; set; }

        [Column("Zaman Bolgesi Ayarlari")]
        public bool? Zaman_Bolgesi_Ayarlari { get; set; }

        [Column("Gecis Grup Ayarlari")]
        public bool? Gecis_Grup_Ayarlari { get; set; }

        [Column("Kullanici Ekleme")]
        public bool? Kullanici_Ekleme { get; set; }

        [Column("Kullanici Duzenleme")]
        public bool? Kullanici_Duzenleme { get; set; }

        [Column("Kullanici Gonderme")]
        public bool? Kullanici_Gonderme { get; set; }

        [Column("Ziyaretci Ekleme")]
        public bool? Ziyaretci_Ekleme { get; set; }

        [Column("Ziyaretci Duzenleme")]
        public bool? Ziyaretci_Duzenleme { get; set; }

        [Column("Ziyaretci Gonderme")]
        public bool? Ziyaretci_Gonderme { get; set; }

        [Column("Kapi Operasyon")]
        public bool? Kapi_Operasyon { get; set; }

        [Column("Kapi Grup Olusturma")]
        public bool? Kapi_Grup_Olusturma { get; set; }

        [Column("Grup Takvimi Olusturma")]
        public bool? Grup_Takvimi_Olusturma { get; set; }

        [Column("Tanimlamalar")]
        public bool? Tanimlamalar { get; set; }

        [Column("Kullanici Alarm Ekleme")]
        public bool? Kullanici_Alarm_Ekleme { get; set; }

        [Column("Kamera Ekleme")]
        public bool? Kamera_Ekleme { get; set; }

        [Column("Asansor Gecis Grubu Ekleme")]
        public bool? Asansor_Gecis_Grubu_Ekleme { get; set; }

        [Column("Global Bolge Guncelleme")]
        public bool? Global_Bolge_Guncelleme { get; set; }

        [Column("E-Mail Gonderme Ayarlari")]
        public bool? E_Mail_Gonderme_Ayarlari { get; set; }

        [Column("SMS Gonderme Ayarlari")]
        public bool? SMS_Gonderme_Ayarlari { get; set; }

        [Column("Gecis Olay Verileri")]
        public bool? Gecis_Olay_Verileri { get; set; }

        [Column("Gecis Olay Yedekle")]
        public bool? Gecis_Olay_Yedekle { get; set; }

        [Column("Personel Listesi")]
        public bool? Personel_Listesi { get; set; }

        [Column("Aktif Personel Raporlari")]
        public bool? Aktif_Personel_Raporlari { get; set; }

        [Column("Eski Personel Raporlari")]
        public bool? Eski_Personel_Raporlari { get; set; }

        [Column("Aktif Olmayanlar Listesi")]
        public bool? Aktif_Olmayanlar_Listesi { get; set; }

        [Column("Ilk Giris Son Cikis Raporlari")]
        public bool? Ilk_Giris_Son_Cikis_Raporlari { get; set; }

        [Column("Toplam Icerde Kalma Raporu")]
        public bool? Toplam_Icerde_Kalma_Raporu { get; set; }

        [Column("Gelen Kisi Raporlari")]
        public bool? Gelen_Kisi_Raporlari { get; set; }

        [Column("Gelmeyen Kisi Raporlari")]
        public bool? Gelmeyen_Kisi_Raporlari { get; set; }

        [Column("Pasif Kullanici Raporlari")]
        public bool? Pasif_Kullanici_Raporlari { get; set; }

        [Column("Toplu Giris Sayisi Raporlari")]
        public bool? Toplu_Giris_Sayisi_Raporlari { get; set; }

        [Column("Icerde-Disarda Personel Raporlari")]
        public bool? Icerde_Disarda_Personel_Raporlari { get; set; }

        [Column("Icerde-Disarda Ziyaretci Raporlari")]
        public bool? Icerde_Disarda_Ziyaretci_Raporlari { get; set; }

        [Column("Icerde-Disarda Tumu")]
        public bool? Icerde_Disarda_Tumu { get; set; }

        [Column("Yemekhane-Kisi Bazli Rapor")]
        public bool? Yemekhane_Kisi_Bazli_Rapor { get; set; }

        [Column("Yemekhane-Toplu Gecis Sayisi Raporlari")]
        public bool? Yemekhane_Toplu_Gecis_Sayisi_Raporlari { get; set; }

        [Column("Diger Raporlar")]
        public bool? Diger_Raporlar { get; set; }

        [Column("Kullanici Alarm Raporu")]
        public bool? Kullanici_Alarm_Raporu { get; set; }

        [Column("Ziyaretci Raporlari")]
        public bool? Ziyaretci_Raporlari { get; set; }

        [Column("Tanimsiz Kullanici Raporlari")]
        public bool? Tanimsiz_Kullanici_Raporlari { get; set; }

        [Column("Operator Log Raporlari")]
        public bool? Operator_Log_Raporlari { get; set; }

        [Column("Panel Durum Tablosu")]
        public bool? Panel_Durum_Tablosu { get; set; }

        [Column("Spot Monitor")]
        public bool? Spot_Monitor { get; set; }

        [Column("Gec Gelen Erken Cikan")]
        public bool? Gec_Gelen_Erken_Cikan { get; set; }

        [Column("Guvenlik Ayarlari")]
        public bool? Guvenlik_Ayarlari { get; set; }


    }
}
