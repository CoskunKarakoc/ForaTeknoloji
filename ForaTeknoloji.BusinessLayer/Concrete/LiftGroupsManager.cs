using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<LiftGroups> GetAllLiftGroups()
        {
            return _liftGroupsDal.GetList();
        }

        public LiftGroups GetById(int id)
        {
            return _liftGroupsDal.Get(x => x.Asansor_Grup_No == id);
        }

        public LiftGroups UpdateLiftGroup(LiftGroups liftGroups)
        {
            return _liftGroupsDal.Update(liftGroups);
        }
    }
}
