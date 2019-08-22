using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IPanelSettingsService
    {
        List<PanelSettings> GetAllPanelSettings();
        PanelSettings GetById(int id);
        PanelSettings AddPanelSetting(PanelSettings panelSettings);
        void DeletePanelSetting(PanelSettings panelSettings);
        PanelSettings UpdatePanelSetting(PanelSettings panelSettings);
    }
}
