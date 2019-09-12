using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    public class GelenGelmeyenReportController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private ISirketService _sirketService;
        private IGroupsDetailService _groupsDetailService;
        private IVisitorsService _visitorsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        public DBUsers user;
        public GelenGelmeyenReportController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupsDetailService groupsDetailService, IVisitorsService visitorsService, IGlobalZoneService globalZoneService, IReportService reportService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }

            _userService = userService;
            _departmanService = departmanService;
            _sirketService = sirketService;
            _groupsDetailService = groupsDetailService;
            _visitorsService = visitorsService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;



            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
        }





        public ActionResult Gelenler()
        {
            var nesne = _reportService.GelenGelmeyen_Gelenlers(null, null, null, null, null);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
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
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
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


        public ActionResult IlkGirisSonCikis()
        {
            var nesne = _reportService.GelenGelmeyen_IlkGirisSonCikis(null, null, null, null, null, DateTime.Now, DateTime.Now);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var users = _userService.GetAllUsers();
            var model = new GelenGelmeyen_IlkGirisSonCikisListViewModel
            {
                IlkGirisSonCikis = nesne,
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
        public ActionResult IlkGirisSonCikis(int? Sirketler, int? Departmanlar, int? Global_Bolge_Adi, int? Groupsdetail, int? UserID, DateTime? Tarih1, DateTime? Tarih2)
        {
            var nesne = _reportService.GelenGelmeyen_IlkGirisSonCikis(Sirketler, Departmanlar, Global_Bolge_Adi, Groupsdetail, UserID, Tarih1, Tarih2);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var users = _userService.GetAllUsers();
            var model = new GelenGelmeyen_IlkGirisSonCikisListViewModel
            {
                IlkGirisSonCikis = nesne,
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
            TempData["IlkGirisSonCikis"] = nesne;
            return View(model);
        }


        //Gelenler Excell
        public void GelenlerExcell()
        {
            List<GelenGelmeyen_Gelenler> liste = new List<GelenGelmeyen_Gelenler>();
            liste = TempData["Gelenler"] as List<GelenGelmeyen_Gelenler>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_Gelenlers(null, null, null, null, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Gelen Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Plaka";
            worksheet.Cells["I6"].Value = "Blok";
            worksheet.Cells["J6"].Value = "Daire";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Plaka;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BlokAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Daire;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Grup_Adi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }
        //Gelmeyenler Excell
        public void GelmeyenlerExcell()
        {
            List<GelenGelmeyen_Gelmeyen> liste = new List<GelenGelmeyen_Gelmeyen>();
            liste = TempData["Gelmeyenler"] as List<GelenGelmeyen_Gelmeyen>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_Gelmeyens(null, null, null, null, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Gelmeyen Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Plaka";
            worksheet.Cells["I6"].Value = "Blok";
            worksheet.Cells["J6"].Value = "Daire";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Plaka;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BlokAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Daire;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Grup_Adi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Toplam İçerde Kalma Excell
        public void ToplamIcerdeKalmaExcell()
        {
            List<GelenGelmeyen_ToplamIcerdeKalma> liste = new List<GelenGelmeyen_ToplamIcerdeKalma>();
            liste = TempData["Toplam"] as List<GelenGelmeyen_ToplamIcerdeKalma>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(null, null, null, null, null, DateTime.Now, DateTime.Now);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Toplam İçerde Kalma Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Şirket";
            worksheet.Cells["F6"].Value = "Departman";
            worksheet.Cells["G6"].Value = "Grup";
            worksheet.Cells["H6"].Value = "Tarih Değeri";
            worksheet.Cells["I6"].Value = "Toplam Saat";
            worksheet.Cells["J6"].Value = "Toplam Dakika";
            worksheet.Cells["K6"].Value = "Toplam Saniye";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Tarih_Degeri;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Toplam_Saat;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Toplam_Dakika;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Toplam_Saniye;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Pasi Kullanıcı Excell
        public void PasifKullaniciExcell()
        {
            List<GelenGelmeyen_PasifKullanici> liste = new List<GelenGelmeyen_PasifKullanici>();
            liste = TempData["Pasif"] as List<GelenGelmeyen_PasifKullanici>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_PasifKullanicis(null, null, null, null, DateTime.Now, 45);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Pasif Kullanıcı Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Plaka";
            worksheet.Cells["I6"].Value = "Blok";
            worksheet.Cells["J6"].Value = "Daire";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
            worksheet.Cells["L6"].Value = "Global Bölge Adı";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Plaka;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BlokAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Daire;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Global_Bolge_Adi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //İlk Giriş Son Çıkış
        public void IlkGirisSonCikisExcell()
        {
            List<GelenGelmeyen_IlkGirisSonCikis> liste = new List<GelenGelmeyen_IlkGirisSonCikis>();
            liste = TempData["IlkGirisSonCikis"] as List<GelenGelmeyen_IlkGirisSonCikis>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_IlkGirisSonCikis(null, null, null, null, null, DateTime.Now, DateTime.Now);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "İlk Giriş Son Çıkış";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Şirket";
            worksheet.Cells["F6"].Value = "Departman";
            worksheet.Cells["G6"].Value = "Grup";
            worksheet.Cells["H6"].Value = "Tarih Değeri";
            worksheet.Cells["I6"].Value = "İlk Kayıt";
            worksheet.Cells["J6"].Value = "Son Kayıt";
            worksheet.Cells["K6"].Value = "Fark";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Tarih_Degeri;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Ilk_Kayit;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Son_Kayit;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Fark;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

    }
}