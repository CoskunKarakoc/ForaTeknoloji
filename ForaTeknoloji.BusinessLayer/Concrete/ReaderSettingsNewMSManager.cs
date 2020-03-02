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
    public class ReaderSettingsNewMSManager : IReaderSettingsNewMSService
    {
        private IReaderSettingsNewMSDal _readerSettingsNewMSDal;
        public ReaderSettingsNewMSManager(IReaderSettingsNewMSDal readerSettingsNewMSDal)
        {
            _readerSettingsNewMSDal = readerSettingsNewMSDal;
        }

        public ReaderSettingsNewMS AddReaderSettingsNew(ReaderSettingsNewMS readerSettingsNewMS)
        {
            return _readerSettingsNewMSDal.Add(readerSettingsNewMS);
        }

        public void DeleteReaderSettingsNew(ReaderSettingsNewMS readerSettingsNewMS)
        {
            _readerSettingsNewMSDal.Delete(readerSettingsNewMS);
        }

        public void DeleteReaderSettingsNewByPanelID(int PanelID)
        {
            var deletedReader = _readerSettingsNewMSDal.Get(x => x.Panel_ID == PanelID);
            _readerSettingsNewMSDal.Delete(deletedReader);
        }

        public List<ReaderSettingsNewMS> GetAllReaderSettingsNew(Expression<Func<ReaderSettingsNewMS, bool>> filter = null)
        {
            return filter == null ? _readerSettingsNewMSDal.GetList() : _readerSettingsNewMSDal.GetList(filter);
        }

        public ReaderSettingsNewMS GetById(int KapiID)
        {
            return _readerSettingsNewMSDal.Get(x => x.WKapi_ID == KapiID);
        }

        public ReaderSettingsNewMS GetByKapiANDPanel(int KapiID, int PanelID)
        {
            return _readerSettingsNewMSDal.Get(x => x.Panel_ID == PanelID && x.WKapi_ID == KapiID);
        }

        public ReaderSettingsNewMS UpdateReaderSettingsNew(ReaderSettingsNewMS readerSettingsNewMS)
        {
            return _readerSettingsNewMSDal.Update(readerSettingsNewMS);
        }
    }
}
