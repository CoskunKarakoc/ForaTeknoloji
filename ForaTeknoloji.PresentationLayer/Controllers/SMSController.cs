using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class SMSController : Controller
    {
        ISmsSettingsService _smsSettingsService;
        public SMSController(ISmsSettingsService smsSettingsService)
        {
            _smsSettingsService = smsSettingsService;
        }



        // GET: SMS
        public ActionResult Add()
        {
            var model = _smsSettingsService.GetAllSMSSetting().FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(SMSSetting sMSSetting)
        {
            if (ModelState.IsValid)
            {
                _smsSettingsService.UpdateSMSSetting(sMSSetting);
                return RedirectToAction("Add", "SMS");
            }
            return View(sMSSetting);
        }

    }
}