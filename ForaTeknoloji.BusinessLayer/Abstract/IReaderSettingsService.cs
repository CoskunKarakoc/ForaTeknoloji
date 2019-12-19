using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReaderSettingsService
    {
        List<ReaderSettings> GetAllreaderSettings(Expression<Func<ReaderSettings, bool>> filter = null);
        ReaderSettings GetById(int id);
        ReaderSettings AddreaderSettings(ReaderSettings readerSettings);
        void DeletereaderSettings(ReaderSettings readerSettings);
        ReaderSettings UpdatereaderSettings(ReaderSettings readerSettings);
        List<ReaderSettings> GetReaderName(DBUsers kullaniciAdi);
        ReaderSettings GetByQuery(Expression<Func<ReaderSettings, bool>> filter = null);
    }
}
