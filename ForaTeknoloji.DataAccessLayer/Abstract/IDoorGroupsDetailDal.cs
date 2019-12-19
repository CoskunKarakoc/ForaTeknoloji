using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDoorGroupsDetailDal : IEntityRepository<DoorGroupsDetail>
    {
        void DeleteAll();
    }
}
