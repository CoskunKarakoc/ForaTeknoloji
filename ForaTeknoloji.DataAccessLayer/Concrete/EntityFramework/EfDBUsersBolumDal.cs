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
    public class EfDBUsersBolumDal : EfEntityRepositoryBase<DBUsersBolum, ForaContext>, IDBUsersBolumDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {

                context.Database.ExecuteSqlCommand("TRUNCATE TABLE DBUsersBolum");
            }
        }

        public void DeleteAllWithUserName(string UserName)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersBolum WHERE [Kullanici Adi]= '" + UserName + "'");
            }
        }
    }
}
