using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class UndefinedUserReportController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IPanelSettingsService _panelSettingsService;
        public UndefinedUserReportController(IAccessDatasService accessDatasService,IPanelSettingsService panelSettingsService)
        {
            _accessDatasService = accessDatasService;
            _panelSettingsService = panelSettingsService;
        }
        // GET: UndefinedUserReport
        public ActionResult Index()
        {
            var list = _accessDatasService.GetTanimsizListesi(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "");
            var PanelName = _panelSettingsService.GetAllPanelSettings();
            var model = new TanimsizKullaniciListViewModel
            {
                Liste = list,
                Panel = PanelName.Select(x => new SelectListItem
                {
                    Text = x.Panel_Name,
                    Value = x.Panel_ID.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Tümü, bool? TümPanel, int? Panel, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon = "") {
            var liste = _accessDatasService.GetTanimsizListesi(Kapi1, Kapi2, Kapi3, Kapi4, Kapi5, Kapi6, Kapi7, Kapi8, Tümü, TümPanel, Panel, Tarih1, Tarih2, Saat1, Saat2, KapiYon);
            var PanelName = _panelSettingsService.GetAllPanelSettings();
            var model = new TanimsizKullaniciListViewModel
            {
                Liste = liste,
                Panel = PanelName.Select(x => new SelectListItem
                {
                    Text = x.Panel_Name,
                    Value = x.Panel_ID.ToString()
                })
            };
            TempData["Document"] = liste;
            return View(model);
        }

        
    }
}