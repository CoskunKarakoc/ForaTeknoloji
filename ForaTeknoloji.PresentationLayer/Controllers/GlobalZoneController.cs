using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class GlobalZoneController : Controller
    {
        private IGlobalZoneService _globalZoneService;
        public GlobalZoneController(IGlobalZoneService globalZoneService)
        {
            _globalZoneService = globalZoneService;
        }


        // GET: GlobalZone
        public ActionResult Index()
        {
            return View(_globalZoneService.GetAllGlobalZones());
        }


      
        public ActionResult Edit(GlobalZones globalZones)
        {
            if (ModelState.IsValid)
            {
                _globalZoneService.UpdateGlobalZones(globalZones);
            }
            return RedirectToAction("Index");
        }




    }
}