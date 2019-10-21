using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class UsersListViewModel
    {
        public List<EfUserDal.ComplexUser> Users { get; set; }
        public int StatusControl { get; set; }
    }
}