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
    public class EfBolumDal : EfEntityRepositoryBase<Bolum, ForaContext>, IBolumDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Bolum]");
            }
        }


        public List<ComplexBolum> ComplexBolum(Expression<Func<ComplexBolum, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from bol in context.Bolum
                            join d in context.Departmanlar
                            on bol.Departman_No equals d.Departman_No into tb1
                            from tbl1 in tb1.DefaultIfEmpty()
                            join ad in context.AltDepartman
                            on bol.Alt_Departman_No equals ad.Alt_Departman_No into tb2
                            from tbl2 in tb2.DefaultIfEmpty()
                            select new ComplexBolum
                            {
                                Alt_Departman_Adi = tbl2.Adi,
                                Alt_Departman_No = tbl2.Alt_Departman_No,
                                Departman_Adi = tbl1.Adi,
                                Departman_No = tbl1.Departman_No,
                                Adi = bol.Adi,
                                Bolum_No = bol.Bolum_No
                            };
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }



    }
}
