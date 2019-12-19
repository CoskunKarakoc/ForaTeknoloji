using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class TimeGroupsListViewModel
    {
        public List<EfTimeGroupsDal.ComplexTimeGroups> TimeGroups { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}