using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
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
    [Auth]
    [Excp]
    public class WatchScreenController : Controller
    {
        private IReportService _reportService;
        private IDBUsersService _dBUsersService;
        private IAccessDatasService _accessDatasService;
        private IProgInitService _progInitService;
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        DBUsers user = CurrentSession.User;
        DBUsers permissionUser;
        WatchParameters WtchPrmtrs;
        List<int> dbPanelList;


        public WatchScreenController(IReportService reportService, IDBUsersService dBUsersService, IAccessDatasService accessDatasService, IProgInitService progInitService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            WtchPrmtrs = CurrentSession.Get<WatchParameters>("WatchParameter");
            if (WtchPrmtrs == null)
            {
                WtchPrmtrs = new WatchParameters();
            }
            dbPanelList = new List<int>();
            _reportService = reportService;
            _dBUsersService = dBUsersService;
            _accessDatasService = accessDatasService;
            _progInitService = progInitService;
            _panelSettingsService = panelSettingsService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetDoorList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
            _reportService.GetPanelAndDoorListForSpotMonitor(user == null ? new DBUsers { } : user);
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: WatchScreen
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Canli_Izleme == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz Erişim!");
            }
            return View(WtchPrmtrs);
        }

        public ActionResult AccessCount()
        {
            return Json(_reportService.WatchScreenGetCount(null, null), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WatchList()
        {
            return Json(_reportService.GetWatch(WtchPrmtrs, CurrentSession.User), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ByRegistrationNumber(int KayitNo)
        {
            return Json(_reportService.LastRecordWatch(KayitNo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult WatcParameters(WatchParameters watchParameters)
        {
            if (watchParameters != null)
            {
                CurrentSession.Set<WatchParameters>("WatchParameter", watchParameters);
                var nesne = CurrentSession.Get<WatchParameters>("WatchParameter");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult ReturnWatchParameters()
        {
            return Json(WtchPrmtrs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WatchSettings()
        {
            return View(_progInitService.GetAllProgInit().LastOrDefault());
        }

        [HttpPost]
        public ActionResult WatchSettings(ProgInit progInit)
        {
            if (ModelState.IsValid)
            {
                if (progInit != null)
                {
                    if (permissionUser.Canli_Izleme == (int)SecurityCode.Sadece_Izleme || permissionUser.Canli_Izleme == (int)SecurityCode.Yetkisiz)
                        throw new Exception("Değişiklik yapmaya yetkiniz yok!");
                    if (progInit.Kayit_No != 0)
                    {
                        _progInitService.UpdateProgInit(progInit);
                        _accessDatasService.AddOperatorLog(260, user.Kullanici_Adi, progInit.Kayit_No, 0, 0, 0);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(progInit);
        }




        /*Sadece Listenin Olduğu Ve Tüm Kayıtların Geldiği Canlı İzleme*/
        public ActionResult WatchOuther()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Canli_Izleme == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz Erişim!");
            }
            return View();
        }

        public ActionResult WatchListOther()
        {
            return Json(_reportService.GetWatchOuther(CurrentSession.User), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WatchOutherFilterDoor()
        {
            var Paneller = _panelSettingsService.GetAllPanelSettings(x => dbPanelList.Contains((int)x.Panel_ID) && x.Seri_No != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);

            var model = new WatchOtherFilterViewMode
            {
                Panel_ID = Paneller.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult WatchOutherFilterDoor(int? Panel_ID, bool Aktif, List<int> ReaderList)
        {

            return View();
        }


    }
}