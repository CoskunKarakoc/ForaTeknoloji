using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
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

        public DBUsers user;
        private PanelSettings PanelSettings;
        public AccessGroupController(IGroupMasterService groupMasterService, IGlobalZoneService globalZoneService, IGroupsDetailNewService groupsDetailNewService, ITimeGroupsService timeGroupsService, ILiftGroupsService liftGroupsService, IReaderSettingsNewService readerSettingsNewService, IPanelSettingsService panelSettingsService)
        {
            PanelSettings = CurrentSession.Panel;
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _groupMasterService = groupMasterService;
            _globalZoneService = globalZoneService;
            _groupsDetailNewService = groupsDetailNewService;
            _timeGroupsService = timeGroupsService;
            _liftGroupsService = liftGroupsService;
            _readerSettingsNewService = readerSettingsNewService;
            _panelSettingsService = panelSettingsService;
        }


        // GET: AccessGroup
        public ActionResult Groups()
        {
            return View(_groupMasterService.GetAllGroupsMaster());
        }



        /*Edit*/
        public ActionResult GroupSettings(int id = -1)
        {
            if (id != -1)
            {
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
                }
                return RedirectToAction("Groups", "AccessGroup");
            }
            return View(groupsMaster);
        }


        public ActionResult Create()
        {
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
                foreach (var panel in _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0))
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
                            Grup_No = groupsMaster.Grup_No,
                            Grup_Adi = groupsMaster.Grup_Adi
                        };
                        _groupsDetailNewService.AddGroupsDetailNew(groupsDetailNew);
                    }
                }
                return RedirectToAction("Groups", "AccessGroup");
            }
            return View(groupsMaster);
        }


        public ActionResult Delete(int id = -1)
        {
            if (id != 1)
            {
                var entity = _groupMasterService.GetById(id);
                if (entity != null)
                {
                    _groupMasterService.DeleteGroupsMaster(entity);
                    return RedirectToAction("Groups", "AccessGroup");
                }
                throw new Exception("Böyle bir kayıt bulunamadı");
            }
            return RedirectToAction("Groups", "AccessGroup");
        }


        public ActionResult GroupReaders(int? PanelID, int id = -1)
        {

            List<SelectList> KapiZamanGrupNo = new List<SelectList>();
            List<SelectList> KapiAsansorBolgeNo = new List<SelectList>();
            List<ComplexGroupsDetailNew> nesne = new List<ComplexGroupsDetailNew>();
            if (PanelID == null)
            {
                return RedirectToAction("PanelList", "AccessGroup");
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
            var model = new CreateReaderModel
            {
                Kapi_Asansor_Bolge_No = KapiAsansorBolgeNo,
                Kapi_Zaman_Grup_No = KapiZamanGrupNo,
                Groups = nesne,
                Panel_ID = PanelID
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult GroupReaders
            (bool? Kapi_1, bool? Kapi_2, bool? Kapi_3, bool? Kapi_4,
            bool? Kapi_5, bool? Kapi_6, bool? Kapi_7, bool? Kapi_8, bool? Kapi_9, bool? Kapi_10,
            bool? Kapi_11, bool? Kapi_12, bool? Kapi_13, bool? Kapi_14, bool? Kapi_15, bool? Kapi_16,
            IList<int> Kapi_Zaman_Grup_No, IList<int> Kapi_Asansor_Bolge_No, int Grup_No, string Grup_Adi, int Panel_ID)
        {
            if (ModelState.IsValid)
            {
                List<bool?> kapiStatus = new List<bool?>();
                kapiStatus.Add(Kapi_1);
                kapiStatus.Add(Kapi_2);
                kapiStatus.Add(Kapi_3);
                kapiStatus.Add(Kapi_4);
                kapiStatus.Add(Kapi_5);
                kapiStatus.Add(Kapi_6);
                kapiStatus.Add(Kapi_7);
                kapiStatus.Add(Kapi_8);
                kapiStatus.Add(Kapi_9);
                kapiStatus.Add(Kapi_10);
                kapiStatus.Add(Kapi_11);
                kapiStatus.Add(Kapi_12);
                kapiStatus.Add(Kapi_13);
                kapiStatus.Add(Kapi_14);
                kapiStatus.Add(Kapi_15);
                kapiStatus.Add(Kapi_16);

                for (int i = 0; i < 16; i++)
                {
                    var group = _groupsDetailNewService.GetAllGroupsDetailNew(x => x.Kapi_No == (i + 1) && x.Panel_No == Panel_ID && x.Grup_No == Grup_No).FirstOrDefault();
                    if (group == null)
                    {
                        GroupsDetailNew createGroup = new GroupsDetailNew
                        {
                            Asansor_Grup_No = Kapi_Asansor_Bolge_No[i],
                            Global_Bolge_No = 1,
                            Grup_Adi = Grup_Adi,
                            Grup_No = Grup_No,
                            Kapi_Aktif = kapiStatus[i],
                            Kapi_No = i + 1,
                            Zaman_Grup_No = Kapi_Zaman_Grup_No[i],
                            Panel_Adi = _panelSettingsService.GetById(Panel_ID).Panel_Name,
                            Panel_No = (short)_panelSettingsService.GetById(Panel_ID).Panel_ID,
                            Seri_No = _panelSettingsService.GetById(Panel_ID).Seri_No
                        };
                        _groupsDetailNewService.AddGroupsDetailNew(createGroup);
                    }
                    else
                    {
                        group.Grup_Adi = Grup_Adi;
                        group.Grup_No = Grup_No;
                        group.Panel_Adi = _panelSettingsService.GetById(Panel_ID).Panel_Name;
                        group.Panel_No = (short)_panelSettingsService.GetById(Panel_ID).Panel_ID;
                        group.Seri_No = _panelSettingsService.GetById(Panel_ID).Seri_No;
                        group.Kapi_No = i + 1;
                        group.Global_Bolge_No = 1;
                        group.Asansor_Grup_No = Kapi_Asansor_Bolge_No[i];
                        group.Zaman_Grup_No = Kapi_Zaman_Grup_No[i];
                        group.Kapi_Aktif = kapiStatus[i];
                        _groupsDetailNewService.UpdateGroupsDetailNew(group);
                    }

                }

                return RedirectToAction("GroupReaders", "AccessGroup", new { id = Grup_No, PanelID = Panel_ID });

            }

            throw new Exception("Upss! Yanlış giden birşeyler var.");
        }


        public ActionResult PanelList(int id = -1)
        {
            var model = new AccessGroupPanelListViewModel
            {
                Paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0),
                Grup_No = id
            };
            return View(model);
        }


        public ActionResult GroupClone(int GrupNo, int PanelID)
        {
            var entity = _groupsDetailNewService.GetBy_GrupNo_AND_PanelID(GrupNo, PanelID);
            CurrentSession.Remove("Klone");
            CurrentSession.Set<GroupsDetailNew>("Klone", entity);
            return RedirectToAction("Groups", "AccessGroup");
        }

        public ActionResult Klone(List<int> Groups)
        {
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
                                Grup_Adi = liste.Grup_Adi,
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
            return RedirectToAction("Groups", "AccessGroup");
        }

    }
}