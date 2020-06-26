using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
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

    [Auth]
    [Excp]
    public class DoorGroupController : Controller
    {
        private IDoorGroupsDetailService _doorGroupsDetailService;
        private IDoorGroupsMasterService _doorGroupsMasterService;
        private IGroupMasterService _groupMasterService;
        private IGroupsDetailNewService _groupsDetailNewService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IReportService _reportService;
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersService _dBUsersService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersKapiService _dBUsersKapiService;
        DBUsers dBUsers = CurrentSession.User;
        DBUsers permissionUser;
        List<int> dbPanelList;
        List<int> dbDoorList;
        public DoorGroupController(IDoorGroupsDetailService doorGroupsDetailService, IDoorGroupsMasterService doorGroupsMasterService, IGroupsDetailNewService groupsDetailNewService, IGroupMasterService groupMasterService, IReaderSettingsNewService readerSettingsNewService, IReportService reportService, IPanelSettingsService panelSettingsService, IDBUsersService dBUsersService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersKapiService dBUsersKapiService)
        {
            //dBUsers = CurrentSession.User;
            //if (dBUsers == null)
            //{
            //    dBUsers = new DBUsers();
            //}

            _doorGroupsDetailService = doorGroupsDetailService;
            _doorGroupsMasterService = doorGroupsMasterService;
            _groupsDetailNewService = groupsDetailNewService;
            _groupMasterService = groupMasterService;
            _readerSettingsNewService = readerSettingsNewService;
            _reportService = reportService;
            _panelSettingsService = panelSettingsService;
            _dBUsersService = dBUsersService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersKapiService = dBUsersKapiService;
            dbPanelList = new List<int>();
            dbDoorList = new List<int>();
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserDoorNo in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi).Select(a => a.Kapi_Kayit_No))
            {
                dbDoorList.Add((int)dbUserDoorNo);
            }
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi);
        }


        // GET: DoorGroup
        public ActionResult Index()
        {
            //if (permissionUser.SysAdmin == false)
            //    throw new Exception("Yetkisiz Erişim!");

            var model = new DoorGroupsListViewModel
            {
                Gruplar = _doorGroupsMasterService.GetAllDoorGroupsMaster()
            };

            return View(model);
        }



        public ActionResult Create()
        {
            //if (permissionUser.SysAdmin == false)
            //    throw new Exception("Yetkisiz Erişim!");

            int maxID;
            if (_doorGroupsMasterService.GetAllDoorGroupsMaster().Count > 0)
                maxID = _doorGroupsMasterService.GetAllDoorGroupsMaster().Max(X => X.Kapi_Grup_No);
            else
                maxID = 0;

            var model = new DoorGroupsCreateViewModel
            {
                Kapi_Grup_No = (maxID + 1)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(DoorGroupsMaster groupsMaster)
        {
            if (ModelState.IsValid)
            {
                DoorGroupsMaster doorGroups = _doorGroupsMasterService.AddDoorGroupsMaster(groupsMaster);
                return RedirectToAction("Reader", "DoorGroup", new { DoorGroupID = doorGroups.Kapi_Grup_No });
            }
            return View(groupsMaster);
        }

        public ActionResult Edit(int? ID)
        {
            //if (permissionUser.SysAdmin == false)
            //    throw new Exception("Yetkisiz Erişim!");

            DoorGroupsMaster model = new DoorGroupsMaster();
            if (ID != null)
            {
                model = _doorGroupsMasterService.GetByKapiGrupNo((int)ID);
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DoorGroupsMaster doorGroupsMaster)
        {

            if (ModelState.IsValid)
            {
                _doorGroupsMasterService.UpdateDoorGroupsMaster(doorGroupsMaster);
                return RedirectToAction("Index", "DoorGroup");
            }

            return View(doorGroupsMaster);
        }






        public ActionResult Reader(int? DoorGroupID)
        {
            //if (permissionUser.SysAdmin == false)
            //    throw new Exception("Yetkisiz Erişim!");

            var Paneller = _panelSettingsService.GetAllPanelSettings(x => dbPanelList.Contains((int)x.Panel_ID) && x.Seri_No != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            var DoorGroupName = _doorGroupsMasterService.GetByKapiGrupNo((int)DoorGroupID);
            var model = new DoorGroupReaderCreateViewModel
            {
                Panel_ID = Paneller.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Grup_No = DoorGroupID,
                Kapi_Grup_Adi = DoorGroupName.Kapi_Grup_Adi,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Reader(int? Panel_ID, int Grup_No, List<int> ReaderList)
        {
            if (ReaderList != null)
            {
                foreach (var item in ReaderList)
                {
                    var nesne = new DoorGroupsDetail
                    {
                        Kapi_Grup_No = Grup_No,
                        Kapi_ID = item,
                        Panel_ID = Panel_ID
                    };
                    _doorGroupsDetailService.AddDoorGroupsDetail(nesne);
                }
                return RedirectToAction("Index", "DoorGroup");
            }
            _doorGroupsMasterService.DeleteByKapiGrupNo(Grup_No);
            return RedirectToAction("Index", "DoorGroup");
        }



        public ActionResult ReaderEdit(int? DoorGroupID)
        {
            //if (permissionUser.SysAdmin == false)
            //    throw new Exception("Yetkisiz Erişim!");

            var Paneller = _panelSettingsService.GetAllPanelSettings(x => dbPanelList.Contains((int)x.Panel_ID) && x.Seri_No != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            var DoorGroupName = _doorGroupsMasterService.GetByKapiGrupNo((int)DoorGroupID);
            var model = new DoorGroupReaderCreateViewModel
            {
                Panel_ID = Paneller.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Grup_No = DoorGroupID,
                Kapi_Grup_Adi = DoorGroupName.Kapi_Grup_Adi,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Readeredit(int? Panel_ID, int Grup_No, List<int> ReaderList)
        {
            if (ReaderList != null)
            {
                _doorGroupsDetailService.DeleteByGrupNoANDPanelID(Panel_ID, Grup_No);
                foreach (var item in ReaderList)
                {

                    var nesne = new DoorGroupsDetail
                    {
                        Kapi_Grup_No = Grup_No,
                        Kapi_ID = item,
                        Panel_ID = Panel_ID
                    };
                    _doorGroupsDetailService.AddDoorGroupsDetail(nesne);
                }
                return RedirectToAction("Index", "DoorGroup");
            }
            else
            {
                _doorGroupsDetailService.DeleteByGrupNoANDPanelID(Panel_ID, Grup_No);
            }
            return RedirectToAction("ReaderEdit", "DoorGroup", new { DoorGroupID = Grup_No });
        }






        public ActionResult ReaderList(int? PanelID)
        {
            if (PanelID != null)
            {
                var panelModel = _panelSettingsService.GetById((int)PanelID).Panel_Model;
                if (panelModel == (int)PanelModel.Panel_301)
                {
                    var readerList = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID && x.WKapi_ID <= 8 && dbDoorList.Contains(x.Kayit_No));
                    return Json(readerList, JsonRequestBehavior.AllowGet);
                }
                else if (panelModel == (int)PanelModel.Panel_302)
                {
                    var readerList = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID && x.WKapi_ID <= 2 && dbDoorList.Contains(x.Kayit_No));
                    return Json(readerList, JsonRequestBehavior.AllowGet);
                }
                else if (panelModel == (int)PanelModel.Panel_304)
                {
                    var readerList = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID && x.WKapi_ID <= 4 && dbDoorList.Contains(x.Kayit_No));
                    return Json(readerList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var readerList = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID && x.WKapi_ID <= 1 && dbDoorList.Contains(x.Kayit_No));
                    return Json(readerList, JsonRequestBehavior.AllowGet);
                }

            }
            return null;
        }

        public ActionResult ReaderEditList(int? PanelID, int? GrupNo)
        {
            if (PanelID != null)
            {
                var readerEditList = _doorGroupsDetailService.GetAllDoorGroupsDetail(x => x.Panel_ID == PanelID && x.Kapi_Grup_No == GrupNo).Select(x => x.Kapi_ID);
                return Json(readerEditList, JsonRequestBehavior.AllowGet);
            }
            return null;
        }




        public ActionResult Delete(int id = -1)
        {
            //if (permissionUser.SysAdmin == false)
            //    throw new Exception("Yetkisiz Erişim!");


            if (id != -1)
            {
                var entity = _doorGroupsMasterService.GetByKapiGrupNo(id);
                _doorGroupsMasterService.DeleteByKapiGrupNo(entity.Kapi_Grup_No);
                _doorGroupsDetailService.DeleteByKapiGrupNo(entity.Kapi_Grup_No);
            }
            return RedirectToAction("Index", "DoorGroup");
        }




    }
}