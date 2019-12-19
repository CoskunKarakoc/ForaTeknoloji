using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDoorGroupsDetailDal : EfEntityRepositoryBase<DoorGroupsDetail, ForaContext>, IDoorGroupsDetailDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DoorGroupsDetail]");
            }
        }
    }
}
