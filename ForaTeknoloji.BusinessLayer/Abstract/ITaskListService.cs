using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITaskListService
    {
        List<TaskList> GetAllTaskList(Expression<Func<TaskList, bool>> filter = null);
        TaskList AddTaskList(TaskList taskList);
        void DeleteTaskList(TaskList taskList);
        TaskList UpdateTaskList(TaskList taskList);
        TaskList GetByTaskCode(int TaskCode);
        TaskList GetByPanelNo(int PanelNo);
        TaskList GetByStatusCode(int StatusCode);
        TaskList GetByUserName(string kullaniciAdi);
        TaskList GetByGrupNo(int KayitNo);
        List<TaskStatusWatch> TaskStatusWatch();
        List<ComplexTaskList> ComplexTaskList(string UserName);
    }
}
