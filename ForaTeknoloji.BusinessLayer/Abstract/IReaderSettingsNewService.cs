using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IReaderSettingsNewService
    {
        List<ReaderSettingsNew> GetAllReaderSettingsNew(Expression<Func<ReaderSettingsNew, bool>> filter = null);
        ReaderSettingsNew GetById(int KapiID);
        ReaderSettingsNew AddReaderSettingsNew(ReaderSettingsNew readerSettingsNew);
        void DeleteReaderSettingsNew(ReaderSettingsNew readerSettingsNew);
        ReaderSettingsNew UpdateReaderSettingsNew(ReaderSettingsNew readerSettingsNew);
    }
}
