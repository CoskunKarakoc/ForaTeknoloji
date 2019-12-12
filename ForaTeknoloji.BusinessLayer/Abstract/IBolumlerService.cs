using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IBolumlerService
    {
        List<Bolumler> GetAllBolumler(Expression<Func<Bolumler, bool>> filter = null);
        Bolumler GetById(int id);
        Bolumler AddBolum(Bolumler bolum);
        void DeleteBolum(Bolumler bolum);
        void DeleteAll();
        Bolumler UpdateBolum(Bolumler bolum);
        Bolumler GetByBolumAdi(string BolumAdi);
    }
}
