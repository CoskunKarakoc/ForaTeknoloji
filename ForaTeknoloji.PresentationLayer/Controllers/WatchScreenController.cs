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
    public class WatchScreenController : Controller
    {
        private IReportService _reportService;
        private IDBUsersService _dBUsersService;
        private IAccessDatasService _accessDatasService;
        private IProgInitService _progInitService;
        DBUsers user;
        DBUsers permissionUser;
        WatchParameters WtchPrmtrs;
        public WatchScreenController(IReportService reportService, IDBUsersService dBUsersService, IAccessDatasService accessDatasService, IProgInitService progInitService)
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
            _reportService = reportService;
            _dBUsersService = dBUsersService;
            _accessDatasService = accessDatasService;
            _progInitService = progInitService;
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: WatchScreen
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Canli_Izleme == 3)
                    throw new Exception("Yetkisiz Erişim!");
            }
            return View(WtchPrmtrs);
        }

        public ActionResult AccessCount()
        {
            return Json(_reportService.WatchScreenGetCount(null, null), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WatchList()
        {
            return Json(_reportService.GetWatch(WtchPrmtrs), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ByRegistrationNumber(int KayitNo)
        {
            return Json(_reportService.LastRecordWatch(KayitNo), JsonRequestBehavior.AllowGet);
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

        public ActionResult ReturnWatchParameters()
        {
            return Json(WtchPrmtrs, JsonRequestBehavior.AllowGet);
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
                    if (permissionUser.Canli_Izleme == 2 || permissionUser.Canli_Izleme == 3)
                        throw new Exception("Değişiklik yapmaya yetkiniz yok!");
                    if (progInit.Kayit_No != 0)
                    {
                        _progInitService.UpdateProgInit(progInit);
                        _accessDatasService.AddOperatorLog(260, user.Kullanici_Adi, progInit.Kayit_No, 0, 0, 0);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(progInit);
        }
    }
}