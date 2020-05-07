using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
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
    public class EmailController : Controller
    {
        private IEmailSettingsService _emailSettingsService;
        private IAccessDatasService _accessDatasService;
        private IDBUsersService _dBUsersService;
        public DBUsers user = CurrentSession.User;
        public DBUsers permissionUser;
        public EmailController(IEmailSettingsService emailSettingsService, IAccessDatasService accessDatasService, IDBUsersService dBUsersService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _emailSettingsService = emailSettingsService;
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: Email
        public ActionResult Add()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            var model = _emailSettingsService.GetAllEMailSetting().FirstOrDefault();

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(EMailSetting eMailSetting)
        {
            if (ModelState.IsValid)
            {
                if (permissionUser.SysAdmin == false)
                    throw new Exception("Yetkisiz Erişim!");

                var updatedemail = _emailSettingsService.UpdateEMailSetting(eMailSetting);
                ConfigHelper.SetEmailConfig(updatedemail);
                _accessDatasService.AddOperatorLog(220, user.Kullanici_Adi, eMailSetting.Kayit_No, 0, 0, 0);
                return RedirectToAction("Add", "Email");
            }
            return View(eMailSetting);
        }
    }
}