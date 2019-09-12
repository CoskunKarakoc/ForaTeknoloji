using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using OfficeOpenXml;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    public class PersonelListReportController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private IBloklarService _bloklarService;
        private IGroupsDetailService _groupsDetailService;
        private ISirketService _sirketService;
        private IGlobalZoneService _globalZoneService;
        private IGroupMasterService _groupMasterService;
        private IReportService _reportService;
        public DBUsers user;
        public PersonelListReportController(IUserService userService, IDepartmanService departmanService, IBloklarService bloklarService, IGroupsDetailService groupsDetailService, ISirketService sirketService, IGlobalZoneService globalZoneService, IGroupMasterService groupMasterService, IReportService reportService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _userService = userService;
            _departmanService = departmanService;
            _bloklarService = bloklarService;
            _groupsDetailService = groupsDetailService;
            _sirketService = sirketService;
            _globalZoneService = globalZoneService;
            _groupMasterService = groupMasterService;
            _reportService = reportService;


        }



        // GET: PersonelListReport
        public ActionResult Index()
        {

            var personelLists = _reportService.GetPersonelLists(null, null, null, null, null, null, null);
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var model = new PersonelListViewModel
            {
                ListCount = personelLists.Count.ToString(),
                PersonelListesi = personelLists.ToList(),
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
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                })

            };
            TempData["dataGrid"] = personelLists;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int? Sirketler, int? Departmanlar, int? Bloklar, int? Groupsdetail, int? Global_Bolge_Adi, int? Daire, string Plaka = "")
        {

            var personelLists = _reportService.GetPersonelLists(Sirketler, Departmanlar, Bloklar, Groupsdetail, Global_Bolge_Adi, Daire, Plaka);
            var departmanlar = _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var sirketler = _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();

            var model = new PersonelListViewModel
            {
                ListCount = personelLists.Count.ToString(),
                PersonelListesi = personelLists.ToList(),
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
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                })

            };
            TempData["dataGrid"] = personelLists;
            TempData["PersonelLists"] = personelLists;
            return View(model);
        }






        //EXCELL EXPORT
        public void PersonelListesi()
        {
            List<PersonelList> liste = new List<PersonelList>();

            liste = TempData["PersonelLists"] as List<PersonelList>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetPersonelLists(null, null, null, null, null, null, null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Personel Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Plaka";
            worksheet.Cells["I6"].Value = "Blok";
            worksheet.Cells["J6"].Value = "Daire";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
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
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Plaka;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BlokAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Daire;
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