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
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfVisitorsDal;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class VisitorReportController : Controller
    {
        private IVisitorsService _visitorsService;
        private IPanelSettingsService _panelSettingsService;
        private IGroupMasterService _groupMasterService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        public VisitorReportController(IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGroupMasterService groupMasterService, IGlobalZoneService globalZoneService, IReportService reportService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _groupMasterService = groupMasterService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _doorNamesService = doorNamesService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();

        }
        // GET: VisitorReport
        public ActionResult Index(List<string> Kapi = null, bool? Tümü = null, int? Visitors = null, int? Global_Bolge_Adi = null, int? Groupsdetail = null, bool? TümPanel = null, int? Paneller = null, DateTime? Tarih1 = null, DateTime? Tarih2 = null, DateTime? Saat1 = null, DateTime? Saat2 = null, string Kayit = "", string KapiYon = "", string Search = "", bool TümTarih = false)
        {
            if (TümTarih != true)
            {
                Tarih1 = Tarih1 ?? DateTime.Now.Date;
            }
            List<Visitors> visitors = new List<Visitors>();

            var liste = _reportService.GetZiyaretciListesi(Kapi, Tümü, Visitors, Global_Bolge_Adi, Groupsdetail, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Kayit, KapiYon);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != 0 && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));

            if (Search != null && Search != "")
            {
                visitors = _visitorsService.GetAllVisitors(x => x.Adi.Contains(Search) || x.Soyadi.Contains(Search) || x.Plaka.Contains(Search));
            }
            else
            {
                visitors = _visitorsService.GetAllVisitors();
            }
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
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
                    Value = a.Grup_No.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
            };
            TempData["VisitorsList"] = liste;
            return View(model);
        }

        //Ziyaretci Listesi ve Search İşlemi
        public ActionResult ComplexVisitors(string Search)
        {
            List<Visitors> liste = new List<Visitors>();
            if (Search == null || Search == "")
            {
                liste = _visitorsService.GetAllVisitors();
            }
            else
            {
                liste = _visitorsService.GetAllVisitors(x => x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.TCKimlik.Contains(Search.Trim()) || x.Ziyaret_Sebebi.Contains(Search.Trim()) || x.Telefon.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()));

            }
            return Json(liste, JsonRequestBehavior.AllowGet);
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
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Kapi;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Gecis_Tipi;
                worksheet.Cells[string.Format("M{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
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