using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class CreateVisitorViewModel
    {
        public IEnumerable<SelectListItem> Grup_No { get; set; }
        public List<Users> Personeller { get; set; }
        public List<Users> Ziyaretciler { get; set; }
        public List<EfUserDal.ComplexUser> ComplexPersoneller { get; internal set; }
        public List<Users> VisitorCardList { get; internal set; }
    }
}