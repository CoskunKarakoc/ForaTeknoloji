using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfPanelSettingsDal : EfEntityRepositoryBase<PanelSettings, ForaContext>, IPanelSettingsDal
    {
        public List<int> GetPanelIDList()
        {
            using (var context = new ForaContext())
            {
                var query = "SELECT [Panel ID] FROM PanelSettings WHERE [Seri No]<>0 AND [Panel ID]<>0 AND [Panel IP1]<>0 AND [Panel IP2]<>0 AND [Panel IP3]<>0 AND [Panel IP4]<>0";
                var result = context.Database.SqlQuery<int>(query);
                return result.ToList();
            }
        }

        public int GetPanelModelByPanelID(int PanelID)
        {
            using (var context = new ForaContext())
            {
                var query = "SELECT [Panel Model] FROM PanelSettings WHERE [Seri No]<>0 AND [Panel ID]<>0 AND [Panel IP1]<>0 AND [Panel IP2]<>0 AND [Panel IP3]<>0 AND [Panel IP4]<>0 AND [Panel ID]=" + PanelID;
                var result = context.Database.SqlQuery<int>(query);
                return result.First();
            }

        }



    }
}
