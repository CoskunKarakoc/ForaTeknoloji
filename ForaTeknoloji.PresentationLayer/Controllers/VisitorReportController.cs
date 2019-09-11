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
    public class VisitorReportController : Controller
    {
        private IVisitorsService _visitorsService;
        private IPanelSettingsService _panelSettingsService;
        private IGroupsDetailService _groupsDetailService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user = new DBUsers();
        public VisitorReportController(IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGroupsDetailService groupsDetailService, IGlobalZoneService globalZoneService, IReportService reportService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _groupsDetailService = groupsDetailService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _doorNamesService = doorNamesService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();

        }
        // GET: VisitorReport
        public ActionResult Index()
        {
            var liste = _reportService.GetZiyaretciListesi(null, null, null, null, null, null, null, null, null, null, null);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var visitors = _visitorsService.GetAllVisitors();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new VisitorsList
            {

                ComplexVisitorsListesi = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Visitors = visitors,
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
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(List<string> Kapi, bool? Tümü, int? Visitors, int? Global_Bolge_Adi, int? Groupsdetail, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Kayit = "", string KapiYon = "", string Search = "")
        {

            var liste = _reportService.GetZiyaretciListesi(Kapi, Tümü, Visitors, Global_Bolge_Adi, Groupsdetail, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Kayit, KapiYon);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var visitors = _visitorsService.GetAllVisitors();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new VisitorsList
            {

                ComplexVisitorsListesi = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Visitors = visitors,
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
            };

            TempData["VisitorsList"] = liste;
            if (Search != null && Search != "")
            {
                liste = _reportService.GetZiyaretciListesi(Kapi, Tümü, Global_Bolge_Adi, Groupsdetail, Visitors, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Kayit, KapiYon);
                panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
                visitors = _visitorsService.GetAllVisitors(x => x.Adi.Contains(Search) || x.Soyadi.Contains(Search) || x.Plaka.Contains(Search));
                groupsdetail = _groupsDetailService.GetAllGroupsDetail();
                globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
                model = new VisitorsList
                {

                    ComplexVisitorsListesi = liste,
                    Paneller = panel.Select(a => new SelectListItem
                    {
                        Text = a.Panel_Name,
                        Value = a.Panel_ID.ToString()
                    }),
                    Visitors = visitors,
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
                };

            }
            return View(model);
        }


        public ActionResult KapiListesi()
        {
            var liste = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            return Json(_doorNamesService.GetAllDoorNames(x => liste.Contains(x.Panel_No)), JsonRequestBehavior.AllowGet);
        }


        //EXCELL EXPORT
        public void ZiyaretciListesi()
        {
            List<ZiyaretciRaporList> liste = new List<ZiyaretciRaporList>();

            liste = TempData["VisitorsList"] as List<ZiyaretciRaporList>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetZiyaretciListesi(null, null, null, null, null, null, null, null, null, null, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Ziyaretçi Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Telefon";
            worksheet.Cells["G6"].Value = "Plaka";
            worksheet.Cells["H6"].Value = "Ziyaret Sebebi";
            worksheet.Cells["I6"].Value = "Grup Adı";
            worksheet.Cells["J6"].Value = "Panel";
            worksheet.Cells["K6"].Value = "Kapı";
            worksheet.Cells["L6"].Value = "Geçiş";
            worksheet.Cells["M6"].Value = "Tarih";
            worksheet.Cells["N6"].Value = "Personel Adı";
            worksheet.Cells["O6"].Value = "Personel Soyadı";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Ziyaretci_Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Ziyaretci_Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Ziyaretci_TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Ziyaretci_Telefon;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Ziyaretci_Plaka;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Ziyaret_Sebebi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Kapi_ID;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Gecis_Tipi;
                worksheet.Cells[string.Format("M{0}", rowStart)].Value = item.Tarih;
                worksheet.Cells[string.Format("N{0}", rowStart)].Value = item.Personel_Adi;
                worksheet.Cells[string.Format("O{0}", rowStart)].Value = item.Personel_Soyadi;
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