using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class PanelSettingsController : Controller
    {
        private IPanelSettingsService _panelSettings;
        private IReaderSettingsService _readerSettingsService;
        private IGlobalZoneService _globalZoneService;
        PanelSettings PanelSettings;
        public PanelSettingsController(IPanelSettingsService panelSettings, IReaderSettingsService readerSettingsService, IGlobalZoneService globalZoneService)
        {
            PanelSettings = CurrentSession.Panel;
            _panelSettings = panelSettings;
            _readerSettingsService = readerSettingsService;
            _globalZoneService = globalZoneService;
        }




        // GET: PanelSettings
        public ActionResult Genel()
        {
            if (PanelSettings == null)
            {
                return RedirectToAction("Orientation", "Home");
            }
            var model = new GenelPanelSettingsListViewModel
            {
                GenelAyar = _panelSettings.GetAllPanelSettings().FirstOrDefault(x => x.Seri_No == PanelSettings.Seri_No && x.Seri_No != null && x.Panel_ID == PanelSettings.Panel_ID && x.Seri_No != 0),
                Panel = PanelSettings
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Genel(GenelPanelSettingsListViewModel genelPanelSettingsListView)
        {
            if (ModelState.IsValid)
            {
                _panelSettings.AddPanelSetting(genelPanelSettingsListView.GenelAyar);
                return RedirectToAction("Genel");
            }
            return RedirectToAction("Genel");
        }


        public ActionResult Haberlesme()
        {
            var model = new HaberlesmeListViewModel
            {
                HaberlesmeAyar = _panelSettings.GetAllPanelSettings().FirstOrDefault(x => x.Seri_No != 0 && x.Seri_No != null && x.Panel_ID != null && x.Seri_No != 0)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Haberlesme(HaberlesmeListViewModel haberlesmeListView)
        {
            return View();
        }

        public ActionResult Kapilar()
        {
            var model = _readerSettingsService.GetByQuery(x => x.Panel_ID == 8 && x.Seri_No == 1853);
            return View(model);
        }

        public ActionResult Kapasite()
        {
            return View();
        }

        public ActionResult GlobalBolge()
        {
            var model = new GlobalBolgePanelSettingsListViewModel
            {
                Global_Bolge_Adi = _globalZoneService.GetAllGlobalZones().Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })
            };
            return View(model);
        }


        public ActionResult Interlock()
        {
            return View();
        }



        public ActionResult Diger()
        {
            return View();
        }



        public ActionResult LPRKameralar()
        {
            return View();
        }
    }
}