using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AltDepartmanManager : IAltDepartmanService
    {
        private IAltDepartmanDal _altDepartmanDal;
        public AltDepartmanManager(IAltDepartmanDal altDepartmanDal)
        {
            _altDepartmanDal = altDepartmanDal;
        }

        public AltDepartman AddAltDepartman(AltDepartman altDepartman)
        {
            return _altDepartmanDal.Add(altDepartman);
        }

        public List<ComplexAltDepartman> ComplexAltDepartmen(Expression<Func<ComplexAltDepartman, bool>> filter = null)
        {
            return filter == null ? _altDepartmanDal.ComplexAltDepartman() : _altDepartmanDal.ComplexAltDepartman(filter);
        }

        public void DeleteAll()
        {
            _altDepartmanDal.DeleteAll();
        }

        public void DeleteAltDepartman(AltDepartman altDepartman)
        {
            _altDepartmanDal.Delete(altDepartman);
        }

        public List<AltDepartman> GetAllAltDepartman(Expression<Func<AltDepartman, bool>> filter = null)
        {
            return filter == null ? _altDepartmanDal.GetList() : _altDepartmanDal.GetList(filter);
        }

        public AltDepartman GetById(int Alt_Departman_No)
        {
            return _altDepartmanDal.Get(x => x.Alt_Departman_No == Alt_Departman_No);
        }

        public AltDepartman UpdateAltDepartman(AltDepartman altDepartman)
        {
            return _altDepartmanDal.Update(altDepartman);
        }
    }
}
