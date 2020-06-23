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



        public ActionResult Monitoring()
        {
            return View();
        }


    }
}