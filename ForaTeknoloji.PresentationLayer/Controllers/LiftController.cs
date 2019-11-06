using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class LiftController : Controller
    {
        private IFloorNamesService _floorNamesService;
        FloorNames tempFloor;
        public LiftController(IFloorNamesService floorNamesService)
        {
            _floorNamesService = floorNamesService;
        }


        // GET: Lift
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult FloorNames()
        {
            var floors = _floorNamesService.GetAllFloorNames();
            return View(floors);
        }

        [HttpPost]
        public ActionResult FloorNamesEdit(FloorNames floorNames)
        {
            if (ModelState.IsValid)
            {
                _floorNamesService.UpdateFloorName(floorNames);
                return RedirectToAction("FloorNames");
            }
            return RedirectToAction("FloorNames");
        }

        public ActionResult AllNameRemove()
        {

            for (int i = 1; i <= 128; i++)
            {
                tempFloor = new FloorNames { Kat_No = i, Kat_Adi = "" };
                _floorNamesService.UpdateFloorName(tempFloor);
            }

            return RedirectToAction("FloorNames");
        }

        public ActionResult AllNameAdd()
        {
            for (int i = 1; i <= 128; i++)
            {
                tempFloor = new FloorNames { Kat_No = i, Kat_Adi = "Kat " + i };
                _floorNamesService.UpdateFloorName(tempFloor);
            }
            return RedirectToAction("FloorNames");
        }
    }
}