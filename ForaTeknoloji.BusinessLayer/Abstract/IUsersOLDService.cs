using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUsersOLDService
    {
        List<UsersOLD> GetAllUsersOLD(Expression<Func<UsersOLD, bool>> filter = null);
        UsersOLD GetById(int id);
        UsersOLD AddUsersOLD(UsersOLD usersOLD);
        void DeleteUsersOLD(UsersOLD usersOLD);
        UsersOLD UpdateUsersOLD(UsersOLD usersOLD);
    }
}
