using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
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
        private IReportService _reportService;
        private IProgInitService _progInitService;
        DBUsers user;
        WatchParameters WtchPrmtrs;
        public WatchController(IAccessDatasService accessDatasService, IUserService userService, IReportService reportService, IProgInitService progInitService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            WtchPrmtrs = CurrentSession.Get<WatchParameters>("WatchParameter");
            if (WtchPrmtrs == null)
            {
                WtchPrmtrs = new WatchParameters();
            }

            _accessDatasService = accessDatasService;
            _userService = userService;
            _reportService = reportService;
            _progInitService = progInitService;
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
        }


        // GET: Watch
        public ActionResult Index()
        {
            var lastrecordwatch = _reportService.LastRecordWatch(null);
            var cmplxwatch = _reportService.GetWatch(WtchPrmtrs);
            var model = new WatchIndexViewModel
            {
                ComplexAccessDatas = cmplxwatch,
                LastRecordWatch = lastrecordwatch,
                WatchParam = WtchPrmtrs
            };
            return View(model);
        }



        public ActionResult WatchSettings()
        {
            return View(_progInitService.GetAllProgInit().LastOrDefault());
        }

        [HttpPost]
        public ActionResult WatchSettings(ProgInit progInit)
        {
            if (ModelState.IsValid)
            {
                if (progInit != null)
                {
                    _progInitService.AddProgInit(progInit);
                    return RedirectToAction("Index");
                }
            }
            return View(progInit);
        }





        public ActionResult SonKayit(int KayitNo)
        {
            var entity = _reportService.LastRecordWatch(KayitNo);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Count()
        {
            var count = _accessDatasService.GetAllAccessDatas().Count;
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult WatcParameters(WatchParameters watchParameters)
        {
            if (watchParameters != null)
            {
                CurrentSession.Set<WatchParameters>("WatchParameter", watchParameters);
                var nesne = CurrentSession.Get<WatchParameters>("WatchParameter");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }




    }
}