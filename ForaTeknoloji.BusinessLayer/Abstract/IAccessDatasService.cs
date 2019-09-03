using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessDatasService
    {
        List<AccessDatas> GetAllAccessDatas();
        AccessDatas GetById(int id);
        List<AccessDatas> GetByKod(int kod);
        List<int?> GetGecisTipi();
        AccessDatas AddAccessData(AccessDatas accessDatas);
        void DeleteAccessData(AccessDatas accessDatas);
        AccessDatas UpdateAccessData(AccessDatas accessDatas);
    }
}
