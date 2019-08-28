using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AccessDatasManager : IAccessDatasService
    {
        private IAccessDatasDal _accessDatasDal;
        public AccessDatasManager(IAccessDatasDal accessDatasDal)
        {
            _accessDatasDal = accessDatasDal;
        }
        public AccessDatas AddAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Add(accessDatas);
        }

        public void DeleteAccessData(AccessDatas accessDatas)
        {
            _accessDatasDal.Delete(accessDatas);
        }

        public List<AccessDatas> GetAllAccessDatas()
        {
            return _accessDatasDal.GetList();
        }

        public AccessDatas GetById(int id)
        {
            return _accessDatasDal.Get(x => x.Kayit_No == id);
        }

        public AccessDatas UpdateAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Update(accessDatas);
        }

        public List<AccessDatas> GetByKod(int kod)
        {
            return _accessDatasDal.GetList(x => x.Kod == kod);
        }
        public List<int?> GetGecisTipi()
        {
            return _accessDatasDal.GetList().Select(x => x.Gecis_Tipi).ToList();
        }

        public List<AccessDatas> GetTanimsizListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon)
        {

            string queryString = " SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.[Kart ID],AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis, AccessDatas.Tarih, AccessDatas.[Canli Resim] FROM AccessDatas WHERE AccessDatas.Kod = 4";
            if (Panel != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + Panel;
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
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103)";
                queryString += " AND AccessDatas.Tarih <= CONVERT(SMALLDATETIME,'" + Tarih2 + "',103) ";
            }
            if (Tarih1 != null && Tarih2 == null)
            {
                queryString += " AND AccessDatas.Tarih >= CONVERT(SMALLDATETIME,'" + Tarih1 + "',103) ";
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
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";
            List<AccessDatas> liste = new List<AccessDatas>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE-1\ARGE;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
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

        public List<DigerGecisRaporList> GetDigerGecisListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon)
        {
            string queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod >= 5 AND AccessDatas.Kod <= 27";
            if (Tetikleme == "Tümü")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod >= 5 AND AccessDatas.Kod <= 27";

            }
            if (Tetikleme == "KAlarm")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod >= 22 AND AccessDatas.Kod <= 25";
            }

            if (Tetikleme == "OTetikleme")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 5 + "";
            }
            if (Tetikleme == "OAcma")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 6 + "";

            }
            if (Tetikleme == "OKapatma")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 7 + "";

            }
            if (Tetikleme == "OSerbest")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 13 + "";

            }
            if (Tetikleme == "BTetikleme")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 8 + "";

            }
            if (Tetikleme == "PAcma")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 9 + "";

            }
            if (Tetikleme == "PKapatma")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 10 + "";

            }
            if (Tetikleme == "PSerbest")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 14 + "";

            }
            if (Tetikleme == "Alarm")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 20 + "";

            }
            if (Tetikleme == "Yangin")
            {
                queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.[Panel ID] As Panel,AccessDatas.[Kapi ID] As Kapi, AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon, AccessDatas.Tarih FROM CodeOperation RIGHT JOIN AccessDatas ON CodeOperation.TKod = AccessDatas.Kod WHERE AccessDatas.Kod = " + 21 + "";

            }
            if (Paneller != null)
            {
                queryString += " AND AccessDatas.Panel =" + Paneller;
            }
            if (KapiYon == "giris")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (KapiYon == "cikis")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
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
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";

            List<DigerGecisRaporList> liste = new List<DigerGecisRaporList>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE-1\ARGE;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
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
        public List<DigerGecisRaporListKullaniciAlarm> GetDigerGecisRaporListKullaniciAlarms(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme, string KapiYon)
        {
            string queryString = "SELECT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID], Users.Adi, Users.Soyadi,Sirketler.Adi AS Sirket, AccessDatas.[Panel ID] As Panel, AccessDatas.[Kapi ID] As Kapi,AccessDatas.[Gecis Tipi] As Gecis,CodeOperation.Operasyon,AccessDatas.Tarih FROM (CodeOperation RIGHT JOIN (AccessDatas RIGHT JOIN (Users RIGHT JOIN Sirketler ON Sirketler.[Sirket No] = Users.[Sirket No]) ON Users.ID = AccessDatas.ID) ON CodeOperation.TKod = AccessDatas.Kod )WHERE AccessDatas.Kod >= 26 AND AccessDatas.Kod <= 27";


            if (Paneller != null)
            {
                queryString += " AND AccessDatas.Panel =" + Paneller;
            }
            if (KapiYon == "giris")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 0";
            }
            if (KapiYon == "cikis")
            {
                queryString += " AND AccessDatas.[Gecis Tipi] = 1";
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
            queryString += " ORDER BY AccessDatas.[Kayit No] DESC";

            List<DigerGecisRaporListKullaniciAlarm> liste = new List<DigerGecisRaporListKullaniciAlarm>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE-1\ARGE;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
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


    }
}
