using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class VisitorEditViewModel
    {
        public Visitors Ziyaretci { get; set; }
        public Users Personel { get; set; }
        public List<PersonelList> Personeller { get; internal set; }
        public List<Users> VisitorCardList { get; internal set; }
        public string GrupAdi { get; internal set; }
    }
}