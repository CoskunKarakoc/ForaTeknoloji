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
    public class EfAccessDatasDal : EfEntityRepositoryBase<AccessDatas, ForaContext>, IAccessDatasDal
    {
        public IQueryable<DigerGecisRaporList> GetDigerGecisListesi()
        {
            var context = new ForaContext();
            var liste = from co in context.CodeOperation
                        join ad in context.AccessDatas on co.TKod equals ad.Kod into tbl
                        from tbl1 in tbl.DefaultIfEmpty()
                        select new DigerGecisRaporList
                        {
                            Gecis_Tipi = tbl1.Gecis_Tipi,
                            Kapi_ID = tbl1.Kapi_ID,
                            Kayit_No = tbl1.Kayit_No,
                            Operasyon = co.Operasyon,
                            Panel_ID = tbl1.Panel_ID,
                            Tarih = tbl1.Tarih
                        };
            return liste.Distinct();

        }

        public IQueryable<AccessDatas> GetTanimsizListesi()
        {
            var contex = new ForaContext();
            var liste = from ad in contex.AccessDatas
                        where ad.Kod == 4
                        select ad;
            return liste.Distinct();
        }

    }
}
