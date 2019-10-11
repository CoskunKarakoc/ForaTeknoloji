using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
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
                _sirketService.AddSirket(Sirket);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Sirketler sirket = _sirketService.GetById(id);
                if (sirket!=null)
                {
                    _sirketService.DeleteSirket(sirket);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Sirketler sirketler)
        {
            if (ModelState.IsValid)
            {
                _sirketService.UpdateSirket(sirketler);
            }
            return RedirectToAction("Index");
        }


    }
}