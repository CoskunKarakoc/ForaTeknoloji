using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.BusinessLayer.Abstract;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class ExternalDataController : Controller
    {

        private IRawUsersService _rawUsersService;
        private IUserService _userService;
        private IRawGroupsService _rawGroupsService;
        private IGroupMasterService _groupMasterService;
        public ExternalDataController(IUserService userService, IRawUsersService rawUsersService, IRawGroupsService rawGroupsService, IGroupMasterService groupMasterService)
        {
            _userService = userService;
            _rawUsersService = rawUsersService;
            _rawGroupsService = rawGroupsService;
            _groupMasterService = groupMasterService;
        }


        // GET: ExternalData
        public ActionResult UserImport()
        {
            return View();
        }

        public ActionResult GroupImport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportUser(HttpPostedFileBase excelFile, ExcelUserType excelUserType)
        {
            if (excelFile == null || excelFile.ContentLength == 0)
            {
                ViewBag.Error = "Lütfen Excel Dosyası Seçin!";
                return View("UserImport");
            }
            else
            {
                if (excelFile.FileName.EndsWith("xls") || excelFile.FileName.EndsWith("xlsx"))
                {

                    string path = Server.MapPath("~/ExcelFile/" + excelFile.FileName + Guid.NewGuid());
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelFile.SaveAs(path);
                    //Read Data From Excel File
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<RawUsers> userList = new List<RawUsers>();
                    for (int i = 2; i <= range.Rows.Count; i++)
                    {
                        RawUsers user = new RawUsers
                        {
                            ID = int.Parse(((Excel.Range)range.Cells[i, excelUserType.ID]).Text) == null ? 0 : int.Parse(((Excel.Range)range.Cells[i, excelUserType.ID]).Text),
                            Kart_ID = ((Excel.Range)range.Cells[i, excelUserType.Kart_ID]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelUserType.Kart_ID]).Text,
                            Adi = ((Excel.Range)range.Cells[i, excelUserType.Adi]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelUserType.Adi]).Text,
                            Soyadi = ((Excel.Range)range.Cells[i, excelUserType.Soyadi]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelUserType.Soyadi]).Text,
                            Grup_No = int.Parse(((Excel.Range)range.Cells[i, excelUserType.Grup_No]).Text) == null ? 0 : int.Parse(((Excel.Range)range.Cells[i, excelUserType.Grup_No]).Text),
                            Plaka = ((Excel.Range)range.Cells[i, excelUserType.Plaka]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelUserType.Plaka]).Text,
                            Sirket_No = int.Parse(((Excel.Range)range.Cells[i, excelUserType.Sirket_No]).Text) == null ? 0 : int.Parse(((Excel.Range)range.Cells[i, excelUserType.Sirket_No]).Text),
                            Departman_No = int.Parse(((Excel.Range)range.Cells[i, excelUserType.Departman_No]).Text) == null ? 0 : int.Parse(((Excel.Range)range.Cells[i, excelUserType.Departman_No]).Text),
                            Telefon = ((Excel.Range)range.Cells[i, excelUserType.Telefon]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelUserType.Telefon]).Text,
                            TCKimlik = ((Excel.Range)range.Cells[i, excelUserType.TC_Kimlik]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelUserType.TC_Kimlik]).Text,
                        };
                        userList.Add(user);
                    }
                    foreach (var item in userList)
                    {
                        if (!_rawUsersService.GetAllRawUsers().Any(x => x.ID == item.ID))
                        {
                            _rawUsersService.AddRawUsers(item);
                        }
                    }

                    return RedirectToAction("SuccessImportUser");
                }
                else
                {
                    ViewBag.Error = "Dosya tipi geçersiz!";
                    return View("UserImport");
                }
            }
        }

        [HttpPost]
        public ActionResult ImportGroup(HttpPostedFileBase excelFile, ExcelGroupType excelGroupType)
        {
            if (excelFile == null || excelFile.ContentLength == 0)
            {
                ViewBag.Error = "Lütfen Excel Dosyası Seçin!";
                return View("GroupImport");
            }
            else
            {
                if (excelFile.FileName.EndsWith("xls") || excelFile.FileName.EndsWith("xlsx"))
                {

                    string path = Server.MapPath("~/ExcelFile/" + excelFile.FileName + Guid.NewGuid());
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelFile.SaveAs(path);
                    //Read Data From Excel File
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<RawGroups> groupList = new List<RawGroups>();
                    for (int i = 2; i <= range.Rows.Count; i++)
                    {
                        RawGroups group = new RawGroups
                        {
                            Grup_No = int.Parse(((Excel.Range)range.Cells[i, excelGroupType.Grup_No]).Text) == null ? 0 : int.Parse(((Excel.Range)range.Cells[i, excelGroupType.Grup_No]).Text),
                            Grup_Adi = ((Excel.Range)range.Cells[i, excelGroupType.Grup_Adi]).Text == null ? "" : ((Excel.Range)range.Cells[i, excelGroupType.Grup_Adi]).Text,
                        };
                        groupList.Add(group);
                    }
                    foreach (var item in groupList)
                    {
                        if (!_rawGroupsService.GetAllRawGroups().Any(x => x.Grup_No == item.Grup_No))
                        {
                            _rawGroupsService.AddRawGroups(item);
                        }
                    }

                    return RedirectToAction("SuccessImportGroup");
                }
                else
                {
                    ViewBag.Error = "Dosya tipi geçersiz!";
                    return View("GroupImport");
                }
            }
        }


        public ActionResult SuccessImportUser()
        {
            var model = _rawUsersService.GetAllRawUsers();
            return View(model);
        }

        public ActionResult SuccessImportGroup()
        {
            var model = _rawGroupsService.GetAllRawGroups();
            return View(model);
        }



        public ActionResult AddUser(bool TabloDelete)
        {
            if (TabloDelete == true)
            {
                _userService.DeleteAllUsers();
                foreach (var item in _rawUsersService.GetAllRawUsers())
                {
                    Users users = new Users
                    {
                        Adi = item.Adi,
                        Soyadi = item.Soyadi,
                        Adres = item.Adres,
                        Aciklama = item.Aciklama,
                        ID = item.ID,
                        Kart_ID = item.Kart_ID,
                        Dogrulama_PIN = item.Dogrulama_PIN,
                        Kimlik_PIN = item.Kimlik_PIN,
                        Kullanici_Tipi = item.Kullanici_Tipi,
                        Sifre = item.Sifre,
                        Gecis_Modu = item.Gecis_Modu,
                        Grup_No = item.Grup_No,
                        Visitor_Grup_No = item.Visitor_Grup_No,
                        Resim = item.Resim,
                        Plaka = item.Plaka,
                        TCKimlik = item.TCKimlik,
                        Blok_No = item.Blok_No,
                        Daire = item.Daire,
                        Gorev = item.Gorev,
                        Departman_No = item.Departman_No,
                        Sirket_No = item.Sirket_No,
                        Iptal = item.Iptal,
                        Grup_Takvimi_Aktif = item.Grup_Takvimi_Aktif,
                        Grup_Takvimi_No = item.Grup_Takvimi_No,
                        Saat_1 = item.Saat_1,
                        Saat_2 = item.Saat_2,
                        Saat_3 = item.Saat_3,
                        Grup_No_1 = item.Grup_No_1,
                        Grup_No_2 = item.Grup_No_2,
                        Grup_No_3 = item.Grup_No_3,
                        Tmp = item.Tmp,
                        Sureli_Kullanici = item.Sureli_Kullanici,
                        Bitis_Tarihi = item.Bitis_Tarihi,
                        Telefon = item.Telefon,
                        C3_Grup = item.C3_Grup
                    };
                    _userService.AddUsers(users);
                }
            }

            return RedirectToAction("Index", "Users");
        }

        public ActionResult AddGroup(bool TabloDelete)
        {
            if (TabloDelete == true)
            {
                _groupMasterService.DeleteAll();
                foreach (var item in _rawGroupsService.GetAllRawGroups())
                {
                    GroupsMaster group = new GroupsMaster
                    {
                        Grup_No = item.Grup_No,
                        Grup_Adi = item.Grup_Adi
                    };
                    _groupMasterService.AddGroupsMaster(group);
                }
            }

            return RedirectToAction("Groups", "AccessGroup");
        }

    }
}