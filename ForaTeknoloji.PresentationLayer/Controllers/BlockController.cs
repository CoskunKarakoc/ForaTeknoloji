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
    public class BlockController : Controller
    {
        private IBloklarService _bloklarService;
        public BlockController(IBloklarService bloklarService)
        {
            _bloklarService = bloklarService;
        }



        // GET: Block
        public ActionResult Index()
        {
            return View(_bloklarService.GetAllBloklar());
        }


        [HttpPost]
        public ActionResult Create(Bloklar bloklar)
        {
            if (ModelState.IsValid)
            {
                if (bloklar.Adi!=null)
                {
                    _bloklarService.AddBloklar(bloklar);
                    return RedirectToAction("Index");
                }
                throw new Exception("Yanlış yada eksik karakter girdiniz");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Bloklar bloklar = _bloklarService.GetById(id);
                if (bloklar != null)
                {
                    _bloklarService.DeleteBloklar(bloklar);
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
            Bloklar bloklar = _bloklarService.GetById((int)id);
            if (bloklar == null)
            {
                return HttpNotFound();
            }
            return View(bloklar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bloklar bloklar)
        {
            if (ModelState.IsValid)
            {
                var blok = _bloklarService.GetById(bloklar.Blok_No);
                if (blok != null)
                {
                    _bloklarService.UpdateBloklar(bloklar);
                    return RedirectToAction("Index");
                }
            }
            return View(bloklar);
        }





    }
}