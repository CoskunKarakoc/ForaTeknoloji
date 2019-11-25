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
    public class DoorController : Controller
    {
        private ITaskListService _taskListService;
        private IProgRelay2Service _progRelay2Service;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsNewService _readerSettingsNewService;
        public DBUsers user;
        public DoorController(ITaskListService taskListService, IProgRelay2Service progRelay2Service, IDBUsersPanelsService dBUsersPanelsService, IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _taskListService = taskListService;
            _progRelay2Service = progRelay2Service;
            _dBUsersPanelsService = dBUsersPanelsService;
            _panelSettingsService = panelSettingsService;
            _readerSettingsNewService = readerSettingsNewService;
        }
        // GET: Door
        public ActionResult Index(int? PanelID)
        {
            if (PanelID == null)
            {
                var list = UserPanelList();
                if (list.Count == 0)
                    throw new Exception("Sistemde Kayıtlı Herhangi Bir Panel Bulunamadı!");
                PanelID = list.FirstOrDefault().Panel_ID;
            }

            var model = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(KapiOperasyon kapiOperasyon)
        {
            if (ModelState.IsValid)
            {
                if (kapiOperasyon.Tum_Panel == true)
                {
                    foreach (var item in UserPanelList())
                    {
                        if (kapiOperasyon.Kapi_1 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 1,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_2 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 2,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_3 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 3,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_4 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 4,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_5 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 5,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_6 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 6,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_7 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 7,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_8 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 8,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_9 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 9,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_10 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 10,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_11 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 11,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_12 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 12,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_13 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 13,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_14 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 14,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_15 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 15,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Kapi_16 == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 16,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                        if (kapiOperasyon.Alarm == true)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)kapiOperasyon.OprKod,
                                IntParam_1 = 17,
                                IntParam_2 = item.Panel_ID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = kapiOperasyon.Panel_ID,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                        }
                    }
                }
                else
                {
                    if (kapiOperasyon.Kapi_1 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 1,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_2 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 2,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_3 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 3,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_4 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 4,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_5 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 5,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_6 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 6,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_7 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 7,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_8 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 8,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_9 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 9,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_10 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 10,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_11 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 11,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_12 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 12,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_13 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 13,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_14 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 14,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_15 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 15,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Kapi_16 == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 16,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    if (kapiOperasyon.Alarm == true)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)kapiOperasyon.OprKod,
                            IntParam_1 = 17,
                            IntParam_2 = kapiOperasyon.Panel_ID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = kapiOperasyon.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult PartialDoorPanelList()
        {
            var model = UserPanelList();
            return PartialView("PartialDoorPanelList", model);
        }


        public ActionResult ProgRelay(int? ListPanel_No, int ListHaftanin_Gunu = 1)
        {
            Dictionary<int, string> gunler = new Dictionary<int, string>();
            gunler.Add(1, "Pazartesi");
            gunler.Add(2, "Salı");
            gunler.Add(3, "Çarşamba");
            gunler.Add(4, "Perşembe");
            gunler.Add(5, "Cuma");
            gunler.Add(6, "Cumartesi");
            gunler.Add(7, "Pazar");
            if (ListPanel_No == null)
            {
                var list = UserPanelList();
                if (list.Count == 0)
                    throw new Exception("Sistemde Kayıtlı Herhangi Bir Panel Bulunamadı!");
                ListPanel_No = list.FirstOrDefault().Panel_ID;
            }
            var liste = _progRelay2Service.GetAllProgRelay2(x => x.Panel_No == ListPanel_No && x.Haftanin_Gunu == ListHaftanin_Gunu);

            var model = new ProgRelayListViewModel
            {
                Panel_No = UserPanelList().Select(a => new SelectListItem
                {
                    Text = (a.Panel_ID + " - " + a.Panel_Name),
                    Value = a.Panel_ID.ToString()
                }),
                Haftanin_Gunu = gunler.Select(a => new SelectListItem
                {
                    Text = a.Value,
                    Value = a.Key.ToString()
                }),
                Liste = liste,
                Kapilar = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == ListPanel_No)
            };
            return View(model);
        }


        public ActionResult ProgRelayEdit(int Panel_No, int Haftanin_Gunu, int Zaman_Dilimi)
        {
            Dictionary<int, string> gunler = new Dictionary<int, string>();
            gunler.Add(1, "Pazartesi");
            gunler.Add(2, "Salı");
            gunler.Add(3, "Çarşamba");
            gunler.Add(4, "Perşembe");
            gunler.Add(5, "Cuma");
            gunler.Add(6, "Cumartesi");
            gunler.Add(7, "Pazar");
            var editEntity = _progRelay2Service.GetAllProgRelay2().Find(x => x.Panel_No == Panel_No && x.Haftanin_Gunu == Haftanin_Gunu && x.Zaman_Dilimi == Zaman_Dilimi);
            var doorNames = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Panel_No);
            var model = new ProgRelay2EditViewModel
            {
                ProgRelay = editEntity,
                DoorNames = doorNames
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult ProgRelayEdit(ProgRelay2 progRelay2)
        {
            if (ModelState.IsValid)
            {
                _progRelay2Service.UpdateProgRelay2(progRelay2);
                return RedirectToAction("ProgRelay", "Door", new { @ListPanel_No = progRelay2.Panel_No, @ListHaftanin_Gunu = progRelay2.Haftanin_Gunu });
            }
            return View(progRelay2);

        }


        public ActionResult Send(int? Panel_No)
        {
            if (Panel_No != null)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = (int)CommandConstants.CMD_SND_RELAYPROGRAM,
                        IntParam_1 = (int)Panel_No,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = (int)Panel_No,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }

            return RedirectToAction("ProgRelay");
        }


        public ActionResult Receive(int? Panel_No)
        {
            if (Panel_No != null)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = (int)CommandConstants.CMD_RCV_RELAYPROGRAM,
                        IntParam_1 = (int)Panel_No,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = (int)Panel_No,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }

            return RedirectToAction("ProgRelay");
        }


        private List<PanelSettings> UserPanelList()
        {
            List<PanelSettings> panels = new List<PanelSettings>();
            foreach (var item in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi))
            {
                var panel = _panelSettingsService.GetByQuery(x => x.Seri_No != 0 && x.Seri_No != null && x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_ID == item.Panel_No);
                if (panel != null)
                    panels.Add(panel);
            }
            return panels;
        }


    }
}