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
    public interface IAltDepartmanDal : IEntityRepository<AltDepartman>
    {
        void DeleteAll();
        List<ComplexAltDepartman> ComplexAltDepartman(Expression<Func<ComplexAltDepartman, bool>> filter = null);
    }
}
