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
    public class VisitorReportController : Controller
    {
        private IVisitorsService _visitorsService;
        private IPanelSettingsService _panelSettingsService;
        private IGroupsDetailService _groupsDetailService;
        private IGlobalZoneService _globalZoneService;
        public VisitorReportController(IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGroupsDetailService groupsDetailService, IGlobalZoneService globalZoneService)
        {
            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _groupsDetailService = groupsDetailService;
            _globalZoneService = globalZoneService;
        }
        // GET: VisitorReport
        public ActionResult Index()
        {
            var liste = _visitorsService.GetZiyaretciListesi(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            var panel = _panelSettingsService.GetAllPanelSettings();
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
        public ActionResult Index(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, int? Global_Bolge_Adi, int? Groupsdetail, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string Kayit = "", string KapiYon = "", string Search = "")
        {
            var liste = _visitorsService.GetZiyaretciListesi(Kapi1, Kapi2, Kapi3, Kapi4, Kapi5, Kapi6, Kapi7, Kapi8, Global_Bolge_Adi, Groupsdetail, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Kayit, KapiYon);
            var panel = _panelSettingsService.GetAllPanelSettings();
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
                liste = _visitorsService.GetZiyaretciListesi(Kapi1, Kapi2, Kapi3, Kapi4, Kapi5, Kapi6, Kapi7, Kapi8, Global_Bolge_Adi, Groupsdetail, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Kayit, KapiYon);
                panel = _panelSettingsService.GetAllPanelSettings();
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


        //EXCELL EXPORT
        public void ZiyaretciListesi()
        {
            List<ZiyaretciRaporList> liste = new List<ZiyaretciRaporList>();

            liste = TempData["VisitorsList"] as List<ZiyaretciRaporList>;

            if (liste == null || liste.Count == 0)
            {
                liste = _visitorsService.GetZiyaretciListesi(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
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