using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ITaskListDal : IEntityRepository<TaskList>
    {
        List<TaskStatusWatch> GetAllTaskStatusWatch();
        List<ComplexTaskList> ComplexTaskList();
    }
}
