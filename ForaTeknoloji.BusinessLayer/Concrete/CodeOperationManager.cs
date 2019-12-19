using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class CodeOperationManager : ICodeOperationService
    {
        private ICodeOperationDal _codeOperationDal;
        public CodeOperationManager(ICodeOperationDal codeOperationDal)
        {
            _codeOperationDal = codeOperationDal;
        }
        public CodeOperation AddCodeOperation(CodeOperation codeOperation)
        {
            return _codeOperationDal.Add(codeOperation);
        }

        public void DeleteCodeOperation(CodeOperation codeOperation)
        {
            _codeOperationDal.Delete(codeOperation);
        }

        public List<CodeOperation> GetAllCodeOperation()
        {
            return _codeOperationDal.GetList();
        }

        public CodeOperation GetById(int id)
        {
            return _codeOperationDal.Get(x => x.TKod == id);
        }

        public CodeOperation UpdateCodeOperation(CodeOperation codeOperation)
        {
            return _codeOperationDal.Update(codeOperation);
        }
    }
}
