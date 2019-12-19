using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class ReportManager : IReportService
    {
        private IVisitorsDal _visitorsDal;
        private IGroupsDetailDal _groupsDetailDal;
        private IGlobalZoneDal _globalZoneDal;
        private ISirketDal _sirketDal;
        private IBloklarDal _bloklarDal;
        private IDepartmanDal _departmanDal;
        private IPanelSettingsDal _panelSettingsDal;
        private IReaderSettingDal _readerSettingDal;
        private IDBUsersSirketDal _dbUsersSirketDal;
        private IAccessDatasService _accessDatasService;
        private IDBUsersPanelsService _dbUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        private IUserService _userService;
        private IDBUsersDepartmanDal _dBUsersDepartmanDal;
        public string panelListesi = "0";
        public string sirketListesi = "0";
        public string departmanListesi = "0";
        public List<int?> sirketler;
        public ReportManager(IVisitorsDal visitorsDal, IGroupsDetailDal groupsDetailDal, IGlobalZoneDal globalZoneDal, ISirketDal sirketDal, IBloklarDal bloklarDal, IDepartmanDal departmanDal, IPanelSettingsDal panelSettingsDal, IReaderSettingDal readerSettingDal, IAccessDatasService accessDatasService, IDBUsersPanelsService dbUsersPanelsService, IDBUsersSirketDal dBUsersSirketDal, IDoorNamesService doorNamesService, IUserService userService, IDBUsersDepartmanDal dBUsersDepartmanDal)
        {
            _visitorsDal = visitorsDal;
            _groupsDetailDal = groupsDetailDal;
            _globalZoneDal = globalZoneDal;
            _sirketDal = sirketDal;
            _bloklarDal = bloklarDal;
            _departmanDal = departmanDal;
            _panelSettingsDal = panelSettingsDal;
            _readerSettingDal = readerSettingDal;
            _accessDatasService = accessDatasService;
            _dbUsersPanelsService = dbUsersPanelsService;
            _dbUsersSirketDal = dBUsersSirketDal;
            _doorNamesService = doorNamesService;
            _userService = userService;
            _dBUsersDepartmanDal = dBUsersDepartmanDal;
        }

        //=====>Tamamlandı<=====
        //OutherReport Controller
        public List<DigerGecisRaporList> GetDigerGecisListesi(OutherReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod >= 5 AND AccessDatas.Kod <= 27";
            if (parameters.Kod == 100)
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,"
                              + " DoorNames.[Kapi Adi] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                              + " CodeOperation.Operasyon, AccessDatas.Tarih"
                              + " FROM(CodeOperation RIGHT JOIN"
                              + " (AccessDatas RIGHT JOIN DoorNames ON AccessDatas.[Panel ID] = DoorNames.[Panel No] AND AccessDatas.[Kapi ID] = DoorNames.[Kapi No])"
                              + " ON CodeOperation.TKod = AccessDatas.Kod )"
                              + " WHERE AccessDatas.Kod >= 5 AND AccessDatas.Kod <= 27";

            }
            else if (parameters.Kod >= 40)
            {
                int TetiklemePlus = (int)parameters.Kod + 1;
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel, "
                           + " AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                           + " CodeOperation.Operasyon, AccessDatas.Tarih"
                           + " FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod"
                           + " WHERE AccessDatas.Kod >= " + parameters.Kod + " AND AccessDatas.Kod <= " + TetiklemePlus;
            }
            else if (parameters.Kod >= 20 && parameters.Kod <= 21)
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel, "
                   + " AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                   + " CodeOperation.Operasyon, AccessDatas.Tarih"
                   + " FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod"
                   + " WHERE AccessDatas.Kod = " + parameters.Kod;

            }
            else if (parameters.Kod == 22)
            {
                queryString = " SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,"
                   + " DoorNames.[Kapi Adi] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                   + " CodeOperation.Operasyon, AccessDatas.Tarih"
                   + " FROM(CodeOperation RIGHT JOIN"
                   + " (AccessDatas RIGHT JOIN DoorNames ON AccessDatas.[Panel ID] = DoorNames.[Panel No] AND AccessDatas.[Kapi ID] = DoorNames.[Kapi No])"
                   + " ON CodeOperation.TKod = AccessDatas.Kod )"
                   + " WHERE AccessDatas.Kod >= 22 AND AccessDatas.Kod <= 25 ";
            }
            else
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel, "
                   + " DoorNames.[Kapi Adi] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                   + " CodeOperation.Operasyon, AccessDatas.Tarih"
                   + " FROM(CodeOperation RIGHT JOIN"
                   + " (AccessDatas RIGHT JOIN DoorNames ON AccessDatas.[Panel ID] = DoorNames.[Panel No] AND AccessDatas.[Kapi ID] = DoorNames.[Kapi No])"
                   + " ON CodeOperation.TKod = AccessDatas.Kod )"
                   + " WHERE AccessDatas.Kod = " + parameters.Kod;
            }
            queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            if (parameters.Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID]=" + parameters.Panel;
            }
            if (parameters.Tum_Kapi != true && parameters.Tum_Kapi != null)
            {
                if (parameters.Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in parameters.Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            else
            {
                string kapilar = "";
                for (int i = 1; i < 17; i++)
                {
                    kapilar += i + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
            {
                if (parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                {
                    var sonuc1 = parameters.Baslangic_Tarihi?.ToShortDateString() + " " + parameters.Baslangic_Saati?.ToLongTimeString();
                    var sonuc2 = parameters.Bitis_Tarihi?.ToShortDateString() + " " + parameters.Bitis_Saati?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103)";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >='" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                    queryString += " AND AccessDatas.Tarih <='" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                }
            }
            if (parameters.Kapi_Yon == 0)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (parameters.Kapi_Yon == 1)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            else
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }

            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";

            List<DigerGecisRaporList> liste = new List<DigerGecisRaporList>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        var nesne = new DigerGecisRaporList
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            Panel_ID = reader[1] as int? ?? default(int),
                            Kapi = reader[2].ToString(),
                            Gecis_Tipi = reader[3] as int? ?? default(int),
                            Operasyon = reader[4].ToString(),
                            Tarih = reader[5] as DateTime? ?? default(DateTime)
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


        //=====>Tamamlandı<=====
        //OutherReport Farklı Tipteki Liste                       
        public List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(OutherReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = " SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi, "
                   + " Sirketler.Adi AS Sirket, AccessDatas.[Panel ID] As Panel, DoorNames.[Kapi Adi] As Kapi,"
                   + " AccessDatas.[Gecis Tipi] As Gecis, CodeOperation.Operasyon,"
                   + " AccessDatas.Tarih"
                   + " FROM DoorNames RIGHT JOIN(CodeOperation RIGHT JOIN (AccessDatas RIGHT JOIN (Users RIGHT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) ON AccessDatas.ID = Users.ID) ON CodeOperation.TKod = AccessDatas.Kod) ON(DoorNames.[Kapi No] = AccessDatas.[Kapi ID]) AND(DoorNames.[Panel No] = AccessDatas.[Panel ID])"
                   + " WHERE AccessDatas.Kod >= 26 AND AccessDatas.Kod <= 27 ";
            queryString += " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            queryString += " AND Departman.[Departman No] IN(10000," + departmanListesi + ")";
            queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            if (parameters.Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID]=" + parameters.Panel;
            }
            if (parameters.Tum_Kapi != true)
            {
                if (parameters.Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in parameters.Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            else
            {
                string kapilar = "";
                for (int i = 1; i < 17; i++)
                {
                    kapilar += i + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }





            if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
            {
                if (parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                {
                    var sonuc1 = parameters.Baslangic_Tarihi?.ToShortDateString() + " " + parameters.Baslangic_Saati?.ToLongTimeString();
                    var sonuc2 = parameters.Bitis_Tarihi?.ToShortDateString() + " " + parameters.Bitis_Saati?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103)";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >='" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                    queryString += " AND AccessDatas.Tarih <='" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                }
            }
            if (parameters.Kapi_Yon == 0)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            else if (parameters.Kapi_Yon == 1)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            else
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }

            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";

            List<DigerGecisRaporListKullaniciAlarm> liste = new List<DigerGecisRaporListKullaniciAlarm>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        var nesne = new DigerGecisRaporListKullaniciAlarm
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Adi = reader[3].ToString(),
                            Soyadi = reader[4].ToString(),
                            SirketAdi = reader[5].ToString(),
                            PanelID = reader[6] as int? ?? default(int),
                            Kapi_ID = reader[7] as int? ?? default(int),
                            Gecis_Tipi = reader[8] as int? ?? default(int),
                            Operasyon = reader[9].ToString(),
                            Tarih = reader[10] as DateTime? ?? default(DateTime)
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




        //GelenGelmeyen-Gelmeyenler
        public List<GelenGelmeyen_Gelmeyen> GelenGelmeyen_Gelmeyens(GelenGelmeyenReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = " SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi], Users.Resim FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No])LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0";

            if (sirketListesi != null)
            {
                queryString += " AND Sirketler.[Sirket No] IN(1000," + sirketListesi + ")";
            }
            if (departmanListesi != null)
            {
                queryString += " AND Departmanlar.[Departman No] IN(1000," + departmanListesi + ")";
            }
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] = " + parameters.Sirket;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] = " + parameters.Departman;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] = " + parameters.Gecis_Grubu;
            }

            queryString += " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            if (parameters.Baslangic_Tarihi != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.Date.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (parameters.Global_Kapi_Bolgesi != null)
            {
                queryString += ")";
            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + "))";
            }
            queryString += " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";
            queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            queryString += " AND AccessDatas.[Gecis Tipi] = 0)";



            List<GelenGelmeyen_Gelmeyen> liste = new List<GelenGelmeyen_Gelmeyen>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new GelenGelmeyen_Gelmeyen
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
                            Grup_Adi = reader[10].ToString(),
                            Global_Bolge_Adi = reader[11].ToString(),
                            Resim = reader[12].ToString()
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



        //Gelen-Gelmeyen Gelenler
        public List<GelenGelmeyen_Gelenler> GelenGelmeyen_Gelenlers(GelenGelmeyenReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = @" SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,
                Users.TCKimlik, Sirketler.Adi AS Şirket, 
                Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire, 
                GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi] 
                FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) 
                LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]) 
                LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) 
                LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] 
                WHERE Users.ID > 0 ";
            queryString += " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            queryString += " AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ")";
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] =" + parameters.Sirket;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] =" + parameters.Departman;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] =" + parameters.Gecis_Grubu;
            }

            queryString += " AND Users.[Kart ID] IN (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            if (parameters.Global_Kapi_Bolgesi != null)
            {

            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            }
            if (parameters.Baslangic_Tarihi != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            queryString += ")";





            List<GelenGelmeyen_Gelenler> liste = new List<GelenGelmeyen_Gelenler>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new GelenGelmeyen_Gelenler
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
                            Grup_Adi = reader[10].ToString(),
                            Global_Bolge_Adi = reader[11].ToString(),
                            Resim = reader[12].ToString()
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



        //Gelen-Gelmeyen PasifKullanici
        public List<GelenGelmeyen_PasifKullanici> GelenGelmeyen_PasifKullanicis(GelenGelmeyenReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi] FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No])LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0 ";
            queryString += "AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            queryString += "AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ")";
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] =" + parameters.Sirket;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] =" + parameters.Departman;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] =" + parameters.Gecis_Grubu;
            }

            queryString += " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            if (parameters.Global_Kapi_Bolgesi != null)
            {
                queryString += "";
            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            }
            if (parameters.Baslangic_Tarihi != null)
            {
                parameters.Fark = parameters.Fark * -1;
                var baslangicTarihi = parameters.Baslangic_Tarihi?.Date.AddDays((double)parameters.Fark).AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss");

                var dentarr = parameters.Baslangic_Tarihi?.AddDays((double)parameters.Fark).Date.ToString("yyyy/mm/dd");
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + baslangicTarihi + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            }
            queryString += ")";


            List<GelenGelmeyen_PasifKullanici> liste = new List<GelenGelmeyen_PasifKullanici>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new GelenGelmeyen_PasifKullanici
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
                            Grup_Adi = reader[10].ToString(),
                            Global_Bolge_Adi = reader[11].ToString()

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



        //Gelen-Gelmeyen İlk Giriş-Son Çıkış
        public List<GelenGelmeyen_IlkGirisSonCikis> GelenGelmeyen_IlkGirisSonCikis(GelenGelmeyenReportParameters parameters)
        {

            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "SELECT AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi, "
                   + " Sirketler.Adi AS Şirket, Departmanlar.Adi AS Departman,"
                   + " GroupsMaster.[Grup Adi] AS Grup, CONVERT(VARCHAR(10), AccessDatas.Tarih, 103) AS[Tarih Değeri],"
                   + " MIN(AccessDatas.Tarih) AS[İlk Kayıt], MAX(AccessDatas.Tarih) AS[Son Kayıt], "
                   + " CAST((MAX(AccessDatas.Tarih) - MIN(AccessDatas.Tarih)) as time(0)) AS Fark"
                   + " FROM(AccessDatas LEFT JOIN(((Users LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No])"
                   + " LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])"
                   + " LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) ON AccessDatas.ID = Users.ID) "
                   + " LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]"
                   + " WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";
            queryString += "AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            queryString += "AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ")";
            if (parameters.User != null)
            {
                queryString += " AND AccessDatas.ID =" + parameters.User;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] =" + parameters.Gecis_Grubu;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] =" + parameters.Departman;
            }
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] =" + parameters.Sirket;

            }
            if (parameters.Global_Kapi_Bolgesi != null)
            {

            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            }
            if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.Date.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            }
            queryString += " GROUP BY AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi,Sirketler.Adi, Departmanlar.Adi, GroupsMaster.[Grup Adi], CONVERT(VARCHAR(10), AccessDatas.Tarih, 103)";
            queryString += " ORDER BY AccessDatas.ID";

            List<GelenGelmeyen_IlkGirisSonCikis> liste = new List<GelenGelmeyen_IlkGirisSonCikis>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new GelenGelmeyen_IlkGirisSonCikis
                        {
                            ID = reader[0] as int? ?? default(int),
                            Kart_ID = reader[1].ToString(),
                            Adi = reader[2].ToString(),
                            Soyadi = reader[3].ToString(),
                            SirketAdi = reader[4].ToString(),
                            DepartmanAdi = reader[5].ToString(),
                            Grup_Adi = reader[6].ToString(),
                            Tarih_Degeri = reader[7].ToString(),
                            Ilk_Kayit = reader[8].ToString(),
                            Son_Kayit = reader[9].ToString(),
                            Fark = reader[10].ToString()

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


        //Gelen-Gelmeyen Toplam İçerde Kalma
        public List<GelenGelmeyen_ToplamIcerdeKalma> GelenGelmeyen_ToplamIcerdeKalmas(GelenGelmeyenReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "SELECT a.ID, a.[Kart ID], Users.Adi, Users.Soyadi, Sirketler.Adi AS Şirket, Departmanlar.Adi AS Departman, GroupsMaster.[Grup Adi] AS Grup, CONVERT(VARCHAR(10), a.Tarih, 103) AS [Tarih Değeri], a.Tarih AS log_in, COALESCE( (SELECT min(Tarih) FROM AccessDatas as b WHERE a.ID = b.ID AND CAST(a.Tarih AS DATE) = CAST(b.Tarih AS DATE) AND b.Tarih >= a.Tarih AND b.[Gecis Tipi] = 1), a.Tarih) as log_out FROM (AccessDatas AS a LEFT JOIN (((Users LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) ON a.ID = Users.ID) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No] WHERE a.[Kullanici Tipi] = 0 AND a.Kod = 1 AND a.[Gecis Tipi] = 0 AND a.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.Date.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) AND a.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            queryString += "AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            queryString += "AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ")";


            if (parameters.User != null)
            {
                queryString += " AND a.ID =" + parameters.User;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] =" + parameters.Gecis_Grubu;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] =" + parameters.Departman;
            }
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] =" + parameters.Sirket;

            }
            if (parameters.Global_Kapi_Bolgesi != null)
            {

            }
            else
            {
                queryString += " AND a.[Panel ID] IN(200," + panelListesi + ")";
            }
            string tempQuery = "SELECT ID, [Kart ID], Adi, Soyadi, Şirket, Departman, Grup, [Tarih Değeri], (SUM(DATEPART( HOUR, CAST((log_out - log_in) AS TIME))) + (((SUM(DATEPART(MINUTE, CAST((log_out - log_in) AS TIME)))) + (SUM(DATEPART( SECOND, CAST((log_out - log_in) AS TIME))) / 60)) / 60)) AS [Toplam Saat], (((SUM(DATEPART(MINUTE, CAST((log_out - log_in) AS TIME)))) + (SUM(DATEPART( SECOND, CAST((log_out - log_in) AS TIME))) / 60)) % 60) AS [Toplam Dakika], (SUM( DATEPART( SECOND, CAST((log_out - log_in) AS TIME) ) ) % 60 ) AS [Toplam Saniye] FROM ( " + queryString + " ) as t";

            tempQuery += " GROUP BY ID, [Kart ID], Adi, Soyadi, Şirket, Departman, Grup, [Tarih Değeri] ";
            tempQuery += " ORDER BY ID";
            List<GelenGelmeyen_ToplamIcerdeKalma> liste = new List<GelenGelmeyen_ToplamIcerdeKalma>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(tempQuery, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new GelenGelmeyen_ToplamIcerdeKalma
                        {
                            ID = reader[0] as int? ?? default(int),
                            Kart_ID = reader[1].ToString(),
                            Adi = reader[2].ToString(),
                            Soyadi = reader[3].ToString(),
                            SirketAdi = reader[4].ToString(),
                            DepartmanAdi = reader[5].ToString(),
                            Grup_Adi = reader[6].ToString(),
                            Tarih_Degeri = reader[7].ToString(),
                            Toplam_Saat = reader[8].ToString(),
                            Toplam_Dakika = reader[9].ToString(),
                            Toplam_Saniye = reader[10].ToString()
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


        //PersonelListReport Controller
        public List<PersonelList> GetPersonelLists(PersonelListReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            var GlobalZone = _globalZoneDal.Get(x => x.Global_Bolge_No == parameters.Global_Kapi_Bolgesi);
            string queryString = "SELECT DISTINCT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi As Departman, Users.Plaka, Bloklar.Adi As Blok, Users.Daire,Users.[Grup No], GroupsDetailNew.[Grup Adi] As [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi] FROM (((GroupsDetailNew LEFT JOIN Users ON GroupsDetailNew.[Grup No] = Users.[Grup No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No] WHERE Users.[Kullanici Tipi] = 0  AND Users.ID > 0";

            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] = " + parameters.Departman;
            }
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] = " + parameters.Sirket;
            }
            if (parameters.Plaka != null && parameters.Plaka != "")
            {
                queryString += " AND Users.[Plaka] ='" + parameters.Plaka.Trim() + "'";
            }
            if (parameters.Blok != null)
            {
                queryString += " AND Users.[Blok No] =" + parameters.Blok;
            }
            if (parameters.Daire != null)
            {
                queryString += " AND Users.[Daire] =" + parameters.Daire;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] =" + parameters.Gecis_Grubu;
            }
            if (parameters.Global_Kapi_Bolgesi != null)
            {
                queryString += " AND (( GroupsDetailNew.[Kapi No] = 1 AND GroupsDetailNew.[Kapi Aktif] = 1  AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 2 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 3 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 4 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 5 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 6 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 7 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 8 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 9 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 10 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 11 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 12 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 13 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 14 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 15 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + ")"
                    + "  OR(GroupsDetailNew.[Kapi No] = 16 AND GroupsDetailNew.[Kapi Aktif] = 1 AND GroupsDetailNew.[Kapi Global Bolge No] = " + GlobalZone.Global_Bolge_No + "))";
            }

            queryString += " ORDER BY Users.ID";



            List<PersonelList> liste = new List<PersonelList>();
            using (SqlConnection connection = new SqlConnection(address))
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



        //ReportPersonel-Aktif Controller
        public List<ReportPersonelList> GetReportPersonelLists(ActiveUserReportParameters parameters)
        {

            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "";



            queryString = @"SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], 
                    Users.Adi, Users.Soyadi, Users.TCKimlik, Users.Telefon, Sirketler.Adi AS Sirket, 
                    Departmanlar.Adi AS Departman, 
                    Users.Plaka, Bloklar.Adi AS Blok, Users.Daire, 
                    GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, DoorNames.[Kapi Adi] As Kapi,
                    AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, Users.Resim, AccessDatas.[Canli Resim] 
                    FROM ((((GroupsMaster RIGHT JOIN (Users LEFT JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = Users.[Grup No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No] )  LEFT JOIN DoorNames ON (AccessDatas.[Kapi ID] = DoorNames.[Kapi No]) AND (AccessDatas.[Panel ID] = DoorNames.[Panel No]) 
                    WHERE AccessDatas.[Kullanici Tipi] = 0 ";

            if (parameters.Tum_Kullanici != true)
            {
                if (parameters.User != null)
                {
                    queryString += " AND AccessDatas.[User Kayit No] =" + parameters.User;
                }
                else
                {
                    queryString += " AND AccessDatas.[User Kayit No] =" + 0;
                }
            }
            if (parameters.Kapi_Yon == 0)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (parameters.Kapi_Yon == 1)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            if (parameters.Sirket != null)
            {
                queryString += " AND Users.[Sirket No] =" + parameters.Sirket;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND Users.[Departman No] =" + parameters.Departman;
            }
            if (parameters.Blok != null)
            {
                queryString += " AND Users.[Blok No] =" + parameters.Blok;
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Users.[Grup No] =" + parameters.Gecis_Grubu;
            }

            if (parameters.Daire != null)
            {
                queryString += " AND Users.[Daire] =" + parameters.Daire;
            }
            if (parameters.Plaka != null && parameters.Plaka != "")
            {
                queryString += " AND Users.[Plaka] ='" + parameters.Plaka.Trim() + "'";
            }
            if (parameters.Kapilar.Count > 0 && parameters.Kapilar != null)
            {
                string kapilar = "";
                foreach (var item in parameters.Kapilar)
                {
                    kapilar += item + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            else
            {
                string kapilar = "";
                for (int i = 1; i < 17; i++)
                {
                    kapilar += i + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            if (parameters.Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + parameters.Panel;
            }

            if (parameters.Gecis_Tipi == null || parameters.Gecis_Tipi == 3)//Tümü
            {
                queryString += " AND AccessDatas.[Kod] >= 0";
                queryString += " AND AccessDatas.[Kod] <= 2";
            }
            if (parameters.Gecis_Tipi == 1)//Onaylanan
            {
                queryString += " AND AccessDatas.[Kod] = 1";
            }
            if (parameters.Gecis_Tipi == 2)//Antipassback
            {
                queryString += " AND AccessDatas.[Kod] = 2";
            }
            if (parameters.Gecis_Tipi == 0)//Engellenen
            {
                queryString += " AND AccessDatas.[Kod] = 0";
            }
            if (parameters.Tum_Tarih != true)
            {
                if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi == null)
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                }
                else if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
                {
                    if (parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                    {
                        if (parameters.Gunluk_Saat_Dilimi != null && parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null && parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                        {
                            queryString += " AND CAST(AccessDatas.Tarih AS DATE) >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                            queryString += " AND CAST(AccessDatas.Tarih AS DATE) <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                            queryString += " AND CAST(AccessDatas.Tarih AS TIME) >= '" + parameters.Baslangic_Saati?.ToLongTimeString() + "' ";
                            queryString += " AND CAST(AccessDatas.Tarih AS TIME) <= '" + parameters.Bitis_Saati?.ToLongTimeString() + "'";
                        }
                        else
                        {
                            var sonuc1 = parameters.Baslangic_Tarihi?.ToShortDateString() + " " + parameters.Baslangic_Saati?.ToLongTimeString();
                            var sonuc2 = parameters.Bitis_Tarihi?.ToShortDateString() + " " + parameters.Bitis_Saati?.ToLongTimeString();
                            queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103) ";
                            queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                        }
                    }
                    else
                    {
                        queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                        queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    }
                }
            }



            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<ReportPersonelList> liste = new List<ReportPersonelList>();
            using (SqlConnection connection = new SqlConnection(address))
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
                            Kapi = reader[14].ToString(),
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


        //ReportPersonel-Eski Controller
        public List<ReportPersonelList> GetReportPersonelListsEski(ActiveUserReportParameters parameters)
        {

            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = @"SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], 
                    UsersOLD.Adi, UsersOLD.Soyadi, UsersOLD.TCKimlik, UsersOLD.Telefon, Sirketler.Adi AS Sirket, 
                    Departmanlar.Adi AS Departman, 
                    UsersOLD.Plaka, Bloklar.Adi AS Blok, UsersOLD.Daire, 
                    GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,
                    AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, UsersOLD.Resim, AccessDatas.[Canli Resim]  
                    FROM ((((GroupsMaster RIGHT JOIN (UsersOLD LEFT JOIN AccessDatas ON UsersOLD.[User Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = UsersOLD.[Grup No]) LEFT JOIN Sirketler ON UsersOLD.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON UsersOLD.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON UsersOLD.[Blok No] = Bloklar.[Blok No] ) LEFT JOIN DoorNames ON (AccessDatas.[Kapi ID] = DoorNames.[Kapi No]) AND (AccessDatas.[Panel ID] = DoorNames.[Panel No]) 
                    WHERE AccessDatas.[Kullanici Tipi] = 0 ";

            if (parameters.Tum_Kullanici != true)
            {
                if (parameters.User != null)
                {
                    queryString += "AND AccessDatas.[User Kayit No] =" + parameters.User;
                }
                else
                {
                    queryString += "AND AccessDatas.[User Kayit No] =" + 0;
                }
            }
            if (parameters.Kapi_Yon == 0)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (parameters.Kapi_Yon == 1)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND UsersOLD.[Grup No] =" + parameters.Gecis_Grubu;
            }
            if (parameters.Sirket != null)
            {
                queryString += " AND UsersOLD.[Sirket No] =" + parameters.Sirket;
            }
            if (parameters.Departman != null)
            {
                queryString += " AND UsersOLD.[Departman No] =" + parameters.Departman;
            }
            if (parameters.Plaka != null && parameters.Plaka != "")
            {
                queryString += " AND UsersOLD.[Plaka] ='" + parameters.Plaka.Trim() + "'";
            }
            if (parameters.Blok != null)
            {
                queryString += " AND UsersOLD.[Blok No] =" + parameters.Blok;
            }
            if (parameters.Daire != null)
            {
                queryString += " AND UsersOLD.[Daire] =" + parameters.Daire;
            }
            if (parameters.Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + parameters.Panel;
            }


            if (parameters.Kapilar.Count > 0 && parameters.Kapilar != null)
            {
                string kapilar = "";
                foreach (var item in parameters.Kapilar)
                {
                    kapilar += item + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            else
            {
                string kapilar = "";
                for (int i = 1; i < 17; i++)
                {
                    kapilar += i + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }



            if (parameters.Gecis_Tipi == null || parameters.Gecis_Tipi == 3)//Tümü
            {
                queryString += " AND AccessDatas.[Kod] >= 0";
                queryString += " AND AccessDatas.[Kod] <= 2";
            }
            if (parameters.Gecis_Tipi == 1)//Onaylanan
            {
                queryString += " AND AccessDatas.[Kod] = 1";
            }
            if (parameters.Gecis_Tipi == 2)//Antipassback
            {
                queryString += " AND AccessDatas.[Kod] = 2";
            }
            if (parameters.Gecis_Tipi == 0)//Engellenen
            {
                queryString += " AND AccessDatas.[Kod] = 0";
            }
            if (parameters.Tum_Tarih != true)
            {
                if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi == null)
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                }
                else if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
                {
                    if (parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                    {
                        if (parameters.Gunluk_Saat_Dilimi != null && parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null && parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                        {
                            queryString += " AND CAST(AccessDatas.Tarih AS DATE) >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                            queryString += " AND CAST(AccessDatas.Tarih AS DATE) <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                            queryString += " AND CAST(AccessDatas.Tarih AS TIME) >= '" + parameters.Baslangic_Saati?.ToLongTimeString() + "' ";
                            queryString += " AND CAST(AccessDatas.Tarih AS TIME) <= '" + parameters.Bitis_Saati?.ToLongTimeString() + "'";
                        }
                        else
                        {
                            var sonuc1 = parameters.Baslangic_Tarihi?.ToShortDateString() + " " + parameters.Baslangic_Saati?.ToLongTimeString();
                            var sonuc2 = parameters.Bitis_Tarihi?.ToShortDateString() + " " + parameters.Bitis_Saati?.ToLongTimeString();
                            queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103) ";
                            queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                        }
                    }
                    else
                    {
                        queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                        queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    }
                }
            }
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<ReportPersonelList> liste = new List<ReportPersonelList>();
            using (SqlConnection connection = new SqlConnection(address))
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
                            Kapi = reader[14].ToString(),
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



        //UndefinedUserReport Controller
        public List<AccessDatasComplex> GetTanimsizListesi(TanimsizReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.[Kart ID],AccessDatas.[Panel ID] As Panel, DoorNames.[Kapi Adi] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, AccessDatas.[Canli Resim] FROM AccessDatas RIGHT JOIN DoorNames ON AccessDatas.[Panel ID] = DoorNames.[Panel No] AND AccessDatas.[Kapi ID] = DoorNames.[Kapi No] WHERE AccessDatas.Kod = 4 ";
            if (parameters.Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + parameters.Panel;
            }
            if (parameters.Kapi.Count > 0 && parameters.Kapi != null)
            {
                string kapilar = "";
                foreach (var item in parameters.Kapi)
                {
                    kapilar += item + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            else
            {
                string kapilar = "";
                for (int i = 1; i < 17; i++)
                {
                    kapilar += i + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            if (parameters.Kapi_Yon == 0)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            else if (parameters.Kapi_Yon == 1)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            else
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            if (parameters.Tum_Tarih != true)
            {
                if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
                {
                    if (parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                    {
                        var sonuc1 = parameters.Baslangic_Tarihi?.ToShortDateString() + " " + parameters.Baslangic_Saati?.ToLongTimeString();
                        var sonuc2 = parameters.Bitis_Tarihi?.ToShortDateString() + " " + parameters.Bitis_Saati?.ToLongTimeString();
                        queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103)";
                        queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                    }
                    else
                    {
                        queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("") + "',103)";
                        queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59) + "',103)";
                    }

                }
                if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi == null)
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                }
            }
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<AccessDatasComplex> liste = new List<AccessDatasComplex>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new AccessDatasComplex
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            Kart_ID = reader[1].ToString(),
                            Panel_ID = reader[2] as int? ?? default(int),
                            Kapi_Adi = reader[3].ToString(),
                            Gecis_Tipi = reader[4] as int? ?? default(int),
                            Tarih = reader[5] as DateTime? ?? default(DateTime),
                            Canli_Resim = reader[6].ToString()
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



        //VisitorReport Controller
        public List<ZiyaretciRaporList> GetZiyaretciListesi(VisitorReportParameters parameters)
        {
            //TODO: Global Zone düzeltilecek
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            var GlobalZone = _globalZoneDal.Get(x => x.Global_Bolge_No == parameters.Global_Kapi_Bolgesi);
            string queryString = " SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],Visitors.Adi, Visitors.Soyadi, Visitors.TCKimlik, Visitors.Telefon, Visitors.Plaka,Visitors.[Ziyaret Sebebi], GroupsMaster.[Grup Adi],AccessDatas.[Panel ID] AS Panel, DoorNames.[Kapi Adi] AS Kapi,AccessDatas.[Gecis Tipi] AS Gecis, AccessDatas.Tarih,Users.Adi AS [Personel Adi], Users.Soyadi AS [Personel Soyadi], Visitors.Resim FROM (((Visitors RIGHT JOIN AccessDatas ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No]) LEFT JOIN GroupsMaster ON Visitors.[Grup No] = GroupsMaster.[Grup No]) LEFT JOIN Users ON Visitors.ID = Users.ID) LEFT JOIN DoorNames ON (AccessDatas.[Kapi ID] = DoorNames.[Kapi No]) AND (AccessDatas.[Panel ID] = DoorNames.[Panel No]) WHERE AccessDatas.[Kullanici Tipi] = 1 ";
            if (parameters.All_Visitor != true)
            {
                if (parameters.Visitor != null)
                {
                    queryString += " AND AccessDatas.[Visitor Kayit No] =" + parameters.Visitor;
                }
                else
                {
                    queryString += " AND AccessDatas.[Visitor Kayit No] =" + 0;
                }
            }
            if (parameters.Gecis_Grubu != null)
            {
                queryString += " AND Visitors.[Grup No] =" + parameters.Gecis_Grubu;
            }
            if (parameters.Gecis_Tipi == 0)
            {
                queryString += " AND AccessDatas.[Kod] = 0";
            }
            else if (parameters.Gecis_Tipi == 1)
            {
                queryString += " AND AccessDatas.[Kod] = 1";
            }
            else if (parameters.Gecis_Tipi == 2)
            {
                queryString += " AND AccessDatas.[Kod] = 2";
            }

            if (parameters.Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + parameters.Panel;
            }
            if (parameters.Kapi.Count > 0 && parameters.Kapi != null)
            {
                string kapilar = "";
                foreach (var item in parameters.Kapi)
                {
                    kapilar += item + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            else
            {
                string kapilar = "";
                for (int i = 1; i < 17; i++)
                {
                    kapilar += i + ",";
                }
                kapilar = kapilar.Substring(0, kapilar.Length - 1);
                queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
            }
            if (parameters.Kapi_Yon == 0)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (parameters.Kapi_Yon == 1)
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            if (parameters.Tum_Tarih != true)
            {
                if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi == null)
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                }
                if (parameters.Baslangic_Tarihi != null && parameters.Bitis_Tarihi != null)
                {
                    if (parameters.Baslangic_Saati != null && parameters.Bitis_Saati != null)
                    {
                        var sonuc1 = parameters.Baslangic_Tarihi?.ToShortDateString() + " " + parameters.Baslangic_Saati?.ToLongTimeString();
                        var sonuc2 = parameters.Bitis_Tarihi?.ToShortDateString() + " " + parameters.Bitis_Saati?.ToLongTimeString();
                        queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103) ";
                        queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                    }
                    else
                    {
                        queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + parameters.Baslangic_Tarihi?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                        queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + parameters.Bitis_Tarihi?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    }

                }
            }
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<ZiyaretciRaporList> liste = new List<ZiyaretciRaporList>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new ZiyaretciRaporList
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Ziyaretci_Adi = reader[3].ToString(),
                            Ziyaretci_Soyadi = reader[4].ToString(),
                            Ziyaretci_TCKimlik = reader[5].ToString(),
                            Ziyaretci_Telefon = reader[6].ToString(),
                            Ziyaretci_Plaka = reader[7].ToString(),
                            Ziyaret_Sebebi = reader[8].ToString(),
                            Grup_Adi = reader[9].ToString(),
                            Panel_ID = reader[10] as int? ?? default(int),
                            Kapi = reader[11].ToString(),
                            Gecis_Tipi = reader[12] as int? ?? default(int),
                            Tarih = reader[13] as DateTime? ?? default(DateTime),
                            Personel_Adi = reader[14].ToString(),
                            Personel_Soyadi = reader[15].ToString(),
                            Ziyaretci_Resim = reader[16].ToString(),
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



        //İçerde-Dışarda Personel
        public List<IcerdeDisardaPersonel> GetIcerdeDisardaPersonels(IcerdeDisardaReportParameters parameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "";



            if (parameters.Bolge == "Lokal")
            {
                if (parameters.Kapi == "" || parameters.Kapi == null)
                {
                    parameters.Kapi = "1";
                }
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, TTT.Sirket, TTT.Departman,TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi AS Sirket, Departmanlar.Adi AS Departman,MAX(AccessDatas.[Tarih]) AS Tarih FROM Users LEFT OUTER JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No] LEFT OUTER JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] LEFT OUTER JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No] WHERE AccessDatas.[Lokal Bolge No] =" + parameters.Kapi + " AND AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.ID > 0 AND AccessDatas.Kod = 1 AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ") AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ") GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih WHERE AccessDatas.[Gecis Tipi] =" + parameters.Gecis;

            }
            else
            {
                if (parameters.Global_Kapi_Bolgesi == null)
                {
                    parameters.Global_Kapi_Bolgesi = 1;
                }

                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, TTT.Sirket, TTT.Departman,TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi,Sirketler.Adi AS Sirket, Departmanlar.Adi AS Departman,MAX(AccessDatas.[Tarih]) AS Tarih FROM Users LEFT OUTER JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No] LEFT OUTER JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] LEFT OUTER JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No] WHERE AccessDatas.[Global Bolge No] = " + parameters.Global_Kapi_Bolgesi + " AND AccessDatas.ID > 0  AND AccessDatas.Kod = 1  AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")  AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ") GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT  ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih WHERE AccessDatas.[Gecis Tipi] =" + parameters.Gecis;

            }
            List<IcerdeDisardaPersonel> liste = new List<IcerdeDisardaPersonel>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new IcerdeDisardaPersonel
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Adi = reader[3].ToString(),
                            Soyadi = reader[4].ToString(),
                            Sirket = reader[5].ToString(),
                            Departman = reader[6].ToString(),
                            Tarih = reader[7] as DateTime? ?? default(DateTime),
                            Gecis_Tipi = reader[8] as int? ?? default(int)
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



        //İçerde-Dışarda Ziyaretçi
        public List<IcerdeDısardaZiyaretci> GetIcerdeDısardaZiyaretci(IcerdeDisardaReportParameters parameters)
        {
            //TODO: Sorguda hata var ve sorgu içinde değişken tanımlamaları yapılacak
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "";
            if (parameters.Bolge == "Lokal")
            {
                //TODO: Lokal Bölge Gelecek
                if (parameters.Kapi == "" || parameters.Kapi == null)
                {
                    parameters.Kapi = "1";
                }
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, Visitors.[Ziyaret Sebebi], TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi, MAX(AccessDatas.[Tarih]) AS Tarih FROM Visitors LEFT OUTER JOIN AccessDatas ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No] WHERE AccessDatas.[Lokal Bolge No] =" + parameters.Kapi + " AND AccessDatas.[Kullanici Tipi] = 1 AND AccessDatas.[Visitor Kayit No] > 0 AND AccessDatas.Kod = 1 GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi) TTT ON AccessDatas.[Visitor Kayit No] = TTT.[Visitor Kayit No] AND AccessDatas.Tarih = TTT.Tarih LEFT OUTER JOIN Visitors ON AccessDatas.[Visitor Kayit No] = Visitors.[Kayit No] WHERE AccessDatas.[Gecis Tipi] =" + parameters.Gecis;

            }
            else
            {
                if (parameters.Global_Kapi_Bolgesi == null)
                {
                    parameters.Global_Kapi_Bolgesi = 1;
                }

                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi,TTT.[Ziyaret Sebebi],  TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,Visitors.[Ziyaret Sebebi], MAX(AccessDatas.[Tarih]) AS Tarih FROM Visitors LEFT OUTER JOIN AccessDatas ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No] WHERE AccessDatas.[Global Bolge No] = " + parameters.Global_Kapi_Bolgesi + " AND AccessDatas.[Kullanici Tipi] = 1 AND AccessDatas.[Visitor Kayit No] > 0 AND AccessDatas.Kod = 1 GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,Visitors.[Ziyaret Sebebi]) TTT ON AccessDatas.[Visitor Kayit No] = TTT.[Visitor Kayit No] AND AccessDatas.Tarih = TTT.Tarih WHERE AccessDatas.[Gecis Tipi] =" + parameters.Gecis;
            }
            List<IcerdeDısardaZiyaretci> liste = new List<IcerdeDısardaZiyaretci>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new IcerdeDısardaZiyaretci
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            Kart_ID = reader[1].ToString(),
                            Adi = reader[2].ToString(),
                            Soyadi = reader[3].ToString(),
                            Ziyaret_Sebebi = reader[4].ToString(),
                            Tarih = reader[5] as DateTime? ?? default(DateTime),
                            Gecis_Tipi = reader[6] as int? ?? default(int)
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


        //İçerde-Dışarda Tümü
        public List<IcerdeDısardaTümü> GetIcerdeDısardaTümü(IcerdeDisardaReportParameters parameters)
        {
            //TODO: Lokal Bölge Sirket numaraları ve geçiş tipleri gelecek
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "";
            if (parameters.Bolge == "Lokal")
            {
                if (parameters.Kapi == "" || parameters.Kapi == null)
                {
                    parameters.Kapi = "1";
                }
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, TTT2.Adi AS [Ziyaretçi Adi], TTT2.Soyadi AS [Ziyaretçi Soyadi],"
                          + "TTT.Sirket, TTT.Departman,"
                          + "TTT.Tarih, TTT2.Tarih, AccessDatas.[Gecis Tipi] "
                          + "FROM(AccessDatas "
                          + " LEFT JOIN"
                              + " (SELECT AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi,"
                              + " Sirketler.Adi AS Sirket, Departmanlar.Adi AS Departman,"
                              + " MAX(AccessDatas.[Tarih]) AS Tarih"
                              + " FROM Users"
                              + " LEFT OUTER JOIN AccessDatas"
                              + " ON Users.[Kayit No] = AccessDatas.[User Kayit No]"
                              + " LEFT OUTER JOIN Sirketler"
                              + " ON Users.[Sirket No] = Sirketler.[Sirket No]"
                              + " LEFT OUTER JOIN Departmanlar"
                              + " ON Users.[Departman No] = Departmanlar.[Departman No]"
                              + " WHERE AccessDatas.[Lokal Bolge No] =" + parameters.Kapi
                              + " AND AccessDatas.ID > 0"
                              + " AND AccessDatas.Kod = 1"
                              + " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")"
                              + " AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ")"
                              + " GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT"
                              + " ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih) ";


                queryString += " LEFT JOIN "
                                    + " (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,"
                                    + " MAX(AccessDatas.[Tarih]) AS Tarih"
                                    + " FROM Visitors"
                                    + " LEFT OUTER JOIN AccessDatas"
                                    + " ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No]"
                                    + " WHERE AccessDatas.[Lokal Bolge No] = " + parameters.Kapi
                                    + " AND AccessDatas.[Visitor Kayit No] > 0"
                                    + " AND AccessDatas.Kod = 1"
                                    + " GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi) TTT2"
                                    + " ON AccessDatas.[Visitor Kayit No] = TTT2.[Visitor Kayit No] AND AccessDatas.Tarih = TTT2.Tarih"
                                    + " WHERE AccessDatas.[Gecis Tipi] =" + parameters.Gecis
                                    + " AND(TTT.Adi IS NOT NULL OR TTT2.Adi IS NOT NULL)";
            }
            else
            {

                if (parameters.Global_Kapi_Bolgesi == null)
                {
                    parameters.Global_Kapi_Bolgesi = 1;
                }
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, TTT2.Adi AS [Ziyaretçi Adi], TTT2.Soyadi AS [Ziyaretçi Soyadi], "
                           + " TTT.Sirket, TTT.Departman,"
                           + " TTT.Tarih, TTT2.Tarih, AccessDatas.[Gecis Tipi] "
                           + " FROM(AccessDatas "
                           + " LEFT JOIN"
                               + " (SELECT AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi,"
                               + " Sirketler.Adi AS Sirket, Departmanlar.Adi AS Departman,"
                               + " MAX(AccessDatas.[Tarih]) AS Tarih"
                               + " FROM Users"
                               + " LEFT OUTER JOIN AccessDatas"
                               + " ON Users.[Kayit No] = AccessDatas.[User Kayit No]"
                               + " LEFT OUTER JOIN Sirketler"
                               + " ON Users.[Sirket No] = Sirketler.[Sirket No]"
                               + " LEFT OUTER JOIN Departmanlar"
                               + " ON Users.[Departman No] = Departmanlar.[Departman No]"
                               + " WHERE AccessDatas.[Global Bolge No] =" + parameters.Global_Kapi_Bolgesi
                               + " AND AccessDatas.ID > 0"
                               + " AND AccessDatas.Kod = 1"
                               + " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")"
                               + " AND Departmanlar.[Departman No] IN(10000," + departmanListesi + ")"
                               + " GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT"
                               + " ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih) ";

                queryString += "LEFT JOIN "
                                + " (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,"
                                + " MAX(AccessDatas.[Tarih]) AS Tarih"
                                + " FROM Visitors"
                                + " LEFT OUTER JOIN AccessDatas"
                                + " ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No]"
                                + " WHERE AccessDatas.[Global Bolge No] =" + parameters.Global_Kapi_Bolgesi
                                + " AND AccessDatas.[Visitor Kayit No] > 0"
                                + " AND AccessDatas.Kod = 1"
                                + " GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi) TTT2"
                                + " ON AccessDatas.[Visitor Kayit No] = TTT2.[Visitor Kayit No] AND AccessDatas.Tarih = TTT2.Tarih"
                                + " WHERE AccessDatas.[Gecis Tipi] =" + parameters.Gecis
                                + " AND(TTT.Adi IS NOT NULL OR TTT2.Adi IS NOT NULL)";
            }


            List<IcerdeDısardaTümü> liste = new List<IcerdeDısardaTümü>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new IcerdeDısardaTümü
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Adi = reader[3].ToString(),
                            Soyadi = reader[4].ToString(),
                            Ziyaretci_Adi = reader[5].ToString(),
                            Ziyaretci_Soyadi = reader[6].ToString(),
                            Sirket = reader[7].ToString(),
                            Departman = reader[8].ToString(),
                            Tarih = reader[9] as DateTime? ?? default(DateTime),
                            Ziyaret_Tarihi = reader[10] as DateTime? ?? default(DateTime),
                            Gecis_Tipi = reader[11] as int? ?? default(int)
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


        public List<WatchEntityComplex> GetWatch(WatchParameters watchParameters)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "";
            string CodeString = "";
            if (watchParameters != null)
            {
                if (watchParameters.Tumu != true)
                {
                    if (watchParameters.Normal == true)
                        CodeString += "1,";
                    if (watchParameters.Coklu == true)
                        CodeString += "3,";
                    if (watchParameters.Engellenen == true)
                        CodeString += "0,";
                    if (watchParameters.Antipassback == true)
                        CodeString += "2,";
                    if (watchParameters.Tanimsiz == true)
                        CodeString += "4,";
                    if (watchParameters.Manuel == true)
                        CodeString += "5,6,7,";
                    if (watchParameters.Programli == true)
                        CodeString += "9,10,14,";
                    if (watchParameters.Button == true)
                        CodeString += "8,";
                    if (watchParameters.AlarmYangin == true)
                        CodeString += "20,21,";
                    if (watchParameters.KapiAlarm == true)
                        CodeString += "22,23,24,";
                    if (watchParameters.DigerAlarm == true)
                        CodeString += "25,26,27,";

                    if (CodeString != "")
                    {
                        CodeString = CodeString.Substring(0, CodeString.Length - 1);
                    }


                    if (watchParameters.Operatorlog == true)
                    {
                        if (CodeString == "")
                        {
                            CodeString += " AccessDatas.Kod >= 100 ";
                        }
                        else
                        {
                            CodeString = " AND AccessDatas.Kod IN (" + CodeString + ")" + " OR AccessDatas.Kod >= 100 ";
                        }
                    }
                    else
                    {
                        if (CodeString != "")
                        {
                            CodeString = " AND AccessDatas.Kod IN (" + CodeString + ") ";
                        }
                    }
                }


            }






            //Client-Mod
            queryString = "SELECT DISTINCT TOP 100 AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID]," +
                " Users.Adi, Users.Soyadi, Users.TCKimlik, Sirketler.Adi AS Sirket," +
                " Departmanlar.Adi AS Departman," +
                " Users.Plaka, Bloklar.Adi AS Blok, Users.Daire," +
                " GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel," +
                " DoorNames.[Kapi Adi] As Kapi," +
                " AccessDatas.Tarih, AccessDatas.Kod, Users.Resim, CodeOperation.Operasyon," +
                " AccessDatas.[Kullanici Adi] As Operator, AccessDatas.[Islem Verisi 1], AccessDatas.[Islem Verisi 2],AccessDatas.[Gecis Tipi]" +
                " FROM (((AccessDatas LEFT JOIN (((Users LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) ON AccessDatas.ID = Users.ID) LEFT JOIN CodeOperation ON AccessDatas.Kod = CodeOperation.TKod) LEFT JOIN DoorNames ON AccessDatas.[Kapi ID] = DoorNames.[Kapi No]) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]" +
                " WHERE AccessDatas.[Panel ID] IN(200," + panelListesi + ")" +
                " OR Users.[Sirket No] IN(10000," + sirketListesi + ")" +
                " OR Users.[Departman No] IN(10000," + departmanListesi + ")";
            //Server-Mod
            //queryString = " SELECT DISTINCT TOP 100 AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID]," +
            //    "Users.Adi, Users.Soyadi, Users.TCKimlik, Sirketler.Adi AS Sirket, " +
            //    " Departmanlar.Adi AS Departman, " +
            //    " Users.Plaka, Bloklar.Adi AS Blok, Users.Daire, " +
            //    " GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel," +
            //    " ReaderSettingsNew.[WKapi Adi] As Kapi, " +
            //    " AccessDatas.Tarih, AccessDatas.Kod, Users.Resim, CodeOperation.Operasyon," +
            //    " AccessDatas.[Kullanici Adi] As Operator, AccessDatas.[Islem Verisi 1], AccessDatas.[Islem Verisi 2],AccessDatas.[Gecis Tipi] " +
            //    " FROM (((AccessDatas LEFT JOIN (((Users LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])" +
            //    " LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])" +
            //    " LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) ON AccessDatas.ID = Users.ID)" +
            //    " LEFT JOIN CodeOperation ON AccessDatas.Kod = CodeOperation.TKod)" +
            //    " LEFT JOIN ReaderSettingsNew ON AccessDatas.[Kapi ID] = ReaderSettingsNew.[WKapi ID] AND AccessDatas.[Panel ID] = ReaderSettingsNew.[Panel ID]) " +
            //    " LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No] ";
            queryString += CodeString;
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<WatchEntityComplex> liste = new List<WatchEntityComplex>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new WatchEntityComplex
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Adi = reader[3].ToString(),
                            Soyadi = reader[4].ToString(),
                            TCKimlik = reader[5].ToString(),
                            Sirket_Adi = reader[6].ToString(),
                            Departman_Adi = reader[7].ToString(),
                            Plaka = reader[8].ToString(),
                            Blok_Adi = reader[9].ToString(),
                            Daire = reader[10] as int? ?? default(int),
                            Grup_Adi = reader[11].ToString(),
                            Panel_ID = reader[12] as int? ?? default(int),
                            Kapi_Adi = reader[13].ToString(),
                            Tarih = reader[14] as DateTime? ?? default(DateTime),
                            Kod = reader[15] as int? ?? default(int),
                            Resim = reader[16].ToString(),
                            Operasyon = reader[17].ToString(),
                            Operator = reader[18].ToString(),
                            Islem_Verisi_1 = reader[19] as int? ?? default(int),
                            Islem_Verisi_2 = reader[20] as int? ?? default(int),
                            Gecis_Tipi = reader[21] as int? ?? default(int),
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


        public WatchEntityComplex LastRecordWatch(int? Kayit_No)
        {
            string address = ConfigurationManager.ConnectionStrings["ForaContext"].ConnectionString;
            string queryString = "";
            if (Kayit_No != null && Kayit_No > 0)
            {
                queryString = "SELECT DISTINCT TOP 1 AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID]," +
                                  " Users.Adi, Users.Soyadi, Users.TCKimlik, Sirketler.Adi AS Sirket," +
                                  " Departmanlar.Adi AS Departman," +
                                  " Users.Plaka, Bloklar.Adi AS Blok, Users.Daire," +
                                  " GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel," +
                                  " ReaderSettingsNew.[WKapi Adi] As Kapi," +
                                  " AccessDatas.Tarih, AccessDatas.Kod, Users.Resim, CodeOperation.Operasyon," +
                                  " AccessDatas.[Kullanici Adi] As Operator, AccessDatas.[Islem Verisi 1], AccessDatas.[Islem Verisi 2],AccessDatas.[Gecis Tipi]" +
                                  " FROM (((AccessDatas LEFT JOIN (((Users LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])" +
                                  " LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])" +
                                  " LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) ON AccessDatas.ID = Users.ID)" +
                                  " LEFT JOIN CodeOperation ON AccessDatas.Kod = CodeOperation.TKod)" +
                                  " LEFT JOIN ReaderSettingsNew ON AccessDatas.[Kapi ID] = ReaderSettingsNew.[WKapi ID] AND AccessDatas.[Panel ID] = ReaderSettingsNew.[Panel ID])" +
                                  " LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]" +
                                  " WHERE AccessDatas.[Panel ID] IN(200," + panelListesi + ")" +
                                  " AND Users.[Sirket No] IN(10000," + sirketListesi + ")" +
                                  " AND Users.[Departman No] IN(10000," + departmanListesi + ")" +
                                  " AND AccessDatas.[Kayit No] = " + Kayit_No;
            }
            else
            {
                queryString = "SELECT DISTINCT TOP 1 AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID]," +
                                   " Users.Adi, Users.Soyadi, Users.TCKimlik, Sirketler.Adi AS Sirket," +
                                   " Departmanlar.Adi AS Departman," +
                                   " Users.Plaka, Bloklar.Adi AS Blok, Users.Daire," +
                                   " GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel," +
                                   " ReaderSettingsNew.[WKapi Adi] As Kapi," +
                                   " AccessDatas.Tarih, AccessDatas.Kod, Users.Resim, CodeOperation.Operasyon," +
                                   " AccessDatas.[Kullanici Adi] As Operator, AccessDatas.[Islem Verisi 1], AccessDatas.[Islem Verisi 2],AccessDatas.[Gecis Tipi]" +
                                   " FROM (((AccessDatas LEFT JOIN (((Users LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])" +
                                   " LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])" +
                                   " LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) ON AccessDatas.ID = Users.ID)" +
                                   " LEFT JOIN CodeOperation ON AccessDatas.Kod = CodeOperation.TKod)" +
                                   " LEFT JOIN ReaderSettingsNew ON AccessDatas.[Kapi ID] = ReaderSettingsNew.[WKapi ID] AND AccessDatas.[Panel ID] = ReaderSettingsNew.[Panel ID])" +
                                   " LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]" +
                                   " WHERE AccessDatas.[Panel ID] IN(200," + panelListesi + ")" +
                                   " AND Users.[Sirket No] IN(10000," + sirketListesi + ")" +
                                   " AND Users.[Departman No] IN(10000," + departmanListesi + ")";
            }
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new WatchEntityComplex
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            ID = reader[1] as int? ?? default(int),
                            Kart_ID = reader[2].ToString(),
                            Adi = reader[3].ToString(),
                            Soyadi = reader[4].ToString(),
                            TCKimlik = reader[5].ToString(),
                            Sirket_Adi = reader[6].ToString(),
                            Departman_Adi = reader[7].ToString(),
                            Plaka = reader[8].ToString(),
                            Blok_Adi = reader[9].ToString(),
                            Daire = reader[10] as int? ?? default(int),
                            Grup_Adi = reader[11].ToString(),
                            Panel_ID = reader[12] as int? ?? default(int),
                            Kapi_Adi = reader[13].ToString(),
                            Tarih = reader[14] as DateTime? ?? default(DateTime),
                            Kod = reader[15] as int? ?? default(int),
                            Resim = reader[16].ToString(),
                            Operasyon = reader[17].ToString(),
                            Operator = reader[18].ToString(),
                            Islem_Verisi_1 = reader[19] as int? ?? default(int),
                            Islem_Verisi_2 = reader[20] as int? ?? default(int),
                            Gecis_Tipi = reader[21] as int? ?? default(int),
                        };
                        return nesne;
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
                return null;
            }
        }



        public void GetSirketList(DBUsers users)
        {
            if (users.SysAdmin == true)
            {
                var sirketler = _sirketDal.GetList().Select(a => a.Sirket_No).ToList();
                if (sirketler.Count > 0)
                {
                    sirketListesi = "";
                    foreach (var item in sirketler)
                    {
                        sirketListesi += item + ",";
                    }
                    sirketListesi = sirketListesi.Substring(0, sirketListesi.Length - 1);

                }
                else
                {
                    sirketListesi = "0";
                }
            }
            else
            {
                var sirketler = _dbUsersSirketDal.GetList(x => x.Kullanici_Adi == users.Kullanici_Adi).Select(x => x.Sirket_No).ToList();

                if (sirketler.Count > 0)
                {
                    sirketListesi = "";
                    foreach (var item in sirketler)
                    {
                        sirketListesi += item + ",";
                    }
                    sirketListesi = sirketListesi.Substring(0, sirketListesi.Length - 1);

                }
                else
                {
                    sirketListesi = "0";
                }
            }

        }


        public void GetDepartmanList(DBUsers users)
        {
            if (users.SysAdmin == true)
            {
                var departmanlar = _departmanDal.GetList().Select(a => a.Departman_No).ToList();
                if (departmanlar.Count > 0)
                {
                    departmanListesi = "";
                    foreach (var item in departmanlar)
                    {
                        departmanListesi += item + ",";
                    }
                    departmanListesi = departmanListesi.Substring(0, departmanListesi.Length - 1);
                }
                else
                {
                    departmanListesi = "0";
                }
            }
            else
            {
                var departmanlar = _dBUsersDepartmanDal.GetList(x => x.Kullanici_Adi == users.Kullanici_Adi).Select(x => x.Departman_No).ToList();
                if (departmanlar.Count > 0)
                {
                    departmanListesi = "";
                    foreach (var item in departmanlar)
                    {
                        departmanListesi += item + ",";
                    }
                    departmanListesi = departmanListesi.Substring(0, departmanListesi.Length - 1);
                }
                else
                {
                    departmanListesi = "0";
                }
            }
        }


        public void GetPanelList(DBUsers user)
        {
            if (user.SysAdmin == true)
            {
                var paneller = _panelSettingsDal.GetList(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0).Select(a => a.Panel_ID).ToList();
                panelListesi = "";
                if (paneller.Count > 0)
                {
                    panelListesi = "";
                    foreach (var item in paneller)
                    {
                        panelListesi += item + ",";
                    }
                    panelListesi = panelListesi.Substring(0, panelListesi.Length - 1);

                }
                else
                {
                    panelListesi = "0";
                }
            }
            else
            {
                var paneller = _dbUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).OrderBy(x => x.Kullanici_Adi).Select(x => x.Panel_No).ToList();
                panelListesi = "";
                if (paneller.Count > 0)
                {
                    panelListesi = "";
                    foreach (var item in paneller)
                    {
                        panelListesi += item + ",";
                    }
                    panelListesi = panelListesi.Substring(0, panelListesi.Length - 1);

                }
                else
                {
                    panelListesi = "0";
                }
            }
        }


        //TODO: Kayit No'suna göre manuel çıkış yapılacak İçerde Dışarda Raporu
        public void Guncelle(List<int> KayitNo)
        {
            if (KayitNo != null)
            {
                foreach (var item in KayitNo)
                {
                    var nesne = _accessDatasService.GetByKayit_No(item);
                    var kapiID = nesne.Kapi_ID;
                    var panelID = nesne.Panel_ID;
                    var kapiId = _doorNamesService.GetByKapiAdiAndPanelID(kapiID, panelID);
                    if (nesne.Gecis_Tipi == 0)
                    {
                        var newAccessDatas = new AccessDatas
                        {
                            Panel_ID = nesne.Panel_ID,
                            Lokal_Bolge_No = nesne.Lokal_Bolge_No,
                            Global_Bolge_No = nesne.Global_Bolge_No,
                            Kapi_ID = kapiId.Kapi_No,
                            ID = nesne.ID,
                            Kart_ID = nesne.Kart_ID,
                            Tarih = DateTime.Now,
                            Gecis_Tipi = 1,
                            Kod = nesne.Kod,
                            Kullanici_Tipi = nesne.Kullanici_Tipi,
                            Visitor_Kayit_No = nesne.Visitor_Kayit_No,
                            User_Kayit_No = nesne.User_Kayit_No,
                            Kontrol = nesne.Kontrol,
                            Plaka = nesne.Plaka
                        };
                        _accessDatasService.AddAccessData(newAccessDatas);
                    }
                }

            }
        }



    }
}
