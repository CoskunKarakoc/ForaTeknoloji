using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IProgRelay2Dal : IEntityRepository<ProgRelay2>
    {
        void DeleteByDayOfTheWeek(int Haftanin_Gunu);
    }
}
