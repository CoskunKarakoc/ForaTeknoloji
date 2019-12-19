using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class StatusCodesManager : IStatusCodesService
    {
        private IStatusCodesDal _statusCodesDal;
        public StatusCodesManager(IStatusCodesDal statusCodesDal)
        {
            _statusCodesDal = statusCodesDal;
        }


        public StatusCode AddStatusCode(StatusCode statusCode)
        {
            return _statusCodesDal.Add(statusCode);
        }

        public void DeleteStatusCode(StatusCode statusCode)
        {
            _statusCodesDal.Delete(statusCode);
        }

        public List<StatusCode> GetAllStatusCodes(Expression<Func<StatusCode, bool>> filter = null)
        {
            return filter == null ? _statusCodesDal.GetList() : _statusCodesDal.GetList(filter);
        }

        public StatusCode GetById(int Durum_Kodu)
        {
            return _statusCodesDal.Get(x => x.Durum_Kodu == Durum_Kodu);
        }

        public StatusCode UpdateStatusCode(StatusCode statusCode)
        {
            return _statusCodesDal.Update(statusCode);
        }
    }
}
