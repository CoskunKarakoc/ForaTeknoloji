using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IRawGroupsDal : IEntityRepository<RawGroups>
    {
        void DeleteAll();
    }
}
