using ForaTeknoloji.Core.Entities;
using System.Linq;

namespace ForaTeknoloji.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
