using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Data.Entity;

namespace ForaTeknoloji.DataAccessLayer.Concrete.Initializer
{
    public class DBInitializer : CreateDatabaseIfNotExists<ForaContext>
    {
        protected override void Seed(ForaContext context)
        {
            DBUsers dBUsers = new DBUsers
            {
                Adi = "Administrator",
                Soyadi = null,
                Sifre = "12345",
                Kullanici_Adi = "sa",
                SysAdmin = true,
                Kullanici_Islemleri = 1,
                Grup_Islemleri = 1,
                Programli_Kapi_Islemleri = 1,
                Gecis_Verileri_Rapor_Islemleri = 1,
                Ziyaretci_Islemleri = 1,
                Canli_Izleme = 1,
                Alarm_Islemleri = 1,
                OtherDeviceReports = null
            };
            context.DBUsers.Add(dBUsers);
            AccessCountTypes gunluk = new AccessCountTypes
            {
                Gecis_Sayisi_Tipi = "Günlük"
            };
            AccessCountTypes aylik = new AccessCountTypes
            {
                Gecis_Sayisi_Tipi = "Aylık"
            };
            context.AccessCountTypes.Add(gunluk);
            context.AccessCountTypes.Add(aylik);
            AccessModes accessModes0 = new AccessModes
            {
                Gecis_Modu = 0,
                Adi = "Etiket veya Plaka"
            };
            AccessModes accessModes1 = new AccessModes
            {
                Gecis_Modu = 1,
                Adi = "Etiket ve Plaka"
            };
            AccessModes accessModes2 = new AccessModes
            {
                Gecis_Modu = 2,
                Adi = "Kullanıcı Seçimli"
            };
            context.AccessModes.Add(accessModes0);
            context.AccessModes.Add(accessModes1);
            context.AccessModes.Add(accessModes2);
            AlarmTipleri alarmTipleri1 = new AlarmTipleri
            {
                Alarm_Tipi = 1,
                Adi = "KULLANICI ALARM - GEÇİŞTEN ÖNCE"
            };
            AlarmTipleri alarmTipleri2 = new AlarmTipleri
            {
                Alarm_Tipi = 2,
                Adi = "KULLANICI ALARM - GEÇİŞTEN SONRA"
            };
            context.AlarmTipleri.Add(alarmTipleri1);
            context.AlarmTipleri.Add(alarmTipleri2);
            Cameras cameras = new Cameras
            {
                Kamera_No = 1,
                Kamera_Adi = "LPR FORA",
                Kamera_Tipi = 3,
                IP_Adres = "192.168.1.201",
                TCP_Port = 8083,
                Kamera_Admin = "admin",
                Kamera_Password = "12345",
                Geciste_Resim_Kayit = false,
                Antipassback_Resim_Kayit = false,
                Engellenen_Resim_Kayit = false,
                Tanimsiz_Resim_Kayit = false,
            };
            context.Cameras.Add(cameras);
            CameraTypes cameraTypes1 = new CameraTypes
            {
                Kamera_Tipi = 1,
                Adi = "Zavio-BiGES / Compact IP Cameras",
                Marka = "Zavio",
                Model = "F32-F31 Series"
            };
            CameraTypes cameraTypes2 = new CameraTypes
            {
                Kamera_Tipi = 2,
                Adi = "Haikon / IR Bullet 1.3M",
                Marka = "Haikon",
                Model = "IR Bullet 1.3M"
            };
            CameraTypes cameraTypes3 = new CameraTypes
            {
                Kamera_Tipi = 3,
                Adi = "MaviPark LPR Camera",
                Marka = "MaviPark",
                Model = "MaviPark MC-92LPR IP Camera"
            };
            context.CameraTypes.Add(cameraTypes1);
            context.CameraTypes.Add(cameraTypes2);
            context.CameraTypes.Add(cameraTypes3);
            CodeOperation codeOperation0 = new CodeOperation
            {
                TKod = 0,
                Operasyon = "ENGELLENEN GEÇİŞ"
            };
            context.CodeOperation.Add(codeOperation0);
            CodeOperation codeOperation1 = new CodeOperation
            {
                TKod = 1,
                Operasyon = "NORMAL GEÇİŞ"
            };
            context.CodeOperation.Add(codeOperation1);
            CodeOperation codeOperation2 = new CodeOperation
            {
                TKod = 2,
                Operasyon = "ANTIPASSBACK İHLAL"
            };
            context.CodeOperation.Add(codeOperation2);
            CodeOperation codeOperation3 = new CodeOperation
            {
                TKod = 3,
                Operasyon = "ÇOKLU GEÇİŞ"
            };
            context.CodeOperation.Add(codeOperation3);
            CodeOperation codeOperation4 = new CodeOperation
            {
                TKod = 4,
                Operasyon = "TANIMSIZ KULLANICI"
            };
            context.CodeOperation.Add(codeOperation4);
            CodeOperation codeOperation5 = new CodeOperation
            {
                TKod = 5,
                Operasyon = "MANUEL TETİKLEME"
            };
            context.CodeOperation.Add(codeOperation5);
            CodeOperation codeOperation6 = new CodeOperation
            {
                TKod = 6,
                Operasyon = "MANUEL AÇMA"
            };
            context.CodeOperation.Add(codeOperation6);
            CodeOperation codeOperation7 = new CodeOperation
            {
                TKod = 7,
                Operasyon = "MANUEL KAPAMA"
            };
            context.CodeOperation.Add(codeOperation7);
            CodeOperation codeOperation8 = new CodeOperation
            {
                TKod = 8,
                Operasyon = "BUTON TETİKLEME"
            };
            context.CodeOperation.Add(codeOperation8);
            CodeOperation codeOperation9 = new CodeOperation
            {
                TKod = 9,
                Operasyon = "PROGRAMLI AÇMA"
            };
            context.CodeOperation.Add(codeOperation9);
            CodeOperation codeOperation10 = new CodeOperation
            {
                TKod = 10,
                Operasyon = "PROGRAMLI KAPAMA"
            };
            context.CodeOperation.Add(codeOperation10);
            CodeOperation codeOperation13 = new CodeOperation
            {
                TKod = 13,
                Operasyon = "MANUEL SERBEST"
            };
            context.CodeOperation.Add(codeOperation13);
            CodeOperation codeOperation14 = new CodeOperation
            {
                TKod = 14,
                Operasyon = "PROGRAMLI SERBEST"
            };
            context.CodeOperation.Add(codeOperation14);
            CodeOperation codeOperation20 = new CodeOperation
            {
                TKod = 20,
                Operasyon = "ALARM ALGILANDI"
            };
            context.CodeOperation.Add(codeOperation20);
            CodeOperation codeOperation21 = new CodeOperation
            {
                TKod = 21,
                Operasyon = "YANGIN ALGILANDI"
            };
            context.CodeOperation.Add(codeOperation21);
            CodeOperation codeOperation22 = new CodeOperation
            {
                TKod = 22,
                Operasyon = "KAPI AÇIK KALDI"
            };
            context.CodeOperation.Add(codeOperation22);
            CodeOperation codeOperation23 = new CodeOperation
            {
                TKod = 23,
                Operasyon = "KAPI ZORLANDI"
            };
            context.CodeOperation.Add(codeOperation23);
            CodeOperation codeOperation24 = new CodeOperation
            {
                TKod = 24,
                Operasyon = "KAPI AÇILDI"
            };
            context.CodeOperation.Add(codeOperation24);
            CodeOperation codeOperation25 = new CodeOperation
            {
                TKod = 25,
                Operasyon = "PANİK BUTONUNA BASILDI"
            };
            context.CodeOperation.Add(codeOperation25);
            CodeOperation codeOperation26 = new CodeOperation
            {
                TKod = 26,
                Operasyon = "KULANICI ALARM-GEÇİŞ ÖNCESİ"
            };
            context.CodeOperation.Add(codeOperation26);
            CodeOperation codeOperation27 = new CodeOperation
            {
                TKod = 27,
                Operasyon = "KULANICI ALARM-GEÇİŞ SONRASI"
            };
            context.CodeOperation.Add(codeOperation27);
            CodeOperation codeOperation40 = new CodeOperation
            {
                TKod = 40,
                Operasyon = "MAVİ KOD BAŞLADI"
            };
            context.CodeOperation.Add(codeOperation40);
            CodeOperation codeOperation41 = new CodeOperation
            {
                TKod = 41,
                Operasyon = "MAVİ KOD SONLANDI"
            };
            context.CodeOperation.Add(codeOperation41);
            CodeOperation codeOperation42 = new CodeOperation
            {
                TKod = 42,
                Operasyon = "BEYAZ KOD BAŞLADI"
            };
            context.CodeOperation.Add(codeOperation42);
            CodeOperation codeOperation43 = new CodeOperation
            {
                TKod = 43,
                Operasyon = "BEYAZ KOD SONLANDI"
            };
            context.CodeOperation.Add(codeOperation43);
            CodeOperation codeOperation44 = new CodeOperation
            {
                TKod = 44,
                Operasyon = "PEMBE KOD BAŞLADI"
            };
            context.CodeOperation.Add(codeOperation44);
            CodeOperation codeOperation45 = new CodeOperation
            {
                TKod = 45,
                Operasyon = "PEMBE KOD SONLANDI"
            };
            context.CodeOperation.Add(codeOperation45);
            CodeOperation codeOperation46 = new CodeOperation
            {
                TKod = 46,
                Operasyon = "KIRMIZI KOD BAŞLADI"
            };
            context.CodeOperation.Add(codeOperation46);
            CodeOperation codeOperation47 = new CodeOperation
            {
                TKod = 47,
                Operasyon = "KIRMIZI KOD SONLANDI"
            };
            context.CodeOperation.Add(codeOperation47);
            CodeOperation codeOperation100 = new CodeOperation
            {
                TKod = 100,
                Operasyon = "KULLANICI EKLEME"
            };
            context.CodeOperation.Add(codeOperation100);
            CodeOperation codeOperation101 = new CodeOperation
            {
                TKod = 101,
                Operasyon = "KULLANICI İPTAL"
            };
            context.CodeOperation.Add(codeOperation101);
            CodeOperation codeOperation102 = new CodeOperation
            {
                TKod = 102,
                Operasyon = "KULLANICI GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation102);
            CodeOperation codeOperation103 = new CodeOperation
            {
                TKod = 103,
                Operasyon = "KULLANICI GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation103);
            CodeOperation codeOperation104 = new CodeOperation
            {
                TKod = 104,
                Operasyon = "KULLANICI ALMA"
            };
            context.CodeOperation.Add(codeOperation104);
            CodeOperation codeOperation105 = new CodeOperation
            {
                TKod = 105,
                Operasyon = "A.SAYAÇ SİLME"
            };
            context.CodeOperation.Add(codeOperation105);
            CodeOperation codeOperation106 = new CodeOperation
            {
                TKod = 106,
                Operasyon = "G.SAYAÇ SİLME"
            };
            context.CodeOperation.Add(codeOperation106);
            CodeOperation codeOperation110 = new CodeOperation
            {
                TKod = 110,
                Operasyon = "ZAMAN BÖLGESİ EKLEME"
            };
            context.CodeOperation.Add(codeOperation110);
            CodeOperation codeOperation111 = new CodeOperation
            {
                TKod = 111,
                Operasyon = "ZAMAN BÖLGESİ SİLME"
            };
            context.CodeOperation.Add(codeOperation111);
            CodeOperation codeOperation112 = new CodeOperation
            {
                TKod = 112,
                Operasyon = "ZAMAN BÖLGESİ GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation112);
            CodeOperation codeOperation113 = new CodeOperation
            {
                TKod = 113,
                Operasyon = "ZAMAN BÖLGESİ GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation113);
            CodeOperation codeOperation114 = new CodeOperation
            {
                TKod = 114,
                Operasyon = "ZAMAN BÖLGESİ ALMA"
            };
            context.CodeOperation.Add(codeOperation114);
            CodeOperation codeOperation120 = new CodeOperation
            {
                TKod = 120,
                Operasyon = "GEÇİŞ GRUP EKLEME"
            };
            context.CodeOperation.Add(codeOperation120);
            CodeOperation codeOperation121 = new CodeOperation
            {
                TKod = 121,
                Operasyon = "GEÇİŞ GRUP SİLME"
            };
            context.CodeOperation.Add(codeOperation121);
            CodeOperation codeOperation122 = new CodeOperation
            {
                TKod = 122,
                Operasyon = "GEÇİŞ GRUP GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation122);
            CodeOperation codeOperation123 = new CodeOperation
            {
                TKod = 123,
                Operasyon = "GEÇİŞ GRUP GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation123);
            CodeOperation codeOperation124 = new CodeOperation
            {
                TKod = 124,
                Operasyon = "GEÇİŞ GRUP ALMA"
            };
            context.CodeOperation.Add(codeOperation124);
            CodeOperation codeOperation125 = new CodeOperation
            {
                TKod = 125,
                Operasyon = "GRUP SAYAÇ OKUMA"
            };
            context.CodeOperation.Add(codeOperation125);
            CodeOperation codeOperation126 = new CodeOperation
            {
                TKod = 126,
                Operasyon = "GRUP SAYAÇ SİLME"
            };
            context.CodeOperation.Add(codeOperation126);
            CodeOperation codeOperation130 = new CodeOperation
            {
                TKod = 130,
                Operasyon = "PANEL TARAMA"
            };
            context.CodeOperation.Add(codeOperation130);
            CodeOperation codeOperation131 = new CodeOperation
            {
                TKod = 131,
                Operasyon = "PANEL LİSTESİ GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation131);
            CodeOperation codeOperation132 = new CodeOperation
            {
                TKod = 132,
                Operasyon = "PANEL SİLME"
            };
            context.CodeOperation.Add(codeOperation132);
            CodeOperation codeOperation133 = new CodeOperation
            {
                TKod = 133,
                Operasyon = "PANEL GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation133);
            CodeOperation codeOperation134 = new CodeOperation
            {
                TKod = 134,
                Operasyon = "PANEL AYAR GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation134);
            CodeOperation codeOperation135 = new CodeOperation
            {
                TKod = 135,
                Operasyon = "PANEL SAAT GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation135);
            CodeOperation codeOperation136 = new CodeOperation
            {
                TKod = 136,
                Operasyon = "PANEL SAAT ALMA"
            };
            context.CodeOperation.Add(codeOperation136);
            CodeOperation codeOperation137 = new CodeOperation
            {
                TKod = 137,
                Operasyon = "PANEL LPR KAMERA AYAR"
            };
            context.CodeOperation.Add(codeOperation137);
            CodeOperation codeOperation138 = new CodeOperation
            {
                TKod = 138,
                Operasyon = "PANEL HASTANE KOD AYAR"
            };
            context.CodeOperation.Add(codeOperation138);
            CodeOperation codeOperation140 = new CodeOperation
            {
                TKod = 140,
                Operasyon = "KULLANICI ALARM EKLEME"
            };
            context.CodeOperation.Add(codeOperation140);
            CodeOperation codeOperation141 = new CodeOperation
            {
                TKod = 141,
                Operasyon = "KULLANICI ALARM GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation141);
            CodeOperation codeOperation142 = new CodeOperation
            {
                TKod = 142,
                Operasyon = "KULLANICI ALARM SİLME"
            };
            context.CodeOperation.Add(codeOperation142);
            CodeOperation codeOperation143 = new CodeOperation
            {
                TKod = 143,
                Operasyon = "KULLANICI ALARM GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation143);
            CodeOperation codeOperation144 = new CodeOperation
            {
                TKod = 144,
                Operasyon = "KULLANICI ALARM ALMA"
            };
            context.CodeOperation.Add(codeOperation144);
            CodeOperation codeOperation150 = new CodeOperation
            {
                TKod = 150,
                Operasyon = "KAMERA EKLEME"
            };
            context.CodeOperation.Add(codeOperation150);
            CodeOperation codeOperation151 = new CodeOperation
            {
                TKod = 151,
                Operasyon = "KAMERA GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation151);
            CodeOperation codeOperation152 = new CodeOperation
            {
                TKod = 152,
                Operasyon = "KAMERA SİLME"
            };
            context.CodeOperation.Add(codeOperation152);
            CodeOperation codeOperation160 = new CodeOperation
            {
                TKod = 160,
                Operasyon = "ASANSÖR EKLEME"
            };
            context.CodeOperation.Add(codeOperation160);
            CodeOperation codeOperation161 = new CodeOperation
            {
                TKod = 161,
                Operasyon = "ASANSÖR GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation161);
            CodeOperation codeOperation162 = new CodeOperation
            {
                TKod = 162,
                Operasyon = "ASANSÖR SİLME"
            };
            context.CodeOperation.Add(codeOperation162);
            CodeOperation codeOperation163 = new CodeOperation
            {
                TKod = 163,
                Operasyon = "ASANSÖR GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation163);
            CodeOperation codeOperation164 = new CodeOperation
            {
                TKod = 164,
                Operasyon = "ASANSÖR ALMA"
            };
            context.CodeOperation.Add(codeOperation164);
            CodeOperation codeOperation170 = new CodeOperation
            {
                TKod = 170,
                Operasyon = "PROGRAMLI KAPI İŞLEMİ GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation170);
            CodeOperation codeOperation171 = new CodeOperation
            {
                TKod = 171,
                Operasyon = "PROGRAMLI KAPI İŞLEMİ GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation171);
            CodeOperation codeOperation172 = new CodeOperation
            {
                TKod = 172,
                Operasyon = "PROGRAMLI KAPI İŞLEMİ ALMA"
            };
            context.CodeOperation.Add(codeOperation172);
            CodeOperation codeOperation180 = new CodeOperation
            {
                TKod = 180,
                Operasyon = "ŞİRKET EKLEME"
            };
            context.CodeOperation.Add(codeOperation180);
            CodeOperation codeOperation181 = new CodeOperation
            {
                TKod = 181,
                Operasyon = "ŞİRKET GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation181);
            CodeOperation codeOperation182 = new CodeOperation
            {
                TKod = 182,
                Operasyon = "ŞİRKET SİLME"
            };
            context.CodeOperation.Add(codeOperation182);
            CodeOperation codeOperation190 = new CodeOperation
            {
                TKod = 190,
                Operasyon = "DEPARTMAN EKLEME"
            };
            context.CodeOperation.Add(codeOperation190);
            CodeOperation codeOperation191 = new CodeOperation
            {
                TKod = 191,
                Operasyon = "DEPARTMAN GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation191);
            CodeOperation codeOperation192 = new CodeOperation
            {
                TKod = 192,
                Operasyon = "DEPARTMAN SİLME"
            };
            context.CodeOperation.Add(codeOperation192);
            CodeOperation codeOperation200 = new CodeOperation
            {
                TKod = 200,
                Operasyon = "BLOK EKLEME"
            };
            context.CodeOperation.Add(codeOperation200);
            CodeOperation codeOperation201 = new CodeOperation
            {
                TKod = 201,
                Operasyon = "BLOK GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation201);
            CodeOperation codeOperation202 = new CodeOperation
            {
                TKod = 202,
                Operasyon = "BLOK SİLME"
            };
            context.CodeOperation.Add(codeOperation202);
            CodeOperation codeOperation210 = new CodeOperation
            {
                TKod = 210,
                Operasyon = "DIŞ VERİ AL GRUPLAR"
            };
            context.CodeOperation.Add(codeOperation210);
            CodeOperation codeOperation211 = new CodeOperation
            {
                TKod = 211,
                Operasyon = "DIŞ VERİ AL KULLANICILAR"
            };
            context.CodeOperation.Add(codeOperation211);
            CodeOperation codeOperation220 = new CodeOperation
            {
                TKod = 220,
                Operasyon = "E-MAIL AYARLARI GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation220);
            CodeOperation codeOperation221 = new CodeOperation
            {
                TKod = 221,
                Operasyon = "SMS AYARLARI GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation221);
            CodeOperation codeOperation230 = new CodeOperation
            {
                TKod = 230,
                Operasyon = "YENİ OPERATÖR EKLEME"
            };
            context.CodeOperation.Add(codeOperation230);
            CodeOperation codeOperation231 = new CodeOperation
            {
                TKod = 231,
                Operasyon = "OPERATÖR SİLME"
            };
            context.CodeOperation.Add(codeOperation231);
            CodeOperation codeOperation232 = new CodeOperation
            {
                TKod = 232,
                Operasyon = "OPERATÖR GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation232);
            CodeOperation codeOperation240 = new CodeOperation
            {
                TKod = 240,
                Operasyon = "GLOBAL INTERLOCK GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation240);
            CodeOperation codeOperation241 = new CodeOperation
            {
                TKod = 241,
                Operasyon = "GLOBAL INTERLOCK GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation241);
            CodeOperation codeOperation242 = new CodeOperation
            {
                TKod = 242,
                Operasyon = "GLOBAL INTERLOCK ALMA"
            };
            context.CodeOperation.Add(codeOperation242);
            CodeOperation codeOperation243 = new CodeOperation
            {
                TKod = 243,
                Operasyon = "GLOBAL INTERLOCK SAYAÇ SIFIRLAMA"
            };
            context.CodeOperation.Add(codeOperation243);
            CodeOperation codeOperation250 = new CodeOperation
            {
                TKod = 250,
                Operasyon = "GEÇİŞ GRUP TAKVİMİ EKLEME"
            };
            context.CodeOperation.Add(codeOperation250);
            CodeOperation codeOperation251 = new CodeOperation
            {
                TKod = 251,
                Operasyon = "GEÇİŞ GRUP TAKVİMİ GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation251);
            CodeOperation codeOperation252 = new CodeOperation
            {
                TKod = 252,
                Operasyon = "GEÇİŞ GRUP TAKVİMİ SİLME"
            };
            context.CodeOperation.Add(codeOperation252);
            CodeOperation codeOperation253 = new CodeOperation
            {
                TKod = 253,
                Operasyon = "GEÇİŞ GRUP TAKVİMİ GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation253);
            CodeOperation codeOperation254 = new CodeOperation
            {
                TKod = 254,
                Operasyon = "GEÇİŞ GRUP TAKVİMİ ALMA"
            };
            context.CodeOperation.Add(codeOperation254);
            CodeOperation codeOperation260 = new CodeOperation
            {
                TKod = 260,
                Operasyon = "CANLI İZLEME AYAR GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation260);
            CodeOperation codeOperation270 = new CodeOperation
            {
                TKod = 270,
                Operasyon = "PERSONEL LİSTESİ RAPORU"
            };
            context.CodeOperation.Add(codeOperation270);
            CodeOperation codeOperation271 = new CodeOperation
            {
                TKod = 271,
                Operasyon = "Personel Geçiş Raporu"
            };
            context.CodeOperation.Add(codeOperation271);
            CodeOperation codeOperation272 = new CodeOperation
            {
                TKod = 272,
                Operasyon = "Ziyaretçi Geçiş Raporu"
            };
            context.CodeOperation.Add(codeOperation272);
            CodeOperation codeOperation273 = new CodeOperation
            {
                TKod = 273,
                Operasyon = "İÇERDE-DIŞARDA RAPORU"
            };
            context.CodeOperation.Add(codeOperation273);
            CodeOperation codeOperation274 = new CodeOperation
            {
                TKod = 274,
                Operasyon = "GELEN-GELMEYEN RAPORU"
            };
            context.CodeOperation.Add(codeOperation274);
            CodeOperation codeOperation275 = new CodeOperation
            {
                TKod = 275,
                Operasyon = "TOPLAM ÇALIŞMA SÜRESİ RAPORU"
            };
            context.CodeOperation.Add(codeOperation275);
            CodeOperation codeOperation276 = new CodeOperation
            {
                TKod = 276,
                Operasyon = "ILK GİRİŞ-SON ÇIKIŞ RAPORU"
            };
            context.CodeOperation.Add(codeOperation276);
            CodeOperation codeOperation277 = new CodeOperation
            {
                TKod = 277,
                Operasyon = "PASİF PERSONEL RAPORU"
            };
            context.CodeOperation.Add(codeOperation277);
            CodeOperation codeOperation278 = new CodeOperation
            {
                TKod = 278,
                Operasyon = "Diğer Raporlar"
            };
            context.CodeOperation.Add(codeOperation278);
            CodeOperation codeOperation279 = new CodeOperation
            {
                TKod = 279,
                Operasyon = "Tanımsız Kullanıcı Raporu"
            };
            context.CodeOperation.Add(codeOperation279);
            CodeOperation codeOperation300 = new CodeOperation
            {
                TKod = 300,
                Operasyon = "DATABASE YEDEKLEME PERİYOT DEĞİŞİMİ"
            };
            context.CodeOperation.Add(codeOperation300);
            CodeOperation codeOperation301 = new CodeOperation
            {
                TKod = 301,
                Operasyon = "DATABASE YEDEKLEME KLASÖR DEĞİŞİMİ"
            };
            context.CodeOperation.Add(codeOperation301);
            CodeOperation codeOperation302 = new CodeOperation
            {
                TKod = 302,
                Operasyon = "OTOMATİK DATABASE YEDEKLEME"
            };
            context.CodeOperation.Add(codeOperation302);
            CodeOperation codeOperation303 = new CodeOperation
            {
                TKod = 303,
                Operasyon = "MANUEL DATABASE YEDEKLEME"
            };
            context.CodeOperation.Add(codeOperation303);
            CodeOperation codeOperation304 = new CodeOperation
            {
                TKod = 304,
                Operasyon = "GEÇİŞ VERİLERİ TABLOSU SİLİNDİ"
            };
            context.CodeOperation.Add(codeOperation304);
            CodeOperation codeOperation310 = new CodeOperation
            {
                TKod = 310,
                Operasyon = "OFFLINE LOG SAYISI OKUNDU"
            };
            context.CodeOperation.Add(codeOperation310);
            CodeOperation codeOperation311 = new CodeOperation
            {
                TKod = 311,
                Operasyon = "OFFLINE LOGLARI ALMA"
            };
            context.CodeOperation.Add(codeOperation311);
            CodeOperation codeOperation312 = new CodeOperation
            {
                TKod = 312,
                Operasyon = "PANEL LOG HAFIZASINI SİLME"
            };
            context.CodeOperation.Add(codeOperation312);
            CodeOperation codeOperation320 = new CodeOperation
            {
                TKod = 320,
                Operasyon = "ZİYARETÇİ EKLEME"
            };
            context.CodeOperation.Add(codeOperation320);
            CodeOperation codeOperation321 = new CodeOperation
            {
                TKod = 321,
                Operasyon = "ZİYARETÇİ GÜNCELLEME"
            };
            context.CodeOperation.Add(codeOperation321);
            CodeOperation codeOperation322 = new CodeOperation
            {
                TKod = 322,
                Operasyon = "ZİYARETÇİ SİLME"
            };
            context.CodeOperation.Add(codeOperation322);
            CodeOperation codeOperation323 = new CodeOperation
            {
                TKod = 323,
                Operasyon = "ZİYARETÇİ GÖNDERME"
            };
            context.CodeOperation.Add(codeOperation323);

            DBRoles dBRoles1 = new DBRoles
            {
                Yetki_Tipi = 1,
                Yetki_Adi = "Tam Yetkili"
            };
            DBRoles dBRoles2 = new DBRoles
            {
                Yetki_Tipi = 2,
                Yetki_Adi = "Sadece İzleme"
            };
            DBRoles dBRoles3 = new DBRoles
            {
                Yetki_Tipi = 3,
                Yetki_Adi = "Yetkisiz"
            };
            context.DBRoles.Add(dBRoles1);
            context.DBRoles.Add(dBRoles2);
            context.DBRoles.Add(dBRoles3);
            DBUsersPanels dBUsersPanels = new DBUsersPanels
            {
                Panel_No = 1,
                Kullanici_Adi = "admin"
            };
            context.DBUsersPanels.Add(dBUsersPanels);
            DBUsersSirket dBUsersSirket = new DBUsersSirket
            {
                Sirket_No = 1,
                Kullanici_Adi = "admin"
            };
            context.DBUsersSirket.Add(dBUsersSirket);

            for (int i = 1; i < 129; i++)
            {
                FloorNames floorNames = new FloorNames
                {
                    Kat_No = i,
                    Kat_Adi = "Kat " + (i)
                };
                context.FloorNames.Add(floorNames);
            }
            for (int i = 1; i < 1000; i++)
            {
                GlobalZones globalZones = new GlobalZones
                {
                    Global_Bolge_No = i,
                    Global_Bolge_Adi = "Bölge " + (i)
                };
                context.GlobalZones.Add(globalZones);
            }

            GlobalZonesInterlock globalZonesInterlock1 = new GlobalZonesInterlock
            {
                Pair_No = 1,
                Global_Zone_1 = 1,
                Global_Zone_2 = 2
            };
            GlobalZonesInterlock globalZonesInterlock2 = new GlobalZonesInterlock
            {
                Pair_No = 2,
                Global_Zone_1 = 3,
                Global_Zone_2 = 4
            };
            GlobalZonesInterlock globalZonesInterlock3 = new GlobalZonesInterlock
            {
                Pair_No = 3,
                Global_Zone_1 = 5,
                Global_Zone_2 = 6
            };
            GlobalZonesInterlock globalZonesInterlock4 = new GlobalZonesInterlock
            {
                Pair_No = 4,
                Global_Zone_1 = 7,
                Global_Zone_2 = 8
            };
            context.GlobalZonesInterlock.Add(globalZonesInterlock1);
            context.GlobalZonesInterlock.Add(globalZonesInterlock2);
            context.GlobalZonesInterlock.Add(globalZonesInterlock3);
            context.GlobalZonesInterlock.Add(globalZonesInterlock4);

            for (int i = 1; i < 129; i++)
            {
                PanelSettings panelSettings = new PanelSettings
                {
                    Seri_No = 0,
                    Sira_No = i,
                    Panel_ID = 0,
                    Panel_Name = "",
                    Panel_Model = null,
                    Panel_Expansion = null,
                    Panel_Expansion_2 = null,
                    Kontrol_Modu = 0,
                    Lokal_APB = null,
                    Lokal_APB1 = false,
                    Lokal_APB2 = false,
                    Lokal_APB3 = false,
                    Lokal_APB4 = false,
                    Lokal_APB5 = false,
                    Lokal_APB6 = false,
                    Lokal_APB7 = false,
                    Lokal_APB8 = false,
                    Global_APB = false,
                    Global_Bolge_No = null,
                    Global_Capacity_Control = false,
                    Global_Access_Count_Control = false,
                    Global_MaxIn_Count_Control = false,
                    Global_Sequental_Access_Control = null,
                    Panel_Same_Tag_Block = null,
                    Panel_Same_Tag_Block_Type = null,
                    Panel_Same_Tag_Block_HourMinSec = null,
                    Status_Data_Update = null,
                    Status_Data_Update_Type = null,
                    Status_Data_Update_Time = null,
                    Panel_M1_Role = 0,
                    Panel_M2_Role = 0,
                    Panel_M3_Role = 0,
                    Panel_M4_Role = 0,
                    Panel_M5_Role = 0,
                    Panel_M6_Role = 0,
                    Panel_M7_Role = 0,
                    Panel_M8_Role = 0,
                    Panel_Alarm_Role = 0,
                    Panel_Alarm_Mode_Role_Ok = false,
                    Panel_Alarm_Mode = false,
                    Panel_Fire_Mode_Role_Ok = false,
                    Panel_Fire_Mode = false,
                    Panel_Door_Alarm_Role_Ok = null,
                    Panel_Alarm_Broadcast_Ok = null,
                    Panel_Fire_Broadcast_Ok = null,
                    Panel_Door_Alarm_Broadcast_Ok = null,
                    Panel_Global_Bolge1 = 1,
                    Panel_Global_Bolge2 = 1,
                    Panel_Global_Bolge3 = 1,
                    Panel_Global_Bolge4 = 1,
                    Panel_Global_Bolge5 = 1,
                    Panel_Global_Bolge6 = 1,
                    Panel_Global_Bolge7 = 1,
                    Panel_Global_Bolge8 = 1,
                    Panel_Local_Capacity1 = false,
                    Panel_Local_Capacity_Clear1 = false,
                    Panel_Local_Capacity_Value1 = 0,
                    Panel_Local_Capacity2 = false,
                    Panel_Local_Capacity_Clear2 = false,
                    Panel_Local_Capacity_Value2 = 0,
                    Panel_Local_Capacity3 = false,
                    Panel_Local_Capacity_Clear3 = false,
                    Panel_Local_Capacity_Value3 = 0,
                    Panel_Local_Capacity4 = false,
                    Panel_Local_Capacity_Clear4 = false,
                    Panel_Local_Capacity_Value4 = 0,
                    Panel_Local_Capacity5 = false,
                    Panel_Local_Capacity_Clear5 = false,
                    Panel_Local_Capacity_Value5 = 0,
                    Panel_Local_Capacity6 = false,
                    Panel_Local_Capacity_Clear6 = false,
                    Panel_Local_Capacity_Value6 = 0,
                    Panel_Local_Capacity7 = false,
                    Panel_Local_Capacity_Clear7 = false,
                    Panel_Local_Capacity_Value7 = 0,
                    Panel_Local_Capacity8 = false,
                    Panel_Local_Capacity_Clear8 = false,
                    Panel_Local_Capacity_Value8 = 0,
                    Panel_GW1 = 0,
                    Panel_GW2 = 0,
                    Panel_GW3 = 0,
                    Panel_GW4 = 0,
                    Panel_IP1 = 0,
                    Panel_IP2 = 0,
                    Panel_IP3 = 0,
                    Panel_IP4 = 0,
                    Panel_TCP_Port = 0,
                    Panel_Subnet1 = 0,
                    Panel_Subnet2 = 0,
                    Panel_Subnet3 = 0,
                    Panel_Subnet4 = 0,
                    Panel_Remote_IP1 = null,
                    Panel_Remote_IP2 = null,
                    Panel_Remote_IP3 = null,
                    Panel_Remote_IP4 = null,
                    Lift_Capacity = null,
                    Interlock_Active = null,
                    Same_Door_Multiple_Reader = null,
                    Global_Zone_Interlock_Active = null,
                    Panel_Button_Detector = null,
                    Panel_Button_Detector_Time = null,
                    Offline_Blocked_Request = null,
                    Offline_Antipassback = null,
                    Offline_Button_Triggering = null,
                    Offline_Manuel_Operations = null,
                    Offline_Scheduled_Transactions = null,
                    Offline_Undefined_Transition = null,
                    LocalInterlock_G1_1 = null,
                    LocalInterlock_G1_2 = null,
                    LocalInterlock_G2_1 = null,
                    LocalInterlock_G2_2 = null,
                    LocalInterlock_G3_1 = null,
                    LocalInterlock_G3_2 = null,
                    LocalInterlock_G4_1 = null,
                    LocalInterlock_G4_2 = null,
                    DHCP_Enabled = false,
                    Hastane_Aktif = false,
                    Hastane_IP1 = 192,
                    Hastane_IP2 = 168,
                    Hastane_IP3 = 2,
                    Hastane_IP4 = 1,
                    Hastane_Server_TCP_Port = 2112,
                    Hastane_Lokal_TCP_Port = 5950,
                    Hastane_Acil_Durum_Yesil_Kod = true,
                    Hastane_Yesil_Kod_Suresi = 30
                };
                context.PanelSettings.Add(panelSettings);
            }

            for (int i = 1; i < 100; i++)
            {
                RawGroups rawGroups = new RawGroups
                {
                    Grup_No = i,
                    Grup_Adi = "Grup " + (i)
                };
                context.RawGroups.Add(rawGroups);
            }

            StatusCode statusCode1 = new StatusCode
            {
                Durum_Kodu = 1,
                Durum_Adi = "Beklemede"
            };
            StatusCode statusCode2 = new StatusCode
            {
                Durum_Kodu = 2,
                Durum_Adi = "Tamamlandı"
            };
            StatusCode statusCode3 = new StatusCode
            {
                Durum_Kodu = 3,
                Durum_Adi = "Hata"
            };
            StatusCode statusCode4 = new StatusCode
            {
                Durum_Kodu = 4,
                Durum_Adi = "Zaman Aşımı"
            };
            context.StatusCodes.Add(statusCode1);
            context.StatusCodes.Add(statusCode2);
            context.StatusCodes.Add(statusCode3);
            context.StatusCodes.Add(statusCode4);

            TimeZoneIDs timeZoneIDs0 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 0,
                Adi = "Sınırlama Yok"
            };
            TimeZoneIDs timeZoneIDs1 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 1,
                Adi = "İki Tarih Arası Geçiş"
            };
            TimeZoneIDs timeZoneIDs2 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 2,
                Adi = "İki Tarih Arası Yasak"
            };
            TimeZoneIDs timeZoneIDs3 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 3,
                Adi = "İki Saat Arası Geçiş"
            };
            TimeZoneIDs timeZoneIDs4 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 4,
                Adi = "İki Saat Arası Yasak"
            };
            TimeZoneIDs timeZoneIDs5 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 5,
                Adi = "Haftalık Plan"
            };
            TimeZoneIDs timeZoneIDs6 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 6,
                Adi = "Aylık Plan"
            };
            TimeZoneIDs timeZoneIDs7 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 7,
                Adi = "Geçiş Yasak"
            };
            TimeZoneIDs timeZoneIDs8 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 8,
                Adi = "Çoklu Saat Geçiş"
            };
            TimeZoneIDs timeZoneIDs9 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 9,
                Adi = "Çoklu Saat Yasak"
            };
            TimeZoneIDs timeZoneIDs11 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 11,
                Adi = "Altılı Saat Geçiş"
            };
            TimeZoneIDs timeZoneIDs12 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 12,
                Adi = "Altılı Saat Yasak"
            };
            TimeZoneIDs timeZoneIDs13 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 13,
                Adi = "Haftalık Plan + Her Gün Ayrı Saat Sınırı"
            };
            TimeZoneIDs timeZoneIDs14 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 14,
                Adi = "İkili Saat Geçiş + Her Gün Ayrı"
            };
            TimeZoneIDs timeZoneIDs15 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 15,
                Adi = "İkili Saat Yasak + Her Gün Ayrı"
            };
            TimeZoneIDs timeZoneIDs18 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 18,
                Adi = "İki Tarih-Saat Arası Geçiş"
            };
            TimeZoneIDs timeZoneIDs19 = new TimeZoneIDs
            {
                Gecis_Sinirlama_Tipi = 19,
                Adi = "İki Tarih-Saat Arası Yasak"
            };
            context.TimeZoneIDs.Add(timeZoneIDs0);
            context.TimeZoneIDs.Add(timeZoneIDs1);
            context.TimeZoneIDs.Add(timeZoneIDs2);
            context.TimeZoneIDs.Add(timeZoneIDs3);
            context.TimeZoneIDs.Add(timeZoneIDs4);
            context.TimeZoneIDs.Add(timeZoneIDs5);
            context.TimeZoneIDs.Add(timeZoneIDs6);
            context.TimeZoneIDs.Add(timeZoneIDs7);
            context.TimeZoneIDs.Add(timeZoneIDs8);
            context.TimeZoneIDs.Add(timeZoneIDs9);
            context.TimeZoneIDs.Add(timeZoneIDs11);
            context.TimeZoneIDs.Add(timeZoneIDs12);
            context.TimeZoneIDs.Add(timeZoneIDs13);
            context.TimeZoneIDs.Add(timeZoneIDs14);
            context.TimeZoneIDs.Add(timeZoneIDs15);
            context.TimeZoneIDs.Add(timeZoneIDs18);
            context.TimeZoneIDs.Add(timeZoneIDs19);

            UserTypes personel = new UserTypes
            {
                Kullanici_Tipi = 0,
                Ad = "Personel"
            };
            UserTypes ziyaretci = new UserTypes
            {
                Kullanici_Tipi = 1,
                Ad = "Ziyaretçi"
            };
            context.UserTypes.Add(personel);
            context.UserTypes.Add(ziyaretci);

            for (int i = 1; i < 129; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    int saat1 = 5;
                    int saat2 = 6;
                    for (int k = 1; k < 17; k++)
                    {
                        ProgRelay2 progRelay2 = new ProgRelay2
                        {
                            Saat_1 = new DateTime(2019, 11, 25, saat1, 1, 00),
                            Saat_2 = new DateTime(2019, 11, 25, saat2, 0, 00),
                            Panel_No = i,
                            Haftanin_Gunu = j,
                            Zaman_Dilimi = k,
                            Aktif = false,
                            Cihaz_1 = false,
                            Cihaz_2 = false,
                            Cihaz_3 = false,
                            Cihaz_4 = false,
                            Cihaz_5 = false,
                            Cihaz_6 = false,
                            Cihaz_7 = false,
                            Cihaz_8 = false,
                            Role_1 = false,
                            Role_2 = false,
                            Role_3 = false,
                            Role_4 = false,
                            Role_5 = false,
                            Role_6 = false,
                            Role_7 = false,
                            Role_8 = false,
                            Role_9 = false,
                            Role_10 = false,
                            Role_11 = false,
                            Role_12 = false,
                            Role_13 = false,
                            Role_14 = false,
                            Role_15 = false,
                            Role_16 = false,
                            Durum_1 = false,
                            Durum_2 = false,
                            Durum_3 = false,
                            Durum_4 = false,
                            Durum_5 = false,
                            Durum_6 = false,
                            Durum_7 = false,
                            Durum_8 = false,
                            Durum_9 = false,
                            Durum_10 = false,
                            Durum_11 = false,
                            Durum_12 = false,
                            Durum_13 = false,
                            Durum_14 = false,
                            Durum_15 = false,
                            Durum_16 = false,
                        };
                        saat1++;
                        saat2++;
                        context.ProgRelay2.Add(progRelay2);
                    }
                }
            }


            TaskCode taskCode1 = new TaskCode
            {
                Gorev_Kodu = 1,
                Gorev_Adi = "Ağdaki Panellerin Taranması"
            };
            context.TaskCodes.Add(taskCode1);
            TaskCode taskCode2 = new TaskCode
            {
                Gorev_Kodu = 2,
                Gorev_Adi = "Ayarlarının Alınması"
            };
            context.TaskCodes.Add(taskCode2);
            TaskCode taskCode2760 = new TaskCode
            {
                Gorev_Kodu = 2760,
                Gorev_Adi = "Panel Ayarlarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2760);
            TaskCode taskCode2600 = new TaskCode
            {
                Gorev_Kodu = 2600,
                Gorev_Adi = "Zaman Bölgelerinin Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2600);
            TaskCode taskCode2603 = new TaskCode
            {
                Gorev_Kodu = 2603,
                Gorev_Adi = "Zaman Bölgelerinin Alınması"
            };
            context.TaskCodes.Add(taskCode2603);
            TaskCode taskCode2610 = new TaskCode
            {
                Gorev_Kodu = 2610,
                Gorev_Adi = "Geçiş Gruplarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2610);
            TaskCode taskCode2612 = new TaskCode
            {
                Gorev_Kodu = 2612,
                Gorev_Adi = "Geçiş Gruplarının Alınması"
            };
            context.TaskCodes.Add(taskCode2612);
            TaskCode taskCode2620 = new TaskCode
            {
                Gorev_Kodu = 2620,
                Gorev_Adi = "Stand-Alone Kullanıcı Hafızasına Kullanıcı Bilgisi Gönderme (V5.10 Firmware)"
            };
            context.TaskCodes.Add(taskCode2620);
            TaskCode taskCode26200 = new TaskCode
            {
                Gorev_Kodu = 2620,
                Gorev_Adi = "Stand-Alone Kullanıcı Hafızasına Kullanıcı Bilgisi Gönderme (V5.11 ve Üzeri Firmware)"
            };
            context.TaskCodes.Add(taskCode26200);
            TaskCode taskCode2624 = new TaskCode
            {
                Gorev_Kodu = 2624,
                Gorev_Adi = "Stand-Alone Kart Hafızasından Kullanıcı Bilgisi Alma (V5.10 Firmware)"
            };
            context.TaskCodes.Add(taskCode2624);
            TaskCode taskCode26244 = new TaskCode
            {
                Gorev_Kodu = 2624,
                Gorev_Adi = "Stand-Alone Kart Hafızasından Kullanıcı Bilgisi Alma (V5.11 ve Üzeri Firmware)"
            };
            context.TaskCodes.Add(taskCode26244);
            TaskCode taskCode2660 = new TaskCode
            {
                Gorev_Kodu = 2660,
                Gorev_Adi = "Geçiş Grup Takvimi Ayarlarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2660);
            TaskCode taskCode2628 = new TaskCode
            {
                Gorev_Kodu = 2628,
                Gorev_Adi = "Stand-Alone Kart Hafızasından Belirli Bir Kartı Silme"
            };
            context.TaskCodes.Add(taskCode2628);
            TaskCode taskCode26288 = new TaskCode
            {
                Gorev_Kodu = 2629,
                Gorev_Adi = "Stand-Alone Kullanıcı Hafızasının Tamamını Silme"
            };
            context.TaskCodes.Add(taskCode26288);
            TaskCode taskCode2740 = new TaskCode
            {
                Gorev_Kodu = 2740,
                Gorev_Adi = "Stand-Alone Geçiş Olay Hafızası Olay Sayısını Okuma"
            };
            context.TaskCodes.Add(taskCode2740);
            TaskCode taskCode2742 = new TaskCode
            {
                Gorev_Kodu = 2742,
                Gorev_Adi = "Stand Alone Geçiş Olay Hafızasının PC’ye Aktarılması"
            };
            context.TaskCodes.Add(taskCode2742);
            TaskCode taskCode2741 = new TaskCode
            {
                Gorev_Kodu = 2741,
                Gorev_Adi = "Stand-Alone Geçiş Olay Hafızasının Silinmesi"
            };
            context.TaskCodes.Add(taskCode2741);
            TaskCode taskCode2680 = new TaskCode
            {
                Gorev_Kodu = 2680,
                Gorev_Adi = "Belirli Bir Geçiş Grubu İçin İçerdeki Kişi/Araç Sayısının Okunması"
            };
            context.TaskCodes.Add(taskCode2680);
            TaskCode taskCode2701 = new TaskCode
            {
                Gorev_Kodu = 2701,
                Gorev_Adi = "Geçiş Grubu İçin İçerdeki Araç Sayısının Silinmesi"
            };
            context.TaskCodes.Add(taskCode2701);
            TaskCode taskCode2702 = new TaskCode
            {
                Gorev_Kodu = 2702,
                Gorev_Adi = "Tüm Geçiş Grupları İçin İçerdeki Araç Sayısının Silinmesi"
            };
            context.TaskCodes.Add(taskCode2702);
            TaskCode taskCode2700 = new TaskCode
            {
                Gorev_Kodu = 2700,
                Gorev_Adi = "Stand-Alone Kullanıcı Geçiş Sayaç Hafızasının Okunması"
            };
            context.TaskCodes.Add(taskCode2700);
            TaskCode taskCode2615 = new TaskCode
            {
                Gorev_Kodu = 2615,
                Gorev_Adi = "Stand-Alone Kullanıcı Geçiş Grupları Hafızasının Silinmesi (Tüm Hafıza)"
            };
            context.TaskCodes.Add(taskCode2615);
            TaskCode taskCode2614 = new TaskCode
            {
                Gorev_Kodu = 2614,
                Gorev_Adi = "Stand-Alone Kullanıcı Geçiş Sayaç Hafızasının Silinmesi (Tek Personel)"
            };
            context.TaskCodes.Add(taskCode2614);
            TaskCode taskCode2711 = new TaskCode
            {
                Gorev_Kodu = 2711,
                Gorev_Adi = "Stand-Alone Kullanıcı Antipassback Resetleme (Tüm Kullanıcılar İçin)"
            };
            context.TaskCodes.Add(taskCode2711);
            TaskCode taskCode2710 = new TaskCode
            {
                Gorev_Kodu = 2710,
                Gorev_Adi = "Stand-Alone Kullanıcı Antipassback Resetleme (Tek Personel)"
            };
            context.TaskCodes.Add(taskCode2710);
            TaskCode taskCode2730 = new TaskCode
            {
                Gorev_Kodu = 2730,
                Gorev_Adi = "Cihaz Saatinin Güncellenmesi"
            };
            context.TaskCodes.Add(taskCode2730);
            TaskCode taskCode2731 = new TaskCode
            {
                Gorev_Kodu = 2731,
                Gorev_Adi = "Cihaz Saatinin Okunması"
            };
            context.TaskCodes.Add(taskCode2731);
            TaskCode taskCode2770 = new TaskCode
            {
                Gorev_Kodu = 2770,
                Gorev_Adi = "Panel Rölelerinin Tetiklenmesi"
            };
            context.TaskCodes.Add(taskCode2770);
            TaskCode taskCode2771 = new TaskCode
            {
                Gorev_Kodu = 2771,
                Gorev_Adi = "Panel Rölelerinin Açılması (Sürekli Açık)"
            };
            context.TaskCodes.Add(taskCode2771);
            TaskCode taskCode2772 = new TaskCode
            {
                Gorev_Kodu = 2772,
                Gorev_Adi = "Panel Rölelerinin Kapanması (Sürekli Kapalı)"
            };
            context.TaskCodes.Add(taskCode2772);
            TaskCode taskCode2720 = new TaskCode
            {
                Gorev_Kodu = 2720,
                Gorev_Adi = "Panel Rölelerinin Röle Takvimini Ayarlama"
            };
            context.TaskCodes.Add(taskCode2720);
            TaskCode taskCode2721 = new TaskCode
            {
                Gorev_Kodu = 2721,
                Gorev_Adi = "Panel Rölelerinin Röle Takvimini Okuma"
            };
            context.TaskCodes.Add(taskCode2721);
            TaskCode taskCode33 = new TaskCode
            {
                Gorev_Kodu = 33,
                Gorev_Adi = "Kapı Durumlarının ve Anlık Geçişlerin İzlenmesi (Online İzleme)"
            };
            context.TaskCodes.Add(taskCode33);
            TaskCode taskCode34 = new TaskCode
            {
                Gorev_Kodu = 34,
                Gorev_Adi = "Online Mod Çalışma"
            };
            context.TaskCodes.Add(taskCode34);
            TaskCode taskCode2672 = new TaskCode
            {
                Gorev_Kodu = 2672,
                Gorev_Adi = "Panel Anlık Kapasite Sayacının Okunması"
            };
            context.TaskCodes.Add(taskCode2672);
            TaskCode taskCode2670 = new TaskCode
            {
                Gorev_Kodu = 2670,
                Gorev_Adi = "Panel Anlık Kapasite Sayacının Değiştirilmesi veya Silinmesi"
            };
            context.TaskCodes.Add(taskCode2670);
            TaskCode taskCode2630 = new TaskCode
            {
                Gorev_Kodu = 2630,
                Gorev_Adi = "Stand-Alone Kullanıcı Hafızası Maksimum Kullanıcı No’sunu Gönderme"
            };
            context.TaskCodes.Add(taskCode2630);
            TaskCode taskCode2743 = new TaskCode
            {
                Gorev_Kodu = 2743,
                Gorev_Adi = "Olay Hafızası Ayarlarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2743);
            TaskCode taskCode2744 = new TaskCode
            {
                Gorev_Kodu = 2744,
                Gorev_Adi = "Olay Hafızası Ayarlarının Alınması"
            };
            context.TaskCodes.Add(taskCode2744);
            TaskCode taskCode2640 = new TaskCode
            {
                Gorev_Kodu = 2640,
                Gorev_Adi = "Asansör Gruplarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2640);
            TaskCode taskCode2642 = new TaskCode
            {
                Gorev_Kodu = 2642,
                Gorev_Adi = "Asansör Gruplarının Alınması"
            };
            context.TaskCodes.Add(taskCode2642);
            TaskCode taskCode2644 = new TaskCode
            {
                Gorev_Kodu = 2644,
                Gorev_Adi = "Asansör Gruplarının Silinmesi(Tek)"
            };
            context.TaskCodes.Add(taskCode2644);
            TaskCode taskCode2645 = new TaskCode
            {
                Gorev_Kodu = 2645,
                Gorev_Adi = "Asansör Gruplarının Silinmesi(Tümü)"
            };
            context.TaskCodes.Add(taskCode2645);
            TaskCode taskCode2650 = new TaskCode
            {
                Gorev_Kodu = 2650,
                Gorev_Adi = "Kullanıcı Alarmlarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode2650);
            TaskCode taskCode2652 = new TaskCode
            {
                Gorev_Kodu = 2652,
                Gorev_Adi = "Kullanıcı Alarmlarının Alınması"
            };
            context.TaskCodes.Add(taskCode2652);
            TaskCode taskCode2654 = new TaskCode
            {
                Gorev_Kodu = 2654,
                Gorev_Adi = "Kullanıcı Alarmlarının Silinmesi"
            };
            context.TaskCodes.Add(taskCode2654);
            TaskCode taskCode2656 = new TaskCode
            {
                Gorev_Kodu = 2656,
                Gorev_Adi = "Panel Hırsız Alarm ve Yangın Alarm Durumlarının Silinmesi"
            };
            context.TaskCodes.Add(taskCode2656);
            TaskCode taskCode2657 = new TaskCode
            {
                Gorev_Kodu = 2657,
                Gorev_Adi = "Panel Kapı Alarm Durumlarının Silinmesi"
            };
            context.TaskCodes.Add(taskCode2657);
            TaskCode taskCode48 = new TaskCode
            {
                Gorev_Kodu = 48,
                Gorev_Adi = "Lokal Interlock Kapı Sensör Çiftleri Ayarlarının Gönderilmesi"
            };
            context.TaskCodes.Add(taskCode48);
            TaskCode taskCode49 = new TaskCode
            {
                Gorev_Kodu = 49,
                Gorev_Adi = "Lokal Interlock Kapı Sensör Çiftleri Ayarlarının Alınması"
            };
            context.TaskCodes.Add(taskCode49);
            TaskCode taskCode50 = new TaskCode
            {
                Gorev_Kodu = 50,
                Gorev_Adi = "Global Kapı Bölgeleri Interlock Ayarlarının Gönderilmesi (Global Kapı Bölge Çiftleri)"
            };
            context.TaskCodes.Add(taskCode50);
            TaskCode taskCode51 = new TaskCode
            {
                Gorev_Kodu = 51,
                Gorev_Adi = "Global Kapı Bölgeleri Interlock Ayarlarının Alınması  (Global Kapı Bölge Çiftleri)"
            };
            context.TaskCodes.Add(taskCode51);
            TaskCode taskCode262000 = new TaskCode
            {
                Gorev_Kodu = 2620,
                Gorev_Adi = "Kullanıcıları Gönderme"
            };
            context.TaskCodes.Add(taskCode262000);
            TaskCode taskCode262200 = new TaskCode
            {
                Gorev_Kodu = 2622,
                Gorev_Adi = "Tüm Kullanıcıları Gönderme"
            };
            context.TaskCodes.Add(taskCode262200);
            TaskCode taskCode2761 = new TaskCode
            {
                Gorev_Kodu = 2761,
                Gorev_Adi = "Panel Ayarlarının Alınması"
            };
            context.TaskCodes.Add(taskCode2761);
            TaskCode taskCode2605 = new TaskCode
            {
                Gorev_Kodu = 2605,
                Gorev_Adi = "Zaman Gruplarının Silinmesi(Tümü)"
            };
            context.TaskCodes.Add(taskCode2605);
            EMailSetting eMailSetting = new EMailSetting
            {
                E_Mail_Adres = "sample@abcd.com",
                Kullanici_Adi = "Fora Teknoloji",
                Sifre = "12345",
                SMPT_Server = "smtp.gmail.com",
                SMPT_Server_Port = 587,
                SSL_Kullan = true,
                Authentication = 2,
                Gonderme_Saati = DateTime.Now,
                Gelmeyenler_Raporu = true,
                Alici_1_E_Mail_Adres = "sample@forateknoloji.com",
                Alici_1_E_Mail_Gonder = true
            };
            context.EMailSettings.Add(eMailSetting);
            SMSSetting sMSSetting = new SMSSetting
            {
                Kullanici_Adi = "Fora Teknoloji",
                Sifre = "12345",
                Originator = "Fora",
                Gelmeyenler_Gonder = false,
                Gelmeyenler_Mesaj = "",
                Gelmeyenler_Saat = DateTime.Now,
                Gelmeyenler_Global_Bolge = 1,
                IcerdeDisarda_Gonder = false,
                Icerde_Mesaj = "",
                Disarda_Mesaj = "",
                IcerdeDisarda_Saat = DateTime.Now,
                IcerdeDisarda_Global_Bolge = 1,
                HerGirisCikista_Gonder = false,
                HerGirisCikista_Mesaj = "TEST"
            };
            context.SMSSettings.Add(sMSSetting);
            Sirketler sirket = new Sirketler
            {
                Adi = "Şirket 1"
            };
            context.Sirketler.Add(sirket);
            Departmanlar departman = new Departmanlar
            {
                Adi = "Departman"
            };
            context.Departmanlar.Add(departman);

            ProgInit progInit = new ProgInit
            {
                BackupPeriode = null,
                BackupDay = null,
                LastBackupDate = null,
                EndlessReportTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0),
                PeriodicAccessDataTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 3, 0, 0),
                AllPanelPeriodicAccessReceive = false,
                DeleteAfterReceiving = false,
                ReportByHour = false,
                LiveAPBInvalid = false,
                LiveDeniedInvalid = false,
                LiveUnknownInvalid = false,
                LiveButtonInvalid = false,
                LiveManuelInvalid = false,
                LiveProgrammedInvalid = false,
                UpdateAccessFile = false,
                NoOpLogUser = false,
                NoOpLogTimeZone = false,
                NoOpLogGroup = false,
                NoOpLogPanelLogs = false,
                NoOpLogVisitor = false,
                NoOpLogUserAlarm = false,
                NoOpLogCamera = false,
                NoOpLogLift = false,
                NoOpLogProgrammedRelay = false,
                NoOpLogCompany = false,
                NoOpLogDepartment = false,
                NoOpLogBlock = false,
                NoOpLogImport = false,
                NoOpLogEmailSMS = false,
                NoOpLogUserGlobalInterlock = false,
                NoOpLogGroupCalendar = false,
                NoOpLogReports = false,
                NoOpLogDatabase = false,
                NoOpPanelSettings = false,
                NoOpOther = false
            };
            context.ProgInit.Add(progInit);

            context.SaveChanges();
        }
    }
}
