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
    public class OperatorSirketController : Controller
    {
        private IDBUsersSirketService _dBUsersSirketService;
        private ISirketService _sirketService;
        private IReaderSettingsNewService _readerSettingsNewService;
        public OperatorSirketController(IDBUsersSirketService dBUsersSirketService, ISirketService sirketService, IReaderSettingsNewService readerSettingsNewService)
        {
            _dBUsersSirketService = dBUsersSirketService;
            _sirketService = sirketService;
            _readerSettingsNewService = readerSettingsNewService;
        }
        // GET: OperatorSirket
        public ActionResult Index(string KullaniciAdi)
        {
            var model = new OperatorSirketViewModel
            {
                KullaniciAdi = KullaniciAdi
            };

            return View(model);
        }


        public ActionResult SirketList(string kullaniciAdi)
        {
            List<int> userSirketID = new List<int>();
            foreach (var sirketID in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userSirketID.Add((int)sirketID.Sirket_No);
            }
            return Json(_sirketService.GetAllSirketler(x => !userSirketID.Contains(x.Sirket_No)), JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserSirketID(string kullaniciAdi)
        {
            List<int> userSirketID = new List<int>();
            foreach (var sirketID in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userSirketID.Add((int)sirketID.Sirket_No);
            }
            return Json(_sirketService.GetAllSirketler(x => userSirketID.Contains(x.Sirket_No)), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddSirket(int SirketNo, string kullaniciAdi)
        {
            var addedDBUserSirket = new DBUsersSirket
            {
                Kullanici_Adi = kullaniciAdi,
                Sirket_No = SirketNo
            };
            _dBUsersSirketService.AddDBUsersSirket(addedDBUserSirket);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RemoveSirket(int SirketNo, string kullaniciAdi)
        {
            var deletedDBUsersSirket = _dBUsersSirketService.GetByQuery(x => x.Sirket_No == SirketNo && x.Kullanici_Adi == kullaniciAdi);
            _dBUsersSirketService.DeleteDBUsersSirket(deletedDBUsersSirket);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }



    }
}