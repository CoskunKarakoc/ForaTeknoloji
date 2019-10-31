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

        public List<ReaderSettingsNew> GetAllReaderSettingsNew(Expression<Func<ReaderSettingsNew, bool>> filter = null)
        {
            return filter == null ? _readerSettingsNewDal.GetList() : _readerSettingsNewDal.GetList(filter);
        }

        public ReaderSettingsNew GetById(int KapiID)
        {
            return _readerSettingsNewDal.Get(x => x.WKapi_ID == KapiID);
        }

        public ReaderSettingsNew UpdateReaderSettingsNew(ReaderSettingsNew readerSettingsNew)
        {
            return _readerSettingsNewDal.Update(readerSettingsNew);
        }
    }
}
