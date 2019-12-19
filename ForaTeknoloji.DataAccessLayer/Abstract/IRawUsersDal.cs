using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IRawUsersDal : IEntityRepository<RawUsers>
    {
        void DeleteAll();
    }
}
