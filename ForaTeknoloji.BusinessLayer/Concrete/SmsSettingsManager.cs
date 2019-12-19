using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class SmsSettingsManager : ISmsSettingsService
    {
        private ISMSSettingsDal _sMSSettingsDal;
        public SmsSettingsManager(ISMSSettingsDal sMSSettingsDal)
        {
            _sMSSettingsDal = sMSSettingsDal;
        }


        public SMSSetting AddSMSSetting(SMSSetting sMSSetting)
        {
            return _sMSSettingsDal.Add(sMSSetting);
        }

        public void DeleteSMSSetting(SMSSetting sMSSetting)
        {
            _sMSSettingsDal.Delete(sMSSetting);
        }

        public List<SMSSetting> GetAllSMSSetting(Expression<Func<SMSSetting, bool>> filter = null)
        {
            return filter == null ? _sMSSettingsDal.GetList() : _sMSSettingsDal.GetList(filter);
        }

        public SMSSetting GetById(int Kayit_No)
        {
            return _sMSSettingsDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public SMSSetting UpdateSMSSetting(SMSSetting sMSSetting)
        {
            return _sMSSettingsDal.Update(sMSSetting);
        }
    }
}
