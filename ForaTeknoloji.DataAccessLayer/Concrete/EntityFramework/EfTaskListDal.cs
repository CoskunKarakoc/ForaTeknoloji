using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTaskListDal : EfEntityRepositoryBase<TaskList, ForaContext>, ITaskListDal
    {

        public void ClearTakList(string kullaniciAdi)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM TaskList WHERE [Kullanici Adi] = '" + kullaniciAdi + "'");
            }
        }

        public void ClearAllTakList()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM TaskList");
            }
        }

        public void sp_SendAllUserToAllPanel(DBUsers users)
        {
            using (var context = new ForaContext())
            {
                SqlParameter parameter = new SqlParameter("@userName", users.Kullanici_Adi);
                context.Database.ExecuteSqlCommand("sp_AllUsersToAllPanels @userName", parameter);
            }
        }

        public void sp_SendOneUserAllPanel(DBUsers users, int UserId)
        {
            using (var context = new ForaContext())
            {
                SqlParameter parameterUserId = new SqlParameter("@userID", UserId);
                SqlParameter parameterUserName = new SqlParameter("@userName", users.Kullanici_Adi);
                context.Database.ExecuteSqlCommand("sp_OneUserAllPanel @userID, @userName", parameters: new[] { parameterUserId, parameterUserName });
            }
        }


        public void sp_SendAllUserOnePanel(DBUsers users, int PanelId)
        {
            using (var context = new ForaContext())
            {
                SqlParameter parameterPanelId = new SqlParameter("@panelID", PanelId);
                SqlParameter parameterUserName = new SqlParameter("@userName", users.Kullanici_Adi);
                context.Database.ExecuteSqlCommand("sp_AllUserOnePanel @panelID, @userName", parameters: new[] { parameterPanelId, parameterUserName });
            }
        }


        public List<TaskStatusWatch> GetAllTaskStatusWatch(Expression<Func<TaskStatusWatch, bool>> filter = null)
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
                            Kullanici_Adi = tl.Kullanici_Adi,
                            Kayit_No = tl.Kayit_No
                        };
                return filter == null ? query.ToList() : query.Where(filter).ToList();
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
