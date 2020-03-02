using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AccessDatasTempManager : IAccessDatasTempService
    {
        private IAccessDatasTempDal _accessDatasTempDal;
        public AccessDatasTempManager(IAccessDatasTempDal accessDatasTempDal)
        {
            _accessDatasTempDal = accessDatasTempDal;
        }

        public AccessDatasTemp AddAccessDatasTemp(AccessDatasTemp accessDatasTemp)
        {
            return _accessDatasTempDal.Add(accessDatasTemp);
        }

        public void DeleteAccessDatasTemp(AccessDatasTemp accessDatasTemp)
        {
            _accessDatasTempDal.Delete(accessDatasTemp);
        }

        public void DeleteAll()
        {
            _accessDatasTempDal.DeleteAll();
        }

        public List<AccessDatasTemp> GetAllAccessDatasTemp(Expression<Func<AccessDatasTemp, bool>> filter = null)
        {
            return filter == null ? _accessDatasTempDal.GetList() : _accessDatasTempDal.GetList(filter);
        }

        public AccessDatasTemp GetById(int id)
        {
            return _accessDatasTempDal.Get(x => x.ID == id);
        }

        public AccessDatasTemp UpdateAccessDatasTemp(AccessDatasTemp accessDatasTemp)
        {
            return _accessDatasTempDal.Update(accessDatasTemp);
        }
    }
}
