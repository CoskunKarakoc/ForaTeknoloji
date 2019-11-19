using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class TimeGroupsListViewModel
    {
        public List<EfTimeGroupsDal.ComplexTimeGroups> TimeGroups { get; set; }
        public int StatusControl { get; internal set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}