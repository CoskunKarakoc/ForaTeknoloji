using ForaTeknoloji.BusinessLayer.Abstract;
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
    public class UndefinedUserReportController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IPanelSettingsService _panelSettingsService;
        private IReportService _reportService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDoorNamesService _doorNamesService;
        List<int?> kullaniciyaAitPaneller = new List<int?>();
        DBUsers user;
        public UndefinedUserReportController(IAccessDatasService accessDatasService, IPanelSettingsService panelSettingsService, IReportService reportService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService)
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

        }
        // GET: UndefinedUserReport
        public ActionResult Index(List<string> Kapi = null, bool? Tümü = null, bool? TümPanel = null, int? Panel = null, DateTime? Tarih1 = null, DateTime? Tarih2 = null, DateTime? Saat1 = null, DateTime? Saat2 = null, string KapiYon = "")
        {
            //TODO: satırlara data Attribute'u gelecek buna ve reportpoersonele
            var list = _reportService.GetTanimsizListesi(Kapi, Tümü, TümPanel, Panel, Tarih1, Tarih2, Saat1, Saat2, KapiYon);

            var PanelName = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && kullaniciyaAitPaneller.Contains(x.Panel_ID));
            var model = new TanimsizKullaniciListViewModel
            {
                Liste = list,
                Panel = PanelName.Select(x => new SelectListItem
                {
                    Text = x.Panel_Name,
                    Value = x.Panel_ID.ToString()
                })
            };
            TempData["Tanimsiz"] = list;
            return View(model);
        }




        //DoorNames Tablosundan Ajax ile Kapılar Çekiliyor JQuery ile Ekrana Basılıyor 
        public ActionResult KapiListesi()
        {
            var liste = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            return Json(_doorNamesService.GetAllDoorNames(x => liste.Contains(x.Panel_No)), JsonRequestBehavior.AllowGet);
        }


        //Export Excell
        public void TanimsizKullaniciListesi()
        {
            List<AccessDatas> list = new List<AccessDatas>();

            list = TempData["Tanimsiz"] as List<AccessDatas>;
            if (list == null || list.Count == 0)
            {
                list = _reportService.GetTanimsizListesi(null, null, null, null, null, null, null, null, "");
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

            worksheet.Cells["A1"].Value = "Tanımzsız Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Kart ID";
            worksheet.Cells["B6"].Value = "Panel";
            worksheet.Cells["C6"].Value = "Kapı";
            worksheet.Cells["D6"].Value = "Geçiş";
            worksheet.Cells["E6"].Value = "Tarih";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            int rowStart = 7;
            foreach (var item in list)
            {
                // worksheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                // worksheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Kapi_Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:HH: mm tt}", item.Tarih);
                rowStart++;

            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + list.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();



        }



    }
}