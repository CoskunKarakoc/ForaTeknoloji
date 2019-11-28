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
    public class SecuritySettingsController : Controller
    {

        private IDBUsersService _dBUsersService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBRolesService _dBRolesService;
        private IPanelSettingsService _panelSettingsService;
        private ISirketService _sirketService;
        public SecuritySettingsController(IDBUsersService dBUsersService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService, IDBRolesService dBRolesService, IPanelSettingsService panelSettingsService, ISirketService sirketService)
        {
            _dBUsersService = dBUsersService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBRolesService = dBRolesService;
            _panelSettingsService = panelSettingsService;
            _sirketService = sirketService;
        }


        // GET: SecuritySettings
        public ActionResult Index()
        {
            var model = new SecuritySettingsListViewModel
            {
                Kullanıcılar = _dBUsersService.GetAllDBUsers()
            };
            return View(model);
        }


        public ActionResult Edit(string Kullanici_Adi)
        {

            var kullanici = _dBUsersService.GetById(Kullanici_Adi);
            var model = new EditSecurityListViewModel
            {
                Kullanicilar = kullanici
            };
            ViewBag.Kullanici_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Kullanici_Islemleri);
            ViewBag.Grup_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Grup_Islemleri);
            ViewBag.Programli_Kapi_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Programli_Kapi_Islemleri);
            ViewBag.Gecis_Verileri_Rapor_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Gecis_Verileri_Rapor_Islemleri);
            ViewBag.Ziyaretci_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Ziyaretci_Islemleri);
            ViewBag.Canli_Izleme = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Canli_Izleme);
            ViewBag.Alarm_Islemleri = new SelectList(_dBRolesService.GetAllDBRoles(), "Yetki_Tipi", "Yetki_Adi", kullanici.Alarm_Islemleri);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DBUsers dBUsers)
        {
            if (ModelState.IsValid)
            {
                if (dBUsers != null)
                {
                    _dBUsersService.UpdateDBUsers(dBUsers);
                }
            }
            return RedirectToAction("Index");
        }



        public ActionResult Create()
        {
            var model = new SecurityCreateViewModel
            {
                Roller = _dBRolesService.GetAllDBRoles().Select(a => new SelectListItem
                {
                    Text = a.Yetki_Adi,
                    Value = a.Yetki_Tipi.ToString()
                }),
                Sirketler = _sirketService.GetAllSirketler(),
                Paneller = _panelSettingsService.GetAllPanelSettings(x => x.Seri_No != 0 && x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0)

            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(DBUsers dBUsers = null, List<int> Sirketler = null, List<int> Paneller = null)
        {
            DBUsers addedUser = new DBUsers();
            if (ModelState.IsValid)
            {
                if (dBUsers != null)
                {
                    var Kullanici = _dBUsersService.GetById(dBUsers.Kullanici_Adi);
                    var Sifre = _dBUsersService.GetBySifre(dBUsers.Sifre);
                    if (Kullanici != null || Sifre != null)
                    {
                        throw new Exception("Aynı kullanıcı adı veya şifre ile kayıt yapılamaz!");
                    }
                    addedUser = _dBUsersService.AddDBUsers(dBUsers);
                }
                if (Sirketler != null)
                {
                    foreach (var item in Sirketler)
                    {
                        _dBUsersSirketService.AddDBUsersSirket(new DBUsersSirket { Kullanici_Adi = addedUser.Kullanici_Adi, Sirket_No = item });
                    }
                }
                if (Paneller != null)
                {
                    foreach (var item in Paneller)
                    {
                        _dBUsersPanelsService.AddDBUsersPanels(new DBUsersPanels { Kullanici_Adi = addedUser.Kullanici_Adi, Panel_No = item });
                    }
                }
                return RedirectToAction("Index");
            }
            return View(dBUsers);
        }


        public ActionResult Delete(string kullaniciAdi)
        {
            if (kullaniciAdi != null)
            {
                DBUsers user = _dBUsersService.GetById(kullaniciAdi);
                if (user != null)
                {
                    _dBUsersService.DeleteDBUsers(user);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}