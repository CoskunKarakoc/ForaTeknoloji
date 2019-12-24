using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class GelenGelmeyenReportController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private ISirketService _sirketService;
        private IVisitorsService _visitorsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IGroupMasterService _groupMasterService;
        private IAltDepartmanService _altDepartmanService;
        private IUnvanService _unvanService;
        private IBolumService _bolumService;
        public DBUsers user;
        public DateTime DefaultTarih1;
        public DateTime DefaultTarih2;
        public GelenGelmeyenReportController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupsDetailService groupsDetailService, IVisitorsService visitorsService, IGlobalZoneService globalZoneService, IReportService reportService, IGroupMasterService groupMasterService, IAltDepartmanService altDepartmanService, IUnvanService unvanService, IBolumService bolumService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }

            _userService = userService;
            _departmanService = departmanService;
            _sirketService = sirketService;
            _groupMasterService = groupMasterService;
            _visitorsService = visitorsService;
            _globalZoneService = globalZoneService;
            _altDepartmanService = altDepartmanService;
            _unvanService = unvanService;
            _bolumService = bolumService;
            _reportService = reportService;
            DefaultTarih1 = DateTime.Now;
            DefaultTarih2 = DateTime.Now;


            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
        }





        public ActionResult Gelenler(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_Gelenlers(parameters);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var model = new GelenGelmeyen_GelenlerListViewModel
            {
                Gelenler = nesne,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                })
            };
            TempData["Gelenler"] = nesne;
            return View(model);
        }




        public ActionResult Gelmeyenler(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_Gelmeyens(parameters);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var model = new GelenGelmeyen_GelmeyenlerListViewModel
            {
                Gelmeyenler = nesne,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                })
            };
            TempData["Gelmeyenler"] = nesne;
            return View(model);
        }




        public ActionResult PasifKullanici(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_PasifKullanicis(parameters);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var model = new GelenGelmeyen_PasifListViewModel
            {
                Pasif = nesne,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                })
            };
            TempData["Pasif"] = nesne;
            return View(model);
        }




        public ActionResult ToplamIcerdeKalma(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(parameters);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var usersComplex = _userService.GetAllUsersWithOuther();
            var model = new GelenGelmeyen_ToplamIcerdeKalmaListViewModel
            {
                ToplamIcerdeKalma = nesne,
                KullaniciComplex = usersComplex,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                })
            };
            TempData["Toplam"] = nesne;
            return View(model);
        }



        public ActionResult IlkGirisSonCikis(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_IlkGirisSonCikis(parameters);
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var usersComplex = _userService.GetAllUsersWithOuther();
            var model = new GelenGelmeyen_IlkGirisSonCikisListViewModel
            {
                IlkGirisSonCikis = nesne,
                KullaniciComplex = usersComplex,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                })
            };
            TempData["IlkGirisSonCikis"] = nesne;
            return View(model);
        }



        public ActionResult ComplexUser(string Search)
        {
            List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser> liste = new List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser>();
            if (Search == null || Search == "")
            {
                liste = _userService.GetAllUsersWithOuther();
            }
            else
            {
                liste = _userService.GetAllUsersWithOuther(x => x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim()));
            }
            return Json(liste, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AltDepartmanListesi(int? Departman)
        {
            if (Departman != 0 && Departman != null)
            {
                var list = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == Departman);
                var selectAltDepartman = list.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                });
                return Json(selectAltDepartman, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BolumListesi(int? AltDepartman)
        {
            if (AltDepartman != null && AltDepartman != 0)
            {

                var list = _bolumService.GetAllBolum(x => x.Alt_Departman_No == AltDepartman);
                var selectBolum = list.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                });
                return Json(selectBolum, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }

        //Gelenler Excell
        public void GelenlerExcell()
        {
            List<GelenGelmeyen_Gelenler> liste = new List<GelenGelmeyen_Gelenler>();
            liste = TempData["Gelenler"] as List<GelenGelmeyen_Gelenler>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_Gelenlers(new GelenGelmeyenReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Gelen Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
                liste = _reportService.GelenGelmeyen_Gelmeyens(new GelenGelmeyenReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Gelmeyen Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
                liste = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(new GelenGelmeyenReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Toplam İçerde Kalma Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
                liste = _reportService.GelenGelmeyen_PasifKullanicis(new GelenGelmeyenReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Pasif Kullanıcı Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
                liste = _reportService.GelenGelmeyen_IlkGirisSonCikis(new GelenGelmeyenReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "İlk Giriş Son Çıkış";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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