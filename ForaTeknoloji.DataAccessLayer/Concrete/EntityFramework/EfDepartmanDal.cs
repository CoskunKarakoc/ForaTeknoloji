using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDepartmanDal : EfEntityRepositoryBase<Departmanlar, ForaContext>, IDepartmanDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Departmanlar]");
            }
        }
    }
}
