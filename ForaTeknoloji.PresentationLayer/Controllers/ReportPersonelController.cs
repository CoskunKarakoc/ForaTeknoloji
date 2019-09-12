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
    public class ReportPersonelController : Controller
    {
        private IUserService _userService;
        private ISirketService _sirketService;
        private IDepartmanService _departmanService;
        private IBloklarService _bloklarService;
        private IVisitorsService _visitorsService;
        private IGroupsDetailService _groupsDetailService;
        private IPanelSettingsService _panelSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IGroupMasterService _groupMasterService;
        private IReportService _reportService;
        private IUsersOLDService _usersOLDService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        public ReportPersonelController(ISirketService sirketService, IDepartmanService departmanService, IBloklarService bloklarService, IVisitorsService visitorsService, IGroupsDetailService groupsDetailService, IPanelSettingsService panelSettingsService, IGlobalZoneService globalZoneService, IGroupMasterService groupMasterService, IUserService userService, IReportService reportService, IUsersOLDService usersOLDService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService)
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
            _groupsDetailService = groupsDetailService;
            _panelSettingsService = panelSettingsService;
            _globalZoneService = globalZoneService;
            _groupMasterService = groupMasterService;
            _reportService = reportService;
            _usersOLDService = usersOLDService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _doorNamesService = doorNamesService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();

        }
        // GET: ReportPersonel
        public ActionResult Index()
        {
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var liste = _reportService.GetReportPersonelLists(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
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
                Departmanlar = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Bloklar = bloklar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Blok_No.ToString()
                }),
                Sirketler = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                })


            };
            TempData["reportListe"] = liste;
            return View(model);

        }
        [HttpPost]
        public ActionResult Index(List<string> Kapi, bool? Günlük, bool? Tümü, bool? TümKullanici, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Visitors, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kullanici = null, string Kayit = null)
        {
            var liste = _reportService.GetReportPersonelLists(Kapi, Günlük, Tümü, TümKullanici, Sirketler, Departmanlar, Bloklar, TümPanel, Visitors, Panel, Groupsdetail, Daire, Tarih1, Tarih2, Saat1, Saat2, KapiYon, Plaka, Kullanici, Kayit);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
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
                Departmanlar = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Bloklar = bloklar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Blok_No.ToString()
                }),
                Sirketler = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),


            };
            TempData["reportListe"] = liste;
            TempData["ReportPersonel"] = liste;
            return View(model);

        }

        public ActionResult AktifZiyaretciler()//Popup'a Aktif Kulanıcı Yükleniyor
        {
            return Json(_userService.GetAllUsers().OrderBy(x => x.Kayit_No), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EskiZiyaretciler()//Popup'a Eski Kullanıcı Yükleniyor
        {
            return Json(_usersOLDService.GetAllUsersOLD().OrderBy(x => x.Kayit_No), JsonRequestBehavior.AllowGet);
        }

        public ActionResult KapiListesi()//Kullanıcıya ait olan panellerin kapıları listeleniyor
        {
            var liste = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            return Json(_doorNamesService.GetAllDoorNames(x => liste.Contains(x.Panel_No)), JsonRequestBehavior.AllowGet);
        }

        //EXCELL EXPORT
        public void PersonelRaporları()
        {

            List<ReportPersonelList> liste = new List<ReportPersonelList>();
            liste = TempData["ReportPersonel"] as List<ReportPersonelList>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetReportPersonelLists(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Personel Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
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
                worksheet.Cells[string.Format("N{0}", rowStart)].Value = item.Kapi_ID;
                worksheet.Cells[string.Format("O{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("P{0}", rowStart)].Value = item.Tarih;
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