using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDBUsersPanelsDal : IEntityRepository<DBUsersPanels>
    {
        void DeleteAllWithUserName(string UserName);
    }
}
