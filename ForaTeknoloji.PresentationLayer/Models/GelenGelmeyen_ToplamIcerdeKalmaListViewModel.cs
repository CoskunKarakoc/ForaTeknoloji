using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_ToplamIcerdeKalmaListViewModel
    {
        public List<GelenGelmeyen_ToplamIcerdeKalma> ToplamIcerdeKalma { get; set; }
        public IEnumerable<SelectListItem> Departmanlar { get; set; }
        public IEnumerable<SelectListItem> Sirketler { get; set; }
        public IEnumerable<SelectListItem> Groupsdetail { get; set; }
        public IEnumerable<SelectListItem> Global_Bolge_Adi { get; set; }
        public List<EfUserDal.ComplexUser> KullaniciComplex { get; internal set; }
    }
}