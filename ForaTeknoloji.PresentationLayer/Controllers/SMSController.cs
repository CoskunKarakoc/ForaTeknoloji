using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class SMSController : Controller
    {
        private ISmsSettingsService _smsSettingsService;
        private IAccessDatasService _accessDatasService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public SMSController(ISmsSettingsService smsSettingsService, IAccessDatasService accessDatasService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _smsSettingsService = smsSettingsService;
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
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

    }
}