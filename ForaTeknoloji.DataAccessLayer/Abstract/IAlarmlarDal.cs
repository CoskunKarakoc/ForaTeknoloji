using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfAlarmlarDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IAlarmlarDal : IEntityRepository<Alarmlar>
    {
        List<ComplexAlarm> AlarmAndAlarmTip(Expression<Func<ComplexAlarm, bool>> filter = null);
    }
}
