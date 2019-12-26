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
    public class RefectoryController : Controller
    {
        private IReaderSettingsNewService _readerSettingsNewService;
        private IPanelSettingsService _panelSettingsService;
        private IReportService _reportService;
        private IDBUsersService _dBUsersService;
        private IGroupMasterService _groupMasterService;
        private IGroupsDetailNewService _groupsDetailNewService;
        private IDoorGroupsMasterService _doorGroupsMasterService;
        private IDoorGroupsDetailService _doorGroupsDetailService;
        DBUsers user;
        DBUsers permissionUser;
        public RefectoryController(IReaderSettingsNewService readerSettingsNewService, IPanelSettingsService panelSettingsService, IReportService reportService, IDBUsersService dBUsersService, IGroupMasterService groupMasterService, IGroupsDetailNewService groupsDetailNewService, IDoorGroupsMasterService doorGroupsMasterService, IDoorGroupsDetailService doorGroupsDetailService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _readerSettingsNewService = readerSettingsNewService;
            _panelSettingsService = panelSettingsService;
            _reportService = reportService;
            _dBUsersService = dBUsersService;
            _groupMasterService = groupMasterService;
            _groupsDetailNewService = groupsDetailNewService;
            _doorGroupsDetailService = doorGroupsDetailService;
            _doorGroupsMasterService = doorGroupsMasterService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: Refectory
        public ActionResult Index(RefectoryParameters parameters)
        {
            var Liste = _reportService.YemekhaneRaporu(parameters);
            var Toplam = _reportService.YemekhaneRaporuTotal(parameters);
            var Groups = _doorGroupsMasterService.GetAllDoorGroupsMaster();
            var model = new RefectoryListViewModel
            {
                Group_ID = Groups.Select(a => new SelectListItem
                {
                    Text = a.Kapi_Grup_Adi,
                    Value = a.Kapi_Grup_No.ToString()
                }),
                YemekhaneListe = Liste,
                ToplamGecis = Toplam
            };

            return View(model);
        }



    }
}