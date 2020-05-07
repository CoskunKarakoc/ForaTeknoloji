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
    public interface IBolumService
    {
        List<Bolum> GetAllBolum(Expression<Func<Bolum, bool>> filter = null);
        Bolum GetById(int Bolum_No);
        Bolum AddBolum(Bolum bolum);
        void DeleteBolum(Bolum bolum);
        Bolum UpdateBolum(Bolum bolum);
        Bolum GetByBolumAdi(string Bolum_Adi);
        void DeleteAll();
        List<ComplexBolum> ComplexBolums(Expression<Func<ComplexBolum, bool>> filter = null);
    }
}
