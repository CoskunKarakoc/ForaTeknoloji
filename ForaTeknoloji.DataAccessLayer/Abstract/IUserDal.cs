using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IUserDal : IEntityRepository<Users>
    {
        IQueryable<PersonelList> GetComplexPersonelList();
        IQueryable<GelenGelmeyenRaporList> GetComplexGelenGelmeyenRaporList(string Tipler = null);
    }
}
