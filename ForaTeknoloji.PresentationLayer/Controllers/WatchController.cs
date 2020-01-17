using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class WatchController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IUserService _userService;
        private IReportService _reportService;
        private IProgInitService _progInitService;
        private IDBUsersService _dBUsersService;
        DBUsers user;
        DBUsers permissionUser;
        WatchParameters WtchPrmtrs;
        public WatchController(IAccessDatasService accessDatasService, IUserService userService, IReportService reportService, IProgInitService progInitService, IDBUsersService dBUsersService)
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
            _dBUsersService = dBUsersService;
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: Watch
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Canli_Izleme == 3)
                    throw new Exception("Yetkisiz Erişim!");
            }
            var lastrecordwatch = _reportService.GetWatchTopOne(WtchPrmtrs); //_reportService.LastRecordWatch(null);
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


        public ActionResult SonKayit(int KayitNo)
        {
            var entity = _reportService.LastRecordWatch(KayitNo);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Count()
        {
            var count = _reportService.WatchScreenGetCount(null, null);
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