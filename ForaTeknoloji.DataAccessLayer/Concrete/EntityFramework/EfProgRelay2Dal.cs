using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProgRelay2Dal : EfEntityRepositoryBase<ProgRelay2, ForaContext>,IProgRelay2Dal
    {
    }
}
