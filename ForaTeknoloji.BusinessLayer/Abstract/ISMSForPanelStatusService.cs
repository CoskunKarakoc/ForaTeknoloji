using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ISMSForPanelStatusService
    {
        List<SMSForPanelStatus> GetAllSMSForPanelStatus(Expression<Func<SMSForPanelStatus, bool>> filter = null);
        SMSForPanelStatus GetByKayitNo(int KayitNo);
        SMSForPanelStatus AddSMSForPanelStatus(SMSForPanelStatus sMSForPanelStatus);
        void DeleteAlarmTipleri(SMSForPanelStatus sMSForPanelStatus);
        SMSForPanelStatus UpdateSMSForPanelStatus(SMSForPanelStatus sMSForPanelStatus);
        SMSForPanelStatus GetByTelNo(string telNo);
        void DeleteAll();
        void DeleteByTelNo(string TelNo);
    }
}
