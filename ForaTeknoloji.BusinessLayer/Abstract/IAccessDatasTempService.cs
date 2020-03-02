using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessDatasTempService
    {
        List<AccessDatasTemp> GetAllAccessDatasTemp(Expression<Func<AccessDatasTemp, bool>> filter = null);
        AccessDatasTemp GetById(int id);
        AccessDatasTemp AddAccessDatasTemp(AccessDatasTemp accessDatasTemp);
        void DeleteAccessDatasTemp(AccessDatasTemp accessDatasTemp);
        void DeleteAll();
        AccessDatasTemp UpdateAccessDatasTemp(AccessDatasTemp accessDatasTemp);
    }
}
