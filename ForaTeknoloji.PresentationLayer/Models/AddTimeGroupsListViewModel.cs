using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AddTimeGroupsListViewModel
    {
       
        public IEnumerable<SelectListItem> Gecis_Sinirlama_Tipi { get; set; }
        public int Zaman_Grup_No { get; internal set; }
    }
}