using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ICodeOperationService
    {
        List<CodeOperation> GetAllCodeOperation();
        CodeOperation GetById(int id);
        CodeOperation AddCodeOperation(CodeOperation codeOperation);
        void DeleteCodeOperation(CodeOperation codeOperation);
        CodeOperation UpdateCodeOperation(CodeOperation codeOperation);
    }
}
