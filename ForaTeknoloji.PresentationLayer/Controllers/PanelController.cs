using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
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

        public ActionResult SetSession(int ID = -1)
        {
            if (ID != -1)
            {
                PanelSettings panelSettings = _panelSettingsService.GetById(ID);
                if (panelSettings != null)
                {
                    CurrentSession.Remove("Panel");
                    CurrentSession.Set<PanelSettings>("Panel", panelSettings);
                }
            }
            return View("Index");
        }

    }
}