using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class TaskListManager : ITaskListService
    {
        private ITaskListDal _taskListDal;
        public TaskListManager(ITaskListDal taskListDal)
        {
            _taskListDal = taskListDal;
        }


        public TaskList AddTaskList(TaskList taskList)
        {
            return _taskListDal.Add(taskList);
        }

        public void DeleteTaskList(TaskList taskList)
        {
            _taskListDal.Delete(taskList);
        }

        public List<TaskList> GetAllTaskList(Expression<Func<TaskList, bool>> filter = null)
        {
            return filter == null ? _taskListDal.GetList() : _taskListDal.GetList(filter);
        }

        public TaskList GetByGrupNo(int KayitNo)
        {
            return _taskListDal.Get(x => x.Kayit_No == KayitNo);
        }

        public TaskList GetByPanelNo(int PanelNo)
        {
            return _taskListDal.Get(x => x.Panel_No == PanelNo);
        }

        public TaskList GetByStatusCode(int StatusCode)
        {
            return _taskListDal.Get(x => x.Durum_Kodu == StatusCode);
        }

        public TaskList GetByTaskCode(int TaskCode)
        {
            return _taskListDal.Get(x => x.Gorev_Kodu == TaskCode);
        }

        public TaskList GetByUserName(string kullaniciAdi)
        {
            return _taskListDal.Get(x => x.Kullanici_Adi == kullaniciAdi);
        }

        public TaskList UpdateTaskList(TaskList taskList)
        {
            return _taskListDal.Update(taskList);
        }


        public List<TaskStatusWatch> TaskStatusWatch()
        {
            return _taskListDal.GetAllTaskStatusWatch();
        }


        public List<ComplexTaskList> ComplexTaskList(string UserName)
        {
            return _taskListDal.ComplexTaskList().OrderBy(x => x.Kayit_No).Where(x => x.Kullanici_Adi == UserName).ToList();
        }


    }
}
