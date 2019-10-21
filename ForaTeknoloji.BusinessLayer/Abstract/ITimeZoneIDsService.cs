using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITimeZoneIDsService
    {
        List<TimeZoneIDs> GetAllTimeZoneIDs(Expression<Func<TimeZoneIDs, bool>> filter = null);
        TimeZoneIDs GetById(int id);
        TimeZoneIDs AddTimeZoneIDs(TimeZoneIDs timeZoneIDs);
        void DeleteTimeZoneIDs(TimeZoneIDs timeZoneIDs);
        TimeZoneIDs UpdateTimeZoneIDs(TimeZoneIDs timeZoneIDs);
    }
}
