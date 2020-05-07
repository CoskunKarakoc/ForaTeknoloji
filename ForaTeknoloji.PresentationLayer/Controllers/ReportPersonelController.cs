using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.DataTransferObjects;
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
    public class ReportPersonelController : Controller
    {
        private IUserService _userService;
        private ISirketService _sirketService;
        private IDepartmanService _departmanService;
        private IBloklarService _bloklarService;
        private IVisitorsService _visitorsService;
        private IGroupMasterService _groupMasterService;
        private IPanelSettingsService _panelSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IUsersOLDService _usersOLDService;
        private IDoorNamesService _doorNamesService;
        private IDBUsersService _dBUsersService;
        private IAltDepartmanService _altDepartmanService;
        private IUnvanService _unvanService;
        private IBolumService _bolumService;
        private ITaskListService _taskListService;
        private IAccessDatasService _accessDatasService;
        private IBirimService _birimService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IDBUsersKapiService _dBUsersKapiService;
        DBUsers user=CurrentSession.User;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbDoorList;
        List<int> dbSirketList;
        List<int> dbAltDepartmanList;
        public ReportPersonelController(ISirketService sirketService, IDepartmanService departmanService, IBloklarService bloklarService, IVisitorsService visitorsService, IPanelSettingsService panelSettingsService, IGlobalZoneService globalZoneService, IGroupMasterService groupMasterService, IUserService userService, IReportService reportService, IUsersOLDService usersOLDService, IDBUsersPanelsService dBUsersPanelsService, IDoorNamesService doorNamesService, IDBUsersService dBUsersService, IAltDepartmanService altDepartmanService, IUnvanService unvanService, IBolumService bolumService, ITaskListService taskListService, IAccessDatasService accessDatasService, IBirimService birimService, IReaderSettingsNewService readerSettingsNewService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IDBUsersKapiService dBUsersKapiService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _userService = userService;
            _sirketService = sirketService;
            _departmanService = departmanService;
            _bloklarService = bloklarService;
            _visitorsService = visitorsService;
            _panelSettingsService = panelSettingsService;
            _globalZoneService = globalZoneService;
            _groupMasterService = groupMasterService;
            _reportService = reportService;
            _usersOLDService = usersOLDService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _doorNamesService = doorNamesService;
            _dBUsersService = dBUsersService;
            _altDepartmanService = altDepartmanService;
            _unvanService = unvanService;
            _bolumService = bolumService;
            _taskListService = taskListService;
            _accessDatasService = accessDatasService;
            _birimService = birimService;
            _dBUsersKapiService = dBUsersKapiService;
            _readerSettingsNewService = readerSettingsNewService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbDoorList = new List<int>();
            dbSirketList = new List<int>();
            dbAltDepartmanList = new List<int>();
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetDoorList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanList.Add((int)dbUserDepartmanNo);
            }
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserDoorNo in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Kapi_Kayit_No))
            {
                dbDoorList.Add((int)dbUserDoorNo);
            }
            foreach (var dbUserSirketNo in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Sirket_No))
            {
                dbSirketList.Add((int)dbUserSirketNo);
            }
            foreach (var dbUserAltDepartmanNo in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Alt_Departman_No))
            {
                dbAltDepartmanList.Add((int)dbUserAltDepartmanNo);
            }

        }
        // GET: ReportPersonelAktif
        public ActionResult Index(ActiveUserReportParameters parameters)
        {
            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && dbPanelList.Contains((int)x.Panel_ID));
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No)); //_departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var liste = _reportService.GetReportPersonelLists(parameters, CurrentSession.User);
            var kullanicilar = _reportService.GetPersonelLists(null, CurrentSession.User);
            var alddepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Kullanıcı = kullanicilar,
                EskiKullanicilar = null,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
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
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                AltDepartman = alddepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            TempData["ReportPersonel"] = liste;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            return View(model);

        }




        // GET: ReportPersonelEski
        public ActionResult OldStaff(ActiveUserReportParameters parameters)
        {

            var panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0 && dbPanelList.Contains((int)x.Panel_ID));
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No)); // _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); // _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var liste = _reportService.GetReportPersonelListsEski(parameters, CurrentSession.User);
            var eskiKullanicilar = _reportService.GetReportPersonelListsEski(null, CurrentSession.User);
            var alddepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Kullanıcı = null,
                EskiKullanicilar = eskiKullanicilar,
                Panel = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
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
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                AltDepartman = alddepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })


            };
            TempData["ReportPersonel"] = liste;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
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

        public ActionResult PanelKapiListesi(int? PanelNo)
        {
            if (PanelNo != null && PanelNo != 0)
            {
                List<ReaderSettingsNew> readerSettingsNews = new List<ReaderSettingsNew>();
                if (_panelSettingsService.GetById((int)PanelNo).Panel_Model == (int)PanelModel.Panel_301)
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 8);
                }
                else if (_panelSettingsService.GetById((int)PanelNo).Panel_Model == (int)PanelModel.Panel_302)
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 2);
                }
                else if (_panelSettingsService.GetById((int)PanelNo).Panel_Model == (int)PanelModel.Panel_304)
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 4);
                }
                else
                {
                    readerSettingsNews = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo && dbDoorList.Contains(x.Kayit_No) && x.WKapi_ID <= 1);
                }

                List<SelectListItem> doorNameList = new List<SelectListItem>();
                var selectedPanel = readerSettingsNews.Select(a => new SelectListItem
                {
                    Text = a.WKapi_Adi,
                    Value = a.WKapi_ID.ToString()
                });
                return Json(selectedPanel, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }



        public ActionResult AktifZiyaretciler()//Popup'a Aktif Kulanıcı Yükleniyor
        {
            List<EfUserDal.ComplexUser> liste = new List<EfUserDal.ComplexUser>();
            liste = _userService.GetAllUsersWithOuther(x => dbSirketList.Contains((int)x.Sirket_No) && dbDepartmanList.Contains((int)x.Departman_No) && dbAltDepartmanList.Contains((int)x.Alt_Departman_No)).OrderBy(x => x.Kayit_No).ToList();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EskiZiyaretciler()//Popup'a Eski Kullanıcı Yükleniyor
        {
            List<EfUsersOLDDal.ComplexUserOld> liste = new List<EfUsersOLDDal.ComplexUserOld>();
            liste = _usersOLDService.GetAllUserOLDWithOuther(x => dbAltDepartmanList.Contains((int)x.Departman_No) && dbSirketList.Contains((int)x.Sirket_No) && dbAltDepartmanList.Contains((int)x.Alt_Departman_No)).OrderBy(x => x.Kayit_No).ToList();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeletedUsers()
        {
            if (user.SysAdmin == false)
            {
                if (user.Kullanici_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz Erişim!");
            }
            return View(_reportService.GetReportPersonelListsEski(null, CurrentSession.User));
        }

        public ActionResult DeletedUserList()
        {
            return Json(new { data = _reportService.GetReportPersonelListsEski(null, CurrentSession.User) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TurnBackUser(int? id)
        {
            if (id != null)
            {
                if (user.SysAdmin == false)
                {
                    if (user.Kullanici_Islemleri == (int)SecurityCode.Sadece_Izleme || user.Kullanici_Islemleri == (int)SecurityCode.Yetkisiz)
                        throw new Exception("Kullanıcı ekleme yetkiniz yok!");
                }


                var entity = _usersOLDService.GetAllUsersOLD().FirstOrDefault(x => x.ID == id);
                var checkUserKartID = _userService.GetAllUsers().FirstOrDefault(x => x.Kart_ID == entity.Kart_ID);
                if (checkUserKartID == null)
                {

                    Users ReCycleUser = ConvertUser.UserOldToUser(entity);
                    var checkUserID = _userService.GetAllUsers().FirstOrDefault(x => x.ID == ReCycleUser.ID);
                    if (checkUserID != null)
                        ReCycleUser.ID = (_userService.GetAllUsers().Max(x => x.ID) + 1);

                    _userService.AddUsers(ReCycleUser);
                    _usersOLDService.DeleteUsersOLD(entity);
                    _accessDatasService.AddOperatorLog(100, user.Kullanici_Adi, ReCycleUser.ID, 0, 0, 0);
                    foreach (var panel in _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0))
                    {
                        TaskList taskSendUser = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
                            IntParam_1 = ReCycleUser.ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = panel.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        _taskListService.AddTaskList(taskSendUser);
                    }
                    _accessDatasService.AddOperatorLog(103, user.Kullanici_Adi, ReCycleUser.ID, 0, 0, 0);
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    throw new Exception("Aynı Kart ID'sine sahip kullanıcı bulunmaktadır!");
                }
            }
            throw new Exception("Upps! Yanlış Giden Birşeyler Var!");
        }

        //EXCELL EXPORT
        public void PersonelRaporları()
        {

            List<ReportPersonelList> liste = new List<ReportPersonelList>();
            liste = TempData["ReportPersonel"] as List<ReportPersonelList>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GetReportPersonelLists(new ActiveUserReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Personel Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Alınma Tarihi";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "TC Kimlik";
            worksheet.Cells["F6"].Value = "Telefon";
            worksheet.Cells["G6"].Value = "Şirket";
            worksheet.Cells["H6"].Value = "Departman";
            worksheet.Cells["I6"].Value = "Alt Departman";
            worksheet.Cells["J6"].Value = "Bölüm";
            worksheet.Cells["K6"].Value = "Birim";
            worksheet.Cells["L6"].Value = "Grup Adı";
            worksheet.Cells["M6"].Value = "Panel";
            worksheet.Cells["N6"].Value = "Kapı";
            worksheet.Cells["O6"].Value = "Geçiş";
            worksheet.Cells["P6"].Value = "Tarih";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:P6"].Style.Font.Size = 13;
            worksheet.Cells["A6:P6"].Style.Font.Bold = true;
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
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Telefon;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("M{0}", rowStart)].Value = item.Panel_ID;
                worksheet.Cells[string.Format("N{0}", rowStart)].Value = item.Kapi;
                worksheet.Cells[string.Format("O{0}", rowStart)].Value = item.Gecis_Tipi == 0 ? "Giriş" : "Çıkış";
                worksheet.Cells[string.Format("P{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", item.Tarih);
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