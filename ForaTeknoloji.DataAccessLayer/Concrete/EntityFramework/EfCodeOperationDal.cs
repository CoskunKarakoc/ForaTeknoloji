using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfCodeOperationDal : EfEntityRepositoryBase<CodeOperation, ForaContext>, ICodeOperationDal
    {
    }
}
