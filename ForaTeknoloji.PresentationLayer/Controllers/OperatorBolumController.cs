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
    public class OperatorBolumController : Controller
    {
        private IDepartmanService _departmanService;
        private IDBUsersDepartmanService _dBUsersDepartman;
        private IAltDepartmanService _altDepartmanService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IBolumService _bolumService;
        private IDBUsersBolumService _dBUsersBolumService;
        public OperatorBolumController(IDepartmanService departmanService, IDBUsersDepartmanService dBUsersDepartman, IAltDepartmanService altDepartmanService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IBolumService bolumService, IDBUsersBolumService dBUsersBolumService)
        {
            _departmanService = departmanService;
            _dBUsersDepartman = dBUsersDepartman;
            _altDepartmanService = altDepartmanService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            _bolumService = bolumService;
            _dBUsersBolumService = dBUsersBolumService;
        }

        // GET: OperatorBolum
        public ActionResult Index(string KullaniciAdi)
        {
            var model = new OperatorBolumViewModel
            {
                KullaniciAdi = KullaniciAdi
            };

            return View(model);
        }


        public ActionResult BolumList(string kullaniciAdi)
        {
            List<int> userBolumID = new List<int>();
            foreach (var bolumID in _dBUsersBolumService.GetAllDBUsersBolum(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userBolumID.Add((int)bolumID.Bolum_No);
            }
            return Json(_bolumService.GetAllBolum(x => !userBolumID.Contains(x.Bolum_No)), JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserBolumID(string kullaniciAdi)
        {
            List<int> userBolumID = new List<int>();
            foreach (var bolumID in _dBUsersBolumService.GetAllDBUsersBolum(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userBolumID.Add((int)bolumID.Bolum_No);
            }
            return Json(_bolumService.GetAllBolum(x => userBolumID.Contains(x.Bolum_No)), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddBolum(int BolumNo, string kullaniciAdi)
        {
            var bolum = _bolumService.GetAllBolum().FirstOrDefault(x => x.Bolum_No == BolumNo);
            var addedDBUserBolum = new DBUsersBolum
            {
                Kullanici_Adi = kullaniciAdi,
                Bolum_No = BolumNo,
                Alt_Departman_No = bolum.Alt_Departman_No,
                Departman_No = bolum.Departman_No
            };
            _dBUsersBolumService.AddDBUsersBolum(addedDBUserBolum);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RemoveBolum(int BolumNo, string kullaniciAdi)
        {
            var deletedDBUsersBolum = _dBUsersBolumService.GetByQuery(x => x.Bolum_No == BolumNo && x.Kullanici_Adi == kullaniciAdi);
            _dBUsersBolumService.DeleteDBUsersBolum(deletedDBUsersBolum);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

    }
}