using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IStatusCodesService
    {
        List<StatusCode> GetAllStatusCodes(Expression<Func<StatusCode, bool>> filter = null);
        StatusCode GetById(int Durum_Kodu);
        StatusCode AddStatusCode(StatusCode statusCode);
        void DeleteStatusCode(StatusCode statusCode);
        StatusCode UpdateStatusCode(StatusCode statusCode);
    }
}
