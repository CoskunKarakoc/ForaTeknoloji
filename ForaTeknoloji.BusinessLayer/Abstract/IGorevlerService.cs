using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGorevlerService
    {
        List<Gorevler> GetAllGorevler(Expression<Func<Gorevler, bool>> filter = null);
        Gorevler GetById(int id);
        Gorevler AddGorev(Gorevler gorev);
        void DeleteGorev(Gorevler gorev);
        void DeleteAll();
        Gorevler UpdateGorev(Gorevler gorev);
        Gorevler GetByGorevAdi(string GorevAdi);
    }
}
