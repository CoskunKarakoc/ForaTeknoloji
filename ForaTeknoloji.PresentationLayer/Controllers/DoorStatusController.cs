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
        DBUsers dBUsers;
        public DoorStatusController(IDoorStatusService doorStatusService, IReaderSettingsNewService readerSettingsNewService)
        {
            dBUsers = CurrentSession.User;
            if (dBUsers == null)
            {
                dBUsers = new DBUsers();
            }

            _readerSettingsNewService = readerSettingsNewService;
            _doorStatusService = doorStatusService;
        }

        // GET: DoorStatus
        public ActionResult Index()
        {
            var model = new DoorStatusListViewModel
            {
                DoorStatusList = _doorStatusService.ComplexDoorStatuses(),
                ReaderList = _readerSettingsNewService.GetAllReaderSettingsNew()
            };

            return View(model);
        }

    }
}