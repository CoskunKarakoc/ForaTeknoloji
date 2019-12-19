using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class ReaderSettingsManager : IReaderSettingsService
    {
        private IReaderSettingDal _readerSettingDal;
        private IDBUsersPanelsDal _dbUsersPanelsDal;
        public ReaderSettingsManager(IReaderSettingDal readerSettingDal, IDBUsersPanelsDal dBUsersPanelsDal)
        {
            _readerSettingDal = readerSettingDal;
            _dbUsersPanelsDal = dBUsersPanelsDal;
        }
        public ReaderSettings AddreaderSettings(ReaderSettings readerSettings)
        {
            return _readerSettingDal.Add(readerSettings);
        }

        public void DeletereaderSettings(ReaderSettings readerSettings)
        {
            _readerSettingDal.Delete(readerSettings);
        }

        public List<ReaderSettings> GetAllreaderSettings(Expression<Func<ReaderSettings, bool>> filter = null)
        {
            return filter == null ? _readerSettingDal.GetList() : _readerSettingDal.GetList(filter);
        }

        public ReaderSettings GetById(int id)
        {
            return _readerSettingDal.Get(x => x.Kayit_No == id);
        }

        public List<ReaderSettings> GetReaderName(DBUsers kullaniciAdi)
        {
            var liste = _dbUsersPanelsDal.GetList(x => x.Kullanici_Adi == kullaniciAdi.Kullanici_Adi).Select(a => a.Panel_No).ToList();
            return _readerSettingDal.GetList(x => liste.Contains(x.Panel_ID));
        }

        public ReaderSettings UpdatereaderSettings(ReaderSettings readerSettings)
        {
            return _readerSettingDal.Update(readerSettings);
        }

        public ReaderSettings GetByQuery(Expression<Func<ReaderSettings, bool>> filter = null)
        {
            return filter == null ? _readerSettingDal.Get(x => x.Seri_No > 0 && x.Panel_ID > 0) : _readerSettingDal.Get(filter);
        }
    }
}
