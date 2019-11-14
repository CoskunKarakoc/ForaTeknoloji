using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
  public  interface IProgRelay2Service
    {
        List<ProgRelay2> GetAllProgRelay2(Expression<Func<ProgRelay2, bool>> filter = null);
        ProgRelay2 GetById(int Kayit_No);
        ProgRelay2 AddProgRelay2(ProgRelay2 progRelay2);
        void DeleteProgRelay2(ProgRelay2 progRelay2);
        ProgRelay2 UpdateProgRelay2(ProgRelay2 progRelay2);
    }
}
