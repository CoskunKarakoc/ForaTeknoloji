using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
