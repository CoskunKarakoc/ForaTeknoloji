using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IBirimService
    {
        List<Birim> GetAllBirim(Expression<Func<Birim, bool>> filter = null);
        Birim GetById(int Birim_No);
        Birim AddBirim(Birim birim);
        void DeleteBirim(Birim birim);
        Birim UpdateBirim(Birim birim);
        void DeleteAll();
        List<ComplexBirim> ComplexBirim(Expression<Func<ComplexBirim, bool>> filter = null);
    }
}
