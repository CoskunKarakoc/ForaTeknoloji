using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class KullaniciListViewModelModel
    {
      
        public IEnumerable<SelectListItem> Departmanlar { get; set; }
        public IEnumerable<SelectListItem> Sirket { get; internal set; }
        public IEnumerable<SelectListItem> Bloklar { get; internal set; }
        public IEnumerable<SelectListItem> KullaniciTipi { get; internal set; }
        public IEnumerable<SelectListItem> GroupMaster { get; internal set; }
        public Users User { get; internal set; }
    }
}