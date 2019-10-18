using ForaTeknoloji.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class WatchController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IUserService _userService;
        public WatchController(IAccessDatasService accessDatasService,IUserService userService)
        {
            _accessDatasService = accessDatasService;
            _userService = userService;
        }


        // GET: Watch
        public ActionResult Index()
        {
            return View();
        }
    }
}