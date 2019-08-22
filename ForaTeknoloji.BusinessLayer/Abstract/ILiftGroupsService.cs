using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ILiftGroupsService
    {

        List<LiftGroups> GetAllLiftGroups();
        LiftGroups GetById(int id);
        LiftGroups AddLiftGroup(LiftGroups liftGroups);
        void DeleteLiftGroup(LiftGroups liftGroups);
        LiftGroups UpdateLiftGroup(LiftGroups liftGroups);
    }

}
