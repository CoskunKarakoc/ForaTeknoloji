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
    public class PersonelListReportController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private IBloklarService _bloklarService;
        private IGroupMasterService _groupMasterService;
        private ISirketService _sirketService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IAltDepartmanService _altDepartmanService;
        private IUnvanService _unvanService;
        private IBolumService _bolumService;
        private IAccessDatasService _accessDatasService;
        private IBirimService _birimService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        List<int> dbAltDepartmanList;
        public DBUsers user = CurrentSession.User;
        public PersonelListReportController(IUserService userService, IDepartmanService departmanService, IBloklarService bloklarService, IGroupMasterService groupMasterService, ISirketService sirketService, IGlobalZoneService globalZoneService, IReportService reportService, IAltDepartmanService altDepartmanService, IUnvanService unvanService, IBolumService bolumService, IAccessDatasService accessDatasService, IBirimService birimService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersAltDepartmanService dBUsersAltDepartmanService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _userService = userService;
            _departmanService = departmanService;
            _bloklarService = bloklarService;
            _groupMasterService = groupMasterService;
            _sirketService = sirketService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;
            _altDepartmanService = altDepartmanService;
            _unvanService = unvanService;
            _bolumService = bolumService;
            _accessDatasService = accessDatasService;
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
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
        }



        // GET: PersonelListReport
        public ActionResult Index(PersonelListReportParameters parameters)
        {
            var personelLists = _reportService.GetPersonelLists(parameters, CurrentSession.User);
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var bloklar = _bloklarService.GetAllBloklar();
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No));
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var alddepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.Alt_Departman_No && x.Departman_No == parameters.Departman);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.Alt_Departman_No && x.Bolum_No == parameters.Bolum_No);
            var model = new PersonelListViewModel
            {
                ListCount = personelLists.Count.ToString(),
                PersonelListesi = personelLists.ToList(),
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
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Alt_Departman_No = alddepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan_No = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum_No = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                }),

            };
            TempData["PersonelLists"] = personelLists;
            return View(model);
        }



        public ActionResult AltDepartmanListesi(int? Departman)
        {
            if (Departman != 0 && Departman != null)
            {
                var list = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectAltDepartman = list.Select(a => new SelectListItem
                    {
                        Text = a.Adi,
                        Value = a.Alt_Departman_No.ToString()
                    });
                    return Json(selectAltDepartman, JsonRequestBehavior.AllowGet);
                }

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
                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectBolum = list.Select(a => new SelectListItem
                    {
                        Text = a.Adi,
                        Value = a.Bolum_No.ToString()
                    });
                    return Json(selectBolum, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BirimListesi(int? AltDepartman, int? Bolum)
        {
            if (AltDepartman != null && AltDepartman != 0 && Bolum != null && Bolum != 0)
            {

                var list = _birimService.GetAllBirim(x => x.Alt_Departman_No == AltDepartman && x.Bolum_No == Bolum);
                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Birim Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectBirim = list.Select(a => new SelectListItem
                    {
                        Text = a.Adi,
                        Value = a.Birim_No.ToString()
                    });
                    return Json(selectBirim, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Birim Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }





        //EXCELL EXPORT
        public void PersonelListesi()
        {
            List<PersonelList> liste = new List<PersonelList>();

            liste = TempData["PersonelLists"] as List<PersonelList>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetPersonelLists(new PersonelListReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Personel Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Alt Departman";
            worksheet.Cells["I6"].Value = "Bölüm";
            worksheet.Cells["J6"].Value = "Birim";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
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
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Birim_Adi;
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


    }
}