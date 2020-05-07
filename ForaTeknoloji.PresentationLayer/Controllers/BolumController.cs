using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class BolumController : Controller
    {
        private IDBUsersService _dBUsersService;
        private IBolumService _bolumService;
        private IDepartmanService _departmanService;
        private IAltDepartmanService _altDepartmanService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        public DBUsers user = CurrentSession.User;
        public DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        public BolumController(IDBUsersService dBUsersService, IBolumService bolumService, IAltDepartmanService altDepartmanService, IDepartmanService departmanService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _bolumService = bolumService;
            _dBUsersService = dBUsersService;
            _altDepartmanService = altDepartmanService;
            _departmanService = departmanService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbSirketList = new List<int>();
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanList.Add((int)dbUserDepartmanNo);
            }
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserSirketNo in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Sirket_No))
            {
                dbSirketList.Add((int)dbUserSirketNo);
            }
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }


        // GET: Bolum
        public ActionResult Index()
        {
            var model = new BolumListViewModel
            {
                Alt_Departman_No = _altDepartmanService.GetAllAltDepartman().Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Departman_No = _departmanService.GetAllDepartmanlar().Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                BolumListesi = _bolumService.ComplexBolums()
            };



            return View(model);
        }


        [HttpPost]
        public ActionResult Create(Bolum Bolum)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (Bolum.Adi != null && Bolum.Alt_Departman_No != null && Bolum.Departman_No != null)
                    {
                        var ID = _bolumService.GetAllBolum().Count;
                        if (ID == 0)
                            _bolumService.DeleteAll();

                        _bolumService.AddBolum(Bolum);
                        return RedirectToAction("Index");
                    }
                    throw new Exception("Yanlış yada eksik karakter girdiniz.");
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
                    Bolum bolum = _bolumService.GetById(id);
                    if (bolum != null)
                    {
                        _bolumService.DeleteBolum(bolum);
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Bolum bolum = _bolumService.GetById((int)id);
            ViewBag.Departman_No = new SelectList(_departmanService.GetAllDepartmanlar(), "Departman_No", "Adi", bolum.Departman_No);
            ViewBag.Alt_Departman_No = new SelectList(_altDepartmanService.GetAllAltDepartman(x => x.Departman_No == bolum.Departman_No), "Alt_Departman_No", "Adi", bolum.Alt_Departman_No);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bolum Bolum)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var bolum = _bolumService.GetById(Bolum.Bolum_No);
                    if (bolum != null)
                    {
                        _bolumService.UpdateBolum(bolum);
                        return RedirectToAction("Index");
                    }
                }
                return View(Bolum);
            }
        }


        public ActionResult AltDepartmanListesi(int? Departman)
        {
            if (Departman != 0 && Departman != null)
            {
                var list = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == Departman);
                var selectAltDepartman = list.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                });
                return Json(selectAltDepartman, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }





    }
}