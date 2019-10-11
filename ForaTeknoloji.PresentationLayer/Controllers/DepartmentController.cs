using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
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
                _departmanService.AddDepartman(departmanlar);
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

        public ActionResult Edit(Departmanlar departmanlar)
        {
            if (ModelState.IsValid)
            {
                _departmanService.UpdateDepartman(departmanlar);
            }
            return RedirectToAction("Index");
        }





    }
}