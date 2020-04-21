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
    public class EfBirimDal : EfEntityRepositoryBase<Birim, ForaContext>, IBirimDal
    {

        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Birim]");
            }
        }




        public List<ComplexBirim> ComplexBirim(Expression<Func<ComplexBirim, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from birim in context.Birim
                            join bol in context.Bolum
                            on birim.Bolum_No equals bol.Bolum_No into tb
                            from tbb in tb.DefaultIfEmpty()
                            join d in context.Departmanlar
                            on birim.Departman_No equals d.Departman_No into tb1
                            from tbl1 in tb1.DefaultIfEmpty()
                            join ad in context.AltDepartman
                            on birim.Alt_Departman_No equals ad.Alt_Departman_No into tb2
                            from tbl2 in tb2.DefaultIfEmpty()
                            select new ComplexBirim
                            {
                                Alt_Departman_Adi = tbl2.Adi,
                                Alt_Departman_No = tbl2.Alt_Departman_No,
                                Departman_Adi = tbl1.Adi,
                                Departman_No = tbl1.Departman_No,
                                Adi = birim.Adi,
                                Bolum_No = tbb.Bolum_No,
                                Bolum_Adi = tbb.Adi,
                                Birim_No = birim.Birim_No
                            };
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }





    }
}
