using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class TimeGroupsListViewModel
    {
        public List<EfTimeGroupsDal.ComplexTimeGroups> TimeGroups { get; set; }
    }
}