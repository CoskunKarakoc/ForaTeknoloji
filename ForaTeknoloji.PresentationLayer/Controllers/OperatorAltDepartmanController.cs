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
    public class OperatorAltDepartmanController : Controller
    {
        private IDepartmanService _departmanService;
        private IDBUsersDepartmanService _dBUsersDepartman;
        private IAltDepartmanService _altDepartmanService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IBolumService _bolumService;
        private IDBUsersBolumService _dBUsersBolumService;
        public OperatorAltDepartmanController(IDepartmanService departmanService, IDBUsersDepartmanService dBUsersDepartman, IAltDepartmanService altDepartmanService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IBolumService bolumService, IDBUsersBolumService dBUsersBolumService)
        {
            _departmanService = departmanService;
            _dBUsersDepartman = dBUsersDepartman;
            _altDepartmanService = altDepartmanService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            _bolumService = bolumService;
            _dBUsersBolumService = dBUsersBolumService;
        }

        // GET: OperatorAltDepartman
        public ActionResult Index(string KullaniciAdi)
        {
            var model = new OperatorAltDepartmanViewModel
            {
                KullaniciAdi = KullaniciAdi
            };

            return View(model);
        }


        public ActionResult AltDepartmanList(string kullaniciAdi)
        {
            List<int> userAltDepartmanID = new List<int>();
            foreach (var altdepartmanID in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userAltDepartmanID.Add((int)altdepartmanID.Alt_Departman_No);
            }
            return Json(_altDepartmanService.GetAllAltDepartman(x => !userAltDepartmanID.Contains(x.Alt_Departman_No)), JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserAltDepartmanID(string kullaniciAdi)
        {
            List<int> userAltDepartmanID = new List<int>();
            foreach (var altdepartmanID in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userAltDepartmanID.Add((int)altdepartmanID.Alt_Departman_No);
            }
            return Json(_altDepartmanService.GetAllAltDepartman(x => userAltDepartmanID.Contains(x.Alt_Departman_No)), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddAltDepartman(int AltDepartmanNo, string kullaniciAdi)
        {

            var departmanNo = _altDepartmanService.GetAllAltDepartman().FirstOrDefault(x => x.Alt_Departman_No == AltDepartmanNo).Departman_No;

            var addedDBUserAltDepartman = new DBUsersAltDepartman
            {
                Kullanici_Adi = kullaniciAdi,
                Alt_Departman_No = AltDepartmanNo,
                Departman_No = departmanNo
            };
            _dBUsersAltDepartmanService.AddDBUsersAltDepartman(addedDBUserAltDepartman);
            foreach (var bolum in _bolumService.GetAllBolum(x => x.Departman_No == departmanNo && x.Alt_Departman_No == AltDepartmanNo))
            {
                var checkBolum = _dBUsersBolumService.GetAllDBUsersBolum().FirstOrDefault(x => x.Departman_No == departmanNo && x.Alt_Departman_No == AltDepartmanNo && x.Bolum_No == bolum.Bolum_No && x.Kullanici_Adi == kullaniciAdi);
                if (checkBolum == null)
                {
                    var addedDBUsersBolum = new DBUsersBolum
                    {
                        Departman_No = departmanNo,
                        Alt_Departman_No = AltDepartmanNo,
                        Bolum_No = bolum.Bolum_No,
                        Kullanici_Adi = kullaniciAdi
                    };
                    _dBUsersBolumService.AddDBUsersBolum(addedDBUsersBolum);
                }
            }
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RemoveAltDepartman(int AltDepartmanNo, string kullaniciAdi)
        {
            var departmanNo = _altDepartmanService.GetAllAltDepartman().FirstOrDefault(x => x.Alt_Departman_No == AltDepartmanNo).Departman_No;
            var deletedDBUsersAltDepartman = _dBUsersAltDepartmanService.GetByQuery(x => x.Alt_Departman_No == AltDepartmanNo && x.Kullanici_Adi == kullaniciAdi);
            _dBUsersAltDepartmanService.DeleteDBUsersAltDepartman(deletedDBUsersAltDepartman);
            foreach (var bolum in _dBUsersBolumService.GetAllDBUsersBolum(x => x.Kullanici_Adi == kullaniciAdi && x.Departman_No == departmanNo && x.Alt_Departman_No == AltDepartmanNo))
            {
                _dBUsersBolumService.DeleteDBUsersBolum(bolum);
            }
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

    }
}