using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Linq;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IVisitorsDal : IEntityRepository<Visitors>
    {
        IQueryable<ZiyaretciRaporList> GetZiyaretciListesi();


    }
}
