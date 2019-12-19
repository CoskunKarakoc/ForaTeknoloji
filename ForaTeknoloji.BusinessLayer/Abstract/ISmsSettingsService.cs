using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ISmsSettingsService
    {
        List<SMSSetting> GetAllSMSSetting(Expression<Func<SMSSetting, bool>> filter = null);
        SMSSetting GetById(int Kayit_No);
        SMSSetting AddSMSSetting(SMSSetting sMSSetting);
        void DeleteSMSSetting(SMSSetting sMSSetting);
        SMSSetting UpdateSMSSetting(SMSSetting sMSSetting);
    }
}
