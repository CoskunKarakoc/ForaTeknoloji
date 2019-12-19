using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class TimeZoneIDsManager : ITimeZoneIDsService
    {
        private ITimeZoneIDsDal _timeZoneIDsDal;
        public TimeZoneIDsManager(ITimeZoneIDsDal timeZoneIDsDal)
        {
            _timeZoneIDsDal = timeZoneIDsDal;
        }

        public TimeZoneIDs AddTimeZoneIDs(TimeZoneIDs timeZoneIDs)
        {
            return _timeZoneIDsDal.Add(timeZoneIDs);
        }

        public void DeleteTimeZoneIDs(TimeZoneIDs timeZoneIDs)
        {
            _timeZoneIDsDal.Delete(timeZoneIDs);
        }

        public List<TimeZoneIDs> GetAllTimeZoneIDs(Expression<Func<TimeZoneIDs, bool>> filter = null)
        {
            return filter == null ? _timeZoneIDsDal.GetList() : _timeZoneIDsDal.GetList(filter);
        }

        public TimeZoneIDs GetById(int id)
        {
            return _timeZoneIDsDal.Get(x => x.Gecis_Sinirlama_Tipi == id);
        }

        public TimeZoneIDs UpdateTimeZoneIDs(TimeZoneIDs timeZoneIDs)
        {
            return _timeZoneIDsDal.Update(timeZoneIDs);
        }
    }
}
