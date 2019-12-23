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
    public class UnvanController : Controller
    {

        private IUnvanService _unvanService;
        private IDBUsersService _dBUsersService;
        DBUsers dBUsers;
        public DBUsers permissionUser;
        public UnvanController(IUnvanService unvanService, IDBUsersService dBUsersService)
        {
            dBUsers = CurrentSession.User;
            if (dBUsers == null)
            {
                dBUsers = new DBUsers();
            }
            _dBUsersService = dBUsersService;
            _unvanService = unvanService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == dBUsers.Kullanici_Adi);
        }





        // GET: Unvan
        public ActionResult Index()
        {
            return View(_unvanService.GetAllUnvan());
        }



        [HttpPost]
        public ActionResult Create(Unvan Unvan)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (Unvan.Adi != null)
                    {
                        var ID = _unvanService.GetAllUnvan().Count;
                        if (ID == 0)
                            _unvanService.DeleteAll();

                        _unvanService.AddUnvan(Unvan);
                        return RedirectToAction("Index");
                    }
                    throw new Exception("Yanlış yada eksik karakter girdiniz.");
                }
                return RedirectToAction("Index");
            }


        }



        public ActionResult Delete(int id = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (id != -1)
                {
                    Unvan unvan = _unvanService.GetById(id);
                    if (unvan != null)
                    {
                        _unvanService.DeleteUnvan(unvan);
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Unvan unvan = _unvanService.GetById((int)id);
            if (unvan == null)
            {
                return HttpNotFound();
            }
            return View(unvan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Unvan Unvan)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var unvan = _unvanService.GetById(Unvan.Unvan_No);
                    if (unvan != null)
                    {
                        _unvanService.UpdateUnvan(Unvan);
                        return RedirectToAction("Index");
                    }
                }
                return View(Unvan);
            }
        }




    }
}