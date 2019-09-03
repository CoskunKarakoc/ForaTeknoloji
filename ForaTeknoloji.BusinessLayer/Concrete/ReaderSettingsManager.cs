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
    public class ReaderSettingsManager : IReaderSettingsService
    {
        private IReaderSettingDal _readerSettingDal;
        public ReaderSettingsManager(IReaderSettingDal readerSettingDal)
        {
            _readerSettingDal = readerSettingDal;
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

        public ReaderSettings UpdatereaderSettings(ReaderSettings readerSettings)
        {
            return _readerSettingDal.Update(readerSettings);
        }
    }
}
