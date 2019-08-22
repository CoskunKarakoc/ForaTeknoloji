using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<AccessModes> GetAllAccessModes()
        {
            return _accessModesDal.GetList();
        }

        public AccessModes GetById(int id)
        {
            return _accessModesDal.Get(x => x.Kayit_No == id);
        }

        public AccessModes UpdateAccessModes(AccessModes accessModes)
        {
            return _accessModesDal.Update(accessModes);

        }
    }
}
