using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
   public interface ITimeZoneCalendarService
    {

        List<TimeZoneCalendar> GetAllTimeZoneCalendar();
        TimeZoneCalendar GetById(int id);
        TimeZoneCalendar AddTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar);
        void DeleteTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar);
        TimeZoneCalendar UpdateTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar);
    }
}
