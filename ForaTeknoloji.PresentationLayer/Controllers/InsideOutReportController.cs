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
    public class InsideOutReportController : Controller
    {
        private IVisitorsService _visitorsService;
        private IPanelSettingsService _panelSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IReaderSettingsService _readerSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        public InsideOutReportController(IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGlobalZoneService globalZoneService, IReportService reportService, IReaderSettingsService readerSettingsService, IDBUsersPanelsService dBUsersPanelsService)
        {


            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }

            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _globalZoneService = globalZoneService;
            _reportService = reportService;
            _readerSettingsService = readerSettingsService;
            _dBUsersPanelsService = dBUsersPanelsService;
            kullaniciyaAitPaneller = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
        }


        // GET: InsideOutReport
        public ActionResult Personel(IcerdeDisardaReportParameters parameters)
        {

            var liste = _reportService.GetIcerdeDisardaPersonels(parameters);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && x.Seri_No != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaPersonelListViewModel
            {
                IcerdeDısardaPersonel = liste,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            TempData["Personel"] = liste;
            return View(model);
        }





        public ActionResult Ziyaretci(IcerdeDisardaReportParameters parameters)
        {
            //TODO:Tablodan multiselect işlemi uygulanacak
            var liste = _reportService.GetIcerdeDısardaZiyaretci(parameters);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaZiyaretciListViewModel
            {
                ZiyaretciListesi = liste,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            TempData["Ziyaretci"] = liste;
            return View(model);
        }





        public ActionResult Tumu(IcerdeDisardaReportParameters parameters)
        {

            var liste = _reportService.GetIcerdeDısardaTümü(parameters);
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var model = new IcerdeDısardaTumuListViewModel
            {
                TumuListesi = liste,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })

            };
            TempData["Tumu"] = liste;
            return View(model);
        }




        //Personel-Seçilen Kullanıcılar AccessDatas'a yeniden Geçiş Tipi 1 Olacak Şekilde Kaydediliyor
        public ActionResult ManuelCikisPersonel(List<int> Kayit_No)
        {
            if (Kayit_No != null)
            {
                _reportService.Guncelle(Kayit_No);
            }


            return RedirectToAction("Personel");
        }



        //Tumu-Seçilen Kullanıcılar AccessDatas'a yeniden Geçiş Tipi 1 Olacak Şekilde Kaydediliyor
        public ActionResult ManuelCikisTumu(List<int> Kayit_No)
        {
            if (Kayit_No != null)
            {
                _reportService.Guncelle(Kayit_No);
            }

            return RedirectToAction("Tumu");
        }



        //Ziyaretci-Seçilen Kullanıcılar AccessDatas'a yeniden Geçiş Tipi 1 Olacak Şekilde Kaydediliyor
        public ActionResult ManuelCikisZiyaretci(List<int> Kayit_No)
        {
            if (Kayit_No != null)
            {
                _reportService.Guncelle(Kayit_No);
            }

            return RedirectToAction("Ziyaretci");
        }







        //Dropdown'dan seçilen Panel'e göre Reader'ları Reader DropdownList'e gönderiyor
        [HttpPost]
        public ActionResult Reader(int Paneller)
        {
            var nesne = _readerSettingsService.GetAllreaderSettings(x => x.Panel_ID == Paneller);
            return Json(nesne, JsonRequestBehavior.AllowGet);
        }






        //Export Excell Ziyaretci
        public void IcerdeDısardaZiyaretci()
        {
            List<IcerdeDısardaZiyaretci> liste = new List<IcerdeDısardaZiyaretci>();
            liste = TempData["Ziyaretci"] as List<IcerdeDısardaZiyaretci>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetIcerdeDısardaZiyaretci(new IcerdeDisardaReportParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "İçerde Dışarda Rapor Listesi-Ziyaretçi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Kart ID";
            worksheet.Cells["B6"].Value = "Adı";
            worksheet.Cells["C6"].Value = "Soyadı";
            worksheet.Cells["D6"].Value = "Ziyaret Sebebi";
            worksheet.Cells["E6"].Value = "Tarih";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in liste)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Ziyaret_Sebebi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
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


        //Export Excell Personel
        public void IcerdeDısardaPersonel()
        {
            List<IcerdeDisardaPersonel> liste = new List<IcerdeDisardaPersonel>();
            liste = TempData["Personel"] as List<IcerdeDisardaPersonel>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetIcerdeDisardaPersonels(null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "İçerde Dışarda Rapor Listesi-Personel";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Kayıt No";
            worksheet.Cells["B6"].Value = "ID";
            worksheet.Cells["C6"].Value = "Kart ID";
            worksheet.Cells["D6"].Value = "Adı";
            worksheet.Cells["E6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Şirket";
            worksheet.Cells["E6"].Value = "Departman";
            worksheet.Cells["E6"].Value = "Tarih";
            worksheet.Cells["E6"].Value = "Geçiş";
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
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Sirket;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Departman;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
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


        //Export Excell Tümü
        public void IcerdeDısardaTumu()
        {
            List<IcerdeDısardaTümü> liste = new List<IcerdeDısardaTümü>();
            liste = TempData["Tumu"] as List<IcerdeDısardaTümü>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetIcerdeDısardaTümü(null);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "İçerde Dışarda Rapor Listesi-Tümü";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Ziyaretçi Adı";
            worksheet.Cells["F6"].Value = "Ziyaretçi Soyadı";
            worksheet.Cells["G6"].Value = "Şirket";
            worksheet.Cells["H6"].Value = "Departman";
            worksheet.Cells["I6"].Value = "Tarih";
            worksheet.Cells["J6"].Value = "Tarih";
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
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Ziyaretci_Adi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Ziyaretci_Soyadi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Sirket;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Departman;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Ziyaret_Tarihi);

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