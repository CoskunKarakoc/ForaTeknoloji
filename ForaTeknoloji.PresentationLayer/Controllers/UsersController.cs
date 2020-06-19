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
        private IAccessDatasService _accessDatasService;
        private IBirimService _birimService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IDBUsersKapiService _dBUsersKapiService;
        public DBUsers user = CurrentSession.User;
        public DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbDoorList;
        List<int> dbSirketList;
        List<int> dbAltDepartmanList;
        public UsersController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupMasterService groupMasterService, IUserTypesService userTypesService, IBloklarService bloklarService, IAccessModesService accessModesService, ITimeZoneCalendarService timeZoneCalendarService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService, IUsersOLDService usersOLDService, IGorevlerService gorevlerService, IDBUsersSirketService dBUsersSirketService, IDBUsersDepartmanService dBUsersDepartmanService, IReportService reportService, IAltDepartmanService altDepartmanService, IBolumService bolumService, IUnvanService unvanService, IAccessDatasService accessDatasService, IBirimService birimService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IDBUsersKapiService dBUsersKapiService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
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
            _dBUsersKapiService = dBUsersKapiService;
            _bolumService = bolumService;
            _reportService = reportService;
            _unvanService = unvanService;
            _accessDatasService = accessDatasService;
            _birimService = birimService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
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
            _reportService.GetDoorList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        //Kullanıcıların Listelenmesi
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Kullanici_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz Erişim!");
            }

            var model = new UsersListViewModel
            {
                PanelListesi = _panelSettingsService.GetAllPanelSettings(x => dbPanelList.Contains((int)x.Panel_ID))
            };
            return View(model);

        }

        public ActionResult UserList()
        {
            var jsonresult = Json(new { data = _reportService.GetPersonelLists(null, user) }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }



        //Yeni Kullanıcı Oluşturma
        public ActionResult Create(string Kart_ID = null)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Kullanici_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Kullanici_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Kullanıcı ekleme yetkiniz yok!");
            }
            int MaxID;
            if (_userService.GetAllUsers().Count == 0)
                MaxID = 0;
            else
                MaxID = _userService.GetAllUsers().Max(x => x.ID);

            var Sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No));  /*_reportService.SirketListesi(user);*/
            var Departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No)); /*_reportService.DepartmanListesi(user);*/
            var AltDepartmanlar = _altDepartmanService.GetAllAltDepartman(x => dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var Bolumler = _bolumService.GetAllBolum();
            var Birimler = _birimService.GetAllBirim();
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
                }),
                Birim_No = Birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            return View(model);
        }


        //Yeni Kullanıcı Oluşturma
        [HttpPost]
        public ActionResult Create(Users Addeduser, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user_{Addeduser.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
                Addeduser.Resim = filename;
            }
            if (ProfileImage == null)
                Addeduser.Resim = "BaseUser.jpg";

            if (Addeduser.Kart_ID == null || Addeduser.Kart_ID == "")
                throw new Exception("Kart ID Değeri Boş Bırakılamaz!");

            if (Addeduser != null && Addeduser.ID != 0 && Addeduser.Kart_ID != null)
            {
                var CheckKartID = _userService.GetAllUsers(x => x.Kart_ID == Addeduser.Kart_ID);
                if (CheckKartID.Count > 0)
                    throw new Exception("Aynı Kart ID'sine sahip kullanıcı bulunmaktadır.");
                if (Addeduser.TCKimlik != null)
                {
                    var CheckTCNo = _userService.GetAllUsers(x => x.TCKimlik == Addeduser.TCKimlik);
                    if (CheckTCNo.Count > 0)
                        throw new Exception("Aynı TC No'suna ait kullanıcı bulunmaktadır.");
                }

                //  _userService.AddUsers(Addeduser);

                var result = _userService.AddUserWithCheckCardId(Addeduser);
                if (result != "")
                    throw new Exception(result);

                SendAuto(_panelSettingsService.GetPanelIDList(), CommandConstants.CMD_SND_USER, Addeduser.ID);
                _accessDatasService.AddOperatorLog(100, permissionUser.Kullanici_Adi, Addeduser.ID, 0, 0, 0);
                return RedirectToAction("Index");
            }
            return View(Addeduser);
        }

        //Kullanıcı Güncelleme
        public ActionResult Edit(int? id)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
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
            ViewBag.Grup_No_1 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_1);
            ViewBag.Grup_No_2 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_2);
            ViewBag.Grup_No_3 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_3);
            ViewBag.Grup_No_4 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_4);
            ViewBag.Grup_No_5 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_5);
            ViewBag.Grup_No_6 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_6);
            ViewBag.Grup_No_7 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_7);
            ViewBag.Grup_No_8 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_8);
            ViewBag.Grup_Takvimi_No = new SelectList(_timeZoneCalendarService.GetAllTimeZoneCalendar(), "Grup_Takvimi_No", "Grup_Takvimi_Adi", users.Grup_Takvimi_No);
            ViewBag.Alt_Departman_No = new SelectList(_altDepartmanService.GetAllAltDepartman(x => x.Departman_No == users.Departman_No), "Alt_Departman_No", "Adi", users.Alt_Departman_No);
            ViewBag.Bolum_No = new SelectList(_bolumService.GetAllBolum(x => x.Alt_Departman_No == users.Alt_Departman_No), "Bolum_No", "Adi", users.Bolum_No);
            ViewBag.Unvan_No = new SelectList(_unvanService.GetAllUnvan(), "Unvan_No", "Adi", users.Unvan_No);
            ViewBag.Birim_No = new SelectList(_birimService.GetAllBirim(x => x.Alt_Departman_No == users.Alt_Departman_No && x.Bolum_No == users.Bolum_No && x.Departman_No == users.Departman_No), "Birim_No", "Adi", users.Birim_No);
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
            if (ProfileImage == null && entity.Resim == null)
                entity.Resim = "BaseUser.jpg";



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
                    if (entity.Kart_ID == null || entity.Kart_ID == "")
                        throw new Exception("Kart ID Değeri Boş Geçilemez!");

                    //  _userService.UpdateUsers(entity);
                    var result = _userService.UpdateWithCheckCardId(entity);
                    if (result != "")
                        throw new Exception(result);

                    _accessDatasService.AddOperatorLog(102, permissionUser.Kullanici_Adi, entity.ID, 0, 0, 0);

                    if (User.Kart_ID != entity.Kart_ID || User.Kart_ID_2 != entity.Kart_ID_2 || User.Kart_ID_3 != entity.Kart_ID_3
                        || User.Grup_No != entity.Grup_No || User.Grup_No_1 != entity.Grup_No_1 || User.Grup_No_2 != entity.Grup_No_2
                        || User.Grup_No_3 != entity.Grup_No_3 || User.Grup_No_4 != entity.Grup_No_4 || User.Grup_No_5 != entity.Grup_No_5
                        || User.Grup_No_6 != entity.Grup_No_6 || User.Grup_No_7 != entity.Grup_No_7 || User.Grup_No_8 != entity.Grup_No_8
                        || User.C3_Grup != entity.C3_Grup || User.Gecis_Modu != entity.Gecis_Modu || User.Dogrulama_PIN != entity.Dogrulama_PIN
                        || User.Grup_Takvimi_Aktif != entity.Grup_Takvimi_Aktif || User.Grup_Takvimi_No != entity.Grup_Takvimi_No
                        || User.Kimlik_PIN != entity.Kimlik_PIN || User.Kullanici_Tipi != entity.Kullanici_Tipi || User.Plaka != entity.Plaka
                        || User.Saat_1 != entity.Saat_1 || User.Saat_2 != entity.Saat_2 || User.Saat_3 != entity.Saat_3 || User.Sifre != entity.Sifre
                        || User.Sureli_Kullanici != entity.Sureli_Kullanici || User.Tmp != entity.Tmp || User.Visitor_Grup_No != entity.Visitor_Grup_No
                        )
                    {
                     SendAuto(_panelSettingsService.GetPanelIDList(), CommandConstants.CMD_SND_USER, entity.ID);
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }


        public ActionResult Groups(int? id)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
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
            ViewBag.Grup_No_1 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_1);
            ViewBag.Grup_No_2 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_2);
            ViewBag.Grup_No_3 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_3);
            ViewBag.Grup_No_4 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_4);
            ViewBag.Grup_No_5 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_5);
            ViewBag.Grup_No_6 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_6);
            ViewBag.Grup_No_7 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_7);
            ViewBag.Grup_No_8 = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", users.Grup_No_8);
            ViewBag.Grup_Takvimi_No = new SelectList(_timeZoneCalendarService.GetAllTimeZoneCalendar(), "Grup_Takvimi_No", "Grup_Takvimi_Adi", users.Grup_Takvimi_No);
            ViewBag.Alt_Departman_No = new SelectList(_altDepartmanService.GetAllAltDepartman(x => x.Departman_No == users.Departman_No), "Alt_Departman_No", "Adi", users.Alt_Departman_No);
            ViewBag.Bolum_No = new SelectList(_bolumService.GetAllBolum(x => x.Alt_Departman_No == users.Alt_Departman_No), "Bolum_No", "Adi", users.Bolum_No);
            ViewBag.Unvan_No = new SelectList(_unvanService.GetAllUnvan(), "Unvan_No", "Adi", users.Unvan_No);
            ViewBag.Birim_No = new SelectList(_birimService.GetAllBirim(x => x.Alt_Departman_No == users.Alt_Departman_No && x.Bolum_No == users.Bolum_No && x.Departman_No == users.Departman_No), "Birim_No", "Adi", users.Birim_No);
            ViewBag.Bitis_Tarihi = users.Bitis_Tarihi;
            ViewBag.Bitis_Saati = users.Bitis_Saati;
            return View(users);
        }




        public ActionResult Delete(int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
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
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
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
        public ActionResult PanelOperation()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Kullanici_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz Erişim!");
            }
            var model = new UsersListViewModel
            {
                PanelListesi = _reportService.PanelListesi(user)
            };
            return View(model);
        }
        //Panelden Kullanıcı Alma İşlemi
        public ActionResult Receive(int PanelListReceive, int ReceiveUserID = -1)
        {

            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Kullanıcı alma işlemine yetkiniz yok!");
            }


            if (ReceiveUserID != -1)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_RCV_USER,
                        IntParam_1 = ReceiveUserID,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = PanelListReceive,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    _accessDatasService.AddOperatorLog(104, permissionUser.Kullanici_Adi, ReceiveUserID, 0, 0, 0);
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
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
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
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_ERS_USER,
                            IntParam_1 = id,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = item.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
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
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
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
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
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
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(maxUser);
                            _reportService.SendAllUserTask(2620, DateTime.Now, 1, permissionUser.Kullanici_Adi, panel);
                            //foreach (var userID in userListe)
                            //{
                            //    TaskList taskList = new TaskList
                            //    {
                            //        Deneme_Sayisi = 1,
                            //        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            //        Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
                            //        IntParam_1 = userID,
                            //        Kullanici_Adi = user.Kullanici_Adi,
                            //        Panel_No = panel,
                            //        Tablo_Guncelle = true,
                            //        Tarih = DateTime.Now
                            //    };
                            //    _taskListService.AddTaskList(taskList);
                            //    _accessDatasService.AddOperatorLog(103, permissionUser.Kullanici_Adi, userID, 0, 0, 0);
                            //}

                        }
                    }
                    else if (OprKod == CommandConstants.CMD_ERSALL_USER)
                    {
                        foreach (var item in PanelList)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_USER,
                                IntParam_1 = 1,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskList);
                        }
                    }
                    else
                    {
                        foreach (var item in PanelList)
                        {
                            if (OprKod == CommandConstants.CMD_SND_USER)
                            {
                                TaskList maxUser = new TaskList
                                {
                                    Deneme_Sayisi = 1,
                                    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                    Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                    IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                    Kullanici_Adi = user.Kullanici_Adi,
                                    Panel_No = item,
                                    Tablo_Guncelle = true,
                                    Tarih = DateTime.Now
                                };
                                _taskListService.AddTaskList(maxUser);
                            }
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)OprKod,
                                IntParam_1 = UserID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskList);
                            _accessDatasService.AddOperatorLog(103, permissionUser.Kullanici_Adi, UserID, 0, 0, 0);
                        }
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

        public void SendAuto(List<int> PanelList, CommandConstants OprKod, int UserID = -1)
        {
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
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
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
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(maxUser);
                            _reportService.SendAllUserTask(2620, DateTime.Now, 1, permissionUser.Kullanici_Adi, panel);
                            //foreach (var userID in userListe)
                            //{
                            //    TaskList taskList = new TaskList
                            //    {
                            //        Deneme_Sayisi = 1,
                            //        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            //        Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
                            //        IntParam_1 = userID,
                            //        Kullanici_Adi = user.Kullanici_Adi,
                            //        Panel_No = panel,
                            //        Tablo_Guncelle = true,
                            //        Tarih = DateTime.Now
                            //    };
                            //    _taskListService.AddTaskList(taskList);
                            //    _accessDatasService.AddOperatorLog(103, permissionUser.Kullanici_Adi, userID, 0, 0, 0);
                            //}

                        }
                    }
                    else if (OprKod == CommandConstants.CMD_ERSALL_USER)
                    {
                        foreach (var item in PanelList)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_USER,
                                IntParam_1 = 1,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskList);
                        }
                    }
                    else
                    {
                        foreach (var item in PanelList)
                        {
                            if (OprKod == CommandConstants.CMD_SND_USER)
                            {
                                TaskList maxUser = new TaskList
                                {
                                    Deneme_Sayisi = 1,
                                    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                    Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                    IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                    Kullanici_Adi = user.Kullanici_Adi,
                                    Panel_No = item,
                                    Tablo_Guncelle = true,
                                    Tarih = DateTime.Now
                                };
                                _taskListService.AddTaskList(maxUser);
                            }
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)OprKod,
                                IntParam_1 = UserID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.AddTaskList(taskList);
                            _accessDatasService.AddOperatorLog(103, permissionUser.Kullanici_Adi, UserID, 0, 0, 0);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }
        }


    }

}
