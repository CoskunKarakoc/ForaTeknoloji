using ForaTeknoloji.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class WatchController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IUserService _userService;
        public WatchController(IAccessDatasService accessDatasService, IUserService userService)
        {
            _accessDatasService = accessDatasService;
            _userService = userService;
        }


        // GET: Watch
        public ActionResult Index()
        {
            return View(_accessDatasService.GetAllAccessDatas().OrderByDescending(x => x.Tarih));
        }



        public ActionResult WatchSettings()
        {
            return View();
        }


        public ActionResult Deneme(int KayitNo)
        {
            var entity = _accessDatasService.GetByKayit_No(KayitNo);
            return Json(entity,JsonRequestBehavior.AllowGet);
        }


    }
}