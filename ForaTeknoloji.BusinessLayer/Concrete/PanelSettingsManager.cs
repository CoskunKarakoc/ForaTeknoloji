using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public List<PanelSettings> GetAllPanelSettings(Expression<Func<PanelSettings, bool>> filter = null)
        {
            return filter == null ? _panelSettingsDal.GetList() : _panelSettingsDal.GetList(filter);
        }

        public PanelSettings GetById(int PanelID)
        {
            return _panelSettingsDal.Get(x => x.Panel_ID == PanelID);
        }

        public PanelSettings UpdatePanelSetting(PanelSettings panelSettings)
        {
            return _panelSettingsDal.Update(panelSettings);
        }

        public PanelSettings GetByQuery(Expression<Func<PanelSettings, bool>> filter = null)
        {
            return filter == null ? _panelSettingsDal.GetList().FirstOrDefault(x => x.Seri_No != null) : _panelSettingsDal.Get(filter);
        }

        public List<int> GetPanelIDList()
        {
            return _panelSettingsDal.GetPanelIDList();
        }

        public int GetPanelModelByPanelID(int Panel_ID)
        {
            return _panelSettingsDal.GetPanelModelByPanelID(Panel_ID);
        }


    }
}
