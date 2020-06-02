using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDBUsersAltDepartmanDal : IEntityRepository<DBUsersAltDepartman>
    {
        void DeleteAll();
        void DeleteAllWithUserName(string UserName);
        void DeleteAllWithUserNameAndDepartmanNo(string UserName, int DepartmanNo);
        void DeleteAllWithUserNameAndDepartmanNoAndAltDepartman(string UserName, int DepartmanNo, int AltDepartmanNo);
    }
}
