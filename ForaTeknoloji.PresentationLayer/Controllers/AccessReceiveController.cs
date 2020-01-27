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
        public DBUsers user;
        public DBUsers permissionUser;
        public AccessReceiveController(IProgInitService progInitService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersService dBUsersService)
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
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }

        // GET: AccessReceive
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            var model = _progInitService.GetAllProgInit().FirstOrDefault();
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

        public ActionResult ClearPanelMemory()
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");

            foreach (var item in _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_TCP_Port != 0))
            {
                TaskList taskList = new TaskList
                {
                    Deneme_Sayisi = 1,
                    Durum_Kodu = 1,
                    Gorev_Kodu = (int)CommandConstants.CMD_ERS_LOGCOUNT,
                    IntParam_1 = 1,
                    Kullanici_Adi = user.Kullanici_Adi,
                    Panel_No = item.Panel_ID,
                    Tablo_Guncelle = true,
                    Tarih = DateTime.Now
                };
                _taskListService.AddTaskList(taskList);
            }
            return RedirectToAction("Index", "AccessReceive");
        }



    }
}