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
    public class EfDBUsersGorevDal : EfEntityRepositoryBase<DBUsersGorev, ForaContext>, IDBUsersGorevDal
    {
        public void DeleteAllWithUserName(string UserName)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersGorev WHERE [Kullanici Adi] = '" + UserName + "'");
            }
        }
    }
}
