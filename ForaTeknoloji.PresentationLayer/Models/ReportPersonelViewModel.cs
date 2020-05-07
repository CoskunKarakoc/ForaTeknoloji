using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ReportPersonelViewModel
    {
        public List<ReportPersonelList> ReportPersonel { get; internal set; }
        public List<PersonelList> Kullanıcı { get; internal set; }
        public List<ReportPersonelList> EskiKullanicilar { get; internal set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; internal set; }
        public IEnumerable<SelectListItem> Sirket { get; internal set; }
        public IEnumerable<SelectListItem> Blok { get; internal set; }
        public IEnumerable<SelectListItem> Departman { get; internal set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; internal set; }
        public IEnumerable<SelectListItem> Panel { get; internal set; }
        public IEnumerable<SelectListItem> AltDepartman { get; internal set; }
        public IEnumerable<SelectListItem> Unvan { get; internal set; }
        public IEnumerable<SelectListItem> Bolum { get; internal set; }
        public IEnumerable<SelectListItem> Birim_No { get; internal set; }
    }
}