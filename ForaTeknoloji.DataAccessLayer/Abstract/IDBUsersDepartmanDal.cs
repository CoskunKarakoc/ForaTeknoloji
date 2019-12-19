using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDBUsersDepartmanDal : IEntityRepository<DBUsersDepartman>
    {
        void DeleteAllWithUserName(string UserName);
    }
}
