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
    public class InsideOutReportController : Controller
    {
        private IVisitorsService _visitorsService;
        private IPanelSettingsService _panelSettingsService;
        private IGroupsDetailService _groupsDetailService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        public InsideOutReportController(IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGroupsDetailService groupsDetailService, IGlobalZoneService globalZoneService, IReportService reportService)
        {
            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _groupsDetailService = groupsDetailService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;
        }


        // GET: InsideOutReport
        public ActionResult Personel()
        {
            var liste = _reportService.GetIcerdeDisardaPersonels();
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new ZiyaretciListViewModel
            {
                IcerdeDısardaPersonel = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            return View(model);
        }




        public ActionResult Tümü()
        {
            var liste = _reportService.GetIcerdeDısardaTümü();
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new ZiyaretciListViewModel
            {
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            return View(model);

        }

        public ActionResult Ziyaretci()
        {
            var liste = _reportService.GetIcerdeDısardaZiyaretci();
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new ZiyaretciListViewModel
            {
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Ziyaretci(int? Paneller, int? Global_Bolge_Adi)
        {
            var liste = _reportService.GetIcerdeDısardaZiyaretci();
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new ZiyaretciListViewModel
            {
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            return View(model);
        }

        //EXPORT EXCELL
        public void IcerdeDısardaZiyaretci()
        {


        }
    }
}