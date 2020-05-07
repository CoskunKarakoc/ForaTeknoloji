using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class ReaderSettingsNewManager : IReaderSettingsNewService
    {

        private IReaderSettingsNewDal _readerSettingsNewDal;
        public ReaderSettingsNewManager(IReaderSettingsNewDal readerSettingsNewDal)
        {
            _readerSettingsNewDal = readerSettingsNewDal;
        }

        public ReaderSettingsNew AddReaderSettingsNew(ReaderSettingsNew readerSettingsNew)
        {
            return _readerSettingsNewDal.Add(readerSettingsNew);
        }

        public void DeleteReaderSettingsNew(ReaderSettingsNew readerSettingsNew)
        {
            _readerSettingsNewDal.Delete(readerSettingsNew);
        }

        public void DeleteReaderSettingsNewQuery(Expression<Func<ReaderSettingsNew, bool>> filter = null)
        {
            ReaderSettingsNew entity;
            if (filter == null)
            {
                entity = _readerSettingsNewDal.Get(filter);
                _readerSettingsNewDal.Delete(entity);
            }
        }

        public List<ReaderSettingsNew> GetAllReaderSettingsNew(Expression<Func<ReaderSettingsNew, bool>> filter = null)
        {
            return filter == null ? _readerSettingsNewDal.GetList() : _readerSettingsNewDal.GetList(filter);
        }

        public ReaderSettingsNew GetById(int KapiID)
        {
            return _readerSettingsNewDal.Get(x => x.WKapi_ID == KapiID);
        }

        public ReaderSettingsNew GetByFilter(Expression<Func<ReaderSettingsNew, bool>> filter = null)
        {
            return _readerSettingsNewDal.Get(filter);
        }

        public ReaderSettingsNew UpdateReaderSettingsNew(ReaderSettingsNew readerSettingsNew)
        {
            return _readerSettingsNewDal.Update(readerSettingsNew);
        }


        public ReaderSettingsNew GetByKapiANDPanel(int KapiID, int PanelID)
        {
            return _readerSettingsNewDal.Get(x => x.WKapi_ID == KapiID && x.Panel_ID == PanelID);
        }

        public void DeleteReaderSettingsNewByPanelID(int PanelID)
        {
            _readerSettingsNewDal.DeleteReaderSettingsNewByPanelID(PanelID);
        }


    }
}
