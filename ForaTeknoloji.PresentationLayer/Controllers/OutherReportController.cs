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

    [Auth]//Authentication İçin Yazılmış Filtre
    [Excp]
    public class OutherReportController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IPanelSettingsService _panelSettingsService;
        private IReportService _reportService;
        private IDoorNamesService _doorNamesService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        public OutherReportController(IAccessDatasService accessDatasService, IPanelSettingsService panelSettingsService, IReportService reportService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService)
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
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbSirketList = new List<int>();
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanList.Add((int)dbUserDepartmanNo);
            }
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserSirketNo in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Sirket_No))
            {
                dbSirketList.Add((int)dbUserSirketNo);
            }
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);//Account olan kullanıcının panel listeleme metoduna kullanıcı gönderiliyor 
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);//Account olan kullanıcının şirket listeleme metoduna kullanıcı gönderiliyor
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);//Account olan kullanıcının departman listeleme metoduna kullanıcı gönderiliyor
        }


        // GET: OutherReport
        public ActionResult Index(OutherReportParameters parameters)
        {
            var liste = _reportService.GetDigerGecisListesi(parameters);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && dbPanelList.Contains((int)x.Panel_ID));
            var model = new DigerGecisRaporListViewModel
            {
                DigerGecisListesi = liste,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                })
            };
            TempData["DigerGecis"] = liste;
            return View(model);
        }



        //Kullanıcı Alarmlarında Daha Fazla Veri Geldiği İçin Bunu Ayrı Bir Sayfada Yaptım
        public ActionResult KullaniciAlarm(OutherReportParameters parameters)
        {
            var listKulAlarm = _reportService.GetDigerGecisRaporListKullaniciAlarms(parameters);
            var panell = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && dbPanelList.Contains((int)x.Panel_ID));
            var modelAlarm = new DigerGecisRaporAlarmListViewModel
            {
                DigerGecisListesiAlarm = listKulAlarm,
                Panel = panell.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                })
            };
            TempData["DigerGecisAlarm"] = listKulAlarm;
            return View(modelAlarm);
        }





        //Export Excell
        public void DigerGecisListesi()
        {
            List<DigerGecisRaporList> lists = new List<DigerGecisRaporList>();

            lists = TempData["DigerGecis"] as List<DigerGecisRaporList>;
            if (lists == null || lists.Count == 0)
            {
                lists = _reportService.GetDigerGecisListesi(new OutherReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Diğer Geçiş Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Panel";
            worksheet.Cells["B6"].Value = "Kapı";
            worksheet.Cells["C6"].Value = "Geçiş";
            worksheet.Cells["D6"].Value = "Operasyon";
            worksheet.Cells["E6"].Value = "Tarih";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:E6"].Style.Font.Size = 13;
            worksheet.Cells["A6:E6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in lists)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kapi;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Operasyon;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
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
            List<DigerGecisRaporListKullaniciAlarm> liste = new List<DigerGecisRaporListKullaniciAlarm>();
            liste = TempData["DigerGecisAlarm"] as List<DigerGecisRaporListKullaniciAlarm>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetDigerGecisRaporListKullaniciAlarms(new OutherReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Diğer Geçiş Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
            worksheet.Cells["A6:K6"].Style.Font.Size = 13;
            worksheet.Cells["A6:K6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
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
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
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