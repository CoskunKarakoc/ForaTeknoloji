using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class EMailSettingsManager : IEmailSettingsService
    {
        private IEmailSettingsDal _emailSettingsDal;
        public EMailSettingsManager(IEmailSettingsDal emailSettingsDal)
        {
            _emailSettingsDal = emailSettingsDal;
        }


        public EMailSetting AddEMailSetting(EMailSetting eMailSetting)
        {
            return _emailSettingsDal.Add(eMailSetting);
        }

        public void DeleteEMailSetting(EMailSetting eMailSetting)
        {
            _emailSettingsDal.Delete(eMailSetting);
        }

        public List<EMailSetting> GetAllEMailSetting(Expression<Func<EMailSetting, bool>> filter = null)
        {
            return filter == null ? _emailSettingsDal.GetList() : _emailSettingsDal.GetList(filter);
        }

        public EMailSetting GetById(int Kayit_No)
        {
            return _emailSettingsDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public EMailSetting UpdateEMailSetting(EMailSetting eMailSetting)
        {
            return _emailSettingsDal.Update(eMailSetting);
        }
    }
}
