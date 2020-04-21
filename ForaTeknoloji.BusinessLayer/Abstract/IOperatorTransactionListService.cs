using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IOperatorTransactionListService
    {
        List<OperatorTransactionList> GetAllOperatorTransactionList(Expression<Func<OperatorTransactionList, bool>> filter = null);
        OperatorTransactionList GetByKullaniciAdi(string KullaniciAdi);
        OperatorTransactionList AddOperatorTransactionList(OperatorTransactionList operatorTransactionList);
        void DeleteOperatorTransactionList(OperatorTransactionList operatorTransactionList);
        OperatorTransactionList UpdateOperatorTransactionList(OperatorTransactionList operatorTransactionList);
    }
}
