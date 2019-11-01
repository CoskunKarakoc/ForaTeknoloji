using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class PanelSettingsController : Controller
    {
        private IPanelSettingsService _panelSettings;
        private IReaderSettingsService _readerSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IReaderSettingsNewService _settingsNewService;
        private PanelSettings PanelSettings;
        public PanelSettingsController(IPanelSettingsService panelSettings, IReaderSettingsService readerSettingsService, IGlobalZoneService globalZoneService, IReaderSettingsNewService settingsNewService)
        {
            PanelSettings = CurrentSession.Panel;
            _panelSettings = panelSettings;
            _readerSettingsService = readerSettingsService;
            _globalZoneService = globalZoneService;
            _settingsNewService = settingsNewService;
        }


        public ActionResult Settings()
        {
            List<int> interlock = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            if (PanelSettings == null || PanelSettings.Panel_ID == 0 || (PanelSettings.Panel_IP1 == 0 && PanelSettings.Panel_IP2 == 0 && PanelSettings.Panel_IP3 == 0 && PanelSettings.Panel_IP4 == 0))
            {
                return RedirectToAction("Orientation", "Home");
            }
            else
            {
                PanelSettings selectedpanel = _panelSettings.GetById((int)PanelSettings.Panel_ID);
                //var model = new PanelSettingsViewModel
                //{
                //    Panel = selectedpanel
                //};
                ViewBag.Panel_Global_Bolge1 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge1);
                ViewBag.Panel_Global_Bolge2 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge2);
                ViewBag.Panel_Global_Bolge3 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge3);
                ViewBag.Panel_Global_Bolge4 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge4);
                ViewBag.Panel_Global_Bolge5 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge5);
                ViewBag.Panel_Global_Bolge6 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge6);
                ViewBag.Panel_Global_Bolge7 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge7);
                ViewBag.Panel_Global_Bolge8 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge8);
                ViewBag.LocalInterlock_G1_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G1_1);
                ViewBag.LocalInterlock_G1_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G1_2);
                ViewBag.LocalInterlock_G2_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G2_1);
                ViewBag.LocalInterlock_G2_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G2_2);
                ViewBag.LocalInterlock_G3_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G3_1);
                ViewBag.LocalInterlock_G3_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G3_2);
                ViewBag.LocalInterlock_G4_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G4_1);
                ViewBag.LocalInterlock_G4_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G4_2);
                return View(selectedpanel);
            }

        }
        [HttpPost]
        public ActionResult Settings(PanelSettings panel)
        {
            if (ModelState.IsValid)
            {
                _panelSettings.UpdatePanelSetting(panel);
                return RedirectToAction("Settings");
            }

            return View(panel);
        }

        public ActionResult ReaderSettings()
        {
            if (PanelSettings == null || PanelSettings.Panel_ID == 0 || (PanelSettings.Panel_IP1 == 0 && PanelSettings.Panel_IP2 == 0 && PanelSettings.Panel_IP3 == 0 && PanelSettings.Panel_IP4 == 0))
            {
                return RedirectToAction("Orientation", "Home");
            }
            var model = _settingsNewService.GetAllReaderSettingsNew(x => x.Seri_No == PanelSettings.Seri_No);
            return View(model);
        }





        public ActionResult Reader(int id)
        {
            ReaderSettingsNew readerSettingsNew = new ReaderSettingsNew();
            ViewBag.Seri_No = PanelSettings.Seri_No;
            ViewBag.Sira_No = PanelSettings.Sira_No;
            ViewBag.Panel_Name = PanelSettings.Panel_Name;
            ViewBag.Panel_ID = PanelSettings.Panel_ID;
            return View(readerSettingsNew);
        }




        public ActionResult ReaderEdit(int id = -1)
        {
            if (id != -1)
            {
                List<int> role = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                List<int> lokalBolge = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
                List<int> userCount = new List<int> { 2, 3, 4, 5, 6 };
                var model = _settingsNewService.GetById(id);
                ViewBag.WKapi_Role_No = new SelectList(role, model.WKapi_Role_No);
                ViewBag.WKapi_Lokal_Bolge = new SelectList(lokalBolge, model.WKapi_Lokal_Bolge);
                ViewBag.WKapi_User_Count = new SelectList(userCount, model.WKapi_User_Count);
                ViewBag.WKapi_Harici_Alarm_Rolesi = new SelectList(role, model.WKapi_Harici_Alarm_Rolesi);
                return View(model);
            }
            return RedirectToAction("ReaderSettings");
        }

        [HttpPost]
        public ActionResult ReaderEdit(ReaderSettingsNew readerSettingsNew)
        {
            if (ModelState.IsValid)
            {
                _settingsNewService.UpdateReaderSettingsNew(readerSettingsNew);
                return RedirectToAction("ReaderSettings");
            }
            return View(readerSettingsNew);
        }


    }
}