using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTaskListDal : EfEntityRepositoryBase<TaskList, ForaContext>, ITaskListDal
    {
        public List<TaskStatusWatch> GetAllTaskStatusWatch()
        {
            IQueryable<TaskStatusWatch> query;
            using (var context = new ForaContext())
            {
                query = from tl in context.TaskLists
                        join tc in context.TaskCodes
                        on tl.Gorev_Kodu equals tc.Gorev_Kodu
                        join ps in context.PanelSettings
                        on tl.Panel_No equals ps.Panel_ID
                        join dbu in context.DBUsers
                        on tl.Kullanici_Adi equals dbu.Kullanici_Adi
                        join stc in context.StatusCodes
                        on tl.Durum_Kodu equals stc.Durum_Kodu
                        select new TaskStatusWatch
                        {
                            Adi = dbu.Adi,
                            Soyadi = dbu.Soyadi,
                            Panel_Adi = ps.Panel_Name,
                            Durum_Adi = stc.Durum_Adi,
                            Gorev_Adi = tc.Gorev_Adi,
                            Tarih = tl.Tarih,
                            Durum_Kodu = tl.Durum_Kodu,
                            Gorev_Kodu = tl.Gorev_Kodu,
                            Panel_ID = (int)tl.Panel_No,
                            Kullanici_Adi=tl.Kullanici_Adi
                        };
                return query.ToList();
            }

        }
    }
}
