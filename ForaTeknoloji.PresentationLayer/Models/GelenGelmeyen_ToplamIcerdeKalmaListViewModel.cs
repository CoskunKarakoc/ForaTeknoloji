using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_ToplamIcerdeKalmaListViewModel
    {
        public List<GelenGelmeyen_ToplamIcerdeKalma> ToplamIcerdeKalma { get; set; }
        public IEnumerable<SelectListItem> Departman { get; set; }
        public IEnumerable<SelectListItem> Sirket { get; set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
        public List<EfUserDal.ComplexUser> KullaniciComplex { get; internal set; }
    }
}