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
    public class HolidayController : Controller
    {
        private IDBUsersService _dBUsersService;
        private ITatilGunuService _tatilGunuService;
        private IReportService _reportService;
        private IProgRelay2Service _progRelay2Service;
        public DBUsers user;
        public DBUsers permissionUser;
        public HolidayController(ITatilGunuService tatilGunuService, IDBUsersService dBUsersService, IReportService reportService, IProgRelay2Service progRelay2Service)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _tatilGunuService = tatilGunuService;
            _dBUsersService = dBUsersService;
            _reportService = reportService;
            _progRelay2Service = progRelay2Service;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }

        public ActionResult Create()
        {
            TatilGunu tatilGunu = new TatilGunu();
            var model = _tatilGunuService.GetAllTatilGunu().Count();
            if (model == 0)
            {
                tatilGunu = new TatilGunu
                {
                    Ozel_Gun_No = 8,
                    Ozel_Gun_Adi = "23 Nisan",
                    Haftanin_Gunu = Convert.ToInt32(DateTime.Now.DayOfWeek),
                    Tarih = new DateTime(DateTime.Now.Year, 4, 23, 0, 0, 0)
                };
            }
            else
            {
                var entity = _tatilGunuService.GetAllTatilGunu().Max(x => x.Ozel_Gun_No);
                tatilGunu.Ozel_Gun_No = (entity + 1);
                tatilGunu.Ozel_Gun_Adi = "23 Nisan";
                tatilGunu.Haftanin_Gunu = Convert.ToInt32(DateTime.Now.DayOfWeek);
                tatilGunu.Tarih = new DateTime(DateTime.Now.Year, 4, 23, 0, 0, 0);
            }

            return View(tatilGunu);
        }

        [HttpPost]
        public ActionResult Create(TatilGunu tatilGunu)
        {
            if (tatilGunu != null)
            {
                if (tatilGunu.Tarih == null)
                    throw new Exception("Tarih Alanı Boş Geçilemez!");


                var entity = _tatilGunuService.AddTatilGunu(tatilGunu);
                for (int i = 1; i < 129; i++)
                {
                    int saat1 = 5;
                    int saat2 = 6;
                    for (int k = 1; k < 17; k++)
                    {
                        ProgRelay2 progRelay2 = new ProgRelay2
                        {
                            Saat_1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, saat1, 1, 00),
                            Saat_2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, saat2, 0, 00),
                            Panel_No = i,
                            Haftanin_Gunu = entity.Ozel_Gun_No,
                            Zaman_Dilimi = k,
                            Aktif = false,
                            Cihaz_1 = false,
                            Cihaz_2 = false,
                            Cihaz_3 = false,
                            Cihaz_4 = false,
                            Cihaz_5 = false,
                            Cihaz_6 = false,
                            Cihaz_7 = false,
                            Cihaz_8 = false,
                            Role_1 = false,
                            Role_2 = false,
                            Role_3 = false,
                            Role_4 = false,
                            Role_5 = false,
                            Role_6 = false,
                            Role_7 = false,
                            Role_8 = false,
                            Role_9 = false,
                            Role_10 = false,
                            Role_11 = false,
                            Role_12 = false,
                            Role_13 = false,
                            Role_14 = false,
                            Role_15 = false,
                            Role_16 = false,
                            Durum_1 = false,
                            Durum_2 = false,
                            Durum_3 = false,
                            Durum_4 = false,
                            Durum_5 = false,
                            Durum_6 = false,
                            Durum_7 = false,
                            Durum_8 = false,
                            Durum_9 = false,
                            Durum_10 = false,
                            Durum_11 = false,
                            Durum_12 = false,
                            Durum_13 = false,
                            Durum_14 = false,
                            Durum_15 = false,
                            Durum_16 = false,
                        };
                        saat1++;
                        saat2++;
                        _progRelay2Service.AddProgRelay2(progRelay2);
                    }

                }
            }
            return RedirectToAction("ProgRelay", "Door");
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult HolidayList()
        {
            var jsonresult = Json(new { data = _tatilGunuService.GetAllTatilGunu() }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }


        public ActionResult Delete(int? Kayit_No)
        {
            if (Kayit_No != null && Kayit_No > 0)
            {
                var entiy = _tatilGunuService.GetAllTatilGunu().FirstOrDefault(x => x.Kayit_No == Kayit_No);
                _progRelay2Service.DeleteByDayOfTheWeek(entiy.Ozel_Gun_No);
                _tatilGunuService.DeleteTatilGunu(entiy);
                return RedirectToAction("Index", "Holiday");
            }
            throw new Exception("Böyle Bir Tatil Günü Bulunamadı!");
        }

        public ActionResult Edit(int? Kayit_No)
        {
            var model = _tatilGunuService.GetAllTatilGunu().FirstOrDefault(x => x.Kayit_No == Kayit_No);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TatilGunu tatilGunu)
        {
            if (ModelState.IsValid)
            {
                _tatilGunuService.UpdateTatilGunu(tatilGunu);
                return RedirectToAction("Index", "Holiday");
            }
            throw new Exception("Tatil Günü Güncellenirken Hata İle Karşılaşıldı!");
        }

    }
}