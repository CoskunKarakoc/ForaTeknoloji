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
    public class PanelController : Controller
    {
        private IPanelSettingsService _panelSettingsService;
        public PanelController(IPanelSettingsService panelSettingsService)
        {
            _panelSettingsService = panelSettingsService;
        }



        // GET: Panel
        public ActionResult Index()
        {

            return View(_panelSettingsService.GetAllPanelSettings());
        }

        public ActionResult SetSession(int ID)
        {

            PanelSettings panelSettings = _panelSettingsService.GetById(ID);

            CurrentSession.Set<PanelSettings>("Panel", panelSettings);

            var sonuc = CurrentSession.Get<PanelSettings>("Panel");
            return View("Index");
        }

    }
}