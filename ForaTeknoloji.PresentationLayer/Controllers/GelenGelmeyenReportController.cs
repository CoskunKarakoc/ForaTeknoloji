using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.PresentationLayer.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class GelenGelmeyenReportController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private ISirketService _sirketService;
        private IGroupsDetailService _groupsDetailService;
        private IVisitorsService _visitorsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        public GelenGelmeyenReportController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupsDetailService groupsDetailService, IVisitorsService visitorsService, IGlobalZoneService globalZoneService, IReportService reportService)
        {
            _userService = userService;
            _departmanService = departmanService;
            _sirketService = sirketService;
            _groupsDetailService = groupsDetailService;
            _visitorsService = visitorsService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;
        }
        // GET: GelenGelmeyenReport
        public ActionResult Index()
        {
            var nesne = _reportService.GelenGelmeyen_Gelmeyens(null, null, null, null, null, null, null, null, null, null);
            var gelenGelmeyenRaporLists = _reportService.GetGelenGelmeyenLists(null, null, null, null, null, null, null, null, null, null);
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var visitors = _visitorsService.GetAllVisitors();

            var model = new GelenGelmeyenViewModel
            {
                GelenGelmeyen = gelenGelmeyenRaporLists,
                Departmanlar = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirketler = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Groupsdetail = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Kayit_No.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Visitors = visitors.Select(a => new SelectListItem
                {
                    Text = a.Adi + " " + a.Soyadi,
                    Value = a.ID.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? Visitors, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Tipler = "")
        {
            var gelenGelmeyenRaporLists = _reportService.GetGelenGelmeyenLists(Sirketler, Departmanlar, Global_Bolge_Adi, Groupsdetail, Visitors, Tarih1, Tarih2, Saat1, Saat2, Tipler);
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var visitors = _visitorsService.GetAllVisitors();

            var model = new GelenGelmeyenViewModel
            {
                GelenGelmeyen = gelenGelmeyenRaporLists,
                Departmanlar = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirketler = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Groupsdetail = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Visitors = visitors.Select(a => new SelectListItem
                {
                    Text = a.Adi + " " + a.Soyadi,
                    Value = a.ID.ToString()
                })
            };
            TempData["GelenGelmeyen"] = gelenGelmeyenRaporLists;
            return View(model);
        }



        public void GelenGelmeyenListesi()
        {
            List<GelenGelmeyenRaporList> liste = new List<GelenGelmeyenRaporList>();
            liste = TempData["GelenGelmeyen"] as List<GelenGelmeyenRaporList>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetGelenGelmeyenLists(null, null, null, null, null, null, null, null, null, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells[""].Value = "Gelen Gelmeyen Rapor Listesi";


        }



    }
}