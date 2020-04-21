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
    public class OperatorTransactionListManagerr : IOperatorTransactionListService
    {

        private IOperatorTransactionListDal _operatorTransactionListDal;
        public OperatorTransactionListManagerr(IOperatorTransactionListDal operatorTransactionListDal)
        {
            _operatorTransactionListDal = operatorTransactionListDal;
        }


        public OperatorTransactionList AddOperatorTransactionList(OperatorTransactionList operatorTransactionList)
        {
            return _operatorTransactionListDal.Add(operatorTransactionList);
        }

        public void DeleteOperatorTransactionList(OperatorTransactionList operatorTransactionList)
        {
            _operatorTransactionListDal.Delete(operatorTransactionList);
        }

        public List<OperatorTransactionList> GetAllOperatorTransactionList(Expression<Func<OperatorTransactionList, bool>> filter = null)
        {
            return filter == null ? _operatorTransactionListDal.GetList() : _operatorTransactionListDal.GetList(filter);
        }

        public OperatorTransactionList GetByKullaniciAdi(string KullaniciAdi)
        {
            return _operatorTransactionListDal.Get(x => x.Kullanici_Adi_Yonetim_Listesi == KullaniciAdi);
        }

        public OperatorTransactionList UpdateOperatorTransactionList(OperatorTransactionList operatorTransactionList)
        {
            return _operatorTransactionListDal.Update(operatorTransactionList);
        }
    }
}
