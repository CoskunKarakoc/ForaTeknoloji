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
        List<TaskStatusWatch> TaskStatusWatch(Expression<Func<TaskStatusWatch, bool>> filter = null);
        List<ComplexTaskList> ComplexTaskList(string UserName);
        void DeleteAllWithUserName(string kullaniciAdi);
        void DeleteAll();
        void sp_SendAllUserToAllPanel(DBUsers users);
        void sp_SendOneUserAllPanel(DBUsers users, int UserId);
        void sp_SendAllUserOnePanel(DBUsers users, int PanelId);
    }
}
