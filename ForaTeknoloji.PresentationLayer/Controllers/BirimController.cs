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
    public class BirimController : Controller
    {
        private IDBUsersService _dBUsersService;
        private IBolumService _bolumService;
        private IDepartmanService _departmanService;
        private IAltDepartmanService _altDepartmanService;
        private IBirimService _birimService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        public DBUsers user = CurrentSession.User;
        public DBUsers permissionUser;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        public BirimController(IDBUsersService dBUsersService, IBolumService bolumService, IAltDepartmanService altDepartmanService, IDepartmanService departmanService, IBirimService birimService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService)
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
            _birimService = birimService;
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


        // GET: Birim
        public ActionResult Index()
        {
            var model = new BirimListViewModel
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
                Bolum_No = _bolumService.GetAllBolum().Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                BirimListesi = _birimService.ComplexBirim()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Birim Birim)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (Birim.Adi != null && Birim.Alt_Departman_No != null && Birim.Departman_No != null && Birim.Bolum_No != null)
                    {
                        var ID = _birimService.GetAllBirim().Count;
                        if (ID == 0)
                            _birimService.DeleteAll();

                        _birimService.AddBirim(Birim);
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
                    Birim birim = _birimService.GetById(id);
                    if (birim != null)
                    {
                        _birimService.DeleteBirim(birim);
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
            Birim birim = _birimService.GetById((int)id);
            ViewBag.Departman_No = new SelectList(_departmanService.GetAllDepartmanlar(), "Departman_No", "Adi", birim.Departman_No);
            ViewBag.Alt_Departman_No = new SelectList(_altDepartmanService.GetAllAltDepartman(), "Alt_Departman_No", "Adi", birim.Alt_Departman_No);
            ViewBag.Bolum_No = new SelectList(_bolumService.GetAllBolum(x => x.Departman_No == birim.Departman_No && x.Alt_Departman_No == birim.Alt_Departman_No), "Bolum_No", "Adi", birim.Bolum_No);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Birim Birim)
        {
            if (permissionUser.SysAdmin == false)
            {
                throw new Exception("Yetkisiz Erişim!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var birim = _birimService.GetById(Birim.Birim_No);
                    if (birim != null)
                    {
                        _birimService.UpdateBirim(Birim);
                        return RedirectToAction("Index");
                    }
                }
                return View(Birim);
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

        public ActionResult BolumListesi(int? AltDepartman)
        {
            if (AltDepartman != null && AltDepartman != 0)
            {

                var list = _bolumService.GetAllBolum(x => x.Alt_Departman_No == AltDepartman);
                var selectBolum = list.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                });
                return Json(selectBolum, JsonRequestBehavior.AllowGet);
            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }




    }
}