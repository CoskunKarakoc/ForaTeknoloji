using ForaTeknoloji.BusinessLayer.Abstract;
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
        DBUsers dBUsers;
        List<int> dbPanelList;
        List<int> dbDoorList;
        public DoorStatusController(IDoorStatusService doorStatusService, IReaderSettingsNewService readerSettingsNewService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersKapiService dBUsersKapiService)
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
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserDoorNo in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi).Select(a => a.Kapi_Kayit_No))
            {
                dbDoorList.Add((int)dbUserDoorNo);
            }
        }

        // GET: DoorStatus
        public ActionResult Index()
        {
            var model = new DoorStatusListViewModel
            {
                DoorStatusList = _doorStatusService.ComplexDoorStatuses(x => dbPanelList.Contains((int)x.Panel_ID)),
                ReaderList = _readerSettingsNewService.GetAllReaderSettingsNew()
            };
            return View(model);
        }




    }
}