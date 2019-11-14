using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GroupMasterCreateViewModel
    {
        public int Grup_No { get; set; }
        public IEnumerable<SelectListItem> Grup_Icerdeki_Kisi_Sayisi_Global_Bolge_No { get; set; }
        public IEnumerable<SelectListItem> Grup_Gecis_Sayisi_Global_Bolge_No { get; set; }
    }
}