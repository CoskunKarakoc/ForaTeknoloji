using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDepartmanDal : IEntityRepository<Departmanlar>
    {
        void DeleteAll();
    }
}
