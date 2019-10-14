using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class KullaniciListViewModelModel
    {
        public EfUserDal.ComplexUser ComplexUser { get; set; }
        public IEnumerable<SelectListItem> Departmanlar { get; set; }
    }
}