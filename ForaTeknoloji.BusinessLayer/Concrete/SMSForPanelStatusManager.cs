using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class SMSForPanelStatusManager : ISMSForPanelStatusService
    {
        ISMSForPanelStatusDal _sMSForPanelStatusDal;
        public SMSForPanelStatusManager(ISMSForPanelStatusDal sMSForPanelStatusDal)
        {
            _sMSForPanelStatusDal = sMSForPanelStatusDal;
        }

        public SMSForPanelStatus AddSMSForPanelStatus(SMSForPanelStatus sMSForPanelStatus)
        {
            return _sMSForPanelStatusDal.Add(sMSForPanelStatus);
        }

        public void DeleteAlarmTipleri(SMSForPanelStatus sMSForPanelStatus)
        {
            _sMSForPanelStatusDal.Delete(sMSForPanelStatus);
        }

        public void DeleteAll()
        {
            _sMSForPanelStatusDal.DeleteAll();
        }

        public void DeleteByTelNo(string TelNo)
        {
            _sMSForPanelStatusDal.DeleteByTelNo(TelNo);
        }

        public List<SMSForPanelStatus> GetAllSMSForPanelStatus(Expression<Func<SMSForPanelStatus, bool>> filter = null)
        {
            return filter == null ? _sMSForPanelStatusDal.GetList() : _sMSForPanelStatusDal.GetList(filter);
        }

        public SMSForPanelStatus GetByKayitNo(int KayitNo)
        {
            return _sMSForPanelStatusDal.Get(x => x.Kayit_No == KayitNo);
        }

        public SMSForPanelStatus GetByTelNo(string telNo)
        {
            return _sMSForPanelStatusDal.Get(x => x.Phone_Number == telNo);
        }

        public SMSForPanelStatus UpdateSMSForPanelStatus(SMSForPanelStatus sMSForPanelStatus)
        {
            return _sMSForPanelStatusDal.Update(sMSForPanelStatus);
        }
    }
}
