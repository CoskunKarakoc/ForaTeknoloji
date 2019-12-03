using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ILiftGroupsService
    {
        List<LiftGroups> GetAllLiftGroups(Expression<Func<LiftGroups, bool>> filter = null);
        LiftGroups GetById(int Asansor_Grup_No);
        LiftGroups AddLiftGroup(LiftGroups liftGroups);
        void DeleteLiftGroup(LiftGroups liftGroups);
        LiftGroups UpdateLiftGroup(LiftGroups liftGroups);
        void DeleteAll();
    }
}
