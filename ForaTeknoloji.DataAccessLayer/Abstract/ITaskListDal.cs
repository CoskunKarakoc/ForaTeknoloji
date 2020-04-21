using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ITaskListDal : IEntityRepository<TaskList>
    {
        List<TaskStatusWatch> GetAllTaskStatusWatch(Expression<Func<TaskStatusWatch, bool>> filter = null);
        List<ComplexTaskList> ComplexTaskList();
        void ClearTakList(string kullaniciAdi);
        void ClearAllTakList();
    }
}
