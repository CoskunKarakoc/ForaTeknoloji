using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfReaderSettingsNewDal : EfEntityRepositoryBase<ReaderSettingsNew, ForaContext>, IReaderSettingsNewDal
    {
        public void DeleteReaderSettingsNewByPanelID(int PanelID)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM ReaderSettingsNew WHERE ReaderSettingsNew.[Panel ID] = " + PanelID);
            }
        }
    }
}
