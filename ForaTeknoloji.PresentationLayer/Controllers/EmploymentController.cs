using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class EmploymentController : Controller
    {
        private IGorevlerService _gorevlerService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public EmploymentController(IGorevlerService gorevlerService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _gorevlerService = gorevlerService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: Employment
        public ActionResult Index()
        {
            return View(_gorevlerService.GetAllGorevler());
        }

        [HttpPost]
        public ActionResult Create(Gorevler Gorev)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (Gorev.Adi != null)
                    {
                        var ID = _gorevlerService.GetAllGorevler().Count;
                        if (ID == 0)
                            _gorevlerService.DeleteAll();

                        _gorevlerService.AddGorev(Gorev);
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
                    Gorevler gorev = _gorevlerService.GetById(id);
                    if (gorev != null)
                    {
                        _gorevlerService.DeleteGorev(gorev);
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
            Gorevler gorevler = _gorevlerService.GetById((int)id);
            if (gorevler == null)
            {
                return HttpNotFound();
            }
            return View(gorevler);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gorevler gorevler)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var gorev = _gorevlerService.GetById(gorevler.Gorev_No);
                    if (gorev != null)
                    {
                        _gorevlerService.UpdateGorev(gorevler);
                        return RedirectToAction("Index");
                    }
                }
                return View(gorevler);
            }

        }




    }
}