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
    




        public ActionResult Gelenler()
        {
            var nesne = _reportService.GelenGelmeyen_Gelenlers(null, null, null, null, null);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var model = new GelenGelmeyen_GelenlerListViewModel
            {
                Gelenler = nesne,
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
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Gelenler(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih)
        {
            var nesne = _reportService.GelenGelmeyen_Gelenlers(Sirketler, Departmanlar, Global_Bolge_Adi, Groupsdetail, Tarih);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var model = new GelenGelmeyen_GelenlerListViewModel
            {
                Gelenler = nesne,
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
                })
            };
            TempData["Gelenler"] = nesne;
            return View(model);
        }


        public ActionResult Gelmeyenler()
        {
            var nesne = _reportService.GelenGelmeyen_Gelmeyens(null, null, null, null, null);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var model = new GelenGelmeyen_GelmeyenlerListViewModel
            {
                Gelmeyenler = nesne,
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
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Gelmeyenler(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih)
        {
            var nesne = _reportService.GelenGelmeyen_Gelmeyens(Sirketler, Departmanlar, Global_Bolge_Adi, Groupsdetail, Tarih);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var model = new GelenGelmeyen_GelmeyenlerListViewModel
            {
                Gelmeyenler = nesne,
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
                })
            };
            TempData["Gelmeyenler"] = nesne;
            return View(model);
        }


        public ActionResult PasifKullanici()
        {
            var nesne = _reportService.GelenGelmeyen_PasifKullanicis(null, null, null, null, DateTime.Now, 45);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var model = new GelenGelmeyen_PasifListViewModel
            {
                Pasif = nesne,
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
                })
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult PasifKullanici(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, DateTime? Tarih, double? Fark)
        {
            var nesne = _reportService.GelenGelmeyen_PasifKullanicis(Sirketler, Departmanlar, Global_Bolge_Adi, Groupsdetail, Tarih, Fark);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var model = new GelenGelmeyen_PasifListViewModel
            {
                Pasif = nesne,
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
                })
            };
            TempData["Pasif"] = nesne;
            return View(model);
        }



        public ActionResult ToplamIcerdeKalma()
        {
            var nesne = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(null, null, null, null, null, DateTime.Now, DateTime.Now);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var users = _userService.GetAllUsers();
            var model = new GelenGelmeyen_ToplamIcerdeKalmaListViewModel
            {
                ToplamIcerdeKalma = nesne,
                Kullanicilar = users,
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
                })
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ToplamIcerdeKalma(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? UserID, DateTime? Tarih1, DateTime? Tarih2)
        {
            var nesne = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(Sirketler, Departmanlar, Global_Bolge_Adi, Groupsdetail, UserID, Tarih1, Tarih2);
            var sirketler = _sirketService.GetAllSirketler();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var users = _userService.GetAllUsers();
            var model = new GelenGelmeyen_ToplamIcerdeKalmaListViewModel
            {
                ToplamIcerdeKalma = nesne,
                Kullanicilar = users,
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
                })
            };
            TempData["Toplam"] = nesne;
            return View(model);
        }







        //Gelenler Excell
        public void GelenlerExcell() { }
        //Gelmeyenler Excell
        public void GelmeyenlerExcell() { }

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