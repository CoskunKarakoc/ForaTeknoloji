using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class OperatorLogListViewModel
    {
        public IEnumerable<SelectListItem> Kullanici_Adi { get; set; }
        public IEnumerable<SelectListItem> Code_Operation { get; set; }
        public List<OperatorLogComplex> OperatorLogList { get; set; }
    }
}