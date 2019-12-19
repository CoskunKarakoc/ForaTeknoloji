using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDBUsersSirketDal : EfEntityRepositoryBase<DBUsersSirket, ForaContext>, IDBUsersSirketDal
    {
        public void DeleteAllWithUserName(string UserName)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersSirket WHERE [Kullanici Adi] = '" + UserName + "'");
            }
        }

    }
}
