using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
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
                _bloklarService.AddBloklar(bloklar);
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

        public ActionResult Edit(Bloklar bloklar)
        {
            if (ModelState.IsValid)
            {
                _bloklarService.UpdateBloklar(bloklar);
            }
            return RedirectToAction("Index");
        }





    }
}