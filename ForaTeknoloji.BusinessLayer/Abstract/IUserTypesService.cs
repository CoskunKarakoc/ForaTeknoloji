using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserTypesService
    {
        List<UserTypes> GetAllUserTypes(Expression<Func<UserTypes, bool>> filter);
        UserTypes GetById(int id);
        UserTypes AddUserTypes(UserTypes userTypes);
        void DeleteUserTypes(UserTypes userTypes);
        UserTypes UpdateUserTypes(UserTypes userTypes);
    }
}
