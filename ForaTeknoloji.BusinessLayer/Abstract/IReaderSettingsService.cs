using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReaderSettingsService
    {

        List<ReaderSettings> GetAllReaderSettings();
        ReaderSettings GetById(int id);
        ReaderSettings AddReaderSetting(ReaderSettings readerSettings);
        void DeleteReaderSetting(ReaderSettings readerSettings);
        ReaderSettings UpdateReaderSetting(ReaderSettings readerSettings);
    }
}
