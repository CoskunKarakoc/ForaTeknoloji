using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class CreateVisitorViewModel
    {
        public IEnumerable<SelectListItem> Grup_No { get; set; }
        public List<Users> Personeller { get; set; }
        public List<Users> Ziyaretciler { get; set; }
        public List<PersonelList> ComplexPersoneller { get; internal set; }
        public List<Users> VisitorCardList { get; internal set; }
    }
}