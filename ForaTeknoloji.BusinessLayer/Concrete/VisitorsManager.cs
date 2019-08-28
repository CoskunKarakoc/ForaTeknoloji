using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class VisitorsManager : IVisitorsService
    {
        private IVisitorsDal _visitorsDal;
        private IGroupsDetailDal _groupsDetailDal;
        private IGlobalZoneDal _globalZoneDal;
        public VisitorsManager(IVisitorsDal visitorsDal, IGroupsDetailDal groupsDetailDal, IGlobalZoneDal globalZoneDal)
        {
            _visitorsDal = visitorsDal;
            _groupsDetailDal = groupsDetailDal;
            _globalZoneDal = globalZoneDal;
        }
        public Visitors AddVisitor(Visitors visitors)
        {
            return _visitorsDal.Add(visitors);
        }

        public void DeleteVisitor(Visitors visitors)
        {
            _visitorsDal.Delete(visitors);
        }

        public List<Visitors> GetAllVisitors(Expression<Func<Visitors, bool>> filter = null)
        {
            return _visitorsDal.GetList(filter);
        }

        public Visitors GetById(int id)
        {
            return _visitorsDal.Get(x => x.Kayit_No == id);
        }

        public Visitors UpdateVisitor(Visitors visitors)
        {
            return _visitorsDal.Update(visitors);
        }

        public List<ZiyaretciRaporList> GetZiyaretciListesi(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, int? Global_Bolge_Adi, int? Groupsdetail, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Kayit, string KapiYon)
        {
            string Visitors = "";//Buraya Aslında ziyaretçiler gelecek
            var GroupDetail = _groupsDetailDal.Get(x => x.Kayit_No == Groupsdetail);
            var GlobalZone = _globalZoneDal.Get(x => x.Global_Bolge_No == Global_Bolge_Adi);
            string queryString = "SELECT DISTINCT AccessDatas.[Kayit No], AccessDatas.ID, AccessDatas.[Kart ID],Visitors.Adi, Visitors.Soyadi, Visitors.TCKimlik, Visitors.Telefon, Visitors.Plaka,Visitors.[Ziyaret Sebebi], GroupsMaster.[Grup Adi],AccessDatas.[Panel ID] AS Panel, AccessDatas.[Kapi ID] AS Kapi,AccessDatas.[Gecis Tipi] AS Gecis, AccessDatas.Tarih,Users.Adi AS [Personel Adi], Users.Soyadi AS [Personel Soyadi], Visitors.Resim FROM ((Visitors RIGHT JOIN AccessDatas ON Visitors.[Kayit No]=AccessDatas.[Visitor Kayit No]) LEFT JOIN GroupsMaster ON Visitors.[Grup No]=GroupsMaster.[Grup No]) LEFT JOIN Users ON Visitors.ID=Users.ID WHERE AccessDatas.[Kullanici Tipi] = 1 ";
            if (Visitors != null)
            {
                //    queryString += " AND AccessDatas.[Visitor Kayit No] =" + Visitors;
            }
            if (GroupDetail != null)
            {
                queryString += " AND Visitors.[Grup No] =" + GroupDetail.Grup_No;
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
            if (Paneller != null)
            {
                queryString += " AND AccessDatas.[Panel ID] =" + Paneller;
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


            List<ZiyaretciRaporList> liste = new List<ZiyaretciRaporList>();
            using (SqlConnection connection = new SqlConnection(@"data source=ARGE2\SQLEXPRESS;initial catalog=MW301_DB25;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
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

    }
}
