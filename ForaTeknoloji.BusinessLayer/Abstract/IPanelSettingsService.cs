using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IPanelSettingsService
    {
        List<PanelSettings> GetAllPanelSettings(Expression<Func<PanelSettings, bool>> filter = null);
        PanelSettings GetById(int PanelID);
        PanelSettings AddPanelSetting(PanelSettings panelSettings);
        void DeletePanelSetting(PanelSettings panelSettings);
        PanelSettings UpdatePanelSetting(PanelSettings panelSettings);
        PanelSettings GetByQuery(Expression<Func<PanelSettings, bool>> filter = null);
        List<int> GetPanelIDList();
    }
}
