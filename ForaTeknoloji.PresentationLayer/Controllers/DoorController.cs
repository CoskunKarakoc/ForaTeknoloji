using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class DoorController : Controller
    {
        private ITaskListService _taskListService;
        private IProgRelay2Service _progRelay2Service;
        public DBUsers user;
        private PanelSettings PanelSettings;
        public DoorController(ITaskListService taskListService, IProgRelay2Service progRelay2Service)
        {
            PanelSettings = CurrentSession.Panel;
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _taskListService = taskListService;
            _progRelay2Service = progRelay2Service;
        }
        // GET: Door
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Panel Seçimi Yapılacak

        [HttpPost]
        public ActionResult OpenDoor(string Door = null, bool Kapi = false)
        {
            if (Door == "Kapi1" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3077,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi1" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3094,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi2" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3078,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi2" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3095,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi3" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3079,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi3" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3096,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi4" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3080,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi4" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3097,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi5" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3081,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi5" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3098,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi6" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3082,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi6" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3099,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi7" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3083,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi7" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4100,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi8" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3084,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi8" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4101,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi9" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3085,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi9" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4102,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi10" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3086,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi10" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4103,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi11" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3087,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi11" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4104,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi12" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3088,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi12" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4105,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi13" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3089,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi13" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4106,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi14" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3090,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi14" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4107,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi15" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3091,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi15" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4108,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi16" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3092,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Kapi16" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4109,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Alarm" && Kapi == true)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 3093,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }
            else if (Door == "Alarm" && Kapi == false)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 4110,
                        IntParam_1 = 1,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                    {
                        return Json(new { Result = 2 });
                    }
                    else if (Durum == 1)
                    {
                        return Json(new { Result = 1 });
                    }
                    else
                    {
                        return Json(new { Result = 3 });
                    }
                }
                catch (Exception)
                {

                    return Json(new { Result = 3 });
                }
            }

            return Json(new { Result = "İşlem Gerçekleştirilemedi" });
        }


        public ActionResult ProgRelay(int Haftanin_Gunu = -1)
        {
            if (PanelSettings == null)
                return RedirectToAction("Orientation", "Home");

            List<ProgRelay2> model;
            if (Haftanin_Gunu != -1)
            {
                model = _progRelay2Service.GetAllProgRelay2(x => x.Haftanin_Gunu == Haftanin_Gunu && x.Panel_No == PanelSettings.Panel_ID);
            }
            else
            {
                model = _progRelay2Service.GetAllProgRelay2(x => x.Panel_No == PanelSettings.Panel_ID);
            }
            return View(model);
        }





        public int CheckStatus(int GrupNo = -1)
        {
            if (GrupNo != -1)
            {
                return _taskListService.GetByGrupNo(GrupNo).Durum_Kodu;
            }
            return 3;
        }

    }
}