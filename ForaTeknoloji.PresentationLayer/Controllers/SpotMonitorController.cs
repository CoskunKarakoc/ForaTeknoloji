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
    [Auth]
    [Excp]
    public class SpotMonitorController : Controller
    {
        private IReportService _reportService;
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IAccessDatasService _accessDatasService;
        private IDBUsersService _dBUsersService;
        private IDBUsersKapiService _dBUsersKapiService;
        DBUsers dBUsers;
        DBUsers permissionUser;
        public SpotMonitorController(IReportService reportService, IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService, IAccessDatasService accessDatasService, IDBUsersService dBUsersService, IDBUsersKapiService dBUsersKapiService)
        {
            dBUsers = CurrentSession.User;
            if (dBUsers == null)
            {
                dBUsers = new DBUsers();
            }
            _reportService = reportService;
            _panelSettingsService = panelSettingsService;
            _readerSettingsNewService = readerSettingsNewService;
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
            _dBUsersKapiService = dBUsersKapiService;
            _reportService.GetPanelAndDoorListForSpotMonitor(dBUsers == null ? new DBUsers { } : dBUsers);
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi);
        }






        // GET: SpotMonitor
        public ActionResult Index()
        {
            var Panel = SpotMonitorPanelListesi();//_panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            var Kapi = _readerSettingsNewService.GetAllReaderSettingsNew();
            var MonitorList = _reportService.MonitorWatch(null /*CurrentSession.Get<SpotMonitorSettings>("SpotWatchParameter")*/);
            var model = new MonitorWatchViewModel
            {
                Panel_ID = Panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                MonitorListesi = MonitorList,
                Kapi_ID = Kapi.Select(a => new SelectListItem
                {
                    Text = a.WKapi_Adi,
                    Value = a.WKapi_ID.ToString()
                })
            };

            return View(model);
        }


        public ActionResult WatchSettings(SpotMonitorSettings parameters)
        {
            if (parameters.Panel_ID != null && parameters.Kapi_ID != null)
            {
                CurrentSession.Set<SpotMonitorSettings>("SpotWatchParameter", parameters);
                var nesne = CurrentSession.Get<SpotMonitorSettings>("SpotWatchParameter");
                return RedirectToAction("Index");
            }
            else
            {
                CurrentSession.Set<SpotMonitorSettings>("SpotWatchParameter", new SpotMonitorSettings());
                var nesne = CurrentSession.Get<SpotMonitorSettings>("SpotWatchParameter");
                return RedirectToAction("Index");
            }
        }


        public ActionResult Count()
        {
            //var condition = CurrentSession.Get<SpotMonitorSettings>("SpotWatchParameter");
            //if (condition != null)
            //{
            var count = _reportService.WatchScreenGetCount(null, null/*condition.Panel_ID, condition.Kapi_ID*/);
            return Json(count, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(0, JsonRequestBehavior.AllowGet);
            //}

        }


        public ActionResult KapiListesi(int? PanelID)
        {
            if (PanelID != null && PanelID != 0)
            {
                var list = SpotMonitorDoorList(PanelID);// _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID);
                var selectDoor = list.Select(a => new SelectListItem
                {
                    Text = a.WKapi_Adi,
                    Value = a.WKapi_ID.ToString()

                });
                return Json(selectDoor, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Kapı Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }



        public List<PanelSettings> SpotMonitorPanelListesi()
        {
            List<PanelSettings> KullaniciPaneli = new List<PanelSettings>();
            bool door = false;
            foreach (var item in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == permissionUser.Kullanici_Adi))
            {
                door = false;
                if (item.Kapi_1 == true)
                    door = true;
                if (item.Kapi_2 == true)
                    door = true;
                if (item.Kapi_3 == true)
                    door = true;
                if (item.Kapi_4 == true)
                    door = true;
                if (item.Kapi_5 == true)
                    door = true;
                if (item.Kapi_6 == true)
                    door = true;
                if (item.Kapi_7 == true)
                    door = true;
                if (item.Kapi_8 == true)
                    door = true;

                if (door == true)
                {
                    KullaniciPaneli.Add(_panelSettingsService.GetAllPanelSettings().FirstOrDefault(x => x.Panel_ID == item.Panel_No));
                }
            }

            return KullaniciPaneli;
        }

        public List<ReaderSettingsNew> SpotMonitorDoorList(int? Panel_ID)
        {
            List<ReaderSettingsNew> KullaniciKapi = new List<ReaderSettingsNew>();
            bool resul = false;
            var item = _dBUsersKapiService.GetAllDBUsersKapi().FirstOrDefault(x => x.Kullanici_Adi == permissionUser.Kullanici_Adi && x.Panel_No == Panel_ID);
            if (item.Kapi_1 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(1, (int)Panel_ID));
            }
            if (item.Kapi_2 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(2, (int)Panel_ID));
            }
            if (item.Kapi_3 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(3, (int)Panel_ID));
            }
            if (item.Kapi_4 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(4, (int)Panel_ID));
            }
            if (item.Kapi_5 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(5, (int)Panel_ID));
            }
            if (item.Kapi_6 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(6, (int)Panel_ID));
            }
            if (item.Kapi_7 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(7, (int)Panel_ID));
            }
            if (item.Kapi_8 == true)
            {
                KullaniciKapi.Add(_readerSettingsNewService.GetByKapiANDPanel(8, (int)Panel_ID));
            }
            return KullaniciKapi;
        }

    }
}