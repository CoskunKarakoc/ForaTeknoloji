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
        public PanelSettingsController(IPanelSettingsService panelSettings, IReaderSettingsService readerSettingsService,IGlobalZoneService globalZoneService)
        {
            _panelSettings = panelSettings;
            _readerSettingsService = readerSettingsService;
            _globalZoneService = globalZoneService;
        }

        // GET: PanelSettings
        public ActionResult Genel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Genel(PanelSettings panelSettings)
        {
            if (ModelState.IsValid)
            {
                _panelSettings.AddPanelSetting(panelSettings);
                return RedirectToAction("Genel");
            }
            return RedirectToAction("Genel");
        }


        public ActionResult Haberlesme()
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