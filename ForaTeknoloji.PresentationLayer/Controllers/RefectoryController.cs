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
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{

    [Auth]
    [Excp]
    public class RefectoryController : Controller
    {
        private IReaderSettingsNewService _readerSettingsNewService;
        private IPanelSettingsService _panelSettingsService;
        private IReportService _reportService;
        private IDBUsersService _dBUsersService;
        private IGroupMasterService _groupMasterService;
        private IGroupsDetailNewService _groupsDetailNewService;
        private IDoorGroupsMasterService _doorGroupsMasterService;
        private IDoorGroupsDetailService _doorGroupsDetailService;
        private IEmailSettingsService _emailSettingsService;
        private ISirketService _sirketService;
        private IAltDepartmanService _altDepartmanService;
        private IBolumService _bolumService;
        private IBirimService _birimService;
        private IDepartmanService _departmanService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        DBUsers user;
        DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        List<int> dbAltDepartmanList;
        public RefectoryController(IReaderSettingsNewService readerSettingsNewService, IPanelSettingsService panelSettingsService, IReportService reportService, IDBUsersService dBUsersService, IGroupMasterService groupMasterService, IGroupsDetailNewService groupsDetailNewService, IDoorGroupsMasterService doorGroupsMasterService, IDoorGroupsDetailService doorGroupsDetailService, IEmailSettingsService emailSettingsService, ISirketService sirketService, IDepartmanService departmanService, IAltDepartmanService altDepartmanService, IBolumService bolumService, IBirimService birimService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersAltDepartmanService dBUsersAltDepartmanService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _readerSettingsNewService = readerSettingsNewService;
            _panelSettingsService = panelSettingsService;
            _reportService = reportService;
            _dBUsersService = dBUsersService;
            _groupMasterService = groupMasterService;
            _groupsDetailNewService = groupsDetailNewService;
            _doorGroupsDetailService = doorGroupsDetailService;
            _doorGroupsMasterService = doorGroupsMasterService;
            _emailSettingsService = emailSettingsService;
            _sirketService = sirketService;
            _departmanService = departmanService;
            _altDepartmanService = altDepartmanService;
            _bolumService = bolumService;
            _birimService = birimService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbSirketList = new List<int>();
            dbAltDepartmanList = new List<int>();
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
            foreach (var dbUserAltDepartmanNo in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Alt_Departman_No))
            {
                dbAltDepartmanList.Add((int)dbUserAltDepartmanNo);
            }
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: Refectory
        public ActionResult Index(RefectoryParameters parameters)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            var Liste = _reportService.YemekhaneRaporu(parameters);
            var Toplam = _reportService.YemekhaneRaporuTotal(parameters);
            var Groups = _doorGroupsMasterService.GetAllDoorGroupsMaster();
            var Email = _emailSettingsService.GetAllEMailSetting().FirstOrDefault();
            var Sikterler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_reportService.SirketListesi(user);
            var Departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No)); //_reportService.DepartmanListesi(user);
            var AltDepartman = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman_No && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var Bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.Alt_Departman_No && x.Departman_No == parameters.Departman_No);
            var Birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman_No && x.Alt_Departman_No == parameters.Alt_Departman_No && x.Bolum_No == parameters.Bolum_No);
            var model = new RefectoryListViewModel
            {
                Group_ID = Groups.Select(a => new SelectListItem
                {
                    Text = a.Kapi_Grup_Adi,
                    Value = a.Kapi_Grup_No.ToString()
                }),
                Sirket_No = Sikterler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Departman_No = Departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Alt_Departman_No = AltDepartman.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Bolum_No = Bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = Birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                }),
                YemekhaneListe = Liste,
                ToplamGecis = Toplam,
                EmailSettings = Email,
                User = user
            };
            TempData["UserAccessCount"] = Liste;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);

            return View(model);
        }

        public ActionResult Total(RefectoryParameters parameters)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }

            var Total = _reportService.YemekhaneRaporuTotal(parameters);
            var Groups = _doorGroupsMasterService.GetAllDoorGroupsMaster();
            var Email = _emailSettingsService.GetAllEMailSetting().FirstOrDefault();
            var Departmanlar = _departmanService.GetAllDepartmanlar(x => dbSirketList.Contains(x.Departman_No)); //_reportService.DepartmanListesi(user);
            var Sikterler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_reportService.SirketListesi(user);
            var AltDepartman = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman_No && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var Bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.Alt_Departman_No && x.Departman_No == parameters.Departman_No);
            var Birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman_No && x.Alt_Departman_No == parameters.Alt_Departman_No && x.Bolum_No == parameters.Bolum_No);
            ViewBag.Kapi_Grup_No = new SelectList(_doorGroupsMasterService.GetAllDoorGroupsMaster(), "Kapi_Grup_No", "Kapi_Grup_Adi", Email.Kapi_Grup_No);
            var model = new RefectoryListViewModel
            {
                Group_ID = Groups.Select(a => new SelectListItem
                {
                    Text = a.Kapi_Grup_Adi,
                    Value = a.Kapi_Grup_No.ToString()
                }),
                Sirket_No = Sikterler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Departman_No = Departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Alt_Departman_No = AltDepartman.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Bolum_No = Bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = Birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                }),
                ToplamGecis = Total,
                EmailSettings = Email,
                User = user
            };
            TempData["UserAccessCountTotal"] = Total;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            return View(model);
        }

        [HttpPost]
        public ActionResult MailSettings(EMailSetting eMailSetting)
        {
            if (ModelState.IsValid)
            {
                _emailSettingsService.UpdateEMailSetting(eMailSetting);
                return RedirectToAction("Total", "Refectory");
            }
            return RedirectToAction("Total", "Refectory");
        }


        public void UserAccessCount()
        {
            List<YemekhaneComplex> liste = new List<YemekhaneComplex>();
            liste = TempData["UserAccessCount"] as List<YemekhaneComplex>;
            if (liste == null || liste.Count == 0)
            {
                liste = new List<YemekhaneComplex>();
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Yemekhane Raporları";
            worksheet.Cells["A3"].Value = "Tarihi";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:HH: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "Geçiş Sayısı";
            worksheet.Cells["B6"].Value = "ID";
            worksheet.Cells["C6"].Value = "Kart ID";
            worksheet.Cells["D6"].Value = "Adı";
            worksheet.Cells["E6"].Value = "Soyadı";
            worksheet.Cells["F6"].Value = "Tc Kimlik No";
            worksheet.Cells["G6"].Value = "Panel ID";
            worksheet.Cells["H6"].Value = "Panel Adı";
            worksheet.Cells["I6"].Value = "Kapı ID";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:I6"].Style.Font.Size = 13;
            worksheet.Cells["A6:I6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Gecis_Sayisi;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.TC_Kimlik;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Panel_Name;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Kapi_ID;
                rowStart++;
            }
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }


        public void UserAccessCountTotal()
        {
            List<YemekhaneComplexTotal> liste = new List<YemekhaneComplexTotal>();
            liste = TempData["UserAccessCountTotal"] as List<YemekhaneComplexTotal>;
            if (liste == null || liste.Count == 0)
            {
                liste = new List<YemekhaneComplexTotal>();
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Yemekhane Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:HH: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "Cihaz No";
            worksheet.Cells["B6"].Value = "Cihaz Adı";
            worksheet.Cells["C6"].Value = "İlk İşlem Zamanı";
            worksheet.Cells["D6"].Value = "Son İşlem Zamanı";
            worksheet.Cells["E6"].Value = "Onaylı Geçiş Sayısı";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:E6"].Style.Font.Size = 13;
            worksheet.Cells["A6:E6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            int AccessCount = 0;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.PanelID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.PanelAdi;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Ilk_Kayit;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Son_Kayit;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.GecisSayi;
                AccessCount += (int)item.GecisSayi;
                rowStart++;
            }
            worksheet.Cells[string.Format("D{0}", rowStart)].Value = "TOPLAM";
            worksheet.Cells[string.Format("D{0}", rowStart)].Style.Font.Size = 13;
            worksheet.Cells[string.Format("D{0}", rowStart)].Style.Font.Bold = true;
            worksheet.Cells[string.Format("E{0}", rowStart)].Value = AccessCount;
            worksheet.Cells[string.Format("E{0}", rowStart)].Style.Font.Size = 13;
            worksheet.Cells[string.Format("E{0}", rowStart)].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }


       
    }
}