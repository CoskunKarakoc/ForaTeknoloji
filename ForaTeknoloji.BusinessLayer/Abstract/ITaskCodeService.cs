using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITaskCodeService
    {
        List<TaskCode> GetAllTaskCodes(Expression<Func<TaskCode, bool>> filter = null);
        TaskCode GetById(int Gorev_Kodu);
        TaskCode AddTaskCode(TaskCode taskCode);
        void DeleteTaskCode(TaskCode taskCode);
        TaskCode UpdateTaskCode(TaskCode taskCode);
    }
}
