using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class PanelConnectionSMSViewModel
    {
        public SMSSetting SMS { get; set; }
        public List<EfUserDal.ComplexUser> Kullanicilar { get; set; }
    }
}