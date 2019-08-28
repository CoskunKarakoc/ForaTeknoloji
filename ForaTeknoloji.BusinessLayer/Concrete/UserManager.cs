using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private ISirketDal _sirketDal;
        private IBloklarDal _bloklarDal;
        private IGroupsDetailDal _groupsDetailDal;
        private IDepartmanDal _departmanDal;
        private IGlobalZoneDal _globalZoneDal;
        private IAccessDatasDal _accessDatasDal;
        public UserManager(IUserDal userDal, ISirketDal sirketDal, IBloklarDal bloklarDal, IGroupsDetailDal groupsDetailDal, IDepartmanDal departmanDal, IGlobalZoneDal globalZoneDal, IAccessDatasDal accessDatasDal)
        {
            _userDal = userDal;
            _sirketDal = sirketDal;
            _bloklarDal = bloklarDal;
            _groupsDetailDal = groupsDetailDal;
            _departmanDal = departmanDal;
            _globalZoneDal = globalZoneDal;
            _accessDatasDal = accessDatasDal;
        }

        public List<GelenGelmeyenRaporList> GetGelenGelmeyenLists(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? Visitors, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tipler = null)
        {
            var SirketAdi = _sirketDal.Get(x => x.Sirket_No == Sirketler);
            var DepartmanAdi = _departmanDal.Get(x => x.Departman_No == Departmanlar);
            var GroupDetail = _groupsDetailDal.Get(x => x.Grup_No == Groupsdetail);
            string queryString = "SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi], Users.Resim FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0 ";
            if (Tipler == "Gelmeyenler")
            {
                if (Sirketler != null)
                {
                    queryString += " AND Users.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND Users.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (GroupDetail != null)
                {
                    queryString += " AND Users.[Grup No] =" + GroupDetail.Grup_No;
                }

                queryString += "AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1 ";

            }
            if (Tipler == "Gelenler")
            {
                queryString = "SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi], Users.Resim FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No])LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0";
                if (Sirketler != null)
                {
                    queryString += " AND Users.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND Users.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (GroupDetail != null)
                {
                    queryString += " AND Users.[Grup No] =" + GroupDetail.Grup_No;
                }
                queryString += " AND Users.[Kart ID] IN (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";
            }
            if (Tipler == "Pasif Kullanıcı")
            {
                queryString = "SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire, GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi] FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No])LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0";

                if (Sirketler != null)
                {
                    queryString += " AND Users.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND Users.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (GroupDetail != null)
                {
                    queryString += " AND Users.[Grup No] =" + GroupDetail.Grup_No;
                }
                queryString += " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            }
            if (Tipler == "ilk Giriş Son Çıkış")
            {
                queryString = " SELECT AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi,Sirketler.Adi AS Şirket, Departmanlar.Adi AS Departman, GroupsMaster.[Grup Adi] AS Grup, CONVERT(VARCHAR(10), AccessDatas.Tarih, 103) AS [Tarih Değeri],MIN(AccessDatas.Tarih) AS [İlk Kayıt], MAX(AccessDatas.Tarih) AS [Son Kayıt], CAST((MAX(AccessDatas.Tarih)-MIN(AccessDatas.Tarih)) as time(0)) AS Fark FROM (AccessDatas LEFT JOIN (((Users LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No])LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) ON AccessDatas.ID = Users.ID)LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No] WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1 ";
                if (Sirketler != null)
                {
                    queryString += " AND Users.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND Users.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (GroupDetail != null)
                {
                    queryString += " AND Users.[Grup No] =" + GroupDetail.Grup_No;
                }
            }
            if (Tipler == "Toplam İcerde Kalma")
            {
                queryString = "SELECT a.ID, a.[Kart ID], Users.Adi, Users.Soyadi, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, GroupsMaster.[Grup Adi] AS Grup, CONVERT(VARCHAR(10), a.Tarih, 103) AS [Tarih Değeri], a.Tarih AS log_in, COALESCE( (SELECT min(Tarih)FROM AccessDatas as b WHERE a.ID = b.ID AND CAST(a.Tarih AS DATE) = CAST(b.Tarih AS DATE) AND b.Tarih >= a.Tarih AND b.[Gecis Tipi] = 1), a.Tarih) as log_out FROM (AccessDatas AS a LEFT JOIN (((Users LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) ON a.ID = Users.ID) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No] WHERE a.[Kullanici Tipi] = 0 AND a.Kod = 1 AND a.[Gecis Tipi] = 0 AND a.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103) AND a.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2 + "',103)";
                if (Sirketler != null)
                {
                    queryString += " AND Users.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND Users.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (GroupDetail != null)
                {
                    queryString += " AND Users.[Grup No] =" + GroupDetail.Grup_No;
                }
            }

            queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103)";
            queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2 + "',103) ";
            queryString += " GROUP BY AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi,Sirketler.Adi, Departmanlar.Adi, GroupsMaster.[Grup Adi], CONVERT(VARCHAR(10), AccessDatas.Tarih, 103)";
            queryString += " ORDER BY AccessDatas.ID";
            List<GelenGelmeyenRaporList> liste = new List<GelenGelmeyenRaporList>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE-1\ARGE;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new GelenGelmeyenRaporList
                        {

                        };
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }











            /*
            var liste = _userDal.GetComplexGelenGelmeyenRaporList();
            var context = new ForaContext();


            if (Tipler == "Gelenler")
            {
                if (Sirketler != null)
                {
                    liste = liste.Where(x => x.Sirket_Adi == SirketAdi.Adi);
                }
                if (Departmanlar != null)
                {
                    liste = liste.Where(x => x.Departman_Adi == DepartmanAdi.Adi);
                }
                //if (GroupDetail != null)
                //{
                //    liste = liste.Where(x => x.Grup_No == GroupDetail.Grup_No);
                //}
                //Burada
                //repSQLStr = repSQLStr & " AND Users.[Kart ID] IN (SELECT DISTINCT AccessDatas.[Kart ID] " & _
                //"FROM AccessDatas " & _
                //"WHERE AccessDatas.[Kullanici Tipi] = 0 " & _
                //"AND AccessDatas.Kod = 1 " kodu uygulanacak
                return liste.ToList();
            }
            if (Tipler == "Gelmeyenler")
            {
                //if (GroupDetail != null)
                //{
                //    liste = liste.Where(x => x.Grup_No == GroupDetail.Grup_No);
                //}
                if (Sirketler != null)
                {
                    liste = liste.Where(x => x.Sirket_Adi == SirketAdi.Adi);
                }
                if (Departmanlar != null)
                {
                    liste = liste.Where(x => x.Departman_Adi == DepartmanAdi.Adi);
                }
                //Burada 
                //repSQLStr = repSQLStr & " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] " & _
                //"FROM AccessDatas " & _
                //"WHERE AccessDatas.[Kullanici Tipi] = 0 " & _
                //"AND AccessDatas.Kod = 1 " kodu uygulanacak
            }
            if (Tipler == "Pasif Kullanıcı")
            {
                if (Sirketler != null)
                {
                    liste = liste.Where(x => x.Sirket_Adi == SirketAdi.Adi);
                }
                if (Departmanlar != null)
                {
                    liste = liste.Where(x => x.Departman_Adi == DepartmanAdi.Adi);
                }
                //if (GroupDetail != null)
                //{
                //    liste = liste.Where(x => x.Grup_No == GroupDetail.Grup_No);
                //}
                //Burada

                //repSQLStr = repSQLStr & " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] " & _
                //"FROM AccessDatas " & _
                //"WHERE AccessDatas.[Kullanici Tipi] = 0 " & _
                //"AND AccessDatas.Kod = 1 " kodu kullanılacak

            }
            if (Tipler == "ilk Giriş Son Çıkış")
            {

            }
            if (Tipler == "Toplam İcerde Kalma")
            {

            }*/
            return liste;

        }

        public List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail, int? GlobalBolgeNo, int? Daire, string Plaka = null)
        {
            var SirketAdi = _sirketDal.Get(x => x.Sirket_No == Sirketler);
            var DepartmanAdi = _departmanDal.Get(x => x.Departman_No == Departmanlar);
            var Blok = _bloklarDal.Get(x => x.Blok_No == Bloklar);
            var GroupDetail = _groupsDetailDal.Get(x => x.Kayit_No == Groupsdetail);
            var GlobalZone = _globalZoneDal.Get(x => x.Global_Bolge_No == GlobalBolgeNo);
            string queryString = "SELECT DISTINCT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi As Departman, Users.Plaka, Bloklar.Adi As Blok, Users.Daire,Users.[Grup No], GroupsDetail.[Grup Adi] As [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi] FROM (((GroupsDetail LEFT JOIN Users ON GroupsDetail.[Grup No] = Users.[Grup No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No] WHERE Users.[Kullanici Tipi] = 0  AND Users.ID > 0";

            if (Departmanlar != null)
            {
                queryString += " AND Users.[Departman No] = " + DepartmanAdi.Departman_No;
            }
            if (Sirketler != null)
            {
                queryString += " AND Users.[Sirket No] = " + SirketAdi.Sirket_No;
            }
            if (Plaka != null && Plaka != "")
            {
                queryString += " AND Users.[Plaka] ='" + Plaka + "'";
            }
            if (Bloklar != null)
            {
                queryString += " AND Users.[Blok No] =" + Blok.Blok_No;
            }
            if (Daire != null)
            {
                queryString += " AND Users.[Daire] ='" + Daire + "'";
            }
            if (GlobalBolgeNo != null)
            {
                queryString += " AND (( GroupsDetail.[Kapi1] = 1 AND GroupsDetail.[Kapi1 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi2] = 1 AND GroupsDetail.[Kapi2 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi3] = 1 AND GroupsDetail.[Kapi3 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi4] = 1 AND GroupsDetail.[Kapi4 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi5] = 1 AND GroupsDetail.[Kapi5 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi6] = 1 AND GroupsDetail.[Kapi6 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi7] = 1 AND GroupsDetail.[Kapi7 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi8] = 1 AND GroupsDetail.[Kapi8 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi9] = 1 AND GroupsDetail.[Kapi9 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi10] = 1 AND GroupsDetail.[Kapi10 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi11] = 1 AND GroupsDetail.[Kapi11 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi12] = 1 AND GroupsDetail.[Kapi12 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi13] = 1 AND GroupsDetail.[Kapi13 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi14] = 1 AND GroupsDetail.[Kapi14 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi15] = 1 AND GroupsDetail.[Kapi15 Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetail.[Kapi16] = 1 AND GroupsDetail.[Kapi16 Global Bolge No] = " + GlobalZone.Global_Bolge_No + "))";
            }

            queryString += " ORDER BY Users.ID";



            List<PersonelList> liste = new List<PersonelList>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE-1\ARGE;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var nesne = new PersonelList
                        {
                            ID = reader[0] as int? ?? default(int),
                            Kart_ID = reader[1].ToString(),
                            Adi = reader[2].ToString(),
                            Soyadi = reader[3].ToString(),
                            TCKimlik = reader[4].ToString(),
                            SirketAdi = reader[5].ToString(),
                            DepartmanAdi = reader[6].ToString(),
                            Plaka = reader[7].ToString(),
                            BlokAdi = reader[8].ToString(),
                            Daire = reader[9] as int? ?? default(int),
                            Grup_No = reader[10] as int? ?? default(int),
                            Grup_Adi = reader[11].ToString(),
                            Tmp = reader[12].ToString(),
                        };
                        liste.Add(nesne);
                    }
                    reader.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return liste;
        }

        public List<ReportPersonelList> GetReportPersonelLists(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Günlük, bool? Tümü, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kullanici = null, string Kayit = null)
        {
         
            string queryString = "";
            var SirketAdi = _sirketDal.Get(x => x.Sirket_No == Sirketler);
            var DepartmanAdi = _departmanDal.Get(x => x.Departman_No == Departmanlar);
            var GroupDetail = _groupsDetailDal.Get(x => x.Grup_No == Groupsdetail);
            var Blok = _bloklarDal.Get(x => x.Blok_No == Bloklar);
           
            if (Kullanici == "Aktif")
            {
                queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],Users.Adi, Users.Soyadi, Users.TCKimlik, Users.Telefon, Sirketler.Adi AS Sirket,Departmanlar.Adi AS Departman,Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, Users.Resim, AccessDatas.[Canli Resim] FROM (((GroupsMaster RIGHT JOIN (Users LEFT JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = Users.[Grup No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No] WHERE AccessDatas.[Kullanici Tipi] = 0";
                queryString += " AND AccessDatas.[User Kayit No] = 0";
                if (KapiYon == "giris")
                {
                    queryString += " AND AccessDatas.[Gecis Tipi] = 0";
                }
                if (KapiYon == "cikis")
                {
                    queryString += " AND AccessDatas.[Gecis Tipi] = 1";
                }
                if (Sirketler != null)
                {
                    queryString += " AND Users.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND Users.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (Bloklar != null)
                {
                    queryString += " AND Users.[Blok No] =" + Blok.Blok_No;
                }
                if (Groupsdetail != null)
                {
                    queryString += " AND Users.[Grup No] =" + GroupDetail.Grup_No;
                }

                if (Daire != null)
                {
                    queryString += " AND Users.[Daire] =" + Daire;
                }
                if (Plaka != null)
                {
                    queryString += " AND Users.[Plaka] ='" + Plaka + "'";
                }

            }
            else if (Kullanici == "Eski")
            {
                queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],UsersOLD.Adi, UsersOLD.Soyadi, UsersOLD.TCKimlik, UsersOLD.Telefon, Sirketler.Adi AS Sirket,Departmanlar.Adi AS Departman,UsersOLD.Plaka, Bloklar.Adi AS Blok, UsersOLD.Daire,GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, UsersOLD.Resim, AccessDatas.[Canli Resim] FROM (((GroupsMaster RIGHT JOIN (UsersOLD LEFT JOIN AccessDatas ON UsersOLD.[User Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = UsersOLD.[Grup No]) LEFT JOIN Sirketler ON UsersOLD.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON UsersOLD.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON UsersOLD.[Blok No] = Bloklar.[Blok No] WHERE AccessDatas.[Kullanici Tipi] = 0";
                if (Groupsdetail != null)
                {
                    queryString += " AND UsersOLD.[Grup No] =" + GroupDetail.Grup_No;
                }
                if (Sirketler != null)
                {
                    queryString += " AND UsersOLD.[Sirket No] =" + SirketAdi.Sirket_No;
                }
                if (Departmanlar != null)
                {
                    queryString += " AND UsersOLD.[Departman No] =" + DepartmanAdi.Departman_No;
                }
                if (Plaka != null)
                {
                    queryString += " AND UsersOLD.[Plaka] ='" + Plaka + "'";
                }
                if (Bloklar != null)
                {
                    queryString += " AND UsersOLD.[Blok No] =" + Blok.Blok_No;
                }
                if (Daire != null)
                {
                    queryString += " AND UsersOLD.[Daire] =" + Daire;
                }
            }
            if (Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + Panel;
            }
            if (Kapi1 != null)
            {

                queryString += " AND AccessDatas.[Kapi ID]=" + 1;
            }
            if (Kapi2 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 2;
            }
            if (Kapi3 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 3;
            }
            if (Kapi4 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 4;
            }
            if (Kapi5 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 5;
            }
            if (Kapi6 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 6;
            }
            if (Kapi7 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 7;
            }
            if (Kapi8 != null)
            {
                queryString += " AND AccessDatas.[Kapi ID]=" + 8;
            }
            if (Kayit == "tümKayit")
            {
                queryString += " AND AccessDatas.[Kod] >= 0";
                queryString += " AND AccessDatas.[Kod] <= 2";
            }
            if (Kayit == "OnaylananGecisler")
            {
                queryString += " AND AccessDatas.[Kod] = 1";
            }
            if (Kayit == "Antipassback")
            {
                queryString += " AND AccessDatas.[Kod] = 2";
            }
            if (Kayit == "Engellenen")
            {
                queryString += " AND AccessDatas.[Kod] = 0";
            }
            if (Tarih1 != null && Tarih2 == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103)";
            }
            if (Tarih1 != null && Tarih2 != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103) ";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2 + "',103)";
            }
            if (Saat1 != null && Saat2 == null)
            {
                queryString += "";
            }
            if (Saat1 != null && Saat2 != null)
            {
                queryString += "";
            }
            if (Günlük != null && Tarih1 != null && Tarih2 != null && Saat1 != null && Saat2 != null)
            {
                queryString += " AND CAST(AccessDatas.Tarih AS DATE) >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103)";
                queryString += " AND CAST(AccessDatas.Tarih AS DATE) <= CONVERT(SMALLDATETIME,'" + Tarih2 + "',103)";
                queryString += " AND CAST(AccessDatas.Tarih AS TIME) >= '" + Saat1 + "' ";
                queryString += " AND CAST(AccessDatas.Tarih AS TIME) <= '" + Saat2 + "'";
            }


            List<ReportPersonelList> liste = new List<ReportPersonelList>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE-1\ARGE;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new ReportPersonelList
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Adi = reader[3].ToString(),
                            Soyadi = reader[4].ToString(),
                            TCKimlik = reader[5].ToString(),
                            Telefon = reader[6].ToString(),
                            SirketAdi = reader[7].ToString(),
                            DepartmanAdi = reader[8].ToString(),
                            Plaka = reader[9].ToString(),
                            BlokAdi = reader[10].ToString(),
                            Daire = reader[11] as int? ?? default(int),
                            Grup_Adi = reader[12].ToString(),
                            Panel_ID = reader[13] as int? ?? default(int),
                            Kapi_ID = reader[14] as int? ?? default(int),
                            Gecis_Tipi = reader[15] as int? ?? default(int),
                            Tarih = reader[16] as DateTime? ?? default(DateTime),
                            Resim = reader[17].ToString(),
                            Canli_Resim = reader[18].ToString()
                        };
                        liste.Add(nesne);

                    }
                    reader.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return liste;
        }
    }
}
