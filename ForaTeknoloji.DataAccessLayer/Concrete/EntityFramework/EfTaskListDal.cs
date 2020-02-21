using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTaskListDal : EfEntityRepositoryBase<TaskList, ForaContext>, ITaskListDal
    {

        public void ClearTakList()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM TaskList");
            }
        }




        public List<TaskStatusWatch> GetAllTaskStatusWatch()
        {
            IQueryable<TaskStatusWatch> query;
            using (var context = new ForaContext())
            {
                query = from tl in context.TaskLists
                        join tc in context.TaskCodes
                        on tl.Gorev_Kodu equals tc.Gorev_Kodu into tb1
                        from tbl1 in tb1.DefaultIfEmpty()
                        join ps in context.PanelSettings
                        on tl.Panel_No equals ps.Panel_ID into tb2
                        from tbl2 in tb2.DefaultIfEmpty()
                        join dbu in context.DBUsers
                        on tl.Kullanici_Adi equals dbu.Kullanici_Adi into tb3
                        from tbl3 in tb3.DefaultIfEmpty()
                        join stc in context.StatusCodes
                        on tl.Durum_Kodu equals stc.Durum_Kodu into tb4
                        from tbl4 in tb4.DefaultIfEmpty()
                        select new TaskStatusWatch
                        {
                            Adi = tbl3.Adi,
                            Soyadi = tbl3.Soyadi,
                            Panel_Adi = tbl2.Panel_Name,
                            Durum_Adi = tbl4.Durum_Adi,
                            Gorev_Adi = tbl1.Gorev_Adi,
                            Tarih = tl.Tarih,
                            Durum_Kodu = tl.Durum_Kodu,
                            Gorev_Kodu = tl.Gorev_Kodu,
                            Panel_ID = (int)tl.Panel_No,
                            Kullanici_Adi = tl.Kullanici_Adi
                        };
                return query.ToList();
            }

        }


        public List<ComplexTaskList> ComplexTaskList()
        {
            using (var context = new ForaContext())
            {
                var query = from tl in context.TaskLists
                            join tc in context.TaskCodes
                            on tl.Gorev_Kodu equals tc.Gorev_Kodu into tb1
                            from tbl1 in tb1.DefaultIfEmpty()
                            join ps in context.PanelSettings
                            on tl.Panel_No equals ps.Panel_ID into tb2
                            from tbl2 in tb2.DefaultIfEmpty()
                            join dbu in context.DBUsers
                            on tl.Kullanici_Adi equals dbu.Kullanici_Adi into tb3
                            from tbl3 in tb3.DefaultIfEmpty()
                            join stc in context.StatusCodes
                            on tl.Durum_Kodu equals stc.Durum_Kodu into tb4
                            from tbl4 in tb4.DefaultIfEmpty()
                            select new ComplexTaskList
                            {
                                Kayit_No = tbl1.Kayit_No,
                                Panel_Adi = tbl2.Panel_Name,
                                Durum_Adi = tbl4.Durum_Adi,
                                Gorev_Adi = tbl1.Gorev_Adi,
                                Tarih = tl.Tarih,
                                Durum_Kodu = tl.Durum_Kodu,
                                Gorev_Kodu = tl.Gorev_Kodu,
                                Panel_No = (int)tl.Panel_No,
                                Kullanici_Adi = tl.Kullanici_Adi
                            };
                return query.ToList();
            }
        }





    }
}
