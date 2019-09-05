using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
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
            var liste = _reportService.GetIcerdeDisardaPersonels(1, null, null, "Lokal", "0");
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaPersonelListViewModel
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

        [HttpPost]
        public ActionResult Personel(int? Global_Bolge_Adi, int? Paneller, string Kapi, string Bolge, string Gecis)
        {

            var liste = _reportService.GetIcerdeDisardaPersonels(Global_Bolge_Adi, Paneller, Kapi, Bolge, Gecis);
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaPersonelListViewModel
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
            TempData["Personel"] = liste;
            return View(model);
        }




        public ActionResult Ziyaretci()
        {
            var liste = _reportService.GetIcerdeDısardaZiyaretci(1, null, null, null, "0");
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaZiyaretciListViewModel
            {
                ZiyaretciListesi = liste,
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
        public ActionResult Ziyaretci(int? Paneller, string Kapi, string Bolge, string Gecis, int? Global_Bolge_Adi = 1)
        {
            var liste = _reportService.GetIcerdeDısardaZiyaretci(Global_Bolge_Adi, Paneller, Kapi, Bolge, Gecis);
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaZiyaretciListViewModel
            {
                ZiyaretciListesi = liste,
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
            TempData["Ziyaretci"] = liste;
            return View(model);
        }





        public ActionResult Tumu()
        {
            var liste = _reportService.GetIcerdeDısardaTümü(1, null, null, null, "0");
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaTumuListViewModel
            {
                TumuListesi = liste,
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
        public ActionResult Tumu(int? Paneller, string Kapi, string Bolge, string Gecis, int? Global_Bolge_Adi = 1)
        {
            var liste = _reportService.GetIcerdeDısardaTümü(Global_Bolge_Adi, Paneller, Kapi, Bolge, Gecis);
            var panel = _panelSettingsService.GetAllPanelSettings();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaTumuListViewModel
            {
                TumuListesi = liste,
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
            TempData["Tumu"] = liste;
            return View(model);
        }

        public ActionResult ManuelCikis(List<int> Kayit_No)
        {

            return RedirectToAction("Personel");
        }


        //EXPORT EXCELL
        public void IcerdeDısardaZiyaretci()
        {


        }
    }
}