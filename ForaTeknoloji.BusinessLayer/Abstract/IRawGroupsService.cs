using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IRawGroupsService
    {

        List<RawGroups> GetAllRawGroups();
        RawGroups GetById(int id);
        RawGroups AddRawGroup(RawGroups rawGroups);
        void DeleteRawGroup(RawGroups rawGroups);
        RawGroups UpdateRawGroup(RawGroups rawGroups);
    }
}
