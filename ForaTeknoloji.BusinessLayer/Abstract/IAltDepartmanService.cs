using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAltDepartmanService
    {
        List<AltDepartman> GetAllAltDepartman(Expression<Func<AltDepartman, bool>> filter = null);
        AltDepartman GetById(int Alt_Departman_No);
        AltDepartman AddAltDepartman(AltDepartman altDepartman);
        void DeleteAltDepartman(AltDepartman altDepartman);
        void DeleteAll();
        AltDepartman UpdateAltDepartman(AltDepartman altDepartman);
        List<ComplexAltDepartman> ComplexAltDepartmen();
    }
}
