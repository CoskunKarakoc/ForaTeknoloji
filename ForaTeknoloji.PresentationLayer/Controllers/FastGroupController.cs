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
    public class FastGroupController : Controller
    {

        private IGroupMasterService _groupMasterService;
        private IUnvanService _unvanService;
        private IUserService _userService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public FastGroupController(IGroupMasterService groupMasterService, IUnvanService unvanService, IUserService userService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _unvanService = unvanService;
            _groupMasterService = groupMasterService;
            _userService = userService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: FastGroup
        public ActionResult Index(int? Status=0)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 3)
                    throw new Exception("Yetkisiz Erişim!");
            }
            var Group = _groupMasterService.GetAllGroupsMaster();
            var Unvan = _unvanService.GetAllUnvan();
            var model = new FastGroupListViewModel
            {
                Grup_No = Group.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Unvan_No = Unvan.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Durum = Status
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FastGroupParameters parameters)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == 2)
                    throw new Exception("Grup düzenleme yetkiniz yok!");
            }
            if (ModelState.IsValid)
            {
                var result = _userService.FastGroupAdd(parameters);
                if (result)
                    return RedirectToAction("Index", "FastGroup", new { @Status = result == true ? 1 : 0 });
                else
                    throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            return View(parameters);
        }





    }
}