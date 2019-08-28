using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Users, ForaContext>, IUserDal
    {
        public IQueryable<GelenGelmeyenRaporList> GetComplexGelenGelmeyenRaporList(string Tipler = null)
        {
            var contex = new ForaContext();
            var list = from u in contex.Users
                       join d in contex.Departmanlar
                       on u.Departman_No equals d.Departman_No into tb1
                       from tbl1 in tb1.DefaultIfEmpty()
                       join gm in contex.GroupsMaster
                       on u.Grup_No equals gm.Grup_No into tb2
                       from tbl2 in tb2.DefaultIfEmpty()
                       join b in contex.Bloklar
                       on u.Blok_No equals b.Blok_No into tb3
                       from tbl3 in tb3.DefaultIfEmpty()
                       join s in contex.Sirketler
                       on u.Sirket_No equals s.Sirket_No into tb4
                       from tbl4 in tb4.DefaultIfEmpty()
                       where u.ID > 0
                       select new GelenGelmeyenRaporList
                       {
                           ID = u.ID,
                           Adi = u.Adi,
                           Soyadi = u.Soyadi,
                           Daire = u.Daire,
                           Kart_ID = u.Kart_ID,
                           Blok_Adi = tbl3.Adi,
                           Departman_Adi = tbl1.Adi,
                           Global_Bolge_Adi = u.Tmp,
                           Grup_Adi = tbl2.Grup_Adi,
                           Plaka = u.Plaka,
                           Sirket_Adi = tbl4.Adi,
                           TCKimlik = u.TCKimlik,
                           Resim = u.TCKimlik
                       };
            return list;
        }

        public IQueryable<PersonelList> GetComplexPersonelList()
        {
            var context = new ForaContext();
            var list = from u in context.Users
                       join gd in context.GroupsDetail
                       on u.Grup_No equals gd.Grup_No into tb1
                       from tbl1 in tb1.DefaultIfEmpty()
                       join s in context.Sirketler
                       on u.Sirket_No equals s.Sirket_No into tb2
                       from tbl2 in tb2.DefaultIfEmpty()
                       join d in context.Departmanlar
                       on u.Departman_No equals d.Departman_No into tb3
                       from tbl3 in tb3.DefaultIfEmpty()
                       join b in context.Bloklar
                       on u.Blok_No equals b.Blok_No into tb4
                       from tbl4 in tb4.DefaultIfEmpty()
                       where u.Kullanici_Tipi == 0 && u.ID > 0
                       select new PersonelList
                       {
                           ID = u.ID,
                           Adi = u.Adi,
                           DepartmanAdi = tbl3.Adi,
                           Grup_Adi = tbl1.Grup_Adi,
                           BlokAdi = tbl4.Adi,
                           Plaka = u.Plaka,
                           Kart_ID = u.Kart_ID,
                           Soyadi = u.Soyadi,
                           TCKimlik = u.TCKimlik ?? "NULL",
                           Grup_No = tbl1.Grup_No,
                           SirketAdi = tbl2.Adi,
                           Daire = u.Daire,
                           Tmp = u.Tmp,
                           Kapi1 = true,
                           Kapi2 = true,
                           Kapi3 = true,
                           Kapi4 = true,
                           Kapi5 = true,
                           Kapi6 = true,
                           Kapi7 = true,
                           Kapi8 = true,
                           Kapi9 = true,
                           Kapi10 = true,
                           Kapi11 = true,
                           Kapi12 = true,
                           Kapi13 = true,
                           Kapi14 = true,
                           Kapi15 = true,
                           Kapi16 = true,
                           Kapi1_Global_Bolge_No = tbl1.Kapi1_Global_Bolge_No,
                           Kapi2_Global_Bolge_No = tbl1.Kapi2_Global_Bolge_No,
                           Kapi3_Global_Bolge_No = tbl1.Kapi3_Global_Bolge_No,
                           Kapi4_Global_Bolge_No = tbl1.Kapi4_Global_Bolge_No,
                           Kapi5_Global_Bolge_No = tbl1.Kapi5_Global_Bolge_No,
                           Kapi6_Global_Bolge_No = tbl1.Kapi6_Global_Bolge_No,
                           Kapi7_Global_Bolge_No = tbl1.Kapi7_Global_Bolge_No,
                           Kapi8_Global_Bolge_No = tbl1.Kapi8_Global_Bolge_No,
                           Kapi9_Global_Bolge_No = tbl1.Kapi9_Global_Bolge_No,
                           Kapi10_Global_Bolge_No = tbl1.Kapi10_Global_Bolge_No,
                           Kapi11_Global_Bolge_No = tbl1.Kapi11_Global_Bolge_No,
                           Kapi12_Global_Bolge_No = tbl1.Kapi12_Global_Bolge_No,
                           Kapi13_Global_Bolge_No = tbl1.Kapi13_Global_Bolge_No,
                           Kapi14_Global_Bolge_No = tbl1.Kapi14_Global_Bolge_No,
                           Kapi15_Global_Bolge_No = tbl1.Kapi15_Global_Bolge_No,
                           Kapi16_Global_Bolge_No = tbl1.Kapi16_Global_Bolge_No


                       };
            return list.Distinct();
        }
    }
}
