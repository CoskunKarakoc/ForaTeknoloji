using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IBirimDal : IEntityRepository<Birim>
    {
        void DeleteAll();
        List<ComplexBirim> ComplexBirim(Expression<Func<ComplexBirim, bool>> filter = null);
    }
}
