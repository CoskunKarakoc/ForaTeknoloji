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
    public class AltDepartmanController : Controller
    {
        private IDBUsersService _dBUsersService;
        private IAltDepartmanService _altDepartmanService;
        private IDepartmanService _departmanService;
        public DBUsers user;
        public DBUsers permissionUser;
        public AltDepartmanController(IAltDepartmanService altDepartmanService, IDBUsersService dBUsersService, IDepartmanService departmanService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _altDepartmanService = altDepartmanService;
            _dBUsersService = dBUsersService;
            _departmanService = departmanService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: AltDepartman
        public ActionResult Index()
        {
            var model = new AltDepartmanListViewModel
            {
                Departman_No = _departmanService.GetAllDepartmanlar().Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                AltDepartmanListesi = _altDepartmanService.ComplexAltDepartmen()
            };



            return View(model);
        }


        [HttpPost]
        public ActionResult Create(AltDepartman AltDepartman)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (AltDepartman.Adi != null && AltDepartman.Departman_No != null)
                    {
                        var ID = _altDepartmanService.GetAllAltDepartman().Count;
                        if (ID == 0)
                            _altDepartmanService.DeleteAll();

                        _altDepartmanService.AddAltDepartman(AltDepartman);
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
                    AltDepartman altDepartman = _altDepartmanService.GetById(id);
                    if (altDepartman != null)
                    {
                        _altDepartmanService.DeleteAltDepartman(altDepartman);
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            AltDepartman altDepartman = _altDepartmanService.GetById((int)id);
            ViewBag.Departman_No = new SelectList(_departmanService.GetAllDepartmanlar(), "Departman_No", "Adi", altDepartman.Departman_No);
            if (altDepartman == null)
            {
                return HttpNotFound();
            }
            return View(altDepartman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AltDepartman altDepartman)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var altdepartman = _altDepartmanService.GetById(altDepartman.Alt_Departman_No);
                    if (altdepartman != null)
                    {
                        _altDepartmanService.UpdateAltDepartman(altDepartman);
                        return RedirectToAction("Index");
                    }
                }
                return View(altDepartman);
            }
        }








    }
}