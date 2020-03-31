using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class RefectoryListViewModel
    {
        public IEnumerable<SelectListItem> Group_ID { get; set; }
        public List<YemekhaneComplex> YemekhaneListe { get; internal set; }
        public IEnumerable<SelectListItem> Panel_ID { get; internal set; }
        public List<YemekhaneComplexTotal> ToplamGecis { get; internal set; }
        public EMailSetting EmailSettings { get; internal set; }
        public DBUsers User { get; internal set; }
        public IEnumerable<SelectListItem> Departman_No { get; internal set; }
    }
}