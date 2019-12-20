using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class DoorGroupController : Controller
    {
        private IDoorGroupsDetailService _doorGroupsDetailService;
        private IDoorGroupsMasterService _doorGroupsMasterService;
        private IGroupMasterService _groupMasterService;
        private IGroupsDetailNewService _groupsDetailNewService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IReportService _reportService;
        private IPanelSettingsService _panelSettingsService;
        DBUsers dBUsers;
        public DoorGroupController(IDoorGroupsDetailService doorGroupsDetailService, IDoorGroupsMasterService doorGroupsMasterService, IGroupsDetailNewService groupsDetailNewService, IGroupMasterService groupMasterService, IReaderSettingsNewService readerSettingsNewService, IReportService reportService, IPanelSettingsService panelSettingsService)
        {
            dBUsers = CurrentSession.User;
            if (dBUsers == null)
            {
                dBUsers = new DBUsers();
            }

            _doorGroupsDetailService = doorGroupsDetailService;
            _doorGroupsMasterService = doorGroupsMasterService;
            _groupsDetailNewService = groupsDetailNewService;
            _groupMasterService = groupMasterService;
            _readerSettingsNewService = readerSettingsNewService;
            _reportService = reportService;
            _panelSettingsService = panelSettingsService;
        }


        // GET: DoorGroup
        public ActionResult Index()
        {
            return View();
        }
    }
}