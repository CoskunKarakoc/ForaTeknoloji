using ForaTeknoloji.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class VisitorController : Controller
    {
        private IVisitorsService _visitorsService;
        public VisitorController(IVisitorsService visitorsService)
        {
            _visitorsService = visitorsService;
        }



        // GET: Visitor
        public ActionResult Index(string Search)
        {
            if (Search != null && Search != "")
            {
                var model = _visitorsService.GetAllVisitors(x => x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.TCKimlik.Contains(Search.Trim()) || x.Telefon.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Ziyaret_Sebebi.Contains(Search.Trim()))
                return View(model);
            }
            else
            {
                var model = _visitorsService.GetAllVisitors();
                return View(model);
            }
        }
    }
}