using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_IlkGirisSonCikisListViewModel
    {
        public List<GelenGelmeyen_IlkGirisSonCikis> IlkGirisSonCikis { get; set; }
        public IEnumerable<SelectListItem> Departman { get; set; }
        public IEnumerable<SelectListItem> Sirket { get; set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
        public List<EfUserDal.ComplexUser> KullaniciComplex { get; internal set; }
    }
}