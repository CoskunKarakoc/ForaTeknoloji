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
    public class EfDBUsersBolumDal : EfEntityRepositoryBase<DBUsersBolum, ForaContext>, IDBUsersBolumDal
    {
        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {

                context.Database.ExecuteSqlCommand("TRUNCATE TABLE DBUsersBolum");
            }
        }

        public void DeleteAllWithUserName(string UserName)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersBolum WHERE [Kullanici Adi]= '" + UserName + "'");
            }
        }

        public void DeleteAllWithUserNameAndDepartmanNo(string UserName, int DepartmanNo)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersBolum WHERE [Kullanici Adi]= '" + UserName + "' AND [Departman No]=" + DepartmanNo);
            }
        }

        public void DeleteAllWithUserNameAndDepartmanNoAndAltDepartman(string UserName, int DepartmanNo, int AltDepartman)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersBolum WHERE [Kullanici Adi]= '" + UserName + "' AND [Departman No]=" + DepartmanNo + " AND [Alt Departman No]=" + AltDepartman);
            }
        }

        public void DeleteAllWithUserNameAndDepartmanNoAndAltDepartmanAndBolum(string UserName, int DepartmanNo, int AltDepartman, int Bolum)
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM DBUsersBolum WHERE [Kullanici Adi]= '" + UserName + "' AND [Departman No]=" + DepartmanNo + " AND [Alt Departman No]=" + AltDepartman + " AND [Bolum No]=" + Bolum);
            }
        }



    }
}
