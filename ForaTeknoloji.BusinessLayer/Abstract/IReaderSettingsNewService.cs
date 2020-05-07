using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReaderSettingsNewService
    {
        List<ReaderSettingsNew> GetAllReaderSettingsNew(Expression<Func<ReaderSettingsNew, bool>> filter = null);
        ReaderSettingsNew GetById(int KapiID);
        ReaderSettingsNew AddReaderSettingsNew(ReaderSettingsNew readerSettingsNew);
        void DeleteReaderSettingsNew(ReaderSettingsNew readerSettingsNew);
        void DeleteReaderSettingsNewQuery(Expression<Func<ReaderSettingsNew, bool>> filter = null);
        ReaderSettingsNew UpdateReaderSettingsNew(ReaderSettingsNew readerSettingsNew);
        ReaderSettingsNew GetByKapiANDPanel(int KapiID, int PanelID);
        void DeleteReaderSettingsNewByPanelID(int PanelID);
        ReaderSettingsNew GetByFilter(Expression<Func<ReaderSettingsNew, bool>> filter = null);
    }
}
