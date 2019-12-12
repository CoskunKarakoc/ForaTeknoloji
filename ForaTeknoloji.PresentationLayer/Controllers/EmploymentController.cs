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
    public class EmploymentController : Controller
    {
        private IGorevlerService _gorevlerService;
        public EmploymentController(IGorevlerService gorevlerService)
        {
            _gorevlerService = gorevlerService;
        }


        // GET: Employment
        public ActionResult Index()
        {
            return View(_gorevlerService.GetAllGorevler());
        }

        [HttpPost]
        public ActionResult Create(Gorevler Gorev)
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

        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Gorevler gorev = _gorevlerService.GetById(id);
                if (gorev != null)
                {
                    _gorevlerService.DeleteGorev(gorev);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
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