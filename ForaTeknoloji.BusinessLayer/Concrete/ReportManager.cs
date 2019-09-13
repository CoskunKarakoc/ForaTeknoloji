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
        public string panelListesi = "0";
        public string sirketListesi = "0";
        public List<int?> sirketler;
        public ReportManager(IVisitorsDal visitorsDal, IGroupsDetailDal groupsDetailDal, IGlobalZoneDal globalZoneDal, ISirketDal sirketDal, IBloklarDal bloklarDal, IDepartmanDal departmanDal, IPanelSettingsDal panelSettingsDal, IReaderSettingDal readerSettingDal, IAccessDatasService accessDatasService, IDBUsersPanelsService dbUsersPanelsService, IDBUsersSirketDal dBUsersSirketDal)
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

        }

        //=====>Tamamlandı<=====
        //OutherReport Controller
        public List<DigerGecisRaporList> GetDigerGecisListesi(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, int Tetikleme, string KapiYon)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod >= 5 AND AccessDatas.Kod <= 27";
            if (Tetikleme == 100)
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,"
                              + " DoorNames.[Kapi Adi] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                              + " CodeOperation.Operasyon, AccessDatas.Tarih"
                              + " FROM(CodeOperation RIGHT JOIN"
                              + " (AccessDatas RIGHT JOIN DoorNames ON AccessDatas.[Panel ID] = DoorNames.[Panel No] AND AccessDatas.[Kapi ID] = DoorNames.[Kapi No])"
                              + " ON CodeOperation.TKod = AccessDatas.Kod )"
                              + " WHERE AccessDatas.Kod >= 5 AND AccessDatas.Kod <= 27";

            }
            else if (Tetikleme >= 40)
            {
                int TetiklemePlus = Tetikleme + 1;
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel, "
                           + " AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                           + " CodeOperation.Operasyon, AccessDatas.Tarih"
                           + " FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod"
                           + " WHERE AccessDatas.Kod >= " + Tetikleme + " AND AccessDatas.Kod <= " + TetiklemePlus;
            }
            else if (Tetikleme >= 20 && Tetikleme <= 21)
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel, "
                   + " AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,"
                   + " CodeOperation.Operasyon, AccessDatas.Tarih"
                   + " FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod"
                   + " WHERE AccessDatas.Kod = " + Tetikleme;

            }
            else if (Tetikleme == 22)
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
                   + " WHERE AccessDatas.Kod = " + Tetikleme;
            }
            queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            if (Paneller != null)
            {
                queryString += " AND AccessDatas.[Panel ID]=" + Paneller;
            }
            if (Tümü != true)
            {
                if (Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            if (Tarih1 != null && Tarih2 == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih1?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (Tarih1 != null && Tarih2 != null)
            {
                if (Saat1 != null && Saat2 != null)
                {
                    var sonuc1 = Tarih1?.ToShortDateString() + " " + Saat1?.ToLongTimeString();
                    var sonuc2 = Tarih2?.ToShortDateString() + " " + Saat2?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103)";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >='" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                    queryString += " AND AccessDatas.Tarih <='" + Tarih2?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                }
            }
            if (KapiYon == "giris")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (KapiYon == "cikis")
            {
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
                            Kapi_ID = reader[2] as int? ?? default(int),
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
        public List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, int Tetikleme, string KapiYon)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = " SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi, "
                   + " Sirketler.Adi AS Sirket, AccessDatas.[Panel ID] As Panel, DoorNames.[Kapi Adi] As Kapi,"
                   + " AccessDatas.[Gecis Tipi] As Gecis, CodeOperation.Operasyon,"
                   + " AccessDatas.Tarih"
                   + " FROM DoorNames RIGHT JOIN(CodeOperation RIGHT JOIN (AccessDatas RIGHT JOIN (Users RIGHT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) ON AccessDatas.ID = Users.ID) ON CodeOperation.TKod = AccessDatas.Kod) ON(DoorNames.[Kapi No] = AccessDatas.[Kapi ID]) AND(DoorNames.[Panel No] = AccessDatas.[Panel ID])"
                   + " WHERE AccessDatas.Kod >= 26 AND AccessDatas.Kod <= 27 ";
            queryString += " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            if (Paneller != null)
            {
                queryString += " AND AccessDatas.[Panel ID]=" + Paneller;
            }
            if (Tümü != true)
            {
                if (Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            if (Tarih1 != null && Tarih2 == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih1?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (Tarih1 != null && Tarih2 != null)
            {
                if (Saat1 != null && Saat2 != null)
                {
                    var sonuc1 = Tarih1?.ToShortDateString() + " " + Saat1?.ToLongTimeString();
                    var sonuc2 = Tarih2?.ToShortDateString() + " " + Saat2?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103)";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >='" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                    queryString += " AND AccessDatas.Tarih <='" + Tarih2?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "'";
                }
            }
            if (KapiYon == "giris")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (KapiYon == "cikis")
            {
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
        public List<GelenGelmeyen_Gelmeyen> GelenGelmeyen_Gelmeyens(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = " SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi,Users.TCKimlik, Sirketler.Adi AS Şirket,Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi], Users.Resim FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No])LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No])LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No])LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0";

            if (sirketListesi != null)
            {
                //queryString += " AND Sirketler.[Sirket No] IN(1000," + sirketListesi + ")";
            }
            if (Sirketler != null)
            {
                queryString += " AND Users.[Sirket No] = " + Sirketler;
            }
            if (Departmanlar != null)
            {
                queryString += " AND Users.[Departman No] = " + Departmanlar;
            }
            if (Groupsdetail != null)
            {
                queryString += " AND Users.[Grup No] = " + Groupsdetail;
            }

            queryString += " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            if (Tarih != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih?.Date.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (Global_Bolge_Adi != null)
            {

                int max_Panel = 99;
                string tmpQuery = "";
                List<PanelSettings> panels = new List<PanelSettings>();

                var pnesne = _panelSettingsDal.GetList(x => x.Global_Bolge_No == Global_Bolge_Adi && x.Seri_No != null && x.Panel_IP1 != null && x.Panel_TCP_Port != null);
                var rnesne = _readerSettingDal.GetList();
                if (pnesne != null && pnesne.Count >= 0)
                {
                    for (int i = 0; i < pnesne.Count; i++)
                    {
                        if (tmpQuery == "")
                        {
                            tmpQuery += "(AccessDatas.[Panel ID] = " + pnesne[i].Panel_ID + " AND AccessDatas.[Kapi ID] IN(200,";
                        }
                        else
                        {
                            tmpQuery += " OR (AccessDatas.[Panel ID] = " + panels[i].Panel_ID + " AND AccessDatas.[Kapi ID] IN(200,";
                        }

                    }
                    for (int j = 1; j < 4; j++)
                    {
                        if (rnesne[6].WKapi1_Lokal_Bolge == Global_Bolge_Adi)
                        {
                            tmpQuery += j + ",";
                        }
                    }
                    tmpQuery = tmpQuery.Substring(0, tmpQuery.Length - 1);
                    tmpQuery += "))";
                }
                queryString += " AND " + tmpQuery;

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
        public List<GelenGelmeyen_Gelenler> GelenGelmeyen_Gelenlers(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi, Users.TCKimlik, Sirketler.Adi AS Şirket,  Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire, GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi], Users.Resim FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0 ";
            queryString += " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            if (Sirketler != null)
            {
                queryString += " AND Users.[Sirket No] =" + Sirketler;
            }
            if (Departmanlar != null)
            {
                queryString += " AND Users.[Departman No] =" + Departmanlar;
            }
            if (Groupsdetail != null)
            {
                queryString += " AND Users.[Grup No] =" + Groupsdetail;
            }

            queryString += " AND Users.[Kart ID] IN (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            if (Global_Bolge_Adi != null)
            {

            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            }
            if (Tarih != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih?.AddSeconds(1).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih?.AddHours(23).AddMinutes(59).AddSeconds(59).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
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
        public List<GelenGelmeyen_PasifKullanici> GelenGelmeyen_PasifKullanicis(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih, double? Fark)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "SELECT Users.ID, Users.[Kart ID], Users.Adi, Users.Soyadi, Users.TCKimlik, Sirketler.Adi AS Şirket, Departmanlar.Adi AS Departman, Users.Plaka, Bloklar.Adi AS Blok, Users.Daire, GroupsMaster.[Grup Adi] AS [Geçiş Grubu], Users.Tmp AS [Global Bolge Adi] FROM (((Users LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] WHERE Users.ID > 0 ";
            queryString += "AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";
            if (Sirketler != null)
            {
                queryString += " AND Users.[Sirket No] =" + Sirketler;
            }
            if (Departmanlar != null)
            {
                queryString += " AND Users.[Departman No] =" + Departmanlar;
            }
            if (Groupsdetail != null)
            {
                queryString += " AND Users.[Grup No] =" + Groupsdetail;
            }

            queryString += " AND Users.[Kart ID] <> ALL (SELECT DISTINCT AccessDatas.[Kart ID] FROM AccessDatas WHERE AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.Kod = 1";

            if (Global_Bolge_Adi != null)
            {
                queryString += "";
            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            }
            if (Tarih != null)
            {
                Fark = Fark * -1;
                var baslangicTarihi = Tarih?.Date.AddDays((double)Fark).AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss");

                var dentarr = Tarih?.AddDays((double)Fark).Date.ToString("yyyy/mm/dd");
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + baslangicTarihi + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

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
        public List<GelenGelmeyen_IlkGirisSonCikis> GelenGelmeyen_IlkGirisSonCikis(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? UserID, DateTime? Tarih1, DateTime? Tarih2)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
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
            if (UserID != null)
            {
                queryString += " AND AccessDatas.ID =" + UserID;
            }
            if (Groupsdetail != null)
            {
                queryString += " AND Users.[Grup No] =" + Groupsdetail;
            }
            if (Departmanlar != null)
            {
                queryString += " AND Users.[Departman No] =" + Departmanlar;
            }
            if (Sirketler != null)
            {
                queryString += " AND Users.[Sirket No] =" + Sirketler;

            }
            if (Global_Bolge_Adi != null)
            {

            }
            else
            {
                queryString += " AND AccessDatas.[Panel ID] IN(200," + panelListesi + ")";
            }
            if (Tarih1 != null && Tarih2 != null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.Date.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

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



        public List<GelenGelmeyen_ToplamIcerdeKalma> GelenGelmeyen_ToplamIcerdeKalmas(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? UserID, DateTime? Tarih1, DateTime? Tarih2)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "SELECT a.ID, a.[Kart ID], Users.Adi, Users.Soyadi, Sirketler.Adi AS Şirket, Departmanlar.Adi AS Departman, GroupsMaster.[Grup Adi] AS Grup, CONVERT(VARCHAR(10), a.Tarih, 103) AS [Tarih Değeri], a.Tarih AS log_in, COALESCE( (SELECT min(Tarih) FROM AccessDatas as b WHERE a.ID = b.ID AND CAST(a.Tarih AS DATE) = CAST(b.Tarih AS DATE) AND b.Tarih >= a.Tarih AND b.[Gecis Tipi] = 1), a.Tarih) as log_out FROM (AccessDatas AS a LEFT JOIN (((Users LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No]) ON a.ID = Users.ID) LEFT JOIN GroupsMaster ON Users.[Grup No] = GroupsMaster.[Grup No] WHERE a.[Kullanici Tipi] = 0 AND a.Kod = 1 AND a.[Gecis Tipi] = 0 AND a.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.Date.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) AND a.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2?.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            queryString += "AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")";


            if (UserID != null)
            {
                queryString += " AND a.ID =" + UserID;
            }
            if (Groupsdetail != null)
            {
                queryString += " AND Users.[Grup No] =" + Groupsdetail;
            }
            if (Departmanlar != null)
            {
                queryString += " AND Users.[Departman No] =" + Departmanlar;
            }
            if (Sirketler != null)
            {
                queryString += " AND Users.[Sirket No] =" + Sirketler;

            }
            if (Global_Bolge_Adi != null)
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

        //=====>Tamamlandı<=====
        //PersonelListReport Controller
        public List<PersonelList> GetPersonelLists(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail, int? GlobalBolgeNo, int? Daire, string Plaka = null)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
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



        //ReportPersonel Controller
        public List<ReportPersonelList> GetReportPersonelLists(List<string> Kapi, bool? Günlük, bool? Tümü, bool? TümKullanici, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Visitors, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kullanici = null, string Kayit = null)
        {

            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],Users.Adi, Users.Soyadi, Users.TCKimlik, Users.Telefon, Sirketler.Adi AS Sirket,Departmanlar.Adi AS Departman,Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, Users.Resim, AccessDatas.[Canli Resim] FROM (((GroupsMaster RIGHT JOIN (Users LEFT JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = Users.[Grup No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No] WHERE AccessDatas.[Kullanici Tipi] = 0 ";
            var SirketAdi = _sirketDal.Get(x => x.Sirket_No == Sirketler);
            var DepartmanAdi = _departmanDal.Get(x => x.Departman_No == Departmanlar);
            var GroupDetail = _groupsDetailDal.Get(x => x.Grup_No == Groupsdetail);
            var Blok = _bloklarDal.Get(x => x.Blok_No == Bloklar);

            if (Kullanici == "Aktif")
            {
                queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],Users.Adi, Users.Soyadi, Users.TCKimlik, Users.Telefon, Sirketler.Adi AS Sirket,Departmanlar.Adi AS Departman,Users.Plaka, Bloklar.Adi AS Blok, Users.Daire,GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, Users.Resim, AccessDatas.[Canli Resim] FROM (((GroupsMaster RIGHT JOIN (Users LEFT JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = Users.[Grup No]) LEFT JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON Users.[Blok No] = Bloklar.[Blok No] WHERE AccessDatas.[Kullanici Tipi] = 0";
                if (TümKullanici == null)
                {
                    if (Visitors != null)
                    {
                        queryString += " AND AccessDatas.[User Kayit No] =" + Visitors;
                    }
                    else
                    {
                        queryString += " AND AccessDatas.[User Kayit No] = 0";
                    }
                }
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
                if (Plaka != null && Plaka != "")
                {
                    queryString += " AND Users.[Plaka] ='" + Plaka + "'";
                }

            }
            else if (Kullanici == "Eski")
            {
                queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],UsersOLD.Adi, UsersOLD.Soyadi, UsersOLD.TCKimlik, UsersOLD.Telefon, Sirketler.Adi AS Sirket,Departmanlar.Adi AS Departman,UsersOLD.Plaka, Bloklar.Adi AS Blok, UsersOLD.Daire,GroupsMaster.[Grup Adi], AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, UsersOLD.Resim, AccessDatas.[Canli Resim] FROM (((GroupsMaster RIGHT JOIN (UsersOLD LEFT JOIN AccessDatas ON UsersOLD.[User Kayit No] = AccessDatas.[User Kayit No]) ON GroupsMaster.[Grup No] = UsersOLD.[Grup No]) LEFT JOIN Sirketler ON UsersOLD.[Sirket No] = Sirketler.[Sirket No]) LEFT JOIN Departmanlar ON UsersOLD.[Departman No] = Departmanlar.[Departman No]) LEFT JOIN Bloklar ON UsersOLD.[Blok No] = Bloklar.[Blok No] WHERE AccessDatas.[Kullanici Tipi] = 0";
                if (TümKullanici == null)
                {
                    if (Visitors != null)
                    {
                        queryString += " AND AccessDatas.[User Kayit No] =" + Visitors;
                    }
                    else
                    {
                        queryString += " AND AccessDatas.[User Kayit No] = 0";
                    }
                }
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
                if (Plaka != null && Plaka != "")
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
            if (Tümü != true)
            {
                if (Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            if (Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + Panel;
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
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih1?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
            }
            if (Tarih1 != null && Tarih2 != null)
            {
                if (Saat1 != null && Saat2 != null)
                {
                    var sonuc1 = Tarih1?.ToShortDateString() + " " + Saat1?.ToLongTimeString();
                    var sonuc2 = Tarih2?.ToShortDateString() + " " + Saat2?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103) ";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                }

            }
            //if (Saat1 != null && Saat2 == null)
            //{
            //    queryString += "";
            //}

            if (Günlük != null && Tarih1 != null && Tarih2 != null && Saat1 != null && Saat2 != null)
            {
                queryString += " AND CAST(AccessDatas.Tarih AS DATE) >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND CAST(AccessDatas.Tarih AS DATE) <= CONVERT(SMALLDATETIME,'" + Tarih2?.AddHours(23).AddMinutes(59).AddSeconds(59).Date.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND CAST(AccessDatas.Tarih AS TIME) >= '" + Saat1?.ToLongTimeString() + "' ";
                queryString += " AND CAST(AccessDatas.Tarih AS TIME) <= '" + Saat2?.ToLongTimeString() + "'";
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



        //UndefinedUserReport Controller
        public List<AccessDatas> GetTanimsizListesi(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = " SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.[Kart ID],AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, AccessDatas.[Canli Resim] FROM AccessDatas WHERE AccessDatas.Kod = 4";
            if (Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + Panel;
            }
            if (Tümü != true)
            {
                if (Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            if (KapiYon == "giris")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (KapiYon == "cikis")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }

            if (Tarih1 != null && Tarih2 != null)
            {
                if (Saat1 != null && Saat2 != null)
                {
                    var sonuc1 = Tarih1?.ToShortDateString() + " " + Saat1?.ToLongTimeString();
                    var sonuc2 = Tarih2?.ToShortDateString() + " " + Saat2?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("") + "',103)";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2?.AddHours(23).AddMinutes(59).AddSeconds(59) + "',103)";
                }

            }
            if (Tarih1 != null && Tarih2 == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih1?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
            }

            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<AccessDatas> liste = new List<AccessDatas>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var nesne = new AccessDatas
                        {
                            Kayit_No = reader[0] as int? ?? default(int),
                            Kart_ID = reader[1].ToString(),
                            Panel_ID = reader[2] as int? ?? default(int),
                            Kapi_ID = reader[3] as int? ?? default(int),
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
        public List<ZiyaretciRaporList> GetZiyaretciListesi(List<string> Kapi, bool? Tümü, int? Visitors, int? Global_Bolge_Adi, int? Groupsdetail, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Kayit, string KapiYon)
        {
            //TODO: Global Zone düzeltilecek
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            var GroupDetail = _groupsDetailDal.Get(x => x.Kayit_No == Groupsdetail);
            var GlobalZone = _globalZoneDal.Get(x => x.Global_Bolge_No == Global_Bolge_Adi);
            string queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],Visitors.Adi, Visitors.Soyadi, Visitors.TCKimlik, Visitors.Telefon, Visitors.Plaka,Visitors.[Ziyaret Sebebi], GroupsMaster.[Grup Adi],AccessDatas.[Panel ID] AS Panel, AccessDatas.[Kapi ID] AS Kapi,AccessDatas.[Gecis Tipi] AS Gecis, AccessDatas.Tarih,Users.Adi AS [Personel Adi], Users.Soyadi AS [Personel Soyadi], Visitors.Resim FROM ((Visitors RIGHT JOIN AccessDatas ON Visitors.[Kayit No]=AccessDatas.[Visitor Kayit No]) LEFT JOIN GroupsMaster ON Visitors.[Grup No]=GroupsMaster.[Grup No]) LEFT JOIN Users ON Visitors.ID=Users.ID WHERE AccessDatas.[Kullanici Tipi] = 1 ";
            if (Visitors != null)
            {
                queryString += " AND AccessDatas.[Visitor Kayit No] =" + Visitors;
            }
            if (GroupDetail != null)
            {
                queryString += " AND Visitors.[Grup No] =" + GroupDetail.Grup_No;
            }
            if (Kayit == "Engellenen")
            {
                queryString += " AND AccessDatas.[Kod] = 0";
            }
            if (Kayit == "OnaylananGecisler")
            {
                queryString += " AND AccessDatas.[Kod] = 1";
            }
            if (Kayit == "Antipassback")
            {
                queryString += " AND AccessDatas.[Kod] = 2";
            }

            if (Paneller != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + Paneller;
            }
            if (Tümü != true)
            {
                if (Kapi != null)
                {
                    string kapilar = "";
                    foreach (var item in Kapi)
                    {
                        kapilar += item + ",";
                    }
                    kapilar = kapilar.Substring(0, kapilar.Length - 1);
                    queryString += " AND AccessDatas.[Kapi ID] IN(" + kapilar + ")";
                }

            }
            if (KapiYon == "giris")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (KapiYon == "cikis")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
            }
            if (Tarih1 != null && Tarih2 == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih1?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            }
            if (Tarih1 != null && Tarih2 != null)
            {
                if (Saat1 != null && Saat2 != null)
                {
                    var sonuc1 = Tarih1?.ToShortDateString() + " " + Saat1?.ToLongTimeString();
                    var sonuc2 = Tarih2?.ToShortDateString() + " " + Saat2?.ToLongTimeString();
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + sonuc1 + "',103) ";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + sonuc2 + "',103) ";
                }
                else
                {
                    queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1?.AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";
                    queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2?.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
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
                            Kapi_ID = reader[11] as int? ?? default(int),
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
        public List<IcerdeDisardaPersonel> GetIcerdeDisardaPersonels(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis)
        {
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "";



            if (Bolge == "Lokal")
            {
                if (Kapi == null)
                {
                    Kapi = "1";
                }
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, TTT.Sirket, TTT.Departman,TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi AS Sirket, Departmanlar.Adi AS Departman,MAX(AccessDatas.[Tarih]) AS Tarih FROM Users LEFT OUTER JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No] LEFT OUTER JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] LEFT OUTER JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No] WHERE AccessDatas.[Lokal Bolge No] =" + Kapi + " AND AccessDatas.[Kullanici Tipi] = 0 AND AccessDatas.ID > 0 AND AccessDatas.Kod = 1 AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ") GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih WHERE AccessDatas.[Gecis Tipi] =" + Gecis;

            }
            else
            {
                if (Global_Bolge_Adi == null)
                {
                    Global_Bolge_Adi = 1;
                }

                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, TTT.Sirket, TTT.Departman,TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi,Sirketler.Adi AS Sirket, Departmanlar.Adi AS Departman,MAX(AccessDatas.[Tarih]) AS Tarih FROM Users LEFT OUTER JOIN AccessDatas ON Users.[Kayit No] = AccessDatas.[User Kayit No] LEFT OUTER JOIN Sirketler ON Users.[Sirket No] = Sirketler.[Sirket No] LEFT OUTER JOIN Departmanlar ON Users.[Departman No] = Departmanlar.[Departman No] WHERE AccessDatas.[Global Bolge No] = " + Global_Bolge_Adi + " AND AccessDatas.ID > 0  AND AccessDatas.Kod = 1  AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ") GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT  ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih WHERE AccessDatas.[Gecis Tipi] =" + Gecis;

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
        public List<IcerdeDısardaZiyaretci> GetIcerdeDısardaZiyaretci(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis)
        {
            //TODO: Sorguda hata var ve sorgu içinde değişken tanımlamaları yapılacak
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "";
            if (Bolge == "Lokal")
            {
                //TODO: Lokal Bölge Gelecek
                if (Kapi == null)
                {
                    Kapi = "1";
                }
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi, Visitors.[Ziyaret Sebebi], TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi, MAX(AccessDatas.[Tarih]) AS Tarih FROM Visitors LEFT OUTER JOIN AccessDatas ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No] WHERE AccessDatas.[Lokal Bolge No] =" + Kapi + " AND AccessDatas.[Kullanici Tipi] = 1 AND AccessDatas.[Visitor Kayit No] > 0 AND AccessDatas.Kod = 1 GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi) TTT ON AccessDatas.[Visitor Kayit No] = TTT.[Visitor Kayit No] AND AccessDatas.Tarih = TTT.Tarih LEFT OUTER JOIN Visitors ON AccessDatas.[Visitor Kayit No] = Visitors.[Kayit No] WHERE AccessDatas.[Gecis Tipi] =" + Gecis;

            }
            else
            {
                if (Global_Bolge_Adi == null)
                {
                    Global_Bolge_Adi = 1;
                }

                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Kart ID], TTT.Adi, TTT.Soyadi,TTT.[Ziyaret Sebebi],  TTT.Tarih, AccessDatas.[Gecis Tipi] FROM AccessDatas INNER JOIN (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,Visitors.[Ziyaret Sebebi], MAX(AccessDatas.[Tarih]) AS Tarih FROM Visitors LEFT OUTER JOIN AccessDatas ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No] WHERE AccessDatas.[Global Bolge No] = " + Global_Bolge_Adi + " AND AccessDatas.[Kullanici Tipi] = 1 AND AccessDatas.[Visitor Kayit No] > 0 AND AccessDatas.Kod = 1 GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,Visitors.[Ziyaret Sebebi]) TTT ON AccessDatas.[Visitor Kayit No] = TTT.[Visitor Kayit No] AND AccessDatas.Tarih = TTT.Tarih WHERE AccessDatas.[Gecis Tipi] =" + Gecis;
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
        public List<IcerdeDısardaTümü> GetIcerdeDısardaTümü(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis)
        {
            //TODO: Lokal Bölge Sirket numaraları ve geçiş tipleri gelecek
            string address = ConfigurationManager.AppSettings["ForaConnection"];
            string queryString = "";
            if (Bolge == "Lokal")
            {
                if (Kapi == null)
                {
                    Kapi = "1";
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
                              + " WHERE AccessDatas.[Lokal Bolge No] =" + Kapi
                              + " AND AccessDatas.ID > 0"
                              + " AND AccessDatas.Kod = 1"
                              + " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")"
                              + " GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT"
                              + " ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih) ";


                queryString += " LEFT JOIN "
                                    + " (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,"
                                    + " MAX(AccessDatas.[Tarih]) AS Tarih"
                                    + " FROM Visitors"
                                    + " LEFT OUTER JOIN AccessDatas"
                                    + " ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No]"
                                    + " WHERE AccessDatas.[Lokal Bolge No] = " + Kapi
                                    + " AND AccessDatas.[Visitor Kayit No] > 0"
                                    + " AND AccessDatas.Kod = 1"
                                    + " GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi) TTT2"
                                    + " ON AccessDatas.[Visitor Kayit No] = TTT2.[Visitor Kayit No] AND AccessDatas.Tarih = TTT2.Tarih"
                                    + " WHERE AccessDatas.[Gecis Tipi] =" + Gecis
                                    + " AND(TTT.Adi IS NOT NULL OR TTT2.Adi IS NOT NULL)";
            }
            else
            {

                if (Global_Bolge_Adi == null)
                {
                    Global_Bolge_Adi = 1;
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
                               + " WHERE AccessDatas.[Global Bolge No] =" + Global_Bolge_Adi
                               + " AND AccessDatas.ID > 0"
                               + " AND AccessDatas.Kod = 1"
                               + " AND Sirketler.[Sirket No] IN(10000," + sirketListesi + ")"
                               + " GROUP BY AccessDatas.[User Kayit No], Users.Adi, Users.Soyadi, Sirketler.Adi, Departmanlar.Adi) TTT"
                               + " ON AccessDatas.[User Kayit No] = TTT.[User Kayit No] AND AccessDatas.Tarih = TTT.Tarih) ";

                queryString += "LEFT JOIN "
                                + " (SELECT AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi,"
                                + " MAX(AccessDatas.[Tarih]) AS Tarih"
                                + " FROM Visitors"
                                + " LEFT OUTER JOIN AccessDatas"
                                + " ON Visitors.[Kayit No] = AccessDatas.[Visitor Kayit No]"
                                + " WHERE AccessDatas.[Global Bolge No] =" + Global_Bolge_Adi
                                + " AND AccessDatas.[Visitor Kayit No] > 0"
                                + " AND AccessDatas.Kod = 1"
                                + " GROUP BY AccessDatas.[Visitor Kayit No], Visitors.Adi, Visitors.Soyadi) TTT2"
                                + " ON AccessDatas.[Visitor Kayit No] = TTT2.[Visitor Kayit No] AND AccessDatas.Tarih = TTT2.Tarih"
                                + " WHERE AccessDatas.[Gecis Tipi] =" + Gecis
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




        //Kullanıcı adına göre Sirket Listesi döndürüyor
        public void GetSirketList(DBUsers users)
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

        //Kullanıcı adına göre Panel Listesi döndürüyor
        public void GetPanelList(DBUsers user)
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


        //TODO: Kayit No'suna göre manuel çıkış yapılacak İçerde Dışarda Raporu
        public void Guncelle(List<int> KayitNo)
        {
            if (KayitNo != null)
            {
                foreach (var item in KayitNo)
                {
                    var nesne = _accessDatasService.GetByKayit_No(item);
                    if (nesne.Gecis_Tipi == 0)
                    {
                        var newAccessDatas = new AccessDatas
                        {
                            Panel_ID = nesne.Panel_ID,
                            Lokal_Bolge_No = nesne.Lokal_Bolge_No,
                            Global_Bolge_No = nesne.Global_Bolge_No,
                            Kapi_ID = nesne.Kapi_ID,
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
