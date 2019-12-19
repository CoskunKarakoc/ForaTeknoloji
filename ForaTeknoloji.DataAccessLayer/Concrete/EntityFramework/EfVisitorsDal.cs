using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Linq;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfVisitorsDal : EfEntityRepositoryBase<Visitors, ForaContext>, IVisitorsDal
    {
        public IQueryable<ZiyaretciRaporList> GetZiyaretciListesi()
        {
            var context = new ForaContext();
            var liste = from v in context.Visitors
                        join ad in context.AccessDatas
                        on v.Kayit_No equals ad.Visitor_Kayit_No into tb1
                        from tbl1 in tb1.DefaultIfEmpty()
                        join gm in context.GroupsMaster
                        on v.Grup_No equals gm.Grup_No into tb2
                        from tbl2 in tb2.DefaultIfEmpty()
                        join u in context.Users
                        on v.ID equals u.ID into tb3
                        from tbl3 in tb3.DefaultIfEmpty()
                        join d in context.DoorNames
                        on tbl1.Kapi_ID equals d.Kapi_No into tb4
                        from tbl4 in tb4.DefaultIfEmpty()
                        where tbl1.Kullanici_Tipi == 1
                        select new ZiyaretciRaporList
                        {
                            ID = v.ID,
                            Kod = tbl1.Kod,
                            Personel_Adi = tbl3.Adi,
                            Personel_Soyadi = tbl3.Soyadi,
                            Tarih = tbl1.Tarih,
                            Grup_Adi = tbl2.Grup_Adi,
                            Ziyaretci_Adi = v.Adi,
                            Ziyaretci_Soyadi = v.Soyadi,
                            Ziyaretci_Plaka = v.Plaka,
                            Ziyaret_Sebebi = v.Ziyaret_Sebebi,
                            Gecis_Tipi = tbl1.Gecis_Tipi,
                            Ziyaretci_Resim = v.Resim,
                            Ziyaretci_TCKimlik = v.TCKimlik,
                            Ziyaretci_Telefon = v.Telefon,
                            Kapi = tbl4.Kapi_Adi,
                            Kart_ID = tbl1.Kart_ID,
                            Panel_ID = tbl1.Panel_ID,
                            Kayit_No = tbl1.Kayit_No

                        };
            return liste.Distinct();
        }

    }
}
