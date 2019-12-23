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
        DBUsers dBUsers;
        public DoorStatusController(IDoorStatusService doorStatusService)
        {
            dBUsers = CurrentSession.User;
            if (dBUsers == null)
            {
                dBUsers = new DBUsers();
            }


            _doorStatusService = doorStatusService;
        }

        // GET: DoorStatus
        public ActionResult Index()
        {
            return View(_doorStatusService.ComplexDoorStatuses());
        }

    }
}