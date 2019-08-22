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
    public class AccessCountTypesManager : IAccessCountTypesService
    {
        private IAccessCountTypesDal _accessCountTypesDal;
        public AccessCountTypesManager(IAccessCountTypesDal accessCountTypesDal)
        {
            _accessCountTypesDal = accessCountTypesDal;
        }
        public AccessCountTypes AddAccessCountType(AccessCountTypes accessCountTypes)
        {
            return _accessCountTypesDal.Add(accessCountTypes);
        }

        public void DeleteAccessCountType(AccessCountTypes accessCountTypes)
        {
            _accessCountTypesDal.Delete(accessCountTypes);
        }

        public List<AccessCountTypes> GetAllAccessCountTypes()
        {
            return _accessCountTypesDal.GetList();
        }

        public AccessCountTypes GetById(int id)
        {
            return _accessCountTypesDal.Get(x => x.Kayit_No == id);
        }

        public AccessCountTypes UpdateAccessCountType(AccessCountTypes accessCountTypes)
        {
            return _accessCountTypesDal.Update(accessCountTypes);
        }
    }
}
