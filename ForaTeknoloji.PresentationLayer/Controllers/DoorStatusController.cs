using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.DataTransferObjects;
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
    public class DoorStatusController : Controller
    {
        private IDoorStatusService _doorStatusService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersKapiService _dBUsersKapiService;
        private ITaskListService _taskListService;
        DBUsers dBUsers;
        List<int> dbPanelList;
        List<int> dbDoorList;
        public DoorStatusController(IDoorStatusService doorStatusService, IReaderSettingsNewService readerSettingsNewService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersKapiService dBUsersKapiService,ITaskListService taskListService)
        {
            dBUsers = CurrentSession.User;
            if (dBUsers == null)
            {
                dBUsers = new DBUsers();
            }
            dbPanelList = new List<int>();
            dbDoorList = new List<int>();
            _readerSettingsNewService = readerSettingsNewService;
            _doorStatusService = doorStatusService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersKapiService = dBUsersKapiService;
            _taskListService = taskListService;
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserDoorNo in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi).Select(a => a.Kapi_Kayit_No))
            {
                dbDoorList.Add((int)dbUserDoorNo);
            }
        }

    
        public ActionResult DoorList()
        {
            var model = new DoorStatusListViewModel
            {
                DoorStatusList = _doorStatusService.ComplexDoorStatuses(),
                ReaderList = _readerSettingsNewService.GetAllReaderSettingsNew()
            };
            return View(model);
        }


        public ActionResult TriggerDoor(int PanelID, int DoorID)
        {
            KapiOperasyon kapiOperasyon = new KapiOperasyon();
            kapiOperasyon.Alarm = false;
            kapiOperasyon.OprKod = 2770;
            kapiOperasyon.Panel_ID = PanelID;
            kapiOperasyon.Tum_Panel = false;
            if (DoorID == 1)
                kapiOperasyon.Kapi_1 = true;
            else if (DoorID == 2)
                kapiOperasyon.Kapi_2 = true;
            else if (DoorID == 3)
                kapiOperasyon.Kapi_3 = true;
            else if (DoorID == 4)
                kapiOperasyon.Kapi_4 = true;
            else if (DoorID == 5)
                kapiOperasyon.Kapi_5 = true;
            else if (DoorID == 6)
                kapiOperasyon.Kapi_6 = true;
            else if (DoorID == 7)
                kapiOperasyon.Kapi_7 = true;
            else if (DoorID == 8)
                kapiOperasyon.Kapi_8 = true;

            TaskList taskList = new TaskList
            {
                Deneme_Sayisi = 1,
                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                Gorev_Kodu = (int)CommandConstants.CMD_SND_DOORTRIGGER,
                IntParam_1 = 1,
                StrParam_1 = DoorOperationCode.CreateDoorOperationCode(kapiOperasyon),
                IntParam_2 = PanelID,
                Kullanici_Adi = dBUsers.Kullanici_Adi,
                Panel_No = PanelID,
                Tablo_Guncelle = true,
                Tarih = DateTime.Now
            };
            _taskListService.sp_AddTaskList(taskList);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Status()
        {
            var jsonresult = Json(new { data = _doorStatusService.ComplexDoorStatuses() }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }



    }
}