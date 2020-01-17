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
        DBUsers dBUsers;
        DBUsers permissionUser;
        public SpotMonitorController(IReportService reportService, IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService, IAccessDatasService accessDatasService, IDBUsersService dBUsersService)
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
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi);
        }






        // GET: SpotMonitor
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            var Panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            var Kapi = _readerSettingsNewService.GetAllReaderSettingsNew();
            var MonitorList = _reportService.MonitorWatch(CurrentSession.Get<SpotMonitorSettings>("SpotWatchParameter"));
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
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

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
            var condition = CurrentSession.Get<SpotMonitorSettings>("SpotWatchParameter");
            if (condition != null)
            {
                var count = _reportService.WatchScreenGetCount(condition.Panel_ID, condition.Kapi_ID);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult KapiListesi(int? PanelID)
        {
            if (PanelID != null && PanelID != 0)
            {
                var list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID);
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







    }
}