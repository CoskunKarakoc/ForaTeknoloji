using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Excp]
    public class CompanyController : Controller
    {
        private ISirketService _sirketService;
        public CompanyController(ISirketService sirketService)
        {
            _sirketService = sirketService;
        }



        // GET: Company
        public ActionResult Index()
        {
            return View(_sirketService.GetAllSirketler());
        }

        [HttpPost]
        public ActionResult Create(Sirketler Sirket)
        {
            if (ModelState.IsValid)
            {
                if (Sirket.Adi != null)
                {
                    _sirketService.AddSirket(Sirket);
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
                Sirketler sirket = _sirketService.GetById(id);
                if (sirket != null)
                {
                    _sirketService.DeleteSirket(sirket);
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