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
    public class RawUsersManager : IRawUsersService
    {
        private IRawUsersDal _rawUsersDal;
        public RawUsersManager(IRawUsersDal rawUsersDal)
        {
            _rawUsersDal = rawUsersDal;
        }

        public RawUsers AddRawUsers(RawUsers rawUsers)
        {
            return _rawUsersDal.Add(rawUsers);
        }

        public void DeleteRawUsers(RawUsers rawUsers)
        {
            _rawUsersDal.Delete(rawUsers);
        }

        public List<RawUsers> GetAllRawUsers(Expression<Func<RawUsers, bool>> filter = null)
        {
            return filter == null ? _rawUsersDal.GetList() : _rawUsersDal.GetList(filter);
        }

        public RawUsers GetById(int id)
        {
            return _rawUsersDal.Get(x => x.ID == id);
        }

        public RawUsers UpdateRawUsers(RawUsers rawUsers)
        {
            return _rawUsersDal.Update(rawUsers);
        }
    }
}
