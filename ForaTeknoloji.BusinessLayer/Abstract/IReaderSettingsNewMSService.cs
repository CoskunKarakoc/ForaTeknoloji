using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReaderSettingsNewMSService
    {
        List<ReaderSettingsNewMS> GetAllReaderSettingsNew(Expression<Func<ReaderSettingsNewMS, bool>> filter = null);
        ReaderSettingsNewMS GetById(int KapiID);
        ReaderSettingsNewMS AddReaderSettingsNew(ReaderSettingsNewMS readerSettingsNewMS);
        void DeleteReaderSettingsNew(ReaderSettingsNewMS readerSettingsNewMS);
        ReaderSettingsNewMS UpdateReaderSettingsNew(ReaderSettingsNewMS readerSettingsNewMS);
        ReaderSettingsNewMS GetByKapiANDPanel(int KapiID, int PanelID);
        void DeleteReaderSettingsNewByPanelID(int PanelID);
    }
}
