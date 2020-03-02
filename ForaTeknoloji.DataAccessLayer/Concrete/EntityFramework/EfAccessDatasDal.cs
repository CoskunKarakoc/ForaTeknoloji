using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.DataTransferObjects;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAccessDatasDal : EfEntityRepositoryBase<AccessDatas, ForaContext>, IAccessDatasDal
    {
        private IAccessDatasTempDal _accessDatasTempDal;
        public EfAccessDatasDal(IAccessDatasTempDal accessDatasTempDal)
        {
            _accessDatasTempDal = accessDatasTempDal;
        }

        public void BackupAccessDatasTable()
        {
            using (var context = new ForaContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var accessDatas in GetList())
                        {
                            var accessDatasTemp = ConvertAccessDatas.AccessDatasToAccessDatasTemp(accessDatas);
                            _accessDatasTempDal.Add(accessDatasTemp);
                        }
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                        throw new System.Exception("Geçiş Verileri Kopyalnırken Bir Hata Oluştu!");
                    }
                }
            }
        }


        public void DeleteAll()
        {
            using (var context = new ForaContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM AccessDatas");
            }
        }
    }
}
