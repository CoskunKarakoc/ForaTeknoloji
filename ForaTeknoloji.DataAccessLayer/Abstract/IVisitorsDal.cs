using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfVisitorsDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IVisitorsDal : IEntityRepository<Visitors>
    {
        IQueryable<ZiyaretciRaporList> GetZiyaretciListesi();


    }
}
