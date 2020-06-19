using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IPanelSettingsDal : IEntityRepository<PanelSettings>
    {
        List<int> GetPanelIDList();
        int GetPanelModelByPanelID(int PanelID);
    }
}
