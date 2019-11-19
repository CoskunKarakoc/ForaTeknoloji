using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class UsersListViewModel
    {
        public List<EfUserDal.ComplexUser> Users { get; set; }
        public int StatusControl { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}