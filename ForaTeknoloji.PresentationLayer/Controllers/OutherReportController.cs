using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class OutherReportController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IPanelSettingsService _panelSettingsService;
        public OutherReportController(IAccessDatasService accessDatasService, IPanelSettingsService panelSettingsService)
        {
            _accessDatasService = accessDatasService;
            _panelSettingsService = panelSettingsService;
        }
        // GET: OutherReport
        public ActionResult Index()
        {
            var liste = _accessDatasService.GetDigerGecisListesi(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            var panel = _panelSettingsService.GetAllPanelSettings();
            var model = new DigerGecisRaporListViewModel
            {
                DigerGecisListesi = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tetikleme = "", string KapiYon = "")
        {
            var liste = _accessDatasService.GetDigerGecisListesi(Kapi1, Kapi2, Kapi3, Kapi4, Kapi5, Kapi6, Kapi7, Kapi8, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Tetikleme, KapiYon);
            var panel = _panelSettingsService.GetAllPanelSettings();
            var model = new DigerGecisRaporListViewModel
            {
                DigerGecisListesi = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                })
            };
            return View(model);
        }
    }
}