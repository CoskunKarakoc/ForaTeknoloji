using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.ComplexType;
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
    public class OperatorLogReportController : Controller
    {
        private ICodeOperationService _codeOperationService;
        private IDBUsersService _dBUsersService;
        private IReportService _reportService;
        public OperatorLogReportController(ICodeOperationService codeOperationService, IDBUsersService dBUsersService, IReportService reportService)
        {
            _codeOperationService = codeOperationService;
            _dBUsersService = dBUsersService;
            _reportService = reportService;
        }




        // GET: OperatorLogReport
        public ActionResult Index(OperatorLogParameters parameters)
        {
            var User = _dBUsersService.GetAllDBUsers();
            var TCode = _codeOperationService.GetAllCodeOperation();
            var Liste = _reportService.OperatorLogReport(parameters);
            var model = new OperatorLogListViewModel
            {
                Kullanici_Adi = User.Select(a => new SelectListItem
                {
                    Text = (a.Adi + " " + a.Soyadi),
                    Value = a.Kullanici_Adi
                }),
                Code_Operation = TCode.Select(a => new SelectListItem
                {
                    Text = a.Operasyon,
                    Value = a.TKod.ToString()
                }),
                OperatorLogList = Liste
            };
            TempData["Operator"] = Liste;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            return View(model);
        }



        //EXCELL EXPORT
        public void OperatorLogListesi()
        {
            List<OperatorLogComplex> liste = new List<OperatorLogComplex>();

            liste = TempData["Operator"] as List<OperatorLogComplex>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.OperatorLogReport(new OperatorLogParameters());
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Operator Log Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "Kayit No";
            worksheet.Cells["B6"].Value = "Panel";
            worksheet.Cells["C6"].Value = "Kapı";
            worksheet.Cells["D6"].Value = "Geçiş Tipi";
            worksheet.Cells["E6"].Value = "Operasyon";
            worksheet.Cells["F6"].Value = "Tarih";
            worksheet.Cells["G6"].Value = "Kullanıcı Adı";
            worksheet.Cells["H6"].Value = "Islem Verisi 1";
            worksheet.Cells["I6"].Value = "Islem Verisi 2";
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
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Kapi_Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Gecis_Tipi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Operasyon;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Tarih;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Kullanici_Adi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Islem_Verisi_1;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Islem_Verisi_2;
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