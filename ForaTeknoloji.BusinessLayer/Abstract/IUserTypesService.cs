using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserTypesService
    {
        List<UserTypes> GetAllUserTypes(Expression<Func<UserTypes, bool>> filter=null);
        UserTypes GetById(int id);
        UserTypes AddUserTypes(UserTypes userTypes);
        void DeleteUserTypes(UserTypes userTypes);
        UserTypes UpdateUserTypes(UserTypes userTypes);
    }
}
