using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class TaskCodeManager : ITaskCodeService
    {
        private ITaskCodesDal _taskCodesDal;
        public TaskCodeManager(ITaskCodesDal taskCodesDal)
        {
            _taskCodesDal = taskCodesDal;
        }


        public TaskCode AddTaskCode(TaskCode taskCode)
        {
            return _taskCodesDal.Add(taskCode);
        }

        public void DeleteTaskCode(TaskCode taskCode)
        {
            _taskCodesDal.Delete(taskCode);
        }

        public List<TaskCode> GetAllTaskCodes(Expression<Func<TaskCode, bool>> filter = null)
        {
            return filter == null ? _taskCodesDal.GetList() : _taskCodesDal.GetList(filter);
        }

        public TaskCode GetById(int Gorev_Kodu)
        {
            return _taskCodesDal.Get(x => x.Gorev_Kodu == Gorev_Kodu);
        }

        public TaskCode UpdateTaskCode(TaskCode taskCode)
        {
            return _taskCodesDal.Update(taskCode);
        }
    }
}
