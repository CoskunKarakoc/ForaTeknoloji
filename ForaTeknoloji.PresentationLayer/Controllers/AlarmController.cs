using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{

    [Auth]
    [Excp]
    public class AlarmController : Controller
    {
        private IAlarmlarService _alarmlarService;
        private IAlarmTipleriService _alarmTipleriService;
        private IUserService _userService;
        private ITaskListService _taskListService;
        private IDBUsersService _dBUsers;
        private IReportService _reportService;
        private IAccessDatasService _accessDatasService;
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IDBUsersKapiService _dBUsersKapiService;
        private IAccessDatasTempService _accessDatasTempService;
        public DBUsers user = CurrentSession.User;
        public DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbDoorList;
        List<int> dbSirketList;
        List<int> dbAltDepartmanList;
        public AlarmController(IAlarmlarService alarmlarService, IAlarmTipleriService alarmTipleriService, IUserService userService, IPanelSettingsService panelSettingsService, ITaskListService taskListService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsers, IReportService reportService, IAccessDatasService accessDatasService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IReaderSettingsNewService readerSettingsNewService, IDBUsersKapiService dBUsersKapiService, IAccessDatasTempService accessDatasTempService)
        {

            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _alarmlarService = alarmlarService;
            _alarmTipleriService = alarmTipleriService;
            _userService = userService;
            _panelSettingsService = panelSettingsService;
            _taskListService = taskListService;
            _dBUsers = dBUsers;
            _reportService = reportService;
            _accessDatasService = accessDatasService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            _readerSettingsNewService = readerSettingsNewService;
            _dBUsersKapiService = dBUsersKapiService;
            _accessDatasTempService = accessDatasTempService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbDoorList = new List<int>();
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
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
            permissionUser = _dBUsers.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: Alarm
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Alarm_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz erişim!");
            }


            int ID;
            if (_alarmlarService.GetAllAlarmlar().Count == 0)
                ID = 0;
            else
                ID = _alarmlarService.GetAllAlarmlar().Max(x => x.Alarm_No);

            var Alarm = _alarmlarService.AlarmAndTip(x => dbPanelList.Contains((int)x.PanelNo));
            var AlarmTip = _alarmTipleriService.GetAllAlarmlar();
            var User = _userService.GetAllUsers(x => dbSirketList.Contains((int)x.Sirket_No) && dbDepartmanList.Contains((int)x.Departman_No) && dbAltDepartmanList.Contains((int)x.Alt_Departman_No));
            var Panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Seri_No != 0 && x.Panel_ID != 0/* && dbPanelList.Contains((int)x.Panel_ID)*/);
            var model = new AlarmListViewModel
            {
                MaxID = ID + 1,
                Alarmlar = Alarm,
                AlarmTipleri = AlarmTip.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alarm_Tipi.ToString()
                }),
                Users = User,
                Panels = Panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Seri_No.ToString()
                }),
                PanelListesi = _reportService.PanelListesi(user)
            };
            return View(model);
        }



        public ActionResult Edit(int? id)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Alarm değişikliklerine yetkiniz yok!");
            }
            if (id != null)
            {
                List<ReaderSettingsNew> kapiListesi = new List<ReaderSettingsNew>();
                var entity = _alarmlarService.GetById((int)id);
                var paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_TCP_Port != 0 && dbPanelList.Contains((int)x.Panel_ID));
                var kullanıcılar = _reportService.GetPersonelLists(null, user);
                var seciliKullanici = _userService.GetById((int)entity.User_ID);
                var alarmTipleri = _alarmTipleriService.GetAllAlarmlar();

                var panelModel = _panelSettingsService.GetById((int)entity.Panel_No).Panel_Model;
                if (panelModel == (int)PanelModel.Panel_301)
                    kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == entity.Panel_No && x.WKapi_ID <= 8 && dbDoorList.Contains(x.Kayit_No));
                else if (panelModel == (int)PanelModel.Panel_302)
                    kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == entity.Panel_No && x.WKapi_ID <= 2 && dbDoorList.Contains(x.Kayit_No));
                else if (panelModel == (int)PanelModel.Panel_304)
                    kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == entity.Panel_No && x.WKapi_ID <= 4 && dbDoorList.Contains(x.Kayit_No));
                else
                    kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == entity.Panel_No && x.WKapi_ID <= 1 && dbDoorList.Contains(x.Kayit_No));

                List<int> HariciAlarmRolesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                ViewBag.Panel_No = new SelectList(paneller, "Panel_ID", "Panel_Name", entity.Panel_No);
                ViewBag.Alarm_Tipi = new SelectList(alarmTipleri, "Alarm_Tipi", "Adi", entity.Alarm_Tipi);
                ViewBag.Kapi_No = new SelectList(kapiListesi, "WKapi_ID", "WKapi_Adi", entity.Kapi_No);
                ViewBag.Kapi_Role_No = new SelectList(HariciAlarmRolesi, entity.Kapi_Role_No);
                var model = new AlarmEditListViewModel
                {
                    Alarm = entity,
                    Kullanıcılar = kullanıcılar,
                    SeciliKullanici = seciliKullanici
                };
                return View(model);
            }
            throw new Exception("Upss! Yanliş giden birşeyler var.");
        }

        [HttpPost]
        public ActionResult Edit(Alarmlar alarmlar)
        {
            if (ModelState.IsValid)
            {
                if (alarmlar != null)
                {
                    _alarmlarService.UpdateAlarmlar(alarmlar);
                    _accessDatasService.AddOperatorLog(141, user.Kullanici_Adi, alarmlar.Alarm_No, 0, 0, 0);
                    return RedirectToAction("Index", "Alarm");
                }
            }
            return View(alarmlar);
        }



        public ActionResult Create()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Alarm oluşturmaya yetkiniz yok!");
            }
            var maxID = 0;
            var paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_TCP_Port != 0 && dbPanelList.Contains((int)x.Panel_ID));
            var kullanıcılar = _reportService.GetPersonelLists(null, CurrentSession.User);
            var alarmTipleri = _alarmTipleriService.GetAllAlarmlar();
            if (_alarmlarService.GetAllAlarmlar().Count > 0)
            {
                maxID = _alarmlarService.GetAllAlarmlar().Count;
            }
            List<int> KapıListesi = new List<int> { };
            List<int> HariciAlarmRolesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            ViewBag.Kapi_No = new SelectList(KapıListesi);
            ViewBag.Kapi_Role_No = new SelectList(HariciAlarmRolesi);
            var model = new AlarmCreateViewModel
            {
                Alarm_No = maxID + 1,
                Paneller = paneller.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                AlarmTipleri = alarmTipleri.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alarm_Tipi.ToString()
                }),
                Kapilar = KapıListesi,
                AlarmRolesi = HariciAlarmRolesi,
                Kullanıcılar = kullanıcılar
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Alarmlar alarmlar)
        {
            if (ModelState.IsValid)
            {

                _alarmlarService.AddAlarmlar(alarmlar);
                _accessDatasService.AddOperatorLog(140, user.Kullanici_Adi, alarmlar.Alarm_No, 0, 0, 0);
                return RedirectToAction("Index", "Alarm");
            }
            return View(alarmlar);
        }


        public ActionResult KapiListesi(int? Paneller)
        {
            if (Paneller != 0 && Paneller != null)
            {
                var panelModel = _panelSettingsService.GetById((int)Paneller).Panel_Model;
                List<ReaderSettingsNew> list = new List<ReaderSettingsNew>();
                if (panelModel == (int)PanelModel.Panel_301)
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 8 && dbDoorList.Contains(x.Kayit_No));
                else if (panelModel == (int)PanelModel.Panel_302)
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 2 && dbDoorList.Contains(x.Kayit_No));
                else if (panelModel == (int)PanelModel.Panel_304)
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 4 && dbDoorList.Contains(x.Kayit_No));
                else
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 1 && dbDoorList.Contains(x.Kayit_No));

                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Kapı Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectKapi = list.Select(a => new SelectListItem
                    {
                        Text = a.WKapi_Adi,
                        Value = a.WKapi_ID.ToString()
                    });
                    return Json(selectKapi, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DatabaseRemove(int? id)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Alarm silmeye yetkiniz yok!");
            }
            if (id != null)
            {
                var entity = _alarmlarService.GetById((int)id);
                if (entity != null)
                {
                    _alarmlarService.DeleteAlarmlar(entity);
                    _accessDatasService.AddOperatorLog(142, user.Kullanici_Adi, entity.Alarm_No, 0, 0, 0);
                    return RedirectToAction("Index");
                }
                throw new Exception("Böyle bir kayıt bulunamadı!");
            }
            return RedirectToAction("Index");
        }


        public ActionResult Personeller()
        {
            return Json(_reportService.GetPersonelLists(null, CurrentSession.User), JsonRequestBehavior.AllowGet);
        }


        public ActionResult TaskSend(List<int> PanelList, CommandConstants OprKod, int AlarmID = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işleme yetkiniz yok!");
            }
            if (AlarmID != -1)
            {
                try
                {
                    foreach (var item in PanelList)
                    {
                        var panelModel = _panelSettingsService.GetById(item);
                        if (panelModel.Panel_Model != (int)PanelModel.Panel_1010)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)OprKod,
                                Kullanici_Adi = user.Kullanici_Adi,
                                IntParam_1 = AlarmID,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                            if (OprKod == CommandConstants.CMD_ERS_USERALARM)
                                _accessDatasService.AddOperatorLog(142, user.Kullanici_Adi, AlarmID, 0, item, 0);
                            else
                                _accessDatasService.AddOperatorLog(143, user.Kullanici_Adi, AlarmID, 0, item, 0);
                        }

                    }
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult AlarmListesi()
        {
            //var model = _accessDatasService.GetAllAccessDatas().Where(x => x.Kod >= 20 && x.Kod <= 27 && x.Kontrol == 0).ToList();
            var model = _reportService.AlarmListesi();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlarmTable()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Alarm_Islemleri == (int)SecurityCode.Yetkisiz || permissionUser.Alarm_Islemleri == null)
                    throw new Exception("Yetkisiz erişim!");
            }

            var model = _reportService.AlarmListesi();
            return View(model);
        }

        [HttpPost]
        public ActionResult AlarmChange(List<int> Alarmlar)
        {
            if (Alarmlar.Count != 0 && Alarmlar != null)
            {
                foreach (var item in Alarmlar)
                {
                    var editEntityTemps = _accessDatasTempService.GetByKayit_No(item);
                    editEntityTemps.Kontrol = 1;
                    editEntityTemps.Kontrol_Tarihi = DateTime.Now;
                    _accessDatasTempService.UpdateAccessDatasTemp(editEntityTemps);

                    var editEntity = _accessDatasService.GetAllAccessDatas().FirstOrDefault(x => x.Panel_ID == editEntityTemps.Panel_ID && x.Kapi_ID == editEntityTemps.Kapi_ID && x.Kontrol == 0);
                    editEntity.Kontrol = 1;
                    editEntity.Kontrol_Tarihi = DateTime.Now;
                    _accessDatasService.UpdateAccessData(editEntity);
                }
                return RedirectToAction("AlarmTable", "Alarm");
            }
            return RedirectToAction("AlarmTable", "Alarm");
        }
    }
}