using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class SMSController : Controller
    {
        private ISmsSettingsService _smsSettingsService;
        private IAccessDatasService _accessDatasService;
        private IDBUsersService _dBUsersService;
        private IUserService _userService;
        private ISMSForPanelStatusService _sMSForPanelStatusService;
        private IReportService _reportService;
        public DBUsers user;
        public DBUsers permissionUser;
        public SMSController(ISmsSettingsService smsSettingsService, IAccessDatasService accessDatasService, IDBUsersService dBUsersService, IUserService userService, ISMSForPanelStatusService sMSForPanelStatusService, IReportService reportService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _smsSettingsService = smsSettingsService;
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
            _reportService = reportService;
            _userService = userService;
            _sMSForPanelStatusService = sMSForPanelStatusService;
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetDoorList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);

        }



        // GET: SMS
        public ActionResult Add()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            var model = _smsSettingsService.GetAllSMSSetting().FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(SMSSetting sMSSetting)
        {
            if (ModelState.IsValid)
            {
                if (permissionUser.SysAdmin == false)
                    throw new Exception("Yetkisiz Erişim!");

                _smsSettingsService.UpdateSMSSetting(sMSSetting);
                _accessDatasService.AddOperatorLog(221, user.Kullanici_Adi, sMSSetting.Kayit_No, 0, 0, 0);
                return RedirectToAction("Add", "SMS");
            }
            return View(sMSSetting);
        }


        public ActionResult PanelConnectionStatus()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            var smsSettings = _smsSettingsService.GetAllSMSSetting().FirstOrDefault();
            var kullanicilar = _reportService.GetPersonelLists(null, CurrentSession.User);
            var model = new PanelConnectionSMSViewModel
            {
                SMS = smsSettings,
                Kullanicilar = kullanicilar
            };


            return View(model);


        }
        public ActionResult PhoneAdd(string Phone)
        {
            var checkList = _sMSForPanelStatusService.GetByTelNo(Phone);
            if (checkList == null)
                _sMSForPanelStatusService.AddSMSForPanelStatus(new SMSForPanelStatus { Phone_Number = Phone });

            return Json("Eklendi", JsonRequestBehavior.AllowGet);
        }

        public ActionResult PhoneRemove(string Phone)
        {
            _sMSForPanelStatusService.DeleteByTelNo(Phone);
            return Json("Silindi", JsonRequestBehavior.AllowGet);
        }

        public ActionResult PhoneList()
        {
            return Json(_sMSForPanelStatusService.GetAllSMSForPanelStatus(), JsonRequestBehavior.AllowGet);
        }
    }
}