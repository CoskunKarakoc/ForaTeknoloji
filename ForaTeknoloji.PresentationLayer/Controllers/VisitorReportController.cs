using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
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
    public class VisitorReportController : Controller
    {
        private IVisitorsService _visitorsService;
        private IPanelSettingsService _panelSettingsService;
        private IGroupMasterService _groupMasterService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        private IDBUsersKapiService _dBUsersKapiService;
        private IReaderSettingsNewService _readerSettingsNewService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        List<int> dbPanelList;
        List<int> dbDoorList;
        public VisitorReportController(IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGroupMasterService groupMasterService, IGlobalZoneService globalZoneService, IReportService reportService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService, IDBUsersKapiService dBUsersKapiService, IReaderSettingsNewService readerSettingsNewService)
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
            _dBUsersKapiService = dBUsersKapiService;
            _readerSettingsNewService = readerSettingsNewService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            dbPanelList = new List<int>();
            dbDoorList = new List<int>();
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserDoorNo in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Kapi_Kayit_No))
            {
                dbDoorList.Add((int)dbUserDoorNo);
            }
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetDoorList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);

        }
        // GET: VisitorReport
        public ActionResult Index(VisitorReportParameters parameters)
        {
            List<Visitors> visitors = new List<Visitors>();

            var liste = _reportService.GetZiyaretciListesi(parameters);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != 0 && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && dbPanelList.Contains((int)x.Panel_ID));
            visitors = _visitorsService.GetAllVisitors();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new VisitorsList
            {

                ComplexVisitorsListesi = liste,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Visitors = visitors,
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
            };
            TempData["VisitorsList"] = liste;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            return View(model);
        }

        //Ziyaretci Listesi
        public ActionResult ComplexVisitors()
        {
            List<Visitors> liste = new List<Visitors>();
            liste = _visitorsService.GetAllVisitors();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PanelKapiListesi(int? PanelNo)
        {
            if (PanelNo != null && PanelNo != 0)
            {
                List<ReaderSettingsNew> readerSettingsNews = new List<ReaderSettingsNew>();
                if (_panelSettingsService.GetById((int)PanelNo).Panel_Model == (int)PanelModel.Panel_301)
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 8);
                }
                else if (_panelSettingsService.GetById((int)PanelNo).Panel_Model == (int)PanelModel.Panel_302)
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 2);
                }
                else if (_panelSettingsService.GetById((int)PanelNo).Panel_Model == (int)PanelModel.Panel_304)
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 4);
                }
                else
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 1);
                }

                List<SelectListItem> doorNameList = new List<SelectListItem>();
                var selectedPanel = readerSettingsNews.Select(a => new SelectListItem
                {
                    Text = a.WKapi_Adi,
                    Value = a.WKapi_ID.ToString()
                });
                return Json(selectedPanel, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }

        //EXCELL EXPORT
        public void ZiyaretciListesi()
        {
            List<ZiyaretciRaporList> liste = new List<ZiyaretciRaporList>();

            liste = TempData["VisitorsList"] as List<ZiyaretciRaporList>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetZiyaretciListesi(new VisitorReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Ziyaretçi Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
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
            worksheet.Cells["A6:O6"].Style.Font.Size = 13;
            worksheet.Cells["A6:O6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
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