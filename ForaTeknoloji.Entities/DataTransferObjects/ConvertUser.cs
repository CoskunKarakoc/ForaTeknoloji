using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.Entities.DataTransferObjects
{
    public static class ConvertUser
    {
        public static UsersOLD UserToUserOld(Users users)
        {
            var usersOld = new UsersOLD
            {
                Aciklama = users.Aciklama,
                Adi = users.Adi,
                Adres = users.Adres,
                Bitis_Tarihi = users.Bitis_Tarihi,
                Blok_No = users.Blok_No,
                C3_Grup = users.C3_Grup,
                Daire = users.Daire,
                Departman_No = users.Departman_No,
                Alt_Departman_No = users.Alt_Departman_No,
                Unvan_No = users.Unvan_No,
                Bolum_No = users.Bolum_No,
                Dogrulama_PIN = users.Dogrulama_PIN,
                Gecis_Modu = users.Gecis_Modu,
                Gorev = users.Gorev,
                Grup_No = users.Grup_No,
                Grup_No_1 = users.Grup_No_1,
                Grup_No_2 = users.Grup_No_2,
                Grup_No_3 = users.Grup_No_3,
                Grup_Takvimi_Aktif = users.Grup_Takvimi_Aktif,
                Grup_Takvimi_No = users.Grup_Takvimi_No,
                ID = users.ID,
                Iptal = users.Iptal,
                Kart_ID = users.Kart_ID,
                Kimlik_PIN = users.Kimlik_PIN,
                Kullanici_Tipi = users.Kullanici_Tipi,
                Plaka = users.Plaka,
                Resim = users.Resim,
                Saat_1 = users.Saat_1,
                Saat_2 = users.Saat_2,
                Saat_3 = users.Saat_3,
                Sifre = users.Sifre,
                Sirket_No = users.Sirket_No,
                Soyadi = users.Soyadi,
                Sureli_Kullanici = users.Sureli_Kullanici,
                TCKimlik = users.TCKimlik,
                Telefon = users.Telefon,
                Tmp = users.Tmp,
                Visitor_Grup_No = users.Visitor_Grup_No,
                User_Kayit_No = users.Kayit_No,
                Gorev_No = users.Gorev_No
            };

            return usersOld;
        }


    }
}
