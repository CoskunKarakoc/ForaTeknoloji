using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUserService
    {

        List<Users> GetAllUsers();
        Users GetById(int id);
        Users AddUsers(Users users);
        void DeleteUsers(Users users);
        Users UpdateUsers(Users users);
    }
}
