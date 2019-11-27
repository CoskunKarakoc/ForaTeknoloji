using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IRawUsersService
    {
        List<RawUsers> GetAllRawUsers(Expression<Func<RawUsers, bool>> filter = null);
        RawUsers GetById(int id);
        RawUsers AddRawUsers(RawUsers rawUsers);
        void DeleteRawUsers(RawUsers rawUsers);
        RawUsers UpdateRawUsers(RawUsers rawUsers);
    }
}
