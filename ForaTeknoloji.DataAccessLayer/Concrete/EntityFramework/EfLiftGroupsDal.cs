using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Linq;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfLiftGroupsDal : EfEntityRepositoryBase<LiftGroups, ForaContext>, ILiftGroupsDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [LiftGroups]");
            }
        }


        public int Count()
        {
            using (var context = new ForaContext())
            {
                var query = "SELECT COUNT(*) FROM [LiftGroups]";
                var result = context.Database.SqlQuery<int>(query).First();
                return result;
            }
        }
    }
}
