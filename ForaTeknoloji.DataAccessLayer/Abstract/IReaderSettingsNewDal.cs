using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IReaderSettingsNewDal : IEntityRepository<ReaderSettingsNew>
    {
        void DeleteReaderSettingsNewByPanelID(int PanelID);
    }
}
