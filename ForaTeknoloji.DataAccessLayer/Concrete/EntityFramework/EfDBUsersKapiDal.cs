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
    public class EfDBUsersKapiDal : EfEntityRepositoryBase<DBUsersKapi, ForaContext>, IDBUsersKapiDal
    {
        public void DeleteByUserName(string Kullanici_Adi)
        {
            using (var context = new ForaContext())
            {
                var query = "DELETE FROM DBUsersKapi WHERE [Kullanici Adi]='" + Kullanici_Adi + "'";
                context.Database.ExecuteSqlCommand(query);
            }
        }


    }
}
