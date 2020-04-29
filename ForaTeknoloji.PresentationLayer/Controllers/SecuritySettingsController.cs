using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class SecuritySettingsController : Controller
    {

        private IDBUsersService _dBUsersService;
        private IDBRolesService _dBRolesService;

        private IPanelSettingsService _panelSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;

        private ISirketService _sirketService;
        private IDBUsersSirketService _dBUsersSirketService;

        private IDepartmanService _departmanService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;

        private IAccessDatasService _accessDatasService;
        private IOperatorTransactionListService _operatorTransactionListService;

        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IAltDepartmanService _altDepartmanService;

        private IDBUsersKapiService _dBUsersKapiService;
        private IReaderSettingsNewService _readerSettingsNewService;

        DBUsers user;
        DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbAltDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        public SecuritySettingsController(IDBUsersService dBUsersService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService, IDBRolesService dBRolesService, IPanelSettingsService panelSettingsService, ISirketService sirketService, IDepartmanService departmanService, IDBUsersDepartmanService dBUsersDepartmanService, IAccessDatasService accessDatasService, IOperatorTransactionListService operatorTransactionListService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IAltDepartmanService altDepartmanService, IDBUsersKapiService dBUsersKapiService, IReaderSettingsNewService readerSettingsNewService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _dBUsersService = dBUsersService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBRolesService = dBRolesService;
            _panelSettingsService = panelSettingsService;
            _sirketService = sirketService;
            _departmanService = departmanService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _accessDatasService = accessDatasService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            _altDepartmanService = altDepartmanService;
            _operatorTransactionListService = operatorTransactionListService;
            _dBUsersKapiService = dBUsersKapiService;
            _readerSettingsNewService = readerSettingsNewService;
            dbDepartmanList = new List<int>();
            dbAltDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbSirketList = new List<int>();
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanList.Add((int)dbUserDepartmanNo);
            }
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserSirketNo in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Sirket_No))
            {
                dbSirketList.Add((int)dbUserSirketNo);
            }
            foreach (var dbUserAltDepartmanNo in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Alt_Departman_No))
            {
                dbAltDepartmanList.Add((int)dbUserAltDepartmanNo);
            }
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: SecuritySettings
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            SystemAdminSirketDepartmanPanelFill();
            var model = new SecuritySettingsListViewModel
            {
                Kullanıcılar = _dBUsersService.GetAllDBUsers()
            };
            return View(model);
        }


        public ActionResult Edit(string Kullanici_Adi)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }

            var kullanici = _dBUsersService.GetById(Kullanici_Adi);
            var userPanel = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == Kullanici_Adi);
            var userSirket = _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == Kullanici_Adi);
            var userDepartman = _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == Kullanici_Adi);
            var panelList = _panelSettingsService.GetAllPanelSettings(x => x.Seri_No != 0 && x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            var sirketList = _sirketService.GetAllSirketler();
            var departmanList = _departmanService.GetAllDepartmanlar();
            var dbUserAltDepartmanList = _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == Kullanici_Adi);
            var altDepartmanList = _altDepartmanService.GetAllAltDepartman();
            TreeViewDataBindDepartmanAndAltDepartman();
            var model = new EditSecurityListViewModel
            {
                Kullanicilar = kullanici,
                UserPanelList = userPanel,
                PanelList = panelList,
                UserSirketList = userSirket,
                SirketList = sirketList,
                UserDepartmanList = userDepartman,
                DepartmanList = departmanList,
                DBUserAltDepartman = dbUserAltDepartmanList,
                AltDepartmanListesi = altDepartmanList
            };
            ViewBag.Kullanici_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Kullanici_Islemleri);
            ViewBag.Grup_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Grup_Islemleri);
            ViewBag.Programli_Kapi_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Programli_Kapi_Islemleri);
            ViewBag.Gecis_Verileri_Rapor_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Gecis_Verileri_Rapor_Islemleri);
            ViewBag.Ziyaretci_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Ziyaretci_Islemleri);
            ViewBag.Canli_Izleme = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Canli_Izleme);
            ViewBag.Alarm_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Alarm_Islemleri);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(DBUsers dBUsers, string selectedItems, List<int> Sirketler = null, List<int> Paneller = null, List<int> Departmanlar = null)
        {
            if (ModelState.IsValid)
            {
                if (dBUsers != null)
                {
                    List<TreeViewNode> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewNode>>(selectedItems);
                    List<DBUsersAltDepartman> dBUsersAltDepartmen = new List<DBUsersAltDepartman>();
                    _dBUsersDepartmanService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
                    _dBUsersAltDepartmanService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
                    foreach (var treeEntity in items)
                    {
                        int AltDepartmanID = Convert.ToInt32(treeEntity.id);
                        var altDepartmanEntity = _altDepartmanService.GetAllAltDepartman().FirstOrDefault(x => x.Alt_Departman_No == AltDepartmanID);
                        var addedDbUserAltDepartman = new DBUsersAltDepartman { Departman_No = altDepartmanEntity.Departman_No, Alt_Departman_No = altDepartmanEntity.Alt_Departman_No, Kullanici_Adi = dBUsers.Kullanici_Adi };
                        var checkUserDBDepartman = _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi && x.Departman_No == altDepartmanEntity.Departman_No);
                        if (checkUserDBDepartman == null || checkUserDBDepartman.Count == 0)
                        {
                            var addedDBUserDepartman = new DBUsersDepartman { Kullanici_Adi = dBUsers.Kullanici_Adi, Departman_No = altDepartmanEntity.Departman_No };
                            _dBUsersDepartmanService.AddDBUsersDepartman(addedDBUserDepartman);
                        }
                        _dBUsersAltDepartmanService.AddDBUsersAltDepartman(addedDbUserAltDepartman);
                    }




                    DBUserSirketUpdate(dBUsers, Sirketler);
                    DBUserPanelUpdate(dBUsers, Paneller);
                    //DBUserDepartmanUpdate(dBUsers, Departmanlar);
                    var updatedUser = _dBUsersService.UpdateDBUsers(dBUsers);
                    //Spot Monitor İçin Panel ve Kapı Listesi Oluşturma
                    DBUserKapiFill(updatedUser, Paneller);
                    if (updatedUser.SysAdmin == true)
                    {
                        var MenuUserList = _operatorTransactionListService.GetByKullaniciAdi(updatedUser.Kullanici_Adi);
                        MenuUserList.Aktif_Olmayanlar_Listesi = true;
                        MenuUserList.Aktif_Personel_Raporlari = true;
                        MenuUserList.Asansor_Gecis_Grubu_Ekleme = true;
                        MenuUserList.Canli_Izleme = true;
                        MenuUserList.Diger_Raporlar = true;
                        MenuUserList.Eski_Personel_Raporlari = true;
                        MenuUserList.E_Mail_Gonderme_Ayarlari = true;
                        MenuUserList.Gecis_Grup_Ayarlari = true;
                        MenuUserList.Gecis_Olay_Verileri = true;
                        MenuUserList.Gecis_Olay_Yedekle = true;
                        MenuUserList.Gelen_Kisi_Raporlari = true;
                        MenuUserList.Gelmeyen_Kisi_Raporlari = true;
                        MenuUserList.Global_Bolge_Guncelleme = true;
                        MenuUserList.Grup_Takvimi_Olusturma = true;
                        MenuUserList.Icerde_Disarda_Tumu = true;
                        MenuUserList.Icerde_Disarda_Ziyaretci_Raporlari = true;
                        MenuUserList.Icerde_Disarda_Personel_Raporlari = true;
                        MenuUserList.Ilk_Giris_Son_Cikis_Raporlari = true;
                        MenuUserList.Kamera_Ekleme = true;
                        MenuUserList.Kapi_Grup_Olusturma = true;
                        MenuUserList.Kapi_Operasyon = true;
                        MenuUserList.Kullanici_Alarm_Ekleme = true;
                        MenuUserList.Kullanici_Alarm_Raporu = true;
                        MenuUserList.Kullanici_Duzenleme = true;
                        MenuUserList.Kullanici_Ekleme = true;
                        MenuUserList.Kullanici_Gonderme = true;
                        MenuUserList.Operator_Log_Raporlari = true;
                        MenuUserList.Panel_Ayar_Gonderme = true;
                        MenuUserList.Panel_Durum_Tablosu = true;
                        MenuUserList.Panel_Ekleme = true;
                        MenuUserList.Panel_Guncelleme = true;
                        MenuUserList.Pasif_Kullanici_Raporlari = true;
                        MenuUserList.Personel_Listesi = true;
                        MenuUserList.SMS_Gonderme_Ayarlari = true;
                        MenuUserList.Tanimlamalar = true;
                        MenuUserList.Tanimsiz_Kullanici_Raporlari = true;
                        MenuUserList.Toplam_Icerde_Kalma_Raporu = true;
                        MenuUserList.Toplu_Giris_Sayisi_Raporlari = true;
                        MenuUserList.Yemekhane_Kisi_Bazli_Rapor = true;
                        MenuUserList.Yemekhane_Toplu_Gecis_Sayisi_Raporlari = true;
                        MenuUserList.Zaman_Bolgesi_Ayarlari = true;
                        MenuUserList.Ziyaretci_Duzenleme = true;
                        MenuUserList.Ziyaretci_Ekleme = true;
                        MenuUserList.Ziyaretci_Gonderme = true;
                        MenuUserList.Ziyaretci_Raporlari = true;
                        MenuUserList.Spot_Monitor = true;
                        _operatorTransactionListService.UpdateOperatorTransactionList(MenuUserList);
                    }
                    _accessDatasService.AddOperatorLog(232, user.Kullanici_Adi, 0, 0, 0, 0);
                }
            }
            return RedirectToAction("Index", "SecuritySettings");
        }






        public ActionResult UserManagementList(string Kullanici_Adi)
        {
            var model = _operatorTransactionListService.GetByKullaniciAdi(Kullanici_Adi);
            return View(model);
        }


        [HttpPost]
        public ActionResult UserManagementList(OperatorTransactionList operatorTransactionList)
        {
            if (ModelState.IsValid)
            {
                _operatorTransactionListService.UpdateOperatorTransactionList(operatorTransactionList);
                return RedirectToAction("Index", "SecuritySettings");
            }
            return View(operatorTransactionList);
        }



        public ActionResult Create()
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            TreeViewDataBindDepartmanAndAltDepartman();
            var model = new SecurityCreateViewModel
            {
                Roller = _dBRolesService.GetAllDBRoles().Select(a => new SelectListItem
                {
                    Text = a.Yetki_Adi,
                    Value = a.Yetki_Tipi.ToString()
                }),
                Sirketler = _sirketService.GetAllSirketler(),
                Departmanlar = _departmanService.GetAllDepartmanlar(),
                Paneller = _panelSettingsService.GetAllPanelSettings(x => x.Seri_No != 0 && x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0)

            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(string selectedItems, DBUsers dBUsers = null, List<int> Sirketler = null, List<int> Paneller = null, List<int> Departmanlar = null)
        {
            DBUsers addedUser = new DBUsers();
            if (ModelState.IsValid)
            {
                if (dBUsers != null)
                {
                    List<TreeViewNode> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewNode>>(selectedItems);
                    List<DBUsersAltDepartman> dBUsersAltDepartmen = new List<DBUsersAltDepartman>();
                    foreach (var treeEntity in items)
                    {
                        int AltDepartmanID = Convert.ToInt32(treeEntity.id);
                        var altDepartmanEntity = _altDepartmanService.GetAllAltDepartman().FirstOrDefault(x => x.Alt_Departman_No == AltDepartmanID);
                        var addedDbUserAltDepartman = new DBUsersAltDepartman { Departman_No = altDepartmanEntity.Departman_No, Alt_Departman_No = altDepartmanEntity.Alt_Departman_No, Kullanici_Adi = dBUsers.Kullanici_Adi };
                        var checkUserDBDepartman = _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi && x.Departman_No == altDepartmanEntity.Departman_No);
                        if (checkUserDBDepartman == null || checkUserDBDepartman.Count == 0)
                        {
                            var addedDBUserDepartman = new DBUsersDepartman { Kullanici_Adi = dBUsers.Kullanici_Adi, Departman_No = altDepartmanEntity.Departman_No };
                            _dBUsersDepartmanService.AddDBUsersDepartman(addedDBUserDepartman);
                        }
                        _dBUsersAltDepartmanService.AddDBUsersAltDepartman(addedDbUserAltDepartman);
                    }

                    var Kullanici = _dBUsersService.GetById(dBUsers.Kullanici_Adi);
                    if (Kullanici != null && Kullanici.Sifre == dBUsers.Sifre)
                    {
                        throw new Exception("Aynı kullanıcı adı veya şifre ile kayıt yapılamaz!");
                    }
                    if (dBUsers.EMail != null)
                    {
                        var checkEmail = _dBUsersService.GetByEmailAdres(dBUsers.EMail);
                        if (checkEmail != null)
                        {
                            throw new Exception("Bu E-Mail Adresine Kayıtlı Kullanıcı Bulunmaktadır!");
                        }
                    }
                    addedUser = _dBUsersService.AddDBUsers(dBUsers);
                    if (addedUser.SysAdmin == true)
                    {
                        var checkOperator = _operatorTransactionListService.GetByKullaniciAdi(addedUser.Kullanici_Adi);
                        if (checkOperator == null)
                        {
                            OperatorTransactionList operatorTransactionList = new OperatorTransactionList
                            {
                                Kullanici_Adi_Yonetim_Listesi = addedUser.Kullanici_Adi,
                                Aktif_Olmayanlar_Listesi = true,
                                Aktif_Personel_Raporlari = true,
                                Asansor_Gecis_Grubu_Ekleme = true,
                                Canli_Izleme = true,
                                Diger_Raporlar = true,
                                Eski_Personel_Raporlari = true,
                                E_Mail_Gonderme_Ayarlari = true,
                                Gecis_Grup_Ayarlari = true,
                                Gecis_Olay_Verileri = true,
                                Gecis_Olay_Yedekle = true,
                                Gelen_Kisi_Raporlari = true,
                                Gelmeyen_Kisi_Raporlari = true,
                                Global_Bolge_Guncelleme = true,
                                Grup_Takvimi_Olusturma = true,
                                Icerde_Disarda_Tumu = true,
                                Icerde_Disarda_Ziyaretci_Raporlari = true,
                                Icerde_Disarda_Personel_Raporlari = true,
                                Ilk_Giris_Son_Cikis_Raporlari = true,
                                Kamera_Ekleme = true,
                                Kapi_Grup_Olusturma = true,
                                Kapi_Operasyon = true,
                                Kullanici_Alarm_Ekleme = true,
                                Kullanici_Alarm_Raporu = true,
                                Kullanici_Duzenleme = true,
                                Kullanici_Ekleme = true,
                                Kullanici_Gonderme = true,
                                Operator_Log_Raporlari = true,
                                Panel_Ayar_Gonderme = true,
                                Panel_Durum_Tablosu = true,
                                Panel_Ekleme = true,
                                Panel_Guncelleme = true,
                                Pasif_Kullanici_Raporlari = true,
                                Personel_Listesi = true,
                                SMS_Gonderme_Ayarlari = true,
                                Tanimlamalar = true,
                                Tanimsiz_Kullanici_Raporlari = true,
                                Toplam_Icerde_Kalma_Raporu = true,
                                Toplu_Giris_Sayisi_Raporlari = true,
                                Yemekhane_Kisi_Bazli_Rapor = true,
                                Yemekhane_Toplu_Gecis_Sayisi_Raporlari = true,
                                Zaman_Bolgesi_Ayarlari = true,
                                Ziyaretci_Duzenleme = true,
                                Ziyaretci_Ekleme = true,
                                Ziyaretci_Gonderme = true,
                                Ziyaretci_Raporlari = true,
                                Spot_Monitor = true
                            };
                            _operatorTransactionListService.AddOperatorTransactionList(operatorTransactionList);
                        }
                    }
                    else
                    {
                        var checkOperator = _operatorTransactionListService.GetByKullaniciAdi(addedUser.Kullanici_Adi);
                        if (checkOperator == null)
                        {
                            OperatorTransactionList operatorTransactionList = new OperatorTransactionList
                            {
                                Kullanici_Adi_Yonetim_Listesi = addedUser.Kullanici_Adi,
                                Aktif_Olmayanlar_Listesi = false,
                                Aktif_Personel_Raporlari = false,
                                Asansor_Gecis_Grubu_Ekleme = false,
                                Canli_Izleme = false,
                                Diger_Raporlar = false,
                                Eski_Personel_Raporlari = false,
                                E_Mail_Gonderme_Ayarlari = false,
                                Gecis_Grup_Ayarlari = false,
                                Gecis_Olay_Verileri = false,
                                Gecis_Olay_Yedekle = false,
                                Gelen_Kisi_Raporlari = false,
                                Gelmeyen_Kisi_Raporlari = false,
                                Global_Bolge_Guncelleme = false,
                                Grup_Takvimi_Olusturma = false,
                                Icerde_Disarda_Tumu = false,
                                Icerde_Disarda_Ziyaretci_Raporlari = false,
                                Icerde_Disarda_Personel_Raporlari = false,
                                Ilk_Giris_Son_Cikis_Raporlari = false,
                                Kamera_Ekleme = false,
                                Kapi_Grup_Olusturma = false,
                                Kapi_Operasyon = false,
                                Kullanici_Alarm_Ekleme = false,
                                Kullanici_Alarm_Raporu = false,
                                Kullanici_Duzenleme = false,
                                Kullanici_Ekleme = false,
                                Kullanici_Gonderme = false,
                                Operator_Log_Raporlari = false,
                                Panel_Ayar_Gonderme = false,
                                Panel_Durum_Tablosu = false,
                                Panel_Ekleme = false,
                                Panel_Guncelleme = false,
                                Pasif_Kullanici_Raporlari = false,
                                Personel_Listesi = false,
                                SMS_Gonderme_Ayarlari = false,
                                Tanimlamalar = false,
                                Tanimsiz_Kullanici_Raporlari = false,
                                Toplam_Icerde_Kalma_Raporu = false,
                                Toplu_Giris_Sayisi_Raporlari = false,
                                Yemekhane_Kisi_Bazli_Rapor = false,
                                Yemekhane_Toplu_Gecis_Sayisi_Raporlari = false,
                                Zaman_Bolgesi_Ayarlari = false,
                                Ziyaretci_Duzenleme = false,
                                Ziyaretci_Ekleme = false,
                                Ziyaretci_Gonderme = false,
                                Ziyaretci_Raporlari = false,
                                Spot_Monitor = false
                            };
                            _operatorTransactionListService.AddOperatorTransactionList(operatorTransactionList);
                        }
                    }
                    _accessDatasService.AddOperatorLog(230, user.Kullanici_Adi, 0, 0, 0, 0);
                }
                if (addedUser.SysAdmin == true)
                {
                    foreach (var sirket in _sirketService.GetAllSirketler().Select(a => a.Sirket_No).ToList())
                    {
                        _dBUsersSirketService.AddDBUsersSirket(new DBUsersSirket { Kullanici_Adi = addedUser.Kullanici_Adi, Sirket_No = sirket });
                    }
                    foreach (var departman in _departmanService.GetAllDepartmanlar().Select(a => a.Departman_No).ToList())
                    {
                        _dBUsersDepartmanService.AddDBUsersDepartman(new DBUsersDepartman { Kullanici_Adi = addedUser.Kullanici_Adi, Departman_No = departman });
                    }
                    foreach (var panel in _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0).Select(a => a.Panel_ID))
                    {
                        _dBUsersPanelsService.AddDBUsersPanels(new DBUsersPanels { Kullanici_Adi = addedUser.Kullanici_Adi, Panel_No = panel });
                    }
                }
                else
                {
                    if (Sirketler != null)
                    {
                        foreach (var item in Sirketler)
                        {
                            _dBUsersSirketService.AddDBUsersSirket(new DBUsersSirket { Kullanici_Adi = addedUser.Kullanici_Adi, Sirket_No = item });
                        }
                    }
                    if (Paneller != null)
                    {
                        foreach (var item in Paneller)
                        {
                            _dBUsersPanelsService.AddDBUsersPanels(new DBUsersPanels { Kullanici_Adi = addedUser.Kullanici_Adi, Panel_No = item });
                        }
                    }
                }

                //Monitor Watch İçin Panel ve kapı seçimi
                DBUserKapiFill(addedUser, Paneller);
                return RedirectToAction("Index");
            }
            return View(dBUsers);
        }


        public ActionResult Delete(string kullaniciAdi)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }

            if (kullaniciAdi != null)
            {
                DBUsers user = _dBUsersService.GetById(kullaniciAdi);
                if (user != null && user.Kullanici_Adi != "sa")
                {
                    _dBUsersService.DeleteDBUsers(user);
                    var operatorTransactionList = _operatorTransactionListService.GetByKullaniciAdi(user.Kullanici_Adi);
                    _operatorTransactionListService.DeleteOperatorTransactionList(operatorTransactionList);
                    _dBUsersKapiService.DeleteByUserName(user.Kullanici_Adi);
                    _dBUsersPanelsService.DeleteAllWithUserName(user.Kullanici_Adi);
                    _dBUsersAltDepartmanService.DeleteAllWithUserName(user.Kullanici_Adi);
                    _dBUsersDepartmanService.DeleteAllWithUserName(user.Kullanici_Adi);
                    _accessDatasService.AddOperatorLog(231, user.Kullanici_Adi, 0, 0, 0, 0);
                    return RedirectToAction("Index", "SecuritySettings");
                }
            }
            throw new Exception("Böyle bir kullanıcı bulunamadı!");
        }


        public ActionResult UserDoorToWatch(string Kullanici_Adi)
        {
            List<PanelSettings> panelListesi = new List<PanelSettings>();
            var dbUserPanel = _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == Kullanici_Adi);
            foreach (var item in dbUserPanel)
            {
                panelListesi.Add(_panelSettingsService.GetAllPanelSettings().FirstOrDefault(x => x.Panel_ID == item.Panel_No));
            }

            if (panelListesi.Count == 0)
                throw new Exception("Bu kullanıcı için panel seçimi yapmanız gerekmektedir!");

            var model = new UserDoorToWatchListViewModel
            {
                Panel_ID = panelListesi.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Kullanici_Adi = dbUserPanel.FirstOrDefault().Kullanici_Adi
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult UserDoorToWatch(int? Panel_ID, string Kullanici_Adi, List<int> ReaderList)
        {
            bool Kapi1 = false, Kapi2 = false, Kapi3 = false, Kapi4 = false, Kapi5 = false, Kapi6 = false, Kapi7 = false, Kapi8 = false;
            if (Kullanici_Adi != null && Panel_ID != null)
            {
                foreach (var item in ReaderList)
                {
                    if (item == 1)
                        Kapi1 = true;
                    if (item == 2)
                        Kapi2 = true;
                    if (item == 3)
                        Kapi3 = true;
                    if (item == 4)
                        Kapi4 = true;
                    if (item == 5)
                        Kapi5 = true;
                    if (item == 6)
                        Kapi6 = true;
                    if (item == 7)
                        Kapi7 = true;
                    if (item == 8)
                        Kapi8 = true;
                }
                var updatedUserDoor = _dBUsersKapiService.GetAllDBUsersKapi().FirstOrDefault(x => x.Kullanici_Adi == Kullanici_Adi && x.Panel_No == Panel_ID);
                updatedUserDoor.Kapi_1 = Kapi1;
                updatedUserDoor.Kapi_2 = Kapi2;
                updatedUserDoor.Kapi_3 = Kapi3;
                updatedUserDoor.Kapi_4 = Kapi4;
                updatedUserDoor.Kapi_5 = Kapi5;
                updatedUserDoor.Kapi_6 = Kapi6;
                updatedUserDoor.Kapi_7 = Kapi7;
                updatedUserDoor.Kapi_8 = Kapi8;
                _dBUsersKapiService.UpdateDBUsersKapi(updatedUserDoor);

                return RedirectToAction("Index", "SecuritySettings");
            }
            else
            {
                return RedirectToAction("UserDoorToWatch", "SecuritySettings", new { @Kullanici_Adi = Kullanici_Adi });
            }
        }



        public ActionResult ReaderEditList(int PanelID, string Kullanici_Adi)
        {
            if (PanelID != 0 && Kullanici_Adi != null)
            {
                var model = _dBUsersKapiService.GetAllDBUsersKapi().FirstOrDefault(x => x.Kullanici_Adi == Kullanici_Adi && x.Panel_No == PanelID);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new DBUsersKapi(), JsonRequestBehavior.AllowGet);
            }


        }



        public ActionResult ChangePassword()
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult ChangePassword(DBUsers dBUsers)
        {
            if (ModelState.IsValid)
            {
                _dBUsersService.UpdateDBUsers(dBUsers);
                return RedirectToAction("Logout", "Home");
            }
            return View(dBUsers);
        }


        public void DBUserPanelUpdate(DBUsers dBUsers, List<int> Paneller)
        {
            _dBUsersPanelsService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
            if (Paneller != null)
            {
                foreach (var panel in Paneller)
                {
                    DBUsersPanels dBUsersPanels = new DBUsersPanels
                    {
                        Kullanici_Adi = dBUsers.Kullanici_Adi,
                        Panel_No = panel
                    };
                    _dBUsersPanelsService.AddDBUsersPanels(dBUsersPanels);
                }
            }
        }

        public void DBUserSirketUpdate(DBUsers dBUsers, List<int> Sirketler)
        {
            _dBUsersSirketService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
            if (Sirketler != null)
            {
                foreach (var sirket in Sirketler)
                {
                    DBUsersSirket dBUsersSirket = new DBUsersSirket
                    {
                        Kullanici_Adi = dBUsers.Kullanici_Adi,
                        Sirket_No = sirket
                    };
                    _dBUsersSirketService.AddDBUsersSirket(dBUsersSirket);
                }
            }
        }

        public void DBUserDepartmanUpdate(DBUsers dBUsers, List<int> AltDepartmanlar)
        {
            _dBUsersDepartmanService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
            _dBUsersAltDepartmanService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
            if (AltDepartmanlar != null)
            {
                foreach (var altdepartman in AltDepartmanlar)
                {
                    var altdepartmanNo = _altDepartmanService.GetAllAltDepartman().FirstOrDefault(x => x.Alt_Departman_No == altdepartman);
                    var dbUsersDepartman = _dBUsersDepartmanService.GetAllDBUsersDepartman().FirstOrDefault(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi && x.Departman_No == altdepartmanNo.Departman_No);
                    if (dbUsersDepartman == null)
                    {
                        DBUsersDepartman dBUsersDepartman = new DBUsersDepartman
                        {
                            Kullanici_Adi = dBUsers.Kullanici_Adi,
                            Departman_No = altdepartmanNo.Departman_No
                        };
                        _dBUsersDepartmanService.AddDBUsersDepartman(dBUsersDepartman);
                    }
                    DBUsersAltDepartman dBUsersAltDepartman = new DBUsersAltDepartman
                    {
                        Kullanici_Adi = dBUsers.Kullanici_Adi,
                        Departman_No = altdepartmanNo.Departman_No,
                        Alt_Departman_No = altdepartmanNo.Alt_Departman_No,
                    };
                    _dBUsersAltDepartmanService.AddDBUsersAltDepartman(dBUsersAltDepartman);
                }
            }
        }

        public void DBUserAltDepartmanUpdate(DBUsers dBUsers, int Departman, List<int> AltDepartmanlar)
        {
            _dBUsersAltDepartmanService.DeleteAllWithUserName(dBUsers.Kullanici_Adi);
            if (AltDepartmanlar != null)
            {
                foreach (var altdepartman in AltDepartmanlar)
                {
                    DBUsersAltDepartman dBUsersAltDepartman = new DBUsersAltDepartman
                    {
                        Kullanici_Adi = dBUsers.Kullanici_Adi,
                        Departman_No = Departman,
                        Alt_Departman_No = altdepartman
                    };
                    _dBUsersAltDepartmanService.AddDBUsersAltDepartman(dBUsersAltDepartman);
                }
            }
        }

        public void DBUsersKapiUpdate(DBUsers dBUsers)
        {
            foreach (var panelNo in _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0).Select(a => a.Panel_ID).Cast<int>().ToList())
            {
                var checkDBUsersKapi = _dBUsersKapiService.GetAllDBUsersKapi().FirstOrDefault(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi && x.Panel_No == panelNo);
                if (checkDBUsersKapi == null)
                {
                    var entity = new DBUsersKapi
                    {
                        Kapi_1 = true,
                        Kapi_2 = true,
                        Kapi_3 = true,
                        Kapi_4 = true,
                        Kapi_5 = true,
                        Kapi_6 = true,
                        Kapi_7 = true,
                        Kapi_8 = true,
                        Kapi_9 = true,
                        Kapi_10 = true,
                        Kapi_11 = true,
                        Kapi_12 = true,
                        Kapi_13 = true,
                        Kapi_14 = true,
                        Kapi_15 = true,
                        Kapi_16 = true,
                        Kullanici_Adi = dBUsers.Kullanici_Adi,
                        Panel_No = panelNo
                    };
                    _dBUsersKapiService.AddDBUsersKapi(entity);
                }

            }
        }

        //System Admini olan kullanıcının default şirket,departman,panel check işlemleri
        public void SystemAdminSirketDepartmanPanelFill()
        {
            var systemAdmin = _dBUsersService.GetAllDBUsers(x => x.SysAdmin == true);
            foreach (var userSys in systemAdmin)
            {
                DBUsersKapiUpdate(userSys);
                DBUserPanelUpdate(userSys, _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0).Select(a => a.Panel_ID).Cast<int>().ToList());
                DBUserSirketUpdate(userSys, _sirketService.GetAllSirketler().Select(a => a.Sirket_No).ToList());
                DBUserDepartmanUpdate(userSys, _altDepartmanService.GetAllAltDepartman().Select(a => a.Alt_Departman_No).ToList());
            }
        }

        public void TreeViewDataBindDepartmanAndAltDepartman()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            //Ana Root
            foreach (Departmanlar type in _departmanService.GetAllDepartmanlar())
            {
                nodes.Add(new TreeViewNode { id = type.Departman_No.ToString(), parent = "#", text = type.Adi });
            }
            //SubRoot
            foreach (AltDepartman subType in _altDepartmanService.GetAllAltDepartman())
            {
                nodes.Add(new TreeViewNode { id = subType.Departman_No.ToString() + "-" + subType.Alt_Departman_No.ToString(), parent = subType.Departman_No.ToString(), text = subType.Adi });
            }
            //Serialize to JSON string.
            ViewBag.Json = (new JavaScriptSerializer()).Serialize(nodes);
        }




        public ActionResult GetDoorToPanel(int? PanelNo)
        {
            return Json(_readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelNo), JsonRequestBehavior.AllowGet);
        }

        public void DBUserKapiFill(DBUsers dBUsersKapi, List<int> Panel)
        {
            if (Panel != null)
            {
                var checkDBDoor = _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == dBUsersKapi.Kullanici_Adi);
                if (checkDBDoor != null || checkDBDoor.Count > 0)
                {
                    _dBUsersKapiService.DeleteByUserName(dBUsersKapi.Kullanici_Adi);
                }
                if (dBUsersKapi.SysAdmin == true)
                {
                    foreach (var p in Panel)
                    {
                        var entity = new DBUsersKapi
                        {
                            Kapi_1 = true,
                            Kapi_2 = true,
                            Kapi_3 = true,
                            Kapi_4 = true,
                            Kapi_5 = true,
                            Kapi_6 = true,
                            Kapi_7 = true,
                            Kapi_8 = true,
                            Kapi_9 = true,
                            Kapi_10 = true,
                            Kapi_11 = true,
                            Kapi_12 = true,
                            Kapi_13 = true,
                            Kapi_14 = true,
                            Kapi_15 = true,
                            Kapi_16 = true,
                            Kullanici_Adi = dBUsersKapi.Kullanici_Adi,
                            Panel_No = p
                        };
                        _dBUsersKapiService.AddDBUsersKapi(entity);
                    }
                }
                else
                {
                    foreach (var p in Panel)
                    {
                        var entity = new DBUsersKapi
                        {
                            Kapi_1 = false,
                            Kapi_2 = false,
                            Kapi_3 = false,
                            Kapi_4 = false,
                            Kapi_5 = false,
                            Kapi_6 = false,
                            Kapi_7 = false,
                            Kapi_8 = false,
                            Kapi_9 = false,
                            Kapi_10 = false,
                            Kapi_11 = false,
                            Kapi_12 = false,
                            Kapi_13 = false,
                            Kapi_14 = false,
                            Kapi_15 = false,
                            Kapi_16 = false,
                            Kullanici_Adi = dBUsersKapi.Kullanici_Adi,
                            Panel_No = p
                        };
                        _dBUsersKapiService.AddDBUsersKapi(entity);
                    }
                }
            }
        }



        /// <summary>
        /// Operatör kullanıcısı güncelleme işlemi esnasında departman ve alt departman değerlerinin id'ye göre seçim işlemi
        /// </summary>
        /// <param name="Kullanici_Adi">
        /// Güncellenen operatör kullanıcısının kullanıcı adına göre id değerleri gönderiyor.
        /// </param>
        /// <returns></returns>
        public ActionResult TreeViewEditCheckList(string Kullanici_Adi)
        {
            List<string> treeViewCheckList = new List<string>();
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            List<int> tempDepartman = GetEditUserDepartmanList(Kullanici_Adi);
            List<int> tempAltDepartman = GetEditUserAltDepartmanList(Kullanici_Adi);
            //Ana Root
            foreach (Departmanlar type in _departmanService.GetAllDepartmanlar(x => tempDepartman.Contains(x.Departman_No)))
            {
                nodes.Add(new TreeViewNode { id = type.Departman_No.ToString(), parent = "#", text = type.Adi });
            }
            //SubRoot
            foreach (AltDepartman subType in _altDepartmanService.GetAllAltDepartman(x => tempDepartman.Contains((int)x.Departman_No) && tempAltDepartman.Contains(x.Alt_Departman_No)))
            {
                // nodes.Add(new TreeViewNode { id = subType.Departman_No.ToString() + "-" + subType.Alt_Departman_No.ToString(), parent = subType.Departman_No.ToString(), text = subType.Adi });
                treeViewCheckList.Add(subType.Departman_No.ToString() + "-" + subType.Alt_Departman_No.ToString());
            }
            return Json(treeViewCheckList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Edit sayfasından gelen kullanıcı adına göre o kullanıcıya ait departman listesinin id değerleri geri dönüyor.
        /// </summary>
        /// <param name="Kullanici_Adi">
        /// Edit sayfasında güncellenen kullanıcının 'Kullanıcı Adı'
        /// </param>
        /// <returns></returns>
        public List<int> GetEditUserDepartmanList(string Kullanici_Adi)
        {
            List<int> dbDepartmanListEditUser = new List<int>();
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanListEditUser.Add((int)dbUserDepartmanNo);
            }
            return dbDepartmanListEditUser;
        }

        /// <summary>
        /// Edit sayfasından gelen kullanıcı adına göre o kullanıcıya ait alt departman listesinin id değerleri geri dönüyor.
        /// </summary>
        /// <param name="Kullanici_Adi">
        /// Edit sayfasında güncellenen kullanıcının 'Kullanıcı Adı'
        /// </param>
        /// <returns></returns>
        public List<int> GetEditUserAltDepartmanList(string Kullanici_Adi)
        {
            List<int> dbAltDepartmanListEditUser = new List<int>();
            foreach (var dbUserAltDepartmanNo in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == Kullanici_Adi).Select(a => a.Alt_Departman_No))
            {
                dbAltDepartmanListEditUser.Add((int)dbUserAltDepartmanNo);
            }
            return dbAltDepartmanListEditUser;
        }


    }
}