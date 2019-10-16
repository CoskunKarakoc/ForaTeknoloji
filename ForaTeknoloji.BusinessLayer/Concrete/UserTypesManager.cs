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
    public class UserTypesManager : IUserTypesService
    {
        private IUserTypesDal _userTypesDal;
        public UserTypesManager(IUserTypesDal userTypesDal)
        {
            _userTypesDal = userTypesDal;
        }

        public UserTypes AddUserTypes(UserTypes userTypes)
        {
            return _userTypesDal.Add(userTypes);
        }

        public void DeleteUserTypes(UserTypes userTypes)
        {
            _userTypesDal.Delete(userTypes);
        }

        public List<UserTypes> GetAllUserTypes(Expression<Func<UserTypes, bool>> filter=null)
        {
            return filter == null ? _userTypesDal.GetList() : _userTypesDal.GetList(filter);
        }

        public UserTypes GetById(int id)
        {
            return _userTypesDal.Get(x => x.Kullanici_Tipi == id);
        }

        public UserTypes UpdateUserTypes(UserTypes userTypes)
        {
            return _userTypesDal.Update(userTypes);
        }
    }
}
