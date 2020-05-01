using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfSMSForPanelStatusDal : EfEntityRepositoryBase<SMSForPanelStatus, ForaContext>, ISMSForPanelStatusDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE SMSForPanelStatus");
            }

        }

        public void DeleteByTelNo(string TelNo)
        {
            using (var context = new ForaContext())
            {
                var query = "DELETE FROM SMSForPanelStatus WHERE [Phone Number]=" + TelNo;
                context.Database.ExecuteSqlCommand(query);
            }

        }
    }
}
