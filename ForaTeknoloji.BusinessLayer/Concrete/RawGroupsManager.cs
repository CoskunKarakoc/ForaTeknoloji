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
    public class RawGroupsManager : IRawGroupsService
    {
        private IRawGroupsDal _rawGroupsDal;
        public RawGroupsManager(IRawGroupsDal rawGroupsDal)
        {
            _rawGroupsDal = rawGroupsDal;
        }


        public RawGroups AddRawGroups(RawGroups rawGroups)
        {
            return _rawGroupsDal.Add(rawGroups);
        }

        public void DeleteAllRawGroups()
        {
            _rawGroupsDal.DeleteAll();
        }

        public void DeleteRawGroups(RawGroups rawGroups)
        {
            _rawGroupsDal.Delete(rawGroups);
        }

        public List<RawGroups> GetAllRawGroups(Expression<Func<RawGroups, bool>> filter = null)
        {
            return filter == null ? _rawGroupsDal.GetList() : _rawGroupsDal.GetList(filter);
        }

        public RawGroups GetById(int id)
        {
            return _rawGroupsDal.Get(x => x.Grup_No == id);
        }

        public RawGroups UpdateRawGroups(RawGroups rawGroups)
        {
            return _rawGroupsDal.Update(rawGroups);
        }
    }
}
