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
    public class BlockController : Controller
    {
        private IBloklarService _bloklarService;
        private IDBUsersService _dBUsersService;
        public DBUsers user;
        public DBUsers permissionUser;
        public BlockController(IBloklarService bloklarService, IDBUsersService dBUsersService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _bloklarService = bloklarService;
            _dBUsersService = dBUsersService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }



        // GET: Block
        public ActionResult Index()
        {
            return View(_bloklarService.GetAllBloklar());
        }


        [HttpPost]
        public ActionResult Create(Bloklar bloklar)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (bloklar.Adi != null)
                    {
                        var ID = _bloklarService.GetAllBloklar().Count;
                        if (ID == 0)
                            _bloklarService.DeleteAll();

                        _bloklarService.AddBloklar(bloklar);
                        return RedirectToAction("Index");
                    }
                    throw new Exception("Yanlış yada eksik karakter girdiniz");
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
                    Bloklar bloklar = _bloklarService.GetById(id);
                    if (bloklar != null)
                    {
                        _bloklarService.DeleteBloklar(bloklar);
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
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
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
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
}