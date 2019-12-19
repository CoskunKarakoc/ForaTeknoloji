using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfSmsSettingsDal : EfEntityRepositoryBase<SMSSetting, ForaContext>, ISMSSettingsDal
    {
    }
}
