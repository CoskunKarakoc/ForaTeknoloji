using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private ISirketService _sirketService;
        private IGroupMasterService _groupMasterService;
        private IUserTypesService _userTypesService;
        private IBloklarService _bloklarService;
        private IAccessModesService _accessModesService;
        private ITimeZoneCalendarService _timeZoneCalendarService;
        private ITaskListService _taskListService;
        public DBUsers user;
        public UsersController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupMasterService groupMasterService, IUserTypesService userTypesService, IBloklarService bloklarService, IAccessModesService accessModesService, ITimeZoneCalendarService timeZoneCalendarService, ITaskListService taskListService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _userService = userService;
            _departmanService = departmanService;
            _sirketService = sirketService;
            _groupMasterService = groupMasterService;
            _userTypesService = userTypesService;
            _bloklarService = bloklarService;
            _accessModesService = accessModesService;
            _timeZoneCalendarService = timeZoneCalendarService;
            _taskListService = taskListService;
        }



        // GET: Users
        public ActionResult Index(string Search = null, int Status = -1)
        {

            if (Search != null && Search != "")
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())),
                    StatusControl = Status
                };
                return View(model);
            }
            else
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(),
                    StatusControl = Status
                };
                return View(model);
            }
        }

        public ActionResult Create()
        {
            int MaxID;
            if (_userService.GetAllUsers().Count == 0)
                MaxID = 0;
            else
                MaxID = _userService.GetAllUsers().Max(x => x.ID);

            var Sirketler = _sirketService.GetAllSirketler();
            var Departmanlar = _departmanService.GetAllDepartmanlar();
            var Bloklar = _bloklarService.GetAllBloklar();
            var GecisTipi = _accessModesService.GetAllAccessModes();
            var KullaniciTipi = _userTypesService.GetAllUserTypes();
            var GecisGrubu2 = _groupMasterService.GetAllGroupsMaster();
            var GecisGrubu3 = _groupMasterService.GetAllGroupsMaster();
            var ZiyaretciGrubu = _groupMasterService.GetAllGroupsMaster();
            var GrupTakvimi = _timeZoneCalendarService.GetAllTimeZoneCalendar();
            var model = new UsersAddViewModel
            {
                ID = MaxID + 1,
                Sirket_No = Sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Departman_No = Departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Blok_No = Bloklar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Blok_No.ToString()
                }),
                Gecis_Modu = GecisTipi.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Gecis_Modu.ToString()
                }),
                Kullanici_Tipi = KullaniciTipi.Select(a => new SelectListItem
                {
                    Text = a.Ad,
                    Value = a.Kullanici_Tipi.ToString()
                }),
                Grup_No_2 = GecisGrubu2.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Grup_No_3 = GecisGrubu3.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Visitor_Grup_No = ZiyaretciGrubu.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Grup_Takvimi_No = GrupTakvimi.Select(a => new SelectListItem
                {
                    Text = a.Grup_Takvimi_Adi,
                    Value = a.Grup_Takvimi_No.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Users user, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user_{user.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
                user.Resim = filename;
            }
            if (ModelState.IsValid)
            {
                _userService.AddUsers(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Users users = _userService.GetById((int)id);
            if (users.Resim == null)
                users.Resim = "BaseUser.jpg";

            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sirket_No = new SelectList(_sirketService.GetAllSirketler(), "Sirket_No", "Adi", users.Sirket_No);
            ViewBag.Departman_No = new SelectList(_departmanService.GetAllDepartmanlar(), "Departman_No", "Adi", users.Departman_No);
            ViewBag.Blok_No = new SelectList(_bloklarService.GetAllBloklar(), "Blok_No", "Adi", users.Blok_No);
            ViewBag.Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No);
            ViewBag.Kullanici_Tipi = new SelectList(_userTypesService.GetAllUserTypes(), "Kullanici_Tipi", "Ad", users.Kullanici_Tipi);
            ViewBag.Gecis_Modu = new SelectList(_accessModesService.GetAllAccessModes(), "Gecis_Modu", "Adi", users.Gecis_Modu);
            ViewBag.Visitor_Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Visitor_Grup_No);
            ViewBag.Grup_No_2 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_2);
            ViewBag.Grup_No_3 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_3);
            ViewBag.Grup_Takvimi_No = new SelectList(_timeZoneCalendarService.GetAllTimeZoneCalendar(), "Grup_Takvimi_No", "Grup_Takvimi_Adi", users.Grup_Takvimi_No);
            ViewBag.Bitis_Tarihi = users.Bitis_Tarihi;
            ViewBag.Bitis_Saati = users.Bitis_Saati;
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users entity, HttpPostedFileBase ProfileImage)
        {

            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user_{entity.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
                entity.Resim = filename;
            }


            if (ModelState.IsValid)
            {
                var User = _userService.GetAllUsersWithOuther().FirstOrDefault(x => x.ID == entity.ID);
                if (User != null)
                {

                    _userService.UpdateUsers(entity);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }

        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Users users = _userService.GetById(id);
                _userService.DeleteUsers(users);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public ActionResult Grup(int DeleteID)
        {
            if (DeleteID > 0)
            {
                Users users = _userService.GetById(DeleteID);
                users.Grup_No_2 = 0;
                users.Grup_No_3 = 0;
                users = _userService.UpdateUsers(users);
                return RedirectToAction("Edit", "Users", new { id = users.ID });
            }
            return RedirectToAction("Index");
        }


        public ActionResult Send(int UserID = -1)
        {
            if (UserID != -1)
            {
                try
                {

                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 2620,
                        IntParam_1 = UserID,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("Index", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("Index", new { @Status = 1 });
                    else
                        return RedirectToAction("Index", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", new { @Status = 3 });
                }
            }
            return RedirectToAction("Index", new { @Status = 3 });
        }


        public ActionResult Receive(int UserID = -1)
        {
            if (UserID != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 2624,
                        IntParam_1 = UserID,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("Index", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("Index", new { @Status = 1 });
                    else
                        return RedirectToAction("Index", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", new { @Status = 3 });
                }
            }
            return RedirectToAction("Index", new { @Status = 3 });
        }
      

        public ActionResult PanelOperation(string Search, int Status = -1)
        {
            if (Search != null && Search != "")
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())),
                    StatusControl = Status
                };
                return View(model);
            }
            else
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(),
                    StatusControl = Status
                };
                return View(model);
            }
        }


        public ActionResult PanelDelete(int id = -1)
        {
            if (id != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 2628,
                        IntParam_1 = id,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("PanelOperation", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("PanelOperation", new { @Status = 1 });
                    else
                        return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
            }
            return RedirectToAction("PanelOperation", new { @Status = 3 });
        }


        public ActionResult AccessCounterDelete(int id = -1)
        {
            if (id != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 2701,
                        IntParam_1 = id,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("PanelOperation", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("PanelOperation", new { @Status = 1 });
                    else
                        return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
            }
            return RedirectToAction("PanelOperation", new { @Status = 3 });
        }


        public ActionResult AntiCounterDelete(int id = -1)
        {
            if (id != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 2710,
                        IntParam_1 = id,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("PanelOperation", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("PanelOperation", new { @Status = 1 });
                    else
                        return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
            }
            return RedirectToAction("PanelOperation", new { @Status = 3 });
        }


        public ActionResult DeleteAllSystem(int id = -1)
        {
            if (id != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = 2628,
                        IntParam_1 = id,
                        Kullanici_Adi = "coskun",
                        Panel_No = 8,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    Users users = _userService.GetById(id);
                    _userService.DeleteUsers(users);
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("PanelOperation", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("PanelOperation", new { @Status = 1 });
                    else
                        return RedirectToAction("PanelOperation", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
                }

            }
            return RedirectToAction("PanelOperation", new { @Status = 3 });
        }


        public ActionResult PanelDeleteAll()
        {
            try
            {
                TaskList taskList = new TaskList
                {
                    Deneme_Sayisi = 1,
                    Durum_Kodu = 1,
                    Gorev_Kodu = 2629,
                    IntParam_1 = 1,
                    Kullanici_Adi = "coskun",
                    Panel_No = 8,
                    Tablo_Guncelle = true,
                    Tarih = DateTime.Now
                };
                TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                Thread.Sleep(2000);
                var Durum = CheckStatus(taskListReceive.Grup_No);
                if (Durum == 2)
                    return RedirectToAction("PanelOperation", new { @Status = 2 });
                else if (Durum == 1)
                    return RedirectToAction("PanelOperation", new { @Status = 1 });
                else
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
            }
            catch (Exception)
            {
                return RedirectToAction("PanelOperation", new { @Status = 3 });
            }
        }


        public ActionResult AccessCounterDeleteAll()
        {
            try
            {
                TaskList taskList = new TaskList
                {
                    Deneme_Sayisi = 1,
                    Durum_Kodu = 1,
                    Gorev_Kodu = 2702,
                    IntParam_1 = 1,
                    Kullanici_Adi = "coskun",
                    Panel_No = 8,
                    Tablo_Guncelle = true,
                    Tarih = DateTime.Now
                };
                TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                Thread.Sleep(2000);
                var Durum = CheckStatus(taskListReceive.Grup_No);
                if (Durum == 2)
                    return RedirectToAction("PanelOperation", new { @Status = 2 });
                else if (Durum == 1)
                    return RedirectToAction("PanelOperation", new { @Status = 1 });
                else
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
            }
            catch (Exception)
            {
                return RedirectToAction("PanelOperation", new { @Status = 3 });
            }
        }


        public ActionResult AntiCounterDeleteAll()
        {
            try
            {
                TaskList taskList = new TaskList
                {
                    Deneme_Sayisi = 1,
                    Durum_Kodu = 1,
                    Gorev_Kodu = 2711,
                    IntParam_1 = 1,
                    Kullanici_Adi = "coskun",
                    Panel_No = 8,
                    Tablo_Guncelle = true,
                    Tarih = DateTime.Now
                };
                TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                Thread.Sleep(2000);
                var Durum = CheckStatus(taskListReceive.Grup_No);
                if (Durum == 2)
                    return RedirectToAction("PanelOperation", new { @Status = 2 });
                else if (Durum == 1)
                    return RedirectToAction("PanelOperation", new { @Status = 1 });
                else
                    return RedirectToAction("PanelOperation", new { @Status = 3 });
            }
            catch (Exception)
            {
                return RedirectToAction("PanelOperation", new { @Status = 3 });
            }
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
