using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class TaskController : Controller
    {

        private ITaskListService _taskListService;
        private IPanelSettingsService _panelSettingsService;
        private IStatusCodesService _statusCodesService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private ITaskCodeService _taskCodeService;
        private IReportService _reportService;
        public DBUsers user;
        public TaskController(ITaskListService taskListService, IPanelSettingsService panelSettingsService, IStatusCodesService statusCodesService, IDBUsersPanelsService dBUsersPanelsService, ITaskCodeService taskCodeService, IReportService reportService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _taskListService = taskListService;
            _panelSettingsService = panelSettingsService;
            _statusCodesService = statusCodesService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _taskCodeService = taskCodeService;
            _reportService = reportService;
        }


        // GET: Task
        public ActionResult TaskTable(int? Panel, int? Gorev, int? Durum, DateTime? Tarih)
        {
            var Paneller = _reportService.PanelListesi(user);
            var StatusCodes = _statusCodesService.GetAllStatusCodes();
            var TaskCode = _taskCodeService.GetAllTaskCodes();
            var List = QueryList(Panel, Gorev, Durum, Tarih);
            var model = new TaskTableListViewModel
            {
                Panel = Paneller.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Durum = StatusCodes.Select(a => new SelectListItem
                {
                    Text = a.Durum_Adi,
                    Value = a.Durum_Kodu.ToString()
                }),
                Gorev = TaskCode.Select(a => new SelectListItem
                {
                    Text = a.Gorev_Adi,
                    Value = a.Gorev_Kodu.ToString()
                }),
                Liste = List
            };
            return View(model);
        }



        private List<TaskStatusWatch> QueryList(int? Panel, int? Gorev, int? Durum, DateTime? Tarih)
        {
            IEnumerable<TaskStatusWatch> liste;
            liste = _taskListService.TaskStatusWatch().Where(x => x.Kullanici_Adi == user.Kullanici_Adi).OrderByDescending(x => x.Tarih).Take(100);
            if (Panel != null)
            {
                liste = liste.Where(x => x.Panel_ID == Panel);
            }
            if (Gorev != null)
            {
                liste = liste.Where(x => x.Gorev_Kodu == Gorev);
            }
            if (Durum != null)
            {
                liste = liste.Where(x => x.Durum_Kodu == Durum);
            }
            if (Tarih != null)
            {
                liste = liste.Where(x => x.Tarih.Value.Date == Tarih.Value.Date);
            }
            return liste.ToList();

        }


        public PartialViewResult TopManuTask()
        {
            var model = _taskListService.ComplexTaskList(user.Kullanici_Adi).Take(4).ToList();
            return PartialView(model);
        }

    }
}