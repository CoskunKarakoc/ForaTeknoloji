using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IRawGroupsService
    {
        List<RawGroups> GetAllRawGroups(Expression<Func<RawGroups, bool>> filter = null);
        RawGroups GetById(int id);
        RawGroups AddRawGroups(RawGroups rawGroups);
        void DeleteRawGroups(RawGroups rawGroups);
        void DeleteAllRawGroups();
        RawGroups UpdateRawGroups(RawGroups rawGroups);

    }
}
