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
    public class OutherReportController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IPanelSettingsService _panelSettingsService;
        private IReportService _reportService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user = new DBUsers();
        public OutherReportController(IAccessDatasService accessDatasService, IPanelSettingsService panelSettingsService, IReportService reportService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _accessDatasService = accessDatasService;
            _panelSettingsService = panelSettingsService;
            _reportService = reportService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _doorNamesService = doorNamesService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();

            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
        }


        // GET: OutherReport
        public ActionResult Index()
        {
            var liste = _reportService.GetDigerGecisListesi(null, null, null, null, null, null, null, null, 100, null);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var model = new DigerGecisRaporListViewModel
            {
                DigerGecisListesi = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(List<string> Kapi, bool? Tümü, bool? TümPanel, int? Paneller, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, int Tetikleme, string KapiYon = "")
        {

            if (Tetikleme == 26)
            {

                var listKulAlarm = _reportService.GetDigerGecisRaporListKullaniciAlarms(Kapi, Tümü, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, 26, KapiYon);
                var panell = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
                var modelAlarm = new DigerGecisRaporAlarmListViewModel
                {
                    DigerGecisListesiAlarm = listKulAlarm,
                    Paneller = panell.Select(a => new SelectListItem
                    {
                        Text = a.Panel_Name,
                        Value = a.Panel_ID.ToString()
                    })
                };
                TempData["DigerGecisAlarm"] = modelAlarm;
                return RedirectToAction("KullaniciAlarm", "OutherReport");
            }
            else
            {
                var liste = _reportService.GetDigerGecisListesi(Kapi, Tümü, TümPanel, Paneller, Tarih1, Tarih2, Saat1, Saat2, Tetikleme, KapiYon);
                var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
                var model = new DigerGecisRaporListViewModel
                {
                    DigerGecisListesi = liste,
                    Paneller = panel.Select(a => new SelectListItem
                    {
                        Text = a.Panel_Name,
                        Value = a.Panel_ID.ToString()
                    })
                };
                TempData["DigerGecis"] = liste;
                return View(model);
            }
        }



        //Kullanıcı Alarmlarında Daha Fazla Veri Geldiği İçin Bunu Ayrı Bir Sayfada Yaptım
        public ActionResult KullaniciAlarm()
        {
            var nesne = TempData["DigerGecisAlarm"] as DigerGecisRaporAlarmListViewModel;
            return View(nesne);
        }


        public ActionResult KapiListesi()
        {
            var liste = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            return Json(_doorNamesService.GetAllDoorNames(x => liste.Contains(x.Panel_No)), JsonRequestBehavior.AllowGet);
        }



        //Export Excell
        public void DigerGecisListesi()
        {
            List<DigerGecisRaporList> lists = new List<DigerGecisRaporList>();

            lists = TempData["DigerGecis"] as List<DigerGecisRaporList>;
            if (lists == null || lists.Count == 0)
            {
                lists = _reportService.GetDigerGecisListesi(null, null, null, null, null, null, null, null, 100, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Diğer Geçiş Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Panel";
            worksheet.Cells["B6"].Value = "Kapı";
            worksheet.Cells["C6"].Value = "Geçiş";
            worksheet.Cells["D6"].Value = "Operasyon";
            worksheet.Cells["E6"].Value = "Tarih";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in lists)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kapi_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Operasyon;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Tarih;
                rowStart++;

            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + lists.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Export Excell Alarm
        public void DigerGecisListesiAlarm()
        {
            DigerGecisRaporAlarmListViewModel nesne;
            nesne = TempData["DigerGecisAlarm"] as DigerGecisRaporAlarmListViewModel;
            List<DigerGecisRaporListKullaniciAlarm> liste = new List<DigerGecisRaporListKullaniciAlarm>();
            liste = nesne.DigerGecisListesiAlarm;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetDigerGecisRaporListKullaniciAlarms(null, null, null, null, DateTime.Now, null, null, null, 26, "giris");
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Diğer Geçiş Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Kayıt No";
            worksheet.Cells["B6"].Value = "ID";
            worksheet.Cells["C6"].Value = "Kart ID";
            worksheet.Cells["D6"].Value = "Adı";
            worksheet.Cells["E6"].Value = "Soyadı";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Panel";
            worksheet.Cells["H6"].Value = "Kapı";
            worksheet.Cells["I6"].Value = "Geçiş";
            worksheet.Cells["J6"].Value = "Operasyon";
            worksheet.Cells["K6"].Value = "Tarih";

            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Kayit_No;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.PanelID;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Kapi_ID;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Operasyon;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Tarih;
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