using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class AccessReceiveController : Controller
    {
        private IProgInitService _progInitService;
        private ITaskListService _taskListService;
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersService _dBUsersService;
        private IReportService _reportService;
        public DBUsers user;
        public DBUsers permissionUser;
        public AccessReceiveController(IProgInitService progInitService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersService dBUsersService, IReportService reportService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _progInitService = progInitService;
            _taskListService = taskListService;
            _panelSettingsService = panelSettingsService;
            _dBUsersService = dBUsersService;
            _reportService = reportService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }

        // GET: AccessReceive
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");
            var model = new OfflineAccessReceiveListViewModel
            {
                ProgEntity = _progInitService.GetAllProgInit().FirstOrDefault(),
                PanelListesi = _reportService.PanelListesi(user)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProgInit progInit)
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            if (ModelState.IsValid)
            {
                _progInitService.UpdateProgInit(progInit);
                return RedirectToAction("Index");
            }
            return View(progInit);
        }

        public ActionResult ClearPanelMemory(List<int> PanelListClear)
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            foreach (var item in PanelListClear)
            {
                var panelModel = _panelSettingsService.GetById(item);
                if (panelModel.Panel_Model != (int)PanelModel.Panel_1010)
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_ERS_LOGCOUNT,
                        IntParam_1 = 1,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = item,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    _taskListService.AddTaskList(taskList);
                }

            }
            return RedirectToAction("Index", "AccessReceive");
        }

        public ActionResult Receive(List<int> PanelList)
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            foreach (var panel in PanelList)
            {
                var panelModel = _panelSettingsService.GetById(panel);
                if (panelModel.Panel_Model != (int)PanelModel.Panel_1010)
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_RCV_LOGS,
                        IntParam_1 = 1,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = panel,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    _taskListService.AddTaskList(taskList);
                }

            }
            return RedirectToAction("Index", "AccessReceive");
        }

    }
}