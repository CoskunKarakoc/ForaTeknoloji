using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_IlkGirisSonCikisListViewModel
    {
        public List<GelenGelmeyen_IlkGirisSonCikis> IlkGirisSonCikis { get; set; }
        public List<Users> Kullanicilar { get; set; }
        public IEnumerable<SelectListItem> Departmanlar { get; set; }
        public IEnumerable<SelectListItem> Sirketler { get; set; }
        public IEnumerable<SelectListItem> Groupsdetail { get; set; }
        public IEnumerable<SelectListItem> Global_Bolge_Adi { get; set; }
    }
}