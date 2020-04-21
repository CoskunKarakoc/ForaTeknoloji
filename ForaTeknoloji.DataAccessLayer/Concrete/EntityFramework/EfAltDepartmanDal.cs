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
    public class EfAltDepartmanDal : EfEntityRepositoryBase<AltDepartman, ForaContext>, IAltDepartmanDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [AltDepartman]");
            }
        }


        public List<ComplexAltDepartman> ComplexAltDepartman(Expression<Func<ComplexAltDepartman, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from ad in context.AltDepartman
                            join ud in context.Departmanlar
                            on ad.Departman_No equals ud.Departman_No
                            select new ComplexAltDepartman
                            {
                                Alt_Departman_Adi = ad.Adi,
                                Alt_Departman_No = ad.Alt_Departman_No,
                                Departman_Adi = ud.Adi,
                                Departman_No = ud.Departman_No
                            };
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }







    }
}
