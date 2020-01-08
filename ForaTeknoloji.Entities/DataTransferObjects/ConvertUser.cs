using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.Entities.DataTransferObjects
{
    public static class ConvertUser
    {
        /// <summary>
        /// Var olan kullanıcıyı eski kullanıcıya çevirme.
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
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
      
        /// <summary>
        /// Excel'den alınan verileri User nesnesine çevirme.
        /// </summary>
        /// <param name="rawUsers">Excel'den okunan verilerin RawUsers Tablosundaki nesne karşılığı</param>
        /// <returns></returns>
        public static Users RawUserToUser(RawUsers rawUsers)
        {
            var user = new Users
            {
                Adi = rawUsers.Adi,
                Soyadi = rawUsers.Soyadi,
                Adres = rawUsers.Adres,
                Aciklama = rawUsers.Aciklama,
                ID = rawUsers.ID,
                Kart_ID = rawUsers.Kart_ID,
                Dogrulama_PIN = rawUsers.Dogrulama_PIN,
                Kimlik_PIN = rawUsers.Kimlik_PIN,
                Kullanici_Tipi = rawUsers.Kullanici_Tipi,
                Sifre = rawUsers.Sifre,
                Gecis_Modu = rawUsers.Gecis_Modu,
                Grup_No = rawUsers.Grup_No,
                Visitor_Grup_No = rawUsers.Visitor_Grup_No,
                Resim = rawUsers.Resim,
                Plaka = rawUsers.Plaka,
                TCKimlik = rawUsers.TCKimlik,
                Blok_No = rawUsers.Blok_No,
                Daire = rawUsers.Daire,
                Gorev = rawUsers.Gorev,
                Departman_No = rawUsers.Departman_No,
                Sirket_No = rawUsers.Sirket_No,
                Iptal = rawUsers.Iptal,
                Grup_Takvimi_Aktif = rawUsers.Grup_Takvimi_Aktif,
                Grup_Takvimi_No = rawUsers.Grup_Takvimi_No,
                Saat_1 = rawUsers.Saat_1,
                Saat_2 = rawUsers.Saat_2,
                Saat_3 = rawUsers.Saat_3,
                Grup_No_1 = rawUsers.Grup_No_1,
                Grup_No_2 = rawUsers.Grup_No_2,
                Grup_No_3 = rawUsers.Grup_No_3,
                Tmp = rawUsers.Tmp,
                Sureli_Kullanici = rawUsers.Sureli_Kullanici,
                Bitis_Tarihi = rawUsers.Bitis_Tarihi,
                Telefon = rawUsers.Telefon,
                C3_Grup = rawUsers.C3_Grup
            };

            return user;
        }
    }
}
