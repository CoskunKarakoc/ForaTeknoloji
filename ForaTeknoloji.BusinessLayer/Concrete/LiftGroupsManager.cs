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
    public class LiftGroupsManager : ILiftGroupsService
    {
        private ILiftGroupsDal _liftGroupsDal;
        public LiftGroupsManager(ILiftGroupsDal liftGroupsDal)
        {
            _liftGroupsDal = liftGroupsDal;
        }

        public LiftGroups AddLiftGroup(LiftGroups liftGroups)
        {
            return _liftGroupsDal.Add(liftGroups);
        }

        public void DeleteLiftGroup(LiftGroups liftGroups)
        {
            _liftGroupsDal.Delete(liftGroups);
        }

        public List<LiftGroups> GetAllLiftGroups(Expression<Func<LiftGroups, bool>> filter = null)
        {
            return filter == null ? _liftGroupsDal.GetList() : _liftGroupsDal.GetList(filter);
        }

        public LiftGroups GetById(int Asansor_Grup_No)
        {
            return _liftGroupsDal.Get(x => x.Asansor_Grup_No == Asansor_Grup_No);
        }

        public LiftGroups UpdateLiftGroup(LiftGroups liftGroups)
        {
            return _liftGroupsDal.Update(liftGroups);
        }
        public void DeleteAll()
        {
            _liftGroupsDal.DeleteAll();
        }

    }
}
