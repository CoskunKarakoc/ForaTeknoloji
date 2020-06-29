using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProgRelay2Dal : EfEntityRepositoryBase<ProgRelay2, ForaContext>, IProgRelay2Dal
    {
        public void DeleteByDayOfTheWeek(int Haftanin_Gunu)
        {
            using (var context = new ForaContext())
            {
                var query = "DELETE FROM ProgRelay2 WHERE [Haftanin Gunu]=" + Haftanin_Gunu + "";
                context.Database.ExecuteSqlCommand(query);
            }
        }
    }
}
