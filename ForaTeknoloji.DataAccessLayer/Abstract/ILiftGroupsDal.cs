using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ILiftGroupsDal : IEntityRepository<LiftGroups>
    {
        void DeleteAll();
        int Count();
    }
}
