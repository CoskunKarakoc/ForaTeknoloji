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
    public class SectionController : Controller
    {

        private IBolumlerService _bolumlerService;
        public SectionController(IBolumlerService bolumlerService)
        {
            _bolumlerService = bolumlerService;
        }


        // GET: Section
        public ActionResult Index()
        {
            return View(_bolumlerService.GetAllBolumler());
        }

        [HttpPost]
        public ActionResult Create(Bolumler Bolum)
        {
            if (ModelState.IsValid)
            {
                if (Bolum.Adi != null)
                {
                    var ID = _bolumlerService.GetAllBolumler().Count;
                    if (ID == 0)
                        _bolumlerService.DeleteAll();

                    _bolumlerService.AddBolum(Bolum);
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
                Bolumler bolum = _bolumlerService.GetById(id);
                if (bolum != null)
                {
                    _bolumlerService.DeleteBolum(bolum);
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
            Bolumler bolum = _bolumlerService.GetById((int)id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bolumler bolumler)
        {
            if (ModelState.IsValid)
            {
                var bolum = _bolumlerService.GetById(bolumler.Bolum_No);
                if (bolum != null)
                {
                    _bolumlerService.UpdateBolum(bolumler);
                    return RedirectToAction("Index");
                }
            }
            return View(bolumler);
        }


    }
}