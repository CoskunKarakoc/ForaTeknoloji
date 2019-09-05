using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AccessDatasManager : IAccessDatasService
    {
        private IAccessDatasDal _accessDatasDal;
        public AccessDatasManager(IAccessDatasDal accessDatasDal)
        {
            _accessDatasDal = accessDatasDal;
        }

        public AccessDatas AddAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Add(accessDatas);
        }

        public void DeleteAccessData(AccessDatas accessDatas)
        {
            _accessDatasDal.Delete(accessDatas);
        }

        public List<AccessDatas> GetAllAccessDatas(Expression<Func<AccessDatas, bool>> filter = null)
        {
            return filter == null ? _accessDatasDal.GetList() : _accessDatasDal.GetList(filter);
        }

        public AccessDatas GetById(int id)
        {
            return _accessDatasDal.Get(x => x.Kayit_No == id);
        }

        public AccessDatas GetByKayit_No(int Kayit_No)
        {
            return _accessDatasDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public AccessDatas UpdateAccessData(AccessDatas accessDatas)
        {
            return _accessDatasDal.Update(accessDatas);
        }

        public List<AccessDatas> GetByKod(int kod)
        {
            return _accessDatasDal.GetList(x => x.Kod == kod);
        }

        public List<int?> GetGecisTipi()
        {
            return _accessDatasDal.GetList().Select(x => x.Gecis_Tipi).ToList();
        }


    }
}
