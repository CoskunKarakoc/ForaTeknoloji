using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
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
        public PanelSettingsController(IPanelSettingsService panelSettings)
        {
            _panelSettings = panelSettings;
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



    }
}