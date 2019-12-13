using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class CompanyController : Controller
    {
        private ISirketService _sirketService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public CompanyController(ISirketService sirketService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _sirketService = sirketService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: Company
        public ActionResult Index()
        {
            return View(_sirketService.GetAllSirketler());
        }

        [HttpPost]
        public ActionResult Create(Sirketler Sirket)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (Sirket.Adi != null)
                    {
                        var ID = _sirketService.GetAllSirketler().Count;
                        if (ID == 0)
                            _sirketService.DeleteAll();

                        _sirketService.AddSirket(Sirket);
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
                    Sirketler sirket = _sirketService.GetById(id);
                    if (sirket != null)
                    {
                        _sirketService.DeleteSirket(sirket);
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
            Sirketler sirketler = _sirketService.GetById((int)id);
            if (sirketler == null)
            {
                return HttpNotFound();
            }
            return View(sirketler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sirketler sirketler)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var sirket = _sirketService.GetById(sirketler.Sirket_No);
                    if (sirket != null)
                    {
                        _sirketService.UpdateSirket(sirketler);
                        return RedirectToAction("Index");
                    }
                }
                return View(sirketler);
            }
        }

    }
}