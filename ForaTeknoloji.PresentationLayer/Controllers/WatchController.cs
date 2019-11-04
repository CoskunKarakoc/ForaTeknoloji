using ForaTeknoloji.BusinessLayer.Abstract;
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
        DBUsers user;
        public WatchController(IAccessDatasService accessDatasService, IUserService userService, IReportService reportService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _accessDatasService = accessDatasService;
            _userService = userService;
            _reportService = reportService;
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
        }


        // GET: Watch
        public ActionResult Index()
        {
            var lastrecordwatch = _reportService.LastRecordWatch(null);
            var model = new WatchIndexViewModel
            {
                ComplexAccessDatas = _reportService.GetWatch(),
                LastRecordWatch = lastrecordwatch
            };
            return View(model);
        }



        public ActionResult WatchSettings()
        {
            return View();
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

        public ActionResult WatcParameters(int? Normal, int? Coklu)
        {
            return null;
        }




    }
}