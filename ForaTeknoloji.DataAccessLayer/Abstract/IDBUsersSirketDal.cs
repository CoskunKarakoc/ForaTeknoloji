using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDBUsersSirketDal : IEntityRepository<DBUsersSirket>
    {
        void DeleteAllWithUserName(string UserName);
    }
}
