using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessModesService
    {
        List<AccessModes> GetAllAccessModes(Expression<Func<AccessModes, bool>> filter = null);
        AccessModes GetById(int id);
        AccessModes AddAccessModes(AccessModes accessModes);
        void DeleteAccessModes(AccessModes accessModes);
        AccessModes UpdateAccessModes(AccessModes accessModes);
    }
}
