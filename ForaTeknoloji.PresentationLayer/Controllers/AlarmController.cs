using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
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
        private IPanelSettingsService _panelSettingsService;
        private ITaskListService _taskListService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        public DBUsers user;
        public AlarmController(IAlarmlarService alarmlarService, IAlarmTipleriService alarmTipleriService, IUserService userService, IPanelSettingsService panelSettingsService, ITaskListService taskListService, IDBUsersPanelsService dBUsersPanelsService)
        {

            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _alarmlarService = alarmlarService;
            _alarmTipleriService = alarmTipleriService;
            _userService = userService;
            _panelSettingsService = panelSettingsService;
            _taskListService = taskListService;
            _dBUsersPanelsService = dBUsersPanelsService;
        }



        // GET: Alarm
        public ActionResult Index()
        {
            int ID;

            if (_alarmlarService.GetAllAlarmlar().Count == 0)
                ID = 0;
            else
                ID = _alarmlarService.GetAllAlarmlar().Max(x => x.Alarm_No);

            var Alarm = _alarmlarService.AlarmAndTip();
            var AlarmTip = _alarmTipleriService.GetAllAlarmlar();
            var User = _userService.GetAllUsers();
            var Panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Seri_No != 0 && x.Panel_ID != 0);
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
                PanelListesi = UserPanelList()
            };
            return View(model);
        }



        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var entity = _alarmlarService.GetById((int)id);
                var paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_TCP_Port != 0);
                var kullanıcılar = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
                var seciliKullanici = _userService.GetById((int)entity.User_ID);
                var alarmTipleri = _alarmTipleriService.GetAllAlarmlar();
                List<int> KapıListesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                List<int> HariciAlarmRolesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                ViewBag.Panel_No = new SelectList(paneller, "Panel_ID", "Panel_Name", entity.Panel_No);
                ViewBag.Alarm_Tipi = new SelectList(alarmTipleri, "Alarm_Tipi", "Adi", entity.Alarm_Tipi);
                ViewBag.Kapi_No = new SelectList(KapıListesi, entity.Kapi_No);
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
                    return RedirectToAction("Index", "Alarm");
                }
            }
            return View(alarmlar);
        }



        public ActionResult Create()
        {
            var maxID = 0;
            var paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_TCP_Port != 0);
            var kullanıcılar = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            var alarmTipleri = _alarmTipleriService.GetAllAlarmlar();
            if (_alarmlarService.GetAllAlarmlar().Count > 0)
            {
                maxID = _alarmlarService.GetAllAlarmlar().Count;
            }
            List<int> KapıListesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
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
                return RedirectToAction("Index", "Alarm");
            }
            return View(alarmlar);
        }



        public ActionResult DatabaseRemove(int? id)
        {
            if (id != null)
            {
                var entity = _alarmlarService.GetById((int)id);
                if (entity != null)
                {
                    _alarmlarService.DeleteAlarmlar(entity);
                    return RedirectToAction("Index", "Alarm");
                }
                throw new Exception("Böyle bir kayıt bulunamadı!");
            }
            return RedirectToAction("Index", "Alarm");
        }


        public ActionResult Personeller(string Search)
        {
            List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser> liste = new List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser>();

            if (Search != null && Search != "")
            {
                liste = _userService.GetAllUsersWithOuther(x => x.Adi.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())).OrderBy(x => x.Kayit_No).ToList();
            }
            else
            {
                liste = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            }

            return Json(liste, JsonRequestBehavior.AllowGet);

        }


        public ActionResult TaskSend(List<int> PanelList, CommandConstants OprKod, int AlarmID = -1)
        {
            if (AlarmID != -1)
            {
                try
                {
                    foreach (var item in PanelList)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)OprKod,
                            Kullanici_Adi = user.Kullanici_Adi,
                            IntParam_1 = AlarmID,
                            Panel_No = item,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
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

        private List<PanelSettings> UserPanelList()
        {
            List<PanelSettings> panels = new List<PanelSettings>();
            foreach (var item in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi))
            {
                var panel = _panelSettingsService.GetByQuery(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_ID == item.Panel_No);
                if (panel != null)
                    panels.Add(panel);
            }
            return panels;
        }
    }
}