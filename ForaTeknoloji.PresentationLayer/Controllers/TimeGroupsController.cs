using ForaTeknoloji.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class TimeGroupsController : Controller
    {
        private ITimeGroupsService _timeGroupsService;
        private ITimeZoneIDsService _timeZoneIDsService;
        public TimeGroupsController(ITimeGroupsService timeGroupsService, ITimeZoneIDsService timeZoneIDsService)
        {
            _timeGroupsService = timeGroupsService;
            _timeZoneIDsService = timeZoneIDsService;
        }


        // GET: TimeGroups
        public ActionResult Index()
        {
           
           
            return View();
        }
    }
}