using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class AlarmController : Controller
    {
        private IAlarmlarService _alarmlarService;
        private IAlarmTipleriService _alarmTipleriService;
        private IUserService _userService;
        private IPanelSettingsService _panelSettingsService;
        public AlarmController(IAlarmlarService alarmlarService, IAlarmTipleriService alarmTipleriService, IUserService userService, IPanelSettingsService panelSettingsService)
        {
            _alarmlarService = alarmlarService;
            _alarmTipleriService = alarmTipleriService;
            _userService = userService;
            _panelSettingsService = panelSettingsService;
        }



        // GET: Alarm
        public ActionResult Index()
        {
            var Alarm = _alarmlarService.AlarmAndTip();
            var AlarmTip = _alarmTipleriService.GetAllAlarmlar();
            var User = _userService.GetAllUsers();
            var Panel = _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP2 != null && x.Panel_IP3 != null && x.Seri_No != null && x.Panel_ID != null);
            var ID = _alarmlarService.GetAllAlarmlar().Max(x => x.Alarm_No);
            var model = new AlarmListViewModel
            {
                MaxID = ID + 1,
                Alarmlar = Alarm,
                AlarmTipleri = AlarmTip.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alarm_Tipi.ToString()
                }),
                Users = User,
                Panels = Panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Seri_No.ToString()
                }),

            };
            return View(model);
        }
    }
}