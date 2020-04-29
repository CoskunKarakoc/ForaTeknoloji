using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_GelmeyenlerListViewModel
    {
        public IEnumerable<SelectListItem> Departman { get; set; }
        public IEnumerable<SelectListItem> Sirket { get; set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
        public List<GelenGelmeyen_Gelmeyen> Gelmeyenler { get; internal set; }
        public IEnumerable<SelectListItem> AltDepartman { get; internal set; }
        public IEnumerable<SelectListItem> Unvan { get; internal set; }
        public IEnumerable<SelectListItem> Bolum { get; internal set; }
        public DateTime? Saat { get; internal set; }
        public bool? ReportByHour { get; internal set; }
        public IEnumerable<SelectListItem> Birim_No { get; internal set; }
        public List<EfUserDal.ComplexUser> Kullanıcı { get; internal set; }
    }
}