using ForaTeknoloji.BusinessLayer.Abstract;
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
    public class TaskController : Controller
    {

        private ITaskListService _taskListService;

        public DBUsers user;
        public TaskController(ITaskListService taskListService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _taskListService = taskListService;
        }


        // GET: Task
        public ActionResult TaskTable()
        {
            var model = _taskListService.TaskStatusWatch().Where(x => x.Kullanici_Adi == user.Kullanici_Adi).OrderByDescending(x => x.Tarih).Take(100);
            return View(model);
        }
    }
}