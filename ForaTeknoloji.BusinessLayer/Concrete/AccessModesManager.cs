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
    public class AccessModesManager : IAccessModesService
    {
        private IAccessModesDal _accessModesDal;
        public AccessModesManager(IAccessModesDal accessModesDal)
        {
            _accessModesDal = accessModesDal;
        }

        public AccessModes AddAccessModes(AccessModes accessModes)
        {
            return _accessModesDal.Add(accessModes);
        }

        public void DeleteAccessModes(AccessModes accessModes)
        {
            _accessModesDal.Delete(accessModes);
        }

        public List<AccessModes> GetAllAccessModes(Expression<Func<AccessModes, bool>> filter = null)
        {
            return filter == null ? _accessModesDal.GetList() : _accessModesDal.GetList(filter);
        }

        public AccessModes GetById(int id)
        {
            return _accessModesDal.Get(x => x.Gecis_Modu == id);
        }

        public AccessModes UpdateAccessModes(AccessModes accessModes)
        {
            return _accessModesDal.Update(accessModes);
        }
    }
}
