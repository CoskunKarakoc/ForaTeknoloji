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

        public void sp_AddTaskList(TaskList taskList)
        {
            using (var context = new ForaContext())
            {
                SqlParameter gorevKodu = new SqlParameter("@gorevKodu", System.Data.SqlDbType.Int);
                SqlParameter IntParam1 = new SqlParameter("@IntParam1", System.Data.SqlDbType.Int);
                SqlParameter IntParam2 = new SqlParameter("@IntParam2", System.Data.SqlDbType.Int);
                SqlParameter IntParam3 = new SqlParameter("@IntParam3", System.Data.SqlDbType.Int);
                SqlParameter IntParam4 = new SqlParameter("@IntParam4", System.Data.SqlDbType.Int);
                SqlParameter IntParam5 = new SqlParameter("@IntParam5", System.Data.SqlDbType.Int);
                SqlParameter panelNo = new SqlParameter("@panelNo", System.Data.SqlDbType.Int);
                SqlParameter tumPanel = new SqlParameter("@tumPanel", System.Data.SqlDbType.Bit);
                SqlParameter panelGrup1 = new SqlParameter("@panelGrup1", System.Data.SqlDbType.Int);
                SqlParameter panelGrup2 = new SqlParameter("@panelGrup2", System.Data.SqlDbType.Int);
                SqlParameter panelGrup3 = new SqlParameter("@panelGrup3", System.Data.SqlDbType.Int);
                SqlParameter denemeSayisi = new SqlParameter("@denemeSayisi", System.Data.SqlDbType.Int);
                SqlParameter durumKodu = new SqlParameter("@durumKodu", System.Data.SqlDbType.Int);
                SqlParameter tarih = new SqlParameter("@tarih", System.Data.SqlDbType.DateTime);
                SqlParameter kullaniciAdi = new SqlParameter("@kullaniciAdi", System.Data.SqlDbType.NVarChar);
                SqlParameter tabloGuncelle = new SqlParameter("@tabloGuncelle", System.Data.SqlDbType.Bit);
                SqlParameter strParam1 = new SqlParameter("@strParam1", System.Data.SqlDbType.NVarChar);
                SqlParameter strParam2 = new SqlParameter("@strParam2", System.Data.SqlDbType.NVarChar);
                SqlParameter strParam3 = new SqlParameter("@strParam3", System.Data.SqlDbType.NVarChar);

                gorevKodu.Value = taskList.Gorev_Kodu;
                IntParam1.Value = taskList.IntParam_1;

                if (taskList.IntParam_2 == null)
                    IntParam2.Value = DBNull.Value;
                else
                    IntParam2.Value = taskList.IntParam_2;

                if (taskList.IntParam_3 == null)
                    IntParam3.Value = DBNull.Value;
                else
                    IntParam3.Value = taskList.IntParam_3;

                if (taskList.IntParam_4 == null)
                    IntParam4.Value = DBNull.Value;
                else
                    IntParam4.Value = taskList.IntParam_4;

                if (taskList.IntParam_5 == null)
                    IntParam5.Value = DBNull.Value;
                else
                    IntParam5.Value = taskList.IntParam_5;

                if (taskList.Panel_No == null)
                    panelNo.Value = DBNull.Value;
                else
                    panelNo.Value = taskList.Panel_No;

                if (taskList.Tum_Panel == null)
                    tumPanel.Value = DBNull.Value;
                else
                    tumPanel.Value = taskList.Tum_Panel;

                if (taskList.Panel_Grup_1 == null)
                    panelGrup1.Value = DBNull.Value;
                else
                    panelGrup1.Value = taskList.Panel_Grup_1;

                if (taskList.Panel_Grup_2 == null)
                    panelGrup2.Value = DBNull.Value;
                else
                    panelGrup2.Value = taskList.Panel_Grup_2;

                if (taskList.Panel_Grup_3 == null)
                    panelGrup3.Value = DBNull.Value;
                else
                    panelGrup3.Value = taskList.Panel_Grup_3;

                if (taskList.Deneme_Sayisi == null)
                    denemeSayisi.Value = DBNull.Value;
                else
                    denemeSayisi.Value = taskList.Deneme_Sayisi;

                durumKodu.Value = taskList.Durum_Kodu;
                tarih.Value = taskList.Tarih;
                kullaniciAdi.Value = taskList.Kullanici_Adi;

                if (taskList.Tablo_Guncelle == null)
                    tabloGuncelle.Value = DBNull.Value;
                else
                    tabloGuncelle.Value = taskList.Tablo_Guncelle;

                if (taskList.StrParam_1 == null)
                    strParam1.Value = DBNull.Value;
                else
                    strParam1.Value = taskList.StrParam_1;

                if (taskList.StrParam_2 == null)
                    strParam2.Value = DBNull.Value;
                else
                    strParam2.Value = taskList.StrParam_2;

                if (taskList.StrParam_3 == null)
                    strParam3.Value = DBNull.Value;
                else
                    strParam3.Value = taskList.StrParam_3;


                context.Database.ExecuteSqlCommand("sp_AddTaskList @gorevKodu,@IntParam1,@IntParam2," +
                    "@IntParam3,@IntParam4,@IntParam5," +
                    "@panelNo,@tumPanel,@panelGrup1," +
                    "@panelGrup2,@panelGrup3,@denemeSayisi," +
                    "@durumKodu,@tarih,@kullaniciAdi,@tabloGuncelle," +
                    "@strParam1,@strParam2,@strParam3", parameters: new[] { gorevKodu, IntParam1, IntParam2, IntParam3, IntParam4, IntParam5, panelNo, tumPanel, panelGrup1, panelGrup2, panelGrup3, denemeSayisi, durumKodu, tarih, kullaniciAdi, tabloGuncelle, strParam1, strParam2, strParam3 });

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
