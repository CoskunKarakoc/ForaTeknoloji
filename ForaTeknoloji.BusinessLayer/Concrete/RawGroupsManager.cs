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
    public class RawGroupsManager : IRawGroupsService
    {
        private IRawGroupsDal _rawGroupsDal;
        public RawGroupsManager(IRawGroupsDal rawGroupsDal)
        {
            _rawGroupsDal = rawGroupsDal;
        }
        public RawGroups AddRawGroup(RawGroups rawGroups)
        {
            return _rawGroupsDal.Add(rawGroups);
        }

        public void DeleteRawGroup(RawGroups rawGroups)
        {
            _rawGroupsDal.Delete(rawGroups);
        }

        public List<RawGroups> GetAllRawGroups()
        {
            return _rawGroupsDal.GetList();
        }

        public RawGroups GetById(int id)
        {
            return _rawGroupsDal.Get(x => x.Grup_No == id);
        }

        public RawGroups UpdateRawGroup(RawGroups rawGroups)
        {
            return _rawGroupsDal.Update(rawGroups);
        }
    }
}
