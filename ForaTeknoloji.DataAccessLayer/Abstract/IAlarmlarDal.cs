using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfAlarmlarDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IAlarmlarDal : IEntityRepository<Alarmlar>
    {
        List<ComplexAlarm> AlarmAndAlarmTip();
    }
}
