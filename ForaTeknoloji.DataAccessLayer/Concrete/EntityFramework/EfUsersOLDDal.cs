using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfUsersOLDDal : EfEntityRepositoryBase<UsersOLD, ForaContext>, IUsersOLDDal
    {
        public List<ComplexUserOld> GetAllUserOLDWithOuther(Expression<Func<ComplexUserOld, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from u in context.UsersOLD
                            join s in context.Sirketler
                            on u.Sirket_No equals s.Sirket_No into tb1
                            from tbl1 in tb1.DefaultIfEmpty()
                            join d in context.Departmanlar
                            on u.Departman_No equals d.Departman_No into tb2
                            from tbl2 in tb2.DefaultIfEmpty()
                            join b in context.Bloklar
                            on u.Blok_No equals b.Blok_No into tb3
                            from tbl3 in tb3.DefaultIfEmpty()
                            join g in context.GroupsMaster
                            on u.Grup_No equals g.Grup_No into tb4
                            from tbl4 in tb4.DefaultIfEmpty()
                            join grv in context.Gorevlers
                            on u.Gorev_No equals grv.Gorev_No into tb6
                            from tbl6 in tb6.DefaultIfEmpty()
                            join alt in context.AltDepartman
                             on u.Alt_Departman_No equals alt.Alt_Departman_No into tb7
                            from tbl7 in tb7.DefaultIfEmpty()
                            select new ComplexUserOld
                            {
                                Kayit_No = u.Kayit_No,
                                ID = u.ID,
                                Kart_ID = u.Kart_ID,
                                Adi = u.Adi,
                                Soyadi = u.Soyadi,
                                Sirket = tbl1.Adi,
                                Departman = tbl2.Adi,
                                Blok = tbl3.Adi,
                                Plaka = u.Plaka,
                                Gecis_Grubu = tbl4.Grup_Adi,
                                Ziyaretci_Grubu = u.Visitor_Grup_No,
                                Gorev = tbl6.Adi,
                                Sirket_No = u.Sirket_No,
                                Departman_No = u.Departman_No,
                                Alt_Departman_No = u.Alt_Departman_No
                            };

                return filter == null ? query.ToList() : query.Where(filter).ToList();

            }


        }








        public class ComplexUserOld
        {
            public int Kayit_No { get; set; }
            public int ID { get; set; }
            public string Kart_ID { get; set; }
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            public string Sirket { get; set; }
            public string Departman { get; set; }
            public string Gorev { get; set; }
            public string Blok { get; set; }
            public string Plaka { get; set; }
            public string Gecis_Grubu { get; set; }
            public int? Ziyaretci_Grubu { get; set; }
            public int? Departman_No { get; set; }
            public int? Sirket_No { get; set; }
            public int? Alt_Departman_No { get; set; }
        }
    }
}
