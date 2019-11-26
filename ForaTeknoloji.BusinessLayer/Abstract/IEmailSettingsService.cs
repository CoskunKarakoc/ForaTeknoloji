using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
