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
    public class DepartmentController : Controller
    {
        private IDepartmanService _departmanService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public DepartmentController(IDepartmanService departmanService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _departmanService = departmanService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }




        // GET: Department
        public ActionResult Index()
        {
            return View(_departmanService.GetAllDepartmanlar());
        }

        [HttpPost]
        public ActionResult Create(Departmanlar departmanlar)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (departmanlar.Adi != null)
                    {
                        var ID = _departmanService.GetAllDepartmanlar().Count;
                        if (ID == 0)
                            _departmanService.DeleteAll();


                        _departmanService.AddDepartman(departmanlar);
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
                    Departmanlar departman = _departmanService.GetById(id);
                    if (departman != null)
                    {
                        _departmanService.DeleteDepartmanlar(departman);
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
            Departmanlar departmanlar = _departmanService.GetById((int)id);
            if (departmanlar == null)
            {
                return HttpNotFound();
            }
            return View(departmanlar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departmanlar departmanlar)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var departman = _departmanService.GetById(departmanlar.Departman_No);
                    if (departmanlar != null)
                    {
                        _departmanService.UpdateDepartman(departmanlar);
                        return RedirectToAction("Index");
                    }
                }
                return View(departmanlar);
            }

        }





    }
}