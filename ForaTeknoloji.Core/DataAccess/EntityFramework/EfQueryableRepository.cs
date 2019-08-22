using ForaTeknoloji.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        DbContext _context;
        DbSet<T> _entities;
        public EfQueryableRepository(DbContext context)
        {
            _context = context;

        }
        public IQueryable<T> Table => this.Entities;
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    return _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }
}
