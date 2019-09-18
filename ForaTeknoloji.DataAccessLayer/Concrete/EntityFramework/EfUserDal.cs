using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Users, ForaContext>, IUserDal
    {
        public List<ComplexUser> GetAllUsersWithOuther(Expression<Func<ComplexUser, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from u in context.Users
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
                            select new ComplexUser
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
                                Ziyaretci_Grubu = u.Visitor_Grup_No
                            };

                return filter == null ? query.ToList() : query.Where(filter).ToList();

            }


        }

        public class ComplexUser
        {
            public int Kayit_No { get; set; }
            public int ID { get; set; }
            public string Kart_ID { get; set; }
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            public string Sirket { get; set; }
            public string Departman { get; set; }
            public string Blok { get; set; }
            public string Plaka { get; set; }
            public string Gecis_Grubu { get; set; }
            public int? Ziyaretci_Grubu { get; set; }


        }
    }
}
