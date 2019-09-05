using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessDatasService
    {
        List<AccessDatas> GetAllAccessDatas(Expression<Func<AccessDatas, bool>> filter = null);
        AccessDatas GetById(int id);
        List<AccessDatas> GetByKod(int kod);
        AccessDatas GetByKayit_No(int Kayit_No);
        List<int?> GetGecisTipi();
        AccessDatas AddAccessData(AccessDatas accessDatas);
        void DeleteAccessData(AccessDatas accessDatas);
        AccessDatas UpdateAccessData(AccessDatas accessDatas);
    }
}
