using ForaTeknoloji.BusinessLayer.Abstract;
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
    public class BackupAccessDatasController : Controller
    {
        private IAccessDatasService _accessDatasService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public BackupAccessDatasController(IAccessDatasService accessDatasService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }

        // GET: BackupAccessDatas
        public ActionResult Index(string Status = null)
        {
            if (permissionUser.SysAdmin != true)
                throw new Exception("Yetkisiz Erişim!");

            return View(model:Status);
        }



        public ActionResult Backup()
        {
            _accessDatasService.BackupAccessDatasTable();
            _accessDatasService.AddOperatorLog(303, permissionUser.Kullanici_Adi, 0, 0, 0, 0);
            return RedirectToAction("Index", "BackupAccessDatas", new { @Status = "Kopyala İşlemi Başarı ile Gerçekleştirildi!" });
        }


        public ActionResult AccessDatasClear()
        {
            _accessDatasService.DeleteAllAccessDatas();
            _accessDatasService.AddOperatorLog(304, permissionUser.Kullanici_Adi, 0, 0, 0, 0);
            return RedirectToAction("Index", "BackupAccessDatas", new { @Status = "Geçiş Verilerini Silme İşlemi Başarı ile Gerçekleştirildi!" });
        }

    }
}