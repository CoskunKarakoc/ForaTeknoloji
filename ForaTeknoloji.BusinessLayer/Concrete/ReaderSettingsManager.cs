using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class ReaderSettingsManager : IReaderSettingsService
    {
        private IReaderSettingsDal _readerSettingsDal;
        public ReaderSettingsManager(IReaderSettingsDal readerSettingsDal)
        {
            _readerSettingsDal = readerSettingsDal;
        }
        public ReaderSettings AddReaderSetting(ReaderSettings readerSettings)
        {
            return _readerSettingsDal.Add(readerSettings);
        }

        public void DeleteReaderSetting(ReaderSettings readerSettings)
        {
            _readerSettingsDal.Delete(readerSettings);
        }

        public List<ReaderSettings> GetAllReaderSettings()
        {
            return _readerSettingsDal.GetList();
        }

        public ReaderSettings GetById(int id)
        {
            return _readerSettingsDal.Get(x => x.Kayit_No == id);
        }

        public ReaderSettings UpdateReaderSetting(ReaderSettings readerSettings)
        {
            return _readerSettingsDal.Update(readerSettings);
        }
    }
}
