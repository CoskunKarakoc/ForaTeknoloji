using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class VisitorController : Controller
    {
        private IVisitorsService _visitorsService;
        private IUserService _userService;
        private IGroupMasterService _groupMasterService;
        public VisitorController(IVisitorsService visitorsService, IUserService userService, IGroupMasterService groupMasterService)
        {
            _visitorsService = visitorsService;
            _userService = userService;
            _groupMasterService = groupMasterService;
        }



        // GET: Visitor
        public ActionResult Index(string Search)
        {
            if (Search != null && Search != "")
            {
                var model = _visitorsService.GetAllVisitors(x => x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.TCKimlik.Contains(Search.Trim()) || x.Telefon.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Ziyaret_Sebebi.Contains(Search.Trim()));
                return View(model);
            }
            else
            {
                var model = _visitorsService.GetAllVisitors();
                return View(model);
            }
        }


        public ActionResult Create()
        {

            var Grup = _groupMasterService.GetAllGroupsMaster();
            var Personel = _userService.GetAllUsers();
            var Ziyaretci = _userService.GetAllUsers(x => x.Kullanici_Tipi == 1);
            var model = new CreateVisitorViewModel
            {
                Grup_No = Grup.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Personeller = Personel,
                Ziyaretciler = Ziyaretci,
                ComplexPersoneller = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList()
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Visitors visitors)
        {
            if (ModelState.IsValid)
            {
                _visitorsService.AddVisitor(visitors);
                return RedirectToAction("Index");
            }

            return View(visitors);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Visitors visitors = _visitorsService.GetById((int)id);
            Users users = _userService.GetById((int)visitors.User_ID);
            if (visitors == null)
            {
                return HttpNotFound();
            }
            var model = new VisitorEditViewModel
            {
                Ziyaretci = visitors,
                Personel = users,
                Personeller = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList()
            };



            ViewBag.Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", visitors.Grup_No);
            ViewBag.Tarih = visitors.Tarih;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visitors entity)
        {
            if (ModelState.IsValid)
            {
                var visitor = _visitorsService.GetById((int)entity.ID);
                if (visitor != null)
                {
                    _visitorsService.UpdateVisitor(entity);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }


        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Visitors visitor = _visitorsService.GetById(id);
                if (visitor != null)
                {
                    _visitorsService.DeleteVisitor(visitor);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Personeller(string Search)
        {
            List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser> liste = new List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser>();

            if (Search != null && Search != "")
            {
                liste = _userService.GetAllUsersWithOuther(x => x.Adi.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())).OrderBy(x => x.Kayit_No).ToList();
            }
            else
            {
                liste = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            }

            return Json(liste, JsonRequestBehavior.AllowGet);

        }


    }
}