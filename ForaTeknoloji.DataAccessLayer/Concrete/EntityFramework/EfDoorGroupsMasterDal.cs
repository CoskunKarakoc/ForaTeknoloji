using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDoorGroupsMasterDal : EfEntityRepositoryBase<DoorGroupsMaster, ForaContext>, IDoorGroupsMasterDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DoorGroupsMaster]");
            }
        }
    }
}
