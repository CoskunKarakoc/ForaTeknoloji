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
        DBUsers user;
        DBUsers permissionUser;
        public RefectoryController(IReaderSettingsNewService readerSettingsNewService, IPanelSettingsService panelSettingsService, IReportService reportService, IDBUsersService dBUsersService, IGroupMasterService groupMasterService, IGroupsDetailNewService groupsDetailNewService, IDoorGroupsMasterService doorGroupsMasterService, IDoorGroupsDetailService doorGroupsDetailService)
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
            var model = new RefectoryListViewModel
            {
                Group_ID = Groups.Select(a => new SelectListItem
                {
                    Text = a.Kapi_Grup_Adi,
                    Value = a.Kapi_Grup_No.ToString()
                }),
                YemekhaneListe = Liste,
                ToplamGecis = Toplam
            };
            TempData["UserAccessCount"] = Liste;
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
            var model = new RefectoryListViewModel
            {
                Group_ID = Groups.Select(a => new SelectListItem
                {
                    Text = a.Kapi_Grup_Adi,
                    Value = a.Kapi_Grup_No.ToString()
                }),
                ToplamGecis = Total
            };
            TempData["UserAccessCountTotal"] = Total;
            return View(model);
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
            worksheet.Cells["A1"].Value = "Personel Geçiş Sayısı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
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
            worksheet.Cells["A1"].Value = "Personel Geçiş Sayısı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A6"].Value = "Panel ID";
            worksheet.Cells["B6"].Value = "Panel Adı";
            worksheet.Cells["C6"].Value = "Kapı ID";
            worksheet.Cells["D6"].Value = "Geçiş Sayısı";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:D6"].Style.Font.Size = 13;
            worksheet.Cells["A6:D6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.PanelID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.PanelAdi;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.KapiID;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.GecisSayi;
                rowStart++;
            }
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }




    }
}