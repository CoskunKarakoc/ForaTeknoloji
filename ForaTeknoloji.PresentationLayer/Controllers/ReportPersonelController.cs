using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
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
    public class ReportPersonelController : Controller
    {
        private IUserService _userService;
        private ISirketService _sirketService;
        private IDepartmanService _departmanService;
        private IBloklarService _bloklarService;
        private IVisitorsService _visitorsService;
        private IGroupMasterService _groupMasterService;
        private IPanelSettingsService _panelSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IUsersOLDService _usersOLDService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        private IDBUsersService _dBUsersService;
        private IAltDepartmanService _altDepartmanService;
        private IUnvanService _unvanService;
        private IBolumService _bolumService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        public ReportPersonelController(ISirketService sirketService, IDepartmanService departmanService, IBloklarService bloklarService, IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGlobalZoneService globalZoneService, IGroupMasterService groupMasterService, IUserService userService, IReportService reportService, IUsersOLDService usersOLDService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService, IDBUsersService dBUsersService, IAltDepartmanService altDepartmanService, IUnvanService unvanService, IBolumService bolumService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _userService = userService;
            _sirketService = sirketService;
            _departmanService = departmanService;
            _bloklarService = bloklarService;
            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _globalZoneService = globalZoneService;
            _groupMasterService = groupMasterService;
            _reportService = reportService;
            _usersOLDService = usersOLDService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _doorNamesService = doorNamesService;
            _dBUsersService = dBUsersService;
            _altDepartmanService = altDepartmanService;
            _unvanService = unvanService;
            _bolumService = bolumService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();

        }
        // GET: ReportPersonelAktif
        public ActionResult Index(ActiveUserReportParameters parameters)
        {
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var liste = _reportService.GetReportPersonelLists(parameters);
            var kullanicilar = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            var eskiKullanicilar = _usersOLDService.GetAllUserOLDWithOuther().OrderBy(x => x.Kayit_No).ToList();
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Kullanıcı = kullanicilar,
                EskiKullanicilar = eskiKullanicilar,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Blok = bloklar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Blok_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
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
            TempData["ReportPersonel"] = liste;
            return View(model);

        }




        // GET: ReportPersonelEski
        public ActionResult OldStaff(ActiveUserReportParameters parameters)
        {

            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var liste = _reportService.GetReportPersonelListsEski(parameters);
            var kullanicilar = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            var eskiKullanicilar = _usersOLDService.GetAllUserOLDWithOuther().OrderBy(x => x.Kayit_No).ToList();
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum();
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Kullanıcı = kullanicilar,
                EskiKullanicilar = eskiKullanicilar,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Blok = bloklar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Blok_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
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
            TempData["ReportPersonel"] = liste;
            return View(model);
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

        public ActionResult AktifZiyaretciler()//Popup'a Aktif Kulanıcı Yükleniyor
        {
            List<EfUserDal.ComplexUser> liste = new List<EfUserDal.ComplexUser>();
            liste = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EskiZiyaretciler()//Popup'a Eski Kullanıcı Yükleniyor
        {
            List<EfUsersOLDDal.ComplexUserOld> liste = new List<EfUsersOLDDal.ComplexUserOld>();
            liste = _usersOLDService.GetAllUserOLDWithOuther().OrderBy(x => x.Kayit_No).ToList();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }




        //EXCELL EXPORT
        public void PersonelRaporları()
        {

            List<ReportPersonelList> liste = new List<ReportPersonelList>();
            liste = TempData["ReportPersonel"] as List<ReportPersonelList>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetReportPersonelLists(new ActiveUserReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Personel Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "TC Kimlik";
            worksheet.Cells["F6"].Value = "Telefon";
            worksheet.Cells["G6"].Value = "Şirket";
            worksheet.Cells["H6"].Value = "Departman";
            worksheet.Cells["I6"].Value = "Plaka";
            worksheet.Cells["J6"].Value = "Blok";
            worksheet.Cells["K6"].Value = "Daire";
            worksheet.Cells["L6"].Value = "Grup Adı";
            worksheet.Cells["M6"].Value = "Panel";
            worksheet.Cells["N6"].Value = "Kapı";
            worksheet.Cells["O6"].Value = "Geçiş";
            worksheet.Cells["P6"].Value = "Tarih";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:P6"].Style.Font.Size = 13;
            worksheet.Cells["A6:P6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Telefon;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Plaka;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.BlokAdi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Daire;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("M{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("N{0}", rowStart)].Value = item.Kapi;
                worksheet.Cells[string.Format("O{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("P{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
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