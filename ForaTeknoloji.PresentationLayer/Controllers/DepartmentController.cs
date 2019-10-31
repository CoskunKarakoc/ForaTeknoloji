using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class DepartmentController : Controller
    {
        private IDepartmanService _departmanService;
        public DepartmentController(IDepartmanService departmanService)
        {
            _departmanService = departmanService;
        }




        // GET: Department
        public ActionResult Index()
        {
            return View(_departmanService.GetAllDepartmanlar());
        }

        [HttpPost]
        public ActionResult Create(Departmanlar departmanlar)
        {
            if (ModelState.IsValid)
            {
                if (departmanlar.Adi != null)
                {
                    _departmanService.AddDepartman(departmanlar);
                    return RedirectToAction("Index");
                }
                throw new Exception("Yanlış yada eksik karakter girdiniz.");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = -1)
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