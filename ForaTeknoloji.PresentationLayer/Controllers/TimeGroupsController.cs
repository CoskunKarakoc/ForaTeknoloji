using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.ComplexType;
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
    public class TimeGroupsController : Controller
    {
        private ITimeGroupsService _timeGroupsService;
        private ITimeZoneIDsService _timeZoneIDsService;
        private ITaskListService _taskListService;
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public TimeGroupsController(ITimeGroupsService timeGroupsService, ITimeZoneIDsService timeZoneIDsService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _timeGroupsService = timeGroupsService;
            _timeZoneIDsService = timeZoneIDsService;
            _taskListService = taskListService;
            _panelSettingsService = panelSettingsService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: TimeGroups
        public ActionResult Index(string Search = null)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Yetkisiz Erişim");
            }


            if (Search != null && Search != "")
            {
                var model = new TimeGroupsListViewModel
                {
                    TimeGroups = _timeGroupsService.GetComplexTimeGroups(x => x.Zaman_Grup_Adi.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim())).OrderBy(x => x.Zaman_Grup_No).ToList(),
                    PanelListesi = UserPanelList()
                };
                return View(model);
            }
            else
            {
                var model = new TimeGroupsListViewModel
                {
                    TimeGroups = _timeGroupsService.GetComplexTimeGroups().OrderBy(x => x.Zaman_Grup_No).ToList(),
                    PanelListesi = UserPanelList()
                };
                return View(model);
            }

        }

        public ActionResult Add()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }



            int MaxID;

            if (_timeGroupsService.GetAllTimeGroups().Count == 0)
                MaxID = 0;
            else
                MaxID = _timeGroupsService.GetAllTimeGroups().Max(x => x.Zaman_Grup_No);

            var Sinirlama = _timeZoneIDsService.GetAllTimeZoneIDs();
            var model = new AddTimeGroupsListViewModel
            {
                Zaman_Grup_No = MaxID + 1,
                Gecis_Sinirlama_Tipi = Sinirlama.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Gecis_Sinirlama_Tipi.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(TimeGroups timeGroups, DateTime? Baslangic_Tarihi_Two = null, DateTime? Baslangic_Saati_Two = null, DateTime? Bitis_Tarihi_Two = null, DateTime? Bitis_Saati_Two = null)
        {
            if (ModelState.IsValid)
            {
                if (Baslangic_Tarihi_Two != null)
                {
                    if (Baslangic_Saati_Two != null)
                    {
                        timeGroups.Baslangic_Tarihi = Baslangic_Tarihi_Two;
                        timeGroups.Baslangic_Saati = Baslangic_Saati_Two;
                    }
                    else
                    {
                        timeGroups.Baslangic_Tarihi = Baslangic_Tarihi_Two;
                    }
                }
                if (Bitis_Tarihi_Two != null)
                {
                    if (Bitis_Saati_Two != null)
                    {
                        timeGroups.Bitis_Tarihi = Bitis_Tarihi_Two;
                        timeGroups.Bitis_Saati = Bitis_Saati_Two;
                    }
                    else
                    {
                        timeGroups.Bitis_Tarihi = Bitis_Tarihi_Two;
                    }
                }
                _timeGroupsService.AddTimeGroups(timeGroups);
                return RedirectToAction("Index");
            }
            return View(timeGroups);
        }

        public ActionResult Delete(int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }


            if (id != -1)
            {
                var entity = _timeGroupsService.GetById(id);
                if (entity != null)
                {
                    _timeGroupsService.DeleteTimeGroups(entity);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
            }
            throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
        }

        public ActionResult Edit(int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            if (id != -1)
            {
                var entity = _timeGroupsService.GetById(id);
                if (entity != null)
                {
                    ViewBag.Gecis_Sinirlama_Tipi = new SelectList(_timeZoneIDsService.GetAllTimeZoneIDs(), "Gecis_Sinirlama_Tipi", "Adi", entity.Gecis_Sinirlama_Tipi);
                    ViewBag.Baslangic_Tarihi = entity.Baslangic_Tarihi;
                    return View(entity);
                }
                throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
            }
            throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeGroups timeGroups, DateTime? Baslangic_Saati_Two = null, DateTime? Bitis_Saati_Two = null)
        {
            if (ModelState.IsValid)
            {
                if (Baslangic_Saati_Two != null)
                {
                    timeGroups.Baslangic_Saati = Baslangic_Saati_Two;
                }
                if (Bitis_Saati_Two != null)
                {
                    timeGroups.Bitis_Saati = Bitis_Saati_Two;
                }
                var entity = _timeGroupsService.GetById(timeGroups.Zaman_Grup_No);
                if (entity != null)
                {
                    _timeGroupsService.UpdateTimeGroups(timeGroups);
                    return RedirectToAction("Index");
                }
                throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
            }
            return View(timeGroups);
        }

        public ActionResult Send(List<int> PanelList, int ZamanGrupNo = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }


            if (ZamanGrupNo != -1)
            {
                try
                {
                    foreach (var item in PanelList)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)CommandConstants.CMD_SND_TIMEGROUP,
                            IntParam_1 = ZamanGrupNo,
                            Kullanici_Adi = user.Kullanici_Adi,
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


        public ActionResult SendAll(List<int> PanelListAll)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            if (PanelListAll != null)
            {
                try
                {
                    foreach (var panel in PanelListAll)
                    {
                        TaskList taskListERS = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_TIMEGROUP,
                            IntParam_1 = 0,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = panel,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceiveErs = _taskListService.AddTaskList(taskListERS);

                        foreach (var item in _timeGroupsService.GetAllTimeGroups().Select(a => a.Zaman_Grup_No))
                        {
                            TaskList taskListSend = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_TIMEGROUP,
                                IntParam_1 = item,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceiveSend = _taskListService.AddTaskList(taskListSend);
                        }
                    }

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
            if (user.SysAdmin == true)
            {
                panels = _panelSettingsService.GetAllPanelSettings(x => x.Seri_No != 0 && x.Seri_No != null && x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            }
            else
            {
                foreach (var item in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi))
                {
                    var panel = _panelSettingsService.GetByQuery(x => x.Seri_No != 0 && x.Seri_No != null && x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_ID == item.Panel_No);
                    if (panel != null)
                        panels.Add(panel);
                }
            }

            return panels;
        }
    }

}