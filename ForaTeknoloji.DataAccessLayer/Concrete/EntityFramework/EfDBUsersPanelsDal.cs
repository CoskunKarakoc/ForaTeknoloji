using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfDBUsersPanelsDal : EfEntityRepositoryBase<DBUsersPanels, ForaContext>, IDBUsersPanelsDal
    {

        public void DeleteAllWithUserName(string UserName)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersPanels WHERE [Kullanici Adi] = '" + UserName + "'");
            }
        }


    }
}
