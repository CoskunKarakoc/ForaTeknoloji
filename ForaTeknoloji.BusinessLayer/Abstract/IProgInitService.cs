using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IProgInitService
    {
        List<ProgInit> GetAllProgInit(Expression<Func<ProgInit, bool>> filter = null);
        ProgInit GetById(int Kayit_No);
        ProgInit AddProgInit(ProgInit progInit);
        void DeleteProgInit(ProgInit progInit);
        ProgInit UpdateProgInit(ProgInit progInit);
    }
}
