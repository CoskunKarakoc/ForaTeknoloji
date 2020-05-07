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
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class AccessGroupController : Controller
    {
        private IGroupMasterService _groupMasterService;
        private IGlobalZoneService _globalZoneService;
        private IGroupsDetailNewService _groupsDetailNewService;
        private ITimeGroupsService _timeGroupsService;
        private ILiftGroupsService _liftGroupsService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IPanelSettingsService _panelSettingsService;
        private ITaskListService _taskListService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersService _dBUsersService;
        private IReportService _reportService;
        private IAccessDatasService _accessDatasService;
        private IUserService _userService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        public DBUsers user = CurrentSession.User;
        public DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        public AccessGroupController(IGroupMasterService groupMasterService, IGlobalZoneService globalZoneService, IGroupsDetailNewService groupsDetailNewService, ITimeGroupsService timeGroupsService, ILiftGroupsService liftGroupsService, IReaderSettingsNewService readerSettingsNewService, IPanelSettingsService panelSettingsService, ITaskListService taskListService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService, IReportService reportService, IAccessDatasService accessDatasService, IUserService userService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _groupMasterService = groupMasterService;
            _globalZoneService = globalZoneService;
            _groupsDetailNewService = groupsDetailNewService;
            _timeGroupsService = timeGroupsService;
            _liftGroupsService = liftGroupsService;
            _readerSettingsNewService = readerSettingsNewService;
            _panelSettingsService = panelSettingsService;
            _taskListService = taskListService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersService = dBUsersService;
            _reportService = reportService;
            _accessDatasService = accessDatasService;
            _userService = userService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            dbDepartmanList = new List<int>();
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
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
            FillGroups();
        }


        // GET: AccessGroup
        public ActionResult Groups()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz Erişim!");
            }
            IDictionary<int, int> keyValues = new Dictionary<int, int>();
            foreach (var group in _groupMasterService.GetAllGroupsMaster())
            {
                var groupUserCount = _userService.GetAllUsers().Where(x => x.Grup_No == group.Grup_No).Count();
                keyValues.Add(group.Grup_No, groupUserCount);
            }
            var model = new GecisGrupListViewModel
            {
                Gruplar = _groupMasterService.GetAllGroupsMaster(),
                PanelListesi = _reportService.PanelListesi(user),
                GroupUserCount = keyValues
            };

            return View(model);
        }



        /*Edit*/
        public ActionResult GroupSettings(int id = -1)
        {
            if (id != -1)
            {
                if (permissionUser.SysAdmin == false)
                {
                    if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme)
                        throw new Exception("Grup düzenleme yetkiniz yok!");
                }
                var entity = _groupMasterService.GetById(id);
                if (entity != null)
                {
                    ViewBag.Grup_Icerdeki_Kisi_Sayisi_Global_Bolge_No = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", entity.Grup_Icerdeki_Kisi_Sayisi_Global_Bolge_No);
                    ViewBag.Grup_Gecis_Sayisi_Global_Bolge_No = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", entity.Grup_Gecis_Sayisi_Global_Bolge_No);
                    return View(entity);
                }
            }
            throw new Exception("Upss! Yanlış giden birşeyler var.");
        }

        [HttpPost]
        public ActionResult GroupSettings(GroupsMaster groupsMaster)
        {
            if (ModelState.IsValid)
            {
                _groupMasterService.UpdateGroupsMaster(groupsMaster);

                foreach (var item in _groupsDetailNewService.GetAllGroupsDetailNew(x => x.Grup_No == groupsMaster.Grup_No))
                {
                    var entity = item;
                    entity.Grup_Adi = groupsMaster.Grup_Adi;
                    _groupsDetailNewService.UpdateGroupsDetailNew(entity);
                    _accessDatasService.AddOperatorLog(122, permissionUser.Kullanici_Adi, groupsMaster.Grup_No, 0, 0, 0);

                }
                return RedirectToAction("Groups", "AccessGroup");
            }
            return View(groupsMaster);
        }


        public ActionResult Create()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Grup oluşturma yetkiniz yok!");
            }
            int maxID;

            if (_groupMasterService.GetAllGroupsMaster().Count > 0)
                maxID = _groupMasterService.GetAllGroupsMaster().Count;
            else
                maxID = 0;

            var GrupKisi = _globalZoneService.GetAllGlobalZones();
            var GrupSayi = _globalZoneService.GetAllGlobalZones();

            var model = new GroupMasterCreateViewModel
            {
                Grup_No = maxID + 1,
                Grup_Icerdeki_Kisi_Sayisi_Global_Bolge_No = GrupKisi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Grup_Gecis_Sayisi_Global_Bolge_No = GrupSayi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GroupsMaster groupsMaster)
        {
            if (ModelState.IsValid)
            {
                _groupMasterService.AddGroupsMaster(groupsMaster);
                _accessDatasService.AddOperatorLog(120, permissionUser.Kullanici_Adi, groupsMaster.Grup_No, 0, 0, 0);
                if (_liftGroupsService.GetAllLiftGroups().Count() == 0 || _liftGroupsService.GetAllLiftGroups() == null)
                {
                    _liftGroupsService.DeleteAll();
                    LiftGroups liftGroups = new LiftGroups
                    {
                        Asansor_Grup_No = 1,
                        Asansor_Grup_Adi = "Asansör",
                        Kat_Sayisi = 16
                    };
                    _liftGroupsService.AddLiftGroup(liftGroups);
                }
                var count = _timeGroupsService.GetAllTimeGroups().Count;
                var list = _timeGroupsService.GetAllTimeGroups();
                if (_timeGroupsService.GetAllTimeGroups().Count() == 0 || _timeGroupsService.GetAllTimeGroups() == null)
                {
                    _timeGroupsService.DeleteAll();
                    TimeGroups timeGroups = new TimeGroups
                    {
                        Zaman_Grup_No = 1,
                        Zaman_Grup_Adi = "Sınırlama Yok",
                        Gecis_Sinirlama_Tipi = 0,
                    };
                    _timeGroupsService.AddTimeGroups(timeGroups);
                }
                FillGroups();
                return RedirectToAction("Groups", "AccessGroup");
            }
            return View(groupsMaster);
        }


        public ActionResult Delete(int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Grup silme yetkiniz yok!");
            }
            if (id != -1)
            {
                var entity = _groupMasterService.GetById(id);
                if (entity != null)
                {
                    _groupMasterService.DeleteGroupsMaster(entity);
                    _accessDatasService.AddOperatorLog(121, permissionUser.Kullanici_Adi, id, 0, 0, 0);
                    foreach (var item in _groupsDetailNewService.GetAllGroupsDetailNew(x => x.Grup_Adi == entity.Grup_Adi))
                    {
                        _groupsDetailNewService.DeleteGroupsDetailNew(item);
                    }
                    return RedirectToAction("Groups");
                }
                throw new Exception("Böyle bir kayıt bulunamadı");
            }
            return RedirectToAction("Groups", "AccessGroup");
        }


        public ActionResult GroupReaders(int? PanelID, int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            List<SelectList> KapiZamanGrupNo = new List<SelectList>();
            List<SelectList> KapiAsansorBolgeNo = new List<SelectList>();
            List<ComplexGroupsDetailNew> nesne = new List<ComplexGroupsDetailNew>();
            if (PanelID == null)
            {

                try
                {
                    PanelID = _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && dbPanelList.Contains((int)x.Panel_ID)).FirstOrDefault().Panel_ID;
                }
                catch (Exception)
                {
                    throw new Exception("Sistemde kayıtlı panel bulunamadı!");
                }
                   



                var timezonegroupcount = _timeGroupsService.GetAllTimeGroups().Count;
                if (timezonegroupcount == 0)
                    throw new Exception("Zaman Bölgesi Gerekli!");

                var liftgroupcount = _liftGroupsService.GetAllLiftGroups().Count;
                if (liftgroupcount == 0)
                    throw new Exception("Asansör Geçiş Grubu Gerekli!");

                nesne = _groupsDetailNewService.GetComplexGroups().Where(x => x.Grup_No == id && x.Panel_No == PanelID && x.Reader_Panel_No == PanelID).ToList();
                }
            else
            {
                    nesne = _groupsDetailNewService.GetComplexGroups().Where(x => x.Grup_No == id && x.Panel_No == PanelID && x.Reader_Panel_No == PanelID).ToList();
                }

                foreach (var item in nesne)
                {
                    KapiZamanGrupNo.Add(new SelectList(_timeGroupsService.GetAllTimeGroups(), "Zaman_Grup_No", "Zaman_Grup_Adi", item.Zaman_Grup_No));
                    KapiAsansorBolgeNo.Add(new SelectList(_liftGroupsService.GetAllLiftGroups(), "Asansor_Grup_No", "Asansor_Grup_Adi", item.Asansor_Grup_No));
                }


                var panelModel = _panelSettingsService.GetAllPanelSettings().FirstOrDefault(x => x.Panel_ID == PanelID).Panel_Model;
                var model = new CreateReaderModel
                {
                    Kapi_Asansor_Bolge_No = KapiAsansorBolgeNo,
                    Kapi_Zaman_Grup_No = KapiZamanGrupNo,
                    Groups = nesne,
                    Panel_ID = PanelID,
                    PanelList = _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && dbPanelList.Contains((int)x.Panel_ID)), //_reportService.PanelListesi(user),
                    PanelModel = panelModel
                };
                return View(model);
            }

        [HttpPost]
        public ActionResult GroupReaders(GroupReadersParameters parameters)
        {
            if (ModelState.IsValid)
            {
                if (parameters.PanelModel == (int)PanelModel.Panel_1010)
                {
                    List<bool?> kapiStatus = new List<bool?>();
                    kapiStatus.Add(parameters.Kapi_1);

                    for (int i = 0; i < 1; i++)
                    {
                        var group = _groupsDetailNewService.GetAllGroupsDetailNew(x => x.Kapi_No == (i + 1) && x.Panel_No == parameters.Panel_ID && x.Grup_No == parameters.Grup_No).FirstOrDefault();
                        if (group == null)
                        {
                            GroupsDetailNew createGroup = new GroupsDetailNew
                            {
                                Asansor_Grup_No = 1,
                                Global_Bolge_No = 1,
                                Grup_Adi = parameters.Grup_Adi,
                                Grup_No = parameters.Grup_No,
                                Kapi_Aktif = kapiStatus[i],
                                Kapi_No = i + 1,
                                Zaman_Grup_No = parameters.Kapi_Zaman_Grup_No[i],
                                Panel_Adi = _panelSettingsService.GetById(parameters.Panel_ID).Panel_Name,
                                Panel_No = (short)_panelSettingsService.GetById(parameters.Panel_ID).Panel_ID,
                                Seri_No = _panelSettingsService.GetById(parameters.Panel_ID).Seri_No
                            };
                            _groupsDetailNewService.AddGroupsDetailNew(createGroup);
                        }
                        else
                        {
                            group.Grup_Adi = parameters.Grup_Adi;
                            group.Grup_No = parameters.Grup_No;
                            group.Panel_Adi = _panelSettingsService.GetById(parameters.Panel_ID).Panel_Name;
                            group.Panel_No = (short)_panelSettingsService.GetById(parameters.Panel_ID).Panel_ID;
                            group.Seri_No = _panelSettingsService.GetById(parameters.Panel_ID).Seri_No;
                            group.Kapi_No = i + 1;
                            group.Global_Bolge_No = 1;
                            group.Asansor_Grup_No = 1;
                            group.Zaman_Grup_No = parameters.Kapi_Zaman_Grup_No[i];
                            group.Kapi_Aktif = kapiStatus[i];
                            _groupsDetailNewService.UpdateGroupsDetailNew(group);
                        }

                    }

                    return RedirectToAction("GroupReaders", "AccessGroup", new { id = parameters.Grup_No, PanelID = parameters.Panel_ID });
                }
                else
                {
                    List<bool?> kapiStatus = new List<bool?>();
                    kapiStatus.Add(parameters.Kapi_1);
                    kapiStatus.Add(parameters.Kapi_2);
                    kapiStatus.Add(parameters.Kapi_3);
                    kapiStatus.Add(parameters.Kapi_4);
                    kapiStatus.Add(parameters.Kapi_5);
                    kapiStatus.Add(parameters.Kapi_6);
                    kapiStatus.Add(parameters.Kapi_7);
                    kapiStatus.Add(parameters.Kapi_8);
                    kapiStatus.Add(parameters.Kapi_9);
                    kapiStatus.Add(parameters.Kapi_10);
                    kapiStatus.Add(parameters.Kapi_11);
                    kapiStatus.Add(parameters.Kapi_12);
                    kapiStatus.Add(parameters.Kapi_13);
                    kapiStatus.Add(parameters.Kapi_14);
                    kapiStatus.Add(parameters.Kapi_15);
                    kapiStatus.Add(parameters.Kapi_16);

                    for (int i = 0; i < 16; i++)
                    {
                        var group = _groupsDetailNewService.GetAllGroupsDetailNew(x => x.Kapi_No == (i + 1) && x.Panel_No == parameters.Panel_ID && x.Grup_No == parameters.Grup_No).FirstOrDefault();
                        if (group == null)
                        {
                            GroupsDetailNew createGroup = new GroupsDetailNew
                            {
                                Asansor_Grup_No = parameters.Kapi_Asansor_Bolge_No[i],
                                Global_Bolge_No = 1,
                                Grup_Adi = parameters.Grup_Adi,
                                Grup_No = parameters.Grup_No,
                                Kapi_Aktif = kapiStatus[i],
                                Kapi_No = i + 1,
                                Zaman_Grup_No = parameters.Kapi_Zaman_Grup_No[i],
                                Panel_Adi = _panelSettingsService.GetById(parameters.Panel_ID).Panel_Name,
                                Panel_No = (short)_panelSettingsService.GetById(parameters.Panel_ID).Panel_ID,
                                Seri_No = _panelSettingsService.GetById(parameters.Panel_ID).Seri_No
                            };
                            _groupsDetailNewService.AddGroupsDetailNew(createGroup);
                        }
                        else
                        {
                            group.Grup_Adi = parameters.Grup_Adi;
                            group.Grup_No = parameters.Grup_No;
                            group.Panel_Adi = _panelSettingsService.GetById(parameters.Panel_ID).Panel_Name;
                            group.Panel_No = (short)_panelSettingsService.GetById(parameters.Panel_ID).Panel_ID;
                            group.Seri_No = _panelSettingsService.GetById(parameters.Panel_ID).Seri_No;
                            group.Kapi_No = i + 1;
                            group.Global_Bolge_No = 1;
                            group.Asansor_Grup_No = parameters.Kapi_Asansor_Bolge_No[i];
                            group.Zaman_Grup_No = parameters.Kapi_Zaman_Grup_No[i];
                            group.Kapi_Aktif = kapiStatus[i];
                            _groupsDetailNewService.UpdateGroupsDetailNew(group);
                        }

                    }

                    return RedirectToAction("GroupReaders", "AccessGroup", new { id = parameters.Grup_No, PanelID = parameters.Panel_ID });

                }
            }

            throw new Exception("Upss! Yanlış giden birşeyler var.");
        }



        public ActionResult GroupClone(int GrupNo, int PanelID)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            var entity = _groupsDetailNewService.GetBy_GrupNo_AND_PanelID(GrupNo, PanelID);
            CurrentSession.Remove("Klone");
            CurrentSession.Set<GroupsDetailNew>("Klone", entity);
            return RedirectToAction("Groups", "AccessGroup");
        }

        public ActionResult Klone(List<int> Groups)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            if (Groups != null)
            {
                var GroupKlone = CurrentSession.Get<GroupsDetailNew>("Klone");
                if (GroupKlone == null)
                {
                    throw new Exception("Klonlanacak Grup Bulunamadı!");
                }
                else
                {
                    var ListGroup = _groupsDetailNewService.GetAllGroupsDetailNew(x => x.Panel_No == GroupKlone.Panel_No && x.Seri_No == GroupKlone.Seri_No && x.Grup_No == GroupKlone.Grup_No);
                    foreach (var item in Groups)
                    {
                        foreach (var liste in ListGroup)
                        {
                            GroupsDetailNew groupsDetailNew = new GroupsDetailNew
                            {

                                Grup_No = item,
                                Seri_No = liste.Seri_No,
                                Panel_No = liste.Panel_No,
                                Grup_Adi = _groupsDetailNewService.GetById(item).Grup_Adi,
                                Kapi_Aktif = liste.Kapi_Aktif,
                                Panel_Adi = liste.Panel_Adi,
                                Asansor_Grup_No = liste.Asansor_Grup_No,
                                Global_Bolge_No = liste.Global_Bolge_No,
                                Kapi_No = liste.Kapi_No,
                                Zaman_Grup_No = liste.Zaman_Grup_No
                            };
                            var entity = _groupsDetailNewService.GetBy_GrupNo_AND_PanelID(groupsDetailNew.Grup_No, (short)groupsDetailNew.Panel_No);
                            if (entity == null)
                            {
                                _groupsDetailNewService.AddGroupsDetailNew(groupsDetailNew);
                            }
                            else
                            {
                                _groupsDetailNewService.DeleteGroupsDetailNew(entity);
                                _groupsDetailNewService.AddGroupsDetailNew(groupsDetailNew);
                            }
                        }
                    }
                }
            }
            CurrentSession.Remove("Klone");
            return RedirectToAction("Groups", "AccessGroup");
        }

        public ActionResult Send(List<int> PanelList, int GecisGrupNo = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            if (GecisGrupNo != -1)
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
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_ACCESSGROUP,
                                IntParam_1 = GecisGrupNo,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                            _accessDatasService.AddOperatorLog(123, permissionUser.Kullanici_Adi, GecisGrupNo, 0, item, 0);
                        }

                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Groups");
                }
            }
            return RedirectToAction("Groups");
        }

        public ActionResult SendAll(List<int> PanelListAll)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Bu işlem için yetkiniz yok!");
            }
            if (PanelListAll != null)
            {
                try
                {
                    foreach (var panel in PanelListAll)
                    {
                        var panelModel = _panelSettingsService.GetById(panel);
                        if (panelModel.Panel_Model != (int)PanelModel.Panel_1010)
                        {
                            TaskList taskListERS = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_ACCESSGROUP,
                                IntParam_1 = 0,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskListReceiveErs = _taskListService.AddTaskList(taskListERS);

                            foreach (var item in _groupMasterService.GetAllGroupsMaster().Select(a => a.Grup_No))
                            {
                                TaskList taskListSend = new TaskList
                                {
                                    Deneme_Sayisi = 1,
                                    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                    Gorev_Kodu = (int)CommandConstants.CMD_SND_ACCESSGROUP,
                                    IntParam_1 = item,
                                    Kullanici_Adi = user.Kullanici_Adi,
                                    Panel_No = panel,
                                    Tablo_Guncelle = true,
                                    Tarih = DateTime.Now
                                };
                                TaskList taskListReceiveSend = _taskListService.AddTaskList(taskListSend);
                                _accessDatasService.AddOperatorLog(123, permissionUser.Kullanici_Adi, item, 0, panel, 0);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    return RedirectToAction("Groups");
                }

            }
            return RedirectToAction("Groups");
        }

        public void FillGroups()
        {
            foreach (var panel in _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0))
            {
                foreach (var group in _groupMasterService.GetAllGroupsMaster())
                {
                    var entity = _groupsDetailNewService.GetBy_GrupNo_AND_PanelID(group.Grup_No, (int)panel.Panel_ID);
                    if (entity == null)
                    {
                        for (int i = 1; i < 17; i++)
                        {
                            GroupsDetailNew groupsDetailNew = new GroupsDetailNew
                            {
                                Asansor_Grup_No = 1,
                                Global_Bolge_No = 1,
                                Zaman_Grup_No = 1,
                                Kapi_Aktif = false,
                                Panel_Adi = panel.Panel_Name,
                                Panel_No = (short)panel.Panel_ID,
                                Seri_No = panel.Seri_No,
                                Kapi_No = i,
                                Grup_No = group.Grup_No,
                                Grup_Adi = group.Grup_Adi
                            };
                            _groupsDetailNewService.AddGroupsDetailNew(groupsDetailNew);

                        }
                    }
                }
            }
        }

    }
}