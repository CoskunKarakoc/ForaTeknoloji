using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class EmailController : Controller
    {
        private IEmailSettingsService _emailSettingsService;
        public EmailController(IEmailSettingsService emailSettingsService)
        {
            _emailSettingsService = emailSettingsService;
        }


        // GET: Email
        public ActionResult Add()
        {
            var model = _emailSettingsService.GetAllEMailSetting().FirstOrDefault();

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(EMailSetting eMailSetting)
        {
            if (ModelState.IsValid)
            {
                _emailSettingsService.UpdateEMailSetting(eMailSetting);
                return RedirectToAction("Add", "Email");
            }
            return View(eMailSetting);
        }
    }
}