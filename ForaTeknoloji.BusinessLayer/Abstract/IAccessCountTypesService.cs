using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAccessCountTypesService
    {

        List<AccessCountTypes> GetAllAccessCountTypes();
        AccessCountTypes GetById(int id);
        AccessCountTypes AddAccessCountType(AccessCountTypes accessCountTypes);
        void DeleteAccessCountType(AccessCountTypes accessCountTypes);
        AccessCountTypes UpdateAccessCountType(AccessCountTypes accessCountTypes);
    }
}
