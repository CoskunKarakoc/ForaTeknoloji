using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class UsersListViewModel
    {
        public List<EfUserDal.ComplexUser> Users { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}