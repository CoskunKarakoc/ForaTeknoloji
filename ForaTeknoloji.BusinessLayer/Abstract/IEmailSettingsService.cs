using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IEmailSettingsService
    {
        List<EMailSetting> GetAllEMailSetting(Expression<Func<EMailSetting, bool>> filter = null);
        EMailSetting GetById(int Kayit_No);
        EMailSetting AddEMailSetting(EMailSetting eMailSetting);
        void DeleteEMailSetting(EMailSetting eMailSetting);
        EMailSetting UpdateEMailSetting(EMailSetting eMailSetting);
    }
}
