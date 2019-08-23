using ForaTeknoloji.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class VisitorReportController : Controller
    {
        private IVisitorsService _visitorsService;
        public VisitorReportController(IVisitorsService visitorsService)
        {
            _visitorsService = visitorsService;
        }
        // GET: VisitorReport
        public ActionResult Index()
        {
            //TODO:Koşula göre liste ekrana basılacak
            var liste = _visitorsService.GetZiyaretciListesi();
            return View();
        }
    }
}