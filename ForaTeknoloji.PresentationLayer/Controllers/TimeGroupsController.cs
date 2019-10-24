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
    public class TimeGroupsController : Controller
    {
        private ITimeGroupsService _timeGroupsService;
        private ITimeZoneIDsService _timeZoneIDsService;
        public TimeGroupsController(ITimeGroupsService timeGroupsService, ITimeZoneIDsService timeZoneIDsService)
        {
            _timeGroupsService = timeGroupsService;
            _timeZoneIDsService = timeZoneIDsService;
        }


        // GET: TimeGroups
        public ActionResult Index()
        {
            var model = new TimeGroupsListViewModel
            {
                TimeGroups = _timeGroupsService.GetComplexTimeGroups().OrderBy(x => x.Zaman_Grup_No).ToList()
            };

            return View(model);
        }




        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                var entity = _timeGroupsService.GetById(id);
                if (entity != null)
                {
                    _timeGroupsService.DeleteTimeGroups(entity);
                    return RedirectToAction("Index");
                }
                throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
            }
            throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
        }

        public ActionResult Edit(int id = -1)
        {
            if (id != -1)
            {
                var entity = _timeGroupsService.GetById(id);
                if (entity != null)
                {
                    ViewBag.Gecis_Sinirlama_Tipi = new SelectList(_timeZoneIDsService.GetAllTimeZoneIDs(), "Gecis_Sinirlama_Tipi", "Adi", entity.Gecis_Sinirlama_Tipi);
                    ViewBag.Baslangic_Tarihi = entity.Baslangic_Tarihi;
                    return View(entity);
                }
                throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
            }
            throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeGroups timeGroups, DateTime? Baslangic_Saati_Two = null, DateTime? Bitis_Saati_Two = null)
        {
            if (ModelState.IsValid)
            {
                if (Baslangic_Saati_Two != null)
                {
                    timeGroups.Baslangic_Saati = Baslangic_Saati_Two;
                }
                if (Bitis_Saati_Two != null)
                {
                    timeGroups.Bitis_Saati = Bitis_Saati_Two;
                }
                var entity = _timeGroupsService.GetById(timeGroups.Zaman_Grup_No);
                if (entity != null)
                {
                    _timeGroupsService.UpdateTimeGroups(timeGroups);
                    return RedirectToAction("Index");
                }
                throw new Exception("Bu Zaman Grup No'suna uygun kayıt bulunamadı!");
            }
            return View(timeGroups);
        }

        public ActionResult Create()
        {
            var MaxID = _timeGroupsService.GetAllTimeGroups().Max(x => x.Zaman_Grup_No);
            var Sinirlama = _timeZoneIDsService.GetAllTimeZoneIDs();
            var model = new AddTimeGroupsListViewModel
            {
                Zaman_Grup_No = MaxID + 1,
                Gecis_Sinirlama_Tipi = Sinirlama.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Gecis_Sinirlama_Tipi.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TimeGroups timeGroups, DateTime? Baslangic_Tarihi_Two = null, DateTime? Baslangic_Saati_Two = null, DateTime? Bitis_Tarihi_Two = null, DateTime? Bitis_Saati_Two = null)
        {
            if (ModelState.IsValid)
            {
                if (Baslangic_Tarihi_Two != null)
                {
                    if (Baslangic_Saati_Two != null)
                    {
                        timeGroups.Baslangic_Tarihi = Baslangic_Tarihi_Two;
                        timeGroups.Baslangic_Saati = Baslangic_Saati_Two;
                    }
                    else
                    {
                        timeGroups.Baslangic_Tarihi = Baslangic_Tarihi_Two;
                    }
                }
                if (Bitis_Tarihi_Two != null)
                {
                    if (Bitis_Saati_Two != null)
                    {
                        timeGroups.Bitis_Tarihi = Bitis_Tarihi_Two;
                        timeGroups.Bitis_Saati = Bitis_Saati_Two;
                    }
                    else
                    {
                        timeGroups.Bitis_Tarihi = Bitis_Tarihi_Two;
                    }
                }
                _timeGroupsService.AddTimeGroups(timeGroups);
                return RedirectToAction("Index");
            }
            return View(timeGroups);
        }

    }

}