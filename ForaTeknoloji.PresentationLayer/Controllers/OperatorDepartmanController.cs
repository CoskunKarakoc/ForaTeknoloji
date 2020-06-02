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
    public class OperatorDepartmanController : Controller
    {
        private IDepartmanService _departmanService;
        private IDBUsersDepartmanService _dBUsersDepartman;
        private IAltDepartmanService _altDepartmanService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IBolumService _bolumService;
        private IDBUsersBolumService _dBUsersBolumService;
        public OperatorDepartmanController(IDepartmanService departmanService, IDBUsersDepartmanService dBUsersDepartman, IAltDepartmanService altDepartmanService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IBolumService bolumService, IDBUsersBolumService dBUsersBolumService)
        {
            _departmanService = departmanService;
            _dBUsersDepartman = dBUsersDepartman;
            _altDepartmanService = altDepartmanService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            _bolumService = bolumService;
            _dBUsersBolumService = dBUsersBolumService;
        }
        // GET: OperatorDepartman
        public ActionResult Index(string KullaniciAdi)
        {
            var model = new OperatorDepartmanViewModel
            {
                KullaniciAdi = KullaniciAdi
            };

            return View(model);
        }


        public ActionResult DepartmanList(string kullaniciAdi)
        {
            List<int> userDepartmanID = new List<int>();
            foreach (var departmanID in _dBUsersDepartman.GetAllDBUsersDepartman(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userDepartmanID.Add((int)departmanID.Departman_No);
            }
            return Json(_departmanService.GetAllDepartmanlar(x => !userDepartmanID.Contains(x.Departman_No)), JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserDepartmanID(string kullaniciAdi)
        {
            List<int> userDepartmanID = new List<int>();
            foreach (var departmanID in _dBUsersDepartman.GetAllDBUsersDepartman(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userDepartmanID.Add((int)departmanID.Departman_No);
            }
            return Json(_departmanService.GetAllDepartmanlar(x => userDepartmanID.Contains(x.Departman_No)), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddDepartman(int DepartmanNo, string kullaniciAdi)
        {
            var addedDBUserDepartman = new DBUsersDepartman
            {
                Kullanici_Adi = kullaniciAdi,
                Departman_No = DepartmanNo
            };
            _dBUsersDepartman.AddDBUsersDepartman(addedDBUserDepartman);
            foreach (var altDepartman in _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == DepartmanNo))
            {
                var addedDBUserAltDepartman = new DBUsersAltDepartman
                {
                    Kullanici_Adi = kullaniciAdi,
                    Departman_No = DepartmanNo,
                    Alt_Departman_No = altDepartman.Alt_Departman_No
                };
                _dBUsersAltDepartmanService.AddDBUsersAltDepartman(addedDBUserAltDepartman);
            }
            foreach (var bolum in _bolumService.GetAllBolum(x => x.Departman_No == DepartmanNo))
            {
                var addedDBUserBolum = new DBUsersBolum
                {
                    Kullanici_Adi = kullaniciAdi,
                    Departman_No = DepartmanNo,
                    Alt_Departman_No = bolum.Alt_Departman_No,
                    Bolum_No = bolum.Bolum_No
                };
                _dBUsersBolumService.AddDBUsersBolum(addedDBUserBolum);
            }
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RemoveDepartman(int DepartmanNo, string kullaniciAdi)
        {
            var deletedDBUsersDepartman = _dBUsersDepartman.GetByQuery(x => x.Departman_No == DepartmanNo && x.Kullanici_Adi == kullaniciAdi);
            _dBUsersDepartman.DeleteDBUsersDepartman(deletedDBUsersDepartman);
            _dBUsersAltDepartmanService.DeleteAllWithUserNameAndDepartmanNo(kullaniciAdi, DepartmanNo);
            _dBUsersBolumService.DeleteAllWithUserNameAndDepartmanNo(kullaniciAdi, DepartmanNo);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }




    }
}