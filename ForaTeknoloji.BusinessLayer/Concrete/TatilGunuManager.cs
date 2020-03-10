using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class TatilGunuManager : ITatilGunuService
    {
        private ITatilGunuDal _tatilGunuDal;
        public TatilGunuManager(ITatilGunuDal tatilGunuDal)
        {
            _tatilGunuDal = tatilGunuDal;
        }

        public TatilGunu AddTatilGunu(TatilGunu tatilGunu)
        {
            tatilGunu.Haftanin_Gunu = Convert.ToInt32(tatilGunu.Tarih.Value.DayOfWeek);
            return _tatilGunuDal.Add(tatilGunu);
        }

        public void DeleteTatilGunu(TatilGunu tatilGunu)
        {
            _tatilGunuDal.Delete(tatilGunu);
        }

        public List<TatilGunu> GetAllTatilGunu(Expression<Func<TatilGunu, bool>> filter = null)
        {
            return filter == null ? _tatilGunuDal.GetList() : _tatilGunuDal.GetList(filter);
        }

        public TatilGunu GetById(int Kayit_No)
        {
            return _tatilGunuDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public TatilGunu UpdateTatilGunu(TatilGunu tatilGunu)
        {
            return _tatilGunuDal.Update(tatilGunu);
        }
    }
}
