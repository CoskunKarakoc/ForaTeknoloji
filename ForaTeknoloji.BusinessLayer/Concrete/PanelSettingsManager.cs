using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class PanelSettingsManager : IPanelSettingsService
    {
        private IPanelSettingsDal _panelSettingsDal;
        public PanelSettingsManager(IPanelSettingsDal panelSettingsDal)
        {
            _panelSettingsDal = panelSettingsDal;
        }
        public PanelSettings AddPanelSetting(PanelSettings panelSettings)
        {
            return _panelSettingsDal.Add(panelSettings);
        }

        public void DeletePanelSetting(PanelSettings panelSettings)
        {
            _panelSettingsDal.Delete(panelSettings);
        }

        public List<PanelSettings> GetAllPanelSettings()
        {
            return _panelSettingsDal.GetList();
        }

        public PanelSettings GetById(int id)
        {
            return _panelSettingsDal.Get(x => x.Kayit_No == id);
        }

        public PanelSettings UpdatePanelSetting(PanelSettings panelSettings)
        {
            return _panelSettingsDal.Update(panelSettings);
        }
    }
}
