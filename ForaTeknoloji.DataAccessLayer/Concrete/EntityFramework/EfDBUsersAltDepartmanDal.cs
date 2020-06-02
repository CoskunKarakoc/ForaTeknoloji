using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDBUsersAltDepartmanDal : EfEntityRepositoryBase<DBUsersAltDepartman, ForaContext>, IDBUsersAltDepartmanDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DBUsersAltDepartman]");
            }
        }

        public void DeleteAllWithUserName(string UserName)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersAltDepartman WHERE [Kullanici Adi] = '" + UserName + "'");
            }
        }

        public void DeleteAllWithUserNameAndDepartmanNo(string UserName, int DepartmanNo)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersAltDepartman WHERE [Kullanici Adi] = '" + UserName + "' AND [Departman No]=" + DepartmanNo);
            }
        }

        public void DeleteAllWithUserNameAndDepartmanNoAndAltDepartman(string UserName, int DepartmanNo, int AltDepartmanNo)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersAltDepartman WHERE [Kullanici Adi] = '" + UserName + "' AND [Departman No]=" + DepartmanNo + " AND [Alt Departman No]=" + AltDepartmanNo);
            }
        }



    }
}
