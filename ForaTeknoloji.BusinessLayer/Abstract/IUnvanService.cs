using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IUnvanService
    {
        List<Unvan> GetAllUnvan(Expression<Func<Unvan, bool>> filter = null);
        Unvan GetById(int Unvan_No);
        Unvan AddUnvan(Unvan unvan);
        void DeleteUnvan(Unvan unvan);
        void DeleteAll();
        Unvan UpdateUnvan(Unvan unvan);

    }
}
