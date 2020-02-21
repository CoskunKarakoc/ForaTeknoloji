using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ITaskListDal : IEntityRepository<TaskList>
    {
        List<TaskStatusWatch> GetAllTaskStatusWatch();
        List<ComplexTaskList> ComplexTaskList();
        void ClearTakList();
    }
}
