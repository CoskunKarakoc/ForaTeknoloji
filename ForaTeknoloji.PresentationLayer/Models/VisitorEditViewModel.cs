using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class VisitorEditViewModel
    {
        public Visitors Ziyaretci { get; set; }
        public Users Personel { get; set; }
        public List<EfUserDal.ComplexUser> Personeller { get; internal set; }
    }
}