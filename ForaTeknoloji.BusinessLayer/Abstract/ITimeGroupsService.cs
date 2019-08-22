using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITimeGroupsService
    {

        List<TimeGroups> GetAllTimeGroups();
        TimeGroups GetById(int id);
        TimeGroups AddTimeGroup(TimeGroups timeGroups);
        void DeleteTimeGroup(TimeGroups timeGroups);
        TimeGroups UpdateTimeGroup(TimeGroups timeGroups);
    }
}
