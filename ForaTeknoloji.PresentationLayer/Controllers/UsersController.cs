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
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public UsersController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupMasterService groupMasterService, IUserTypesService userTypesService, IBloklarService bloklarService, IAccessModesService accessModesService, ITimeZoneCalendarService timeZoneCalendarService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService)
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
            _panelSettingsService = panelSettingsService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: Users
        public ActionResult Index(string Search = null)
        {
            if (permissionUser.Kullanici_Islemleri == 3)
                throw new Exception("Yetkisiz Erişim!");

            if (Search != null && Search != "")
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())),
                    PanelListesi = UserPanelList()
                };
                return View(model);
            }
            else
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(),
                    PanelListesi = UserPanelList()
                };
                return View(model);
            }
        }


        public ActionResult Create(string Kart_ID = null)
        {
            if (permissionUser.Kullanici_Islemleri == 2 || permissionUser.Kullanici_Islemleri == 3)
                throw new Exception("Kullanıcı ekleme yetkiniz yok!");
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
                }),
                Kart_ID = Kart_ID
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
            if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                throw new Exception("Kullanıcı düzenleme yetkiniz yok!");

            if (id == null)
                throw new Exception("Upps! Yanlış giden birşeyler var.");

            Users users = _userService.GetById((int)id);

            if (users.Resim == null)
                users.Resim = "BaseUser.jpg";

            if (users == null)
                return HttpNotFound();

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
                var User = _userService.GetAllUsers().FirstOrDefault(x => x.ID == entity.ID);
                if (User != null)
                {
                    if (_userService.GetAllUsers().Any(x => x.Kart_ID == entity.Kart_ID))
                        throw new Exception("Kart ID'si daha önceden kullanılıyor.");
                    _userService.UpdateUsers(entity);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }


        public ActionResult Delete(int id = -1)
        {
            if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                throw new Exception("Kullanıcı silme işlemine yetkiniz yok!");
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


        public ActionResult PanelOperation(string Search)
        {
            if (permissionUser.Kullanici_Islemleri == 3)
                throw new Exception("Yetkisiz Erişim!");

            if (Search != null && Search != "")
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())),
                    PanelListesi = UserPanelList()
                };
                return View(model);
            }
            else
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(),
                    PanelListesi = UserPanelList()

                };
                return View(model);
            }
        }


        public ActionResult Receive(int PanelListReceive, int ReceiveUserID = -1)
        {
            if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                throw new Exception("Kullanıcı alma işlemine yetkiniz yok!");
            if (ReceiveUserID != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = (int)CommandConstants.CMD_RCV_USER,
                        IntParam_1 = ReceiveUserID,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = PanelListReceive,
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
            return RedirectToAction("Index");
        }


        public ActionResult DeleteAllSystem(int id = -1)
        {
            if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                throw new Exception("Kullanıcı silme işlemine yetkiniz yok!");
            if (id != -1)
            {
                try
                {

                    foreach (var item in UserPanelList())
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = 1,
                            Gorev_Kodu = (int)CommandConstants.CMD_ERS_USER,
                            IntParam_1 = id,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = item.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    Thread.Sleep(2000);
                    Users users = _userService.GetById(id);
                    _userService.DeleteUsers(users);

                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }
            return RedirectToAction("PanelOperation");
        }


        public ActionResult Send(List<int> PanelList, CommandConstants OprKod, int UserID = -1)
        {
            if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                throw new Exception("Bu işleme yetkiniz yok!");
            if (UserID != -1)
            {
                try
                {
                    if (OprKod == CommandConstants.CMD_SNDALL_USER)
                    {
                        foreach (var panel in PanelList)
                        {
                            foreach (var userID in _userService.GetAllUsers().Select(u => u.ID))
                            {
                                TaskList taskList = new TaskList
                                {
                                    Deneme_Sayisi = 1,
                                    Durum_Kodu = 1,
                                    Gorev_Kodu = (int)OprKod,
                                    IntParam_1 = userID,
                                    Kullanici_Adi = user.Kullanici_Adi,
                                    Panel_No = panel,
                                    Tablo_Guncelle = true,
                                    Tarih = DateTime.Now
                                };
                                _taskListService.AddTaskList(taskList);
                            }
                        }
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        foreach (var item in PanelList)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)OprKod,
                                IntParam_1 = UserID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskList);
                        }
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }
            if (OprKod == CommandConstants.CMD_ERS_USER || OprKod == CommandConstants.CMD_ERSALL_USER || OprKod == CommandConstants.CMD_ERS_ACCESSCOUNTERS || OprKod == CommandConstants.CMD_ERSALL_ACCESSCOUNTERS || OprKod == CommandConstants.CMD_ERS_APBCOUNTERS || OprKod == CommandConstants.CMD_ERSALL_APBCOUNTERS)
                return RedirectToAction("PanelOperation");
            else
                return RedirectToAction("Index");
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
