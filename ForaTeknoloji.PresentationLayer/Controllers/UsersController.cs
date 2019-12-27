using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.DataTransferObjects;
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
        private IUsersOLDService _usersOLDService;
        private IGorevlerService _gorevlerService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IAltDepartmanService _altDepartmanService;
        private IBolumService _bolumService;
        private IReportService _reportService;
        private IUnvanService _unvanService;
        public DBUsers user;
        public DBUsers permissionUser;
        public UsersController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupMasterService groupMasterService, IUserTypesService userTypesService, IBloklarService bloklarService, IAccessModesService accessModesService, ITimeZoneCalendarService timeZoneCalendarService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService, IUsersOLDService usersOLDService, IGorevlerService gorevlerService, IDBUsersSirketService dBUsersSirketService, IDBUsersDepartmanService dBUsersDepartmanService, IReportService reportService, IAltDepartmanService altDepartmanService, IBolumService bolumService, IUnvanService unvanService)
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
            _usersOLDService = usersOLDService;
            _gorevlerService = gorevlerService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _altDepartmanService = altDepartmanService;
            _bolumService = bolumService;
            _reportService = reportService;
            _unvanService = unvanService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        //Kullanıcıların Listelenmesi
        public ActionResult Index(string Search = null)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Kullanici_Islemleri == 3)
                    throw new Exception("Yetkisiz Erişim!");
            }
            if (Search != null && Search != "")
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())),
                    //Users = IndexViewUser().Where(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())).ToList(),
                    PanelListesi = _reportService.PanelListesi(user)
                };
                return View(model);
            }
            else
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(),
                    //Users = IndexViewUser(),
                    PanelListesi = _reportService.PanelListesi(user)
                };
                return View(model);
            }
        }

        //Yeni Kullanıcı Oluşturma
        public ActionResult Create(string Kart_ID = null)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Kullanici_Islemleri == 2 || permissionUser.Kullanici_Islemleri == 3)
                    throw new Exception("Kullanıcı ekleme yetkiniz yok!");
            }
            int MaxID;
            if (_userService.GetAllUsers().Count == 0)
                MaxID = 0;
            else
                MaxID = _userService.GetAllUsers().Max(x => x.ID);

            var Sirketler = _reportService.SirketListesi(user);
            var Departmanlar = _reportService.DepartmanListesi(user);
            var AltDepartmanlar = _altDepartmanService.GetAllAltDepartman();
            var Bolumler = _bolumService.GetAllBolum();
            var Bloklar = _bloklarService.GetAllBloklar();
            var Gorevler = _gorevlerService.GetAllGorevler();
            var GecisTipi = _accessModesService.GetAllAccessModes();
            var KullaniciTipi = _userTypesService.GetAllUserTypes();
            var GecisGrubu2 = _groupMasterService.GetAllGroupsMaster();
            var GecisGrubu3 = _groupMasterService.GetAllGroupsMaster();
            var ZiyaretciGrubu = _groupMasterService.GetAllGroupsMaster();
            var GrupTakvimi = _timeZoneCalendarService.GetAllTimeZoneCalendar();
            var Unvanlar = _unvanService.GetAllUnvan();
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
                Gorev_No = Gorevler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Gorev_No.ToString()
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
                Kart_ID = Kart_ID,
                Alt_Departman_No = AltDepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Bolum_No = Bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Unvan_No = Unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                })
            };
            return View(model);
        }


        //Yeni Kullanıcı Oluşturma
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

        //Kullanıcı Güncelleme
        public ActionResult Edit(int? id)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Kullanıcı düzenleme yetkiniz yok!");
            }
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
            ViewBag.Gorev_No = new SelectList(_gorevlerService.GetAllGorevler(), "Gorev_No", "Adi", users.Gorev_No);
            ViewBag.Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No);
            ViewBag.Kullanici_Tipi = new SelectList(_userTypesService.GetAllUserTypes(), "Kullanici_Tipi", "Ad", users.Kullanici_Tipi);
            ViewBag.Gecis_Modu = new SelectList(_accessModesService.GetAllAccessModes(), "Gecis_Modu", "Adi", users.Gecis_Modu);
            ViewBag.Visitor_Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Visitor_Grup_No);
            ViewBag.Grup_No_2 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_2);
            ViewBag.Grup_No_3 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_3);
            ViewBag.Grup_Takvimi_No = new SelectList(_timeZoneCalendarService.GetAllTimeZoneCalendar(), "Grup_Takvimi_No", "Grup_Takvimi_Adi", users.Grup_Takvimi_No);
            ViewBag.Alt_Departman_No = new SelectList(_altDepartmanService.GetAllAltDepartman(), "Alt_Departman_No", "Adi", users.Alt_Departman_No);
            ViewBag.Bolum_No = new SelectList(_bolumService.GetAllBolum(), "Bolum_No", "Adi", users.Bolum_No);
            ViewBag.Unvan_No = new SelectList(_unvanService.GetAllUnvan(), "Unvan_No", "Adi", users.Unvan_No);
            ViewBag.Bitis_Tarihi = users.Bitis_Tarihi;
            ViewBag.Bitis_Saati = users.Bitis_Saati;
            return View(users);
        }


        //Kullanıcı Güncelleme
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
                    if (_userService.GetAllUsers().Any(x => x.Kart_ID == entity.Kart_ID && x.ID != entity.ID))
                        throw new Exception("Kart ID'si daha önceden kullanılıyor.");
                    if (!CheckSirket((int)entity.Sirket_No))
                        throw new Exception("Yetkisiz Şirket Ataması!");
                    if (!CheckDepartman((int)entity.Departman_No))
                        throw new Exception("Yetkisiz Departman Ataması!");
                    _userService.UpdateUsers(entity);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }


        public ActionResult Delete(int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Kullanıcı silme işlemine yetkiniz yok!");
            }

            if (id != -1)
            {
                Users users = _userService.GetById(id);
                var userOld = ConvertUser.UserToUserOld(users);

                _usersOLDService.AddUsersOLD(userOld);
                _userService.DeleteUsers(users);
                foreach (var item in _reportService.PanelListesi(user))
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

        //Panel Silme Operasyonları Silme İşlemi
        public ActionResult PanelOperation(string Search)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Kullanici_Islemleri == 3)
                    throw new Exception("Yetkisiz Erişim!");
            }

            if (Search != null && Search != "")
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())),
                    //Users = IndexViewUser().Where(x => x.Kart_ID.Contains(Search.Trim()) || x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())).ToList(),
                    PanelListesi = _reportService.PanelListesi(user)
                };
                return View(model);
            }
            else
            {
                var model = new UsersListViewModel
                {
                    Users = _userService.GetAllUsersWithOuther(),
                    //Users = IndexViewUser(),
                    PanelListesi = _reportService.PanelListesi(user)

                };
                return View(model);
            }
        }

        //Panelden Kullanıcı Alma İşlemi
        public ActionResult Receive(int PanelListReceive, int ReceiveUserID = -1)
        {

            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Kullanıcı alma işlemine yetkiniz yok!");
            }


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

            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Kullanıcı silme işlemine yetkiniz yok!");
            }


            if (id != -1)
            {
                try
                {

                    foreach (var item in _reportService.PanelListesi(user))
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
                    UsersOLD usersOLD = ConvertUser.UserToUserOld(users);
                    _usersOLDService.AddUsersOLD(usersOLD);
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
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2 || permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Bu işleme yetkiniz yok!");
            }


            if (UserID != -1)
            {
                try
                {
                    if (OprKod == CommandConstants.CMD_SNDALL_USER)
                    {
                        foreach (var panel in PanelList)
                        {
                            TaskList taskListRemove = new TaskList
                            {
                                Deneme_Sayisi = 2,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_USER,
                                IntParam_1 = 1,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskListRemove);
                            TaskList maxUser = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(maxUser);


                            foreach (var userID in _userService.GetAllUsers().Select(u => u.ID))
                            {
                                TaskList taskList = new TaskList
                                {
                                    Deneme_Sayisi = 1,
                                    Durum_Kodu = 1,
                                    Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
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
                    else if (OprKod == CommandConstants.CMD_ERSALL_USER)
                    {
                        foreach (var item in PanelList)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 2,
                                Durum_Kodu = 1,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_USER,
                                IntParam_1 = 1,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskList);
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




        public ActionResult AltDepartmanListesi(int? Departman)
        {
            if (Departman != 0 && Departman != null)
            {
                var list = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == Departman);
                var selectAltDepartman = list.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                });
                return Json(selectAltDepartman, JsonRequestBehavior.AllowGet);
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
                var selectBolum = list.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                });
                return Json(selectBolum, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }




        public ActionResult DeleteDatabaseAll()
        {

            foreach (var user in _userService.GetAllUsers())
            {
                UsersOLD usersOLD = ConvertUser.UserToUserOld(user);
                _usersOLDService.AddUsersOLD(usersOLD);
            }
            _userService.DeleteAllUsers();
            return RedirectToAction("PanelOperation");
        }


        public List<ComplexUser> IndexViewUser()
        {

            List<ComplexUser> liste = new List<ComplexUser>();
            List<ComplexUser> userList = _userService.GetAllUsersWithOuther();
            if (permissionUser.SysAdmin == true)
            {
                return userList.OrderByDescending(x => x.Kayit_No).ToList();
            }
            else
            {
                foreach (var sirket in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi))
                {
                    foreach (var departman in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi))
                    {
                        foreach (var user in userList)
                        {
                            if (user.Sirket_No == sirket.Sirket_No && user.Departman_No == departman.Departman_No)
                            {
                                liste.Add(user);
                            }
                        }
                    }
                }
                return liste.OrderByDescending(x => x.Kayit_No).ToList();
            }
        }

        public bool CheckSirket(int? Sirket_No)
        {
            if (permissionUser.SysAdmin == true)
            {
                return true;
            }
            else
            {
                if (Sirket_No != null)
                {
                    var sirketList = _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi);
                    foreach (var sirket in sirketList)
                    {
                        if (Sirket_No == sirket.Sirket_No)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return true;
            }
        }

        public bool CheckDepartman(int? Departman_No)
        {
            if (permissionUser.SysAdmin == true)
            {
                return true;
            }
            else
            {
                if (Departman_No != null)
                {
                    var departmanList = _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi);
                    foreach (var departman in departmanList)
                    {
                        if (Departman_No == departman.Departman_No)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return true;
            }

        }

    }

}
