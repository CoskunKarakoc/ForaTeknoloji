using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITatilGunuService
    {
        List<TatilGunu> GetAllTatilGunu(Expression<Func<TatilGunu, bool>> filter = null);
        TatilGunu GetById(int Kayit_No);
        TatilGunu AddTatilGunu(TatilGunu tatilGunu);
        void DeleteTatilGunu(TatilGunu tatilGunu);
        TatilGunu UpdateTatilGunu(TatilGunu tatilGunu);
    }
}
