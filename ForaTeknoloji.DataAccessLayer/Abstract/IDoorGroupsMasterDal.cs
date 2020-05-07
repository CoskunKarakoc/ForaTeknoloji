using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDoorGroupsMasterDal : IEntityRepository<DoorGroupsMaster>
    {
        void DeleteAll();
        void DeleteByKapiGrupNo(int Kapi_Grup_No);
    }
}
