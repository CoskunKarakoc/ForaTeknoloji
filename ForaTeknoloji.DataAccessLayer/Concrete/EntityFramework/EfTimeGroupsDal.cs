using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTimeGroupsDal : EfEntityRepositoryBase<TimeGroups, ForaContext>, ITimeGroupsDal
    {
        public List<ComplexTimeGroups> GetComplexTimeGroups(Expression<Func<ComplexTimeGroups, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {
                var query = from t in context.TimeGroups
                            join tid in context.TimeZoneIDs
                            on t.Gecis_Sinirlama_Tipi equals tid.Gecis_Sinirlama_Tipi
                            select new ComplexTimeGroups
                            {
                                Adi = tid.Adi,
                                Gecis_Sinirlama_Tipi = t.Gecis_Sinirlama_Tipi,
                                Zaman_Grup_Adi = t.Zaman_Grup_Adi,
                                Zaman_Grup_No = t.Zaman_Grup_No
                            };
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }

        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TimeGroups]");
            }
        }

        public class ComplexTimeGroups
        {
            public int Zaman_Grup_No { get; set; }
            public string Zaman_Grup_Adi { get; set; }
            public int? Gecis_Sinirlama_Tipi { get; set; }
            public string Adi { get; set; }
        }

    }
}
