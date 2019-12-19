using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using System;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
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
                if (globalZones.Global_Bolge_Adi != null && globalZones.Global_Bolge_Adi != "")
                {
                    _globalZoneService.UpdateGlobalZones(globalZones);
                    return RedirectToAction("Index");
                }
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            return RedirectToAction("Index");
        }




    }
}