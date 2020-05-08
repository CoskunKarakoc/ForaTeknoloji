using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfGroupsDetailNewDal : EfEntityRepositoryBase<GroupsDetailNew, ForaContext>, IGroupsDetailNewDal
    {
        public List<ComplexGroupsDetailNew> GetComplexGroups()
        {
            using (var context = new ForaContext())
            {
                var query = from gd in context.GroupsDetailNews
                            join rs in context.ReaderSettingsNews
                            on gd.Kapi_No equals rs.WKapi_ID
                            join tg in context.TimeGroups
                            on gd.Zaman_Grup_No equals tg.Zaman_Grup_No
                            join lg in context.LiftGroups
                            on gd.Asansor_Grup_No equals lg.Asansor_Grup_No
                            select new ComplexGroupsDetailNew
                            {
                                Asansor_Grup_Adi = lg.Asansor_Grup_Adi,
                                Asansor_Grup_No = gd.Asansor_Grup_No,
                                Global_Bolge_No = 1,
                                Grup_Adi = gd.Grup_Adi,
                                Grup_No = gd.Grup_No,
                                Kapi_Adi = rs.WKapi_Adi,
                                Kapi_Aktif = gd.Kapi_Aktif,
                                Kapi_No = rs.WKapi_ID,
                                Panel_Adi = gd.Panel_Adi,
                                Panel_No = gd.Panel_No,
                                Seri_No = gd.Seri_No,
                                Zaman_Grup_Adi = tg.Zaman_Grup_Adi,
                                Zaman_Grup_No = gd.Zaman_Grup_No,
                                Reader_Panel_No = rs.Panel_ID
                            };
                return query.ToList();
            }
        }

        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [GroupsDetailNew]");
            }
        }


        public void UpdateTSQL(string GrupAdi, int GrupNo)
        {
            using (var context = new ForaContext())
            {
                var query = "UPDATE GroupsDetailNew SET [Grup Adi]='" + GrupAdi + "' WHERE [Grup No]=" + GrupNo;
                context.Database.ExecuteSqlCommand(query);
            }
        }

        public void DeleteWithGrupNoTSQL(int GrupNo)
        {
            using (var context = new ForaContext())
            {
                var query = "DELETE FROM GroupsDetailNew WHERE [Grup No]=" + GrupNo;
                context.Database.ExecuteSqlCommand(query);
            }
        }
    }
}
