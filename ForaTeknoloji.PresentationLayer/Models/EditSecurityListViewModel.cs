using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class EditSecurityListViewModel
    {
        public DBUsers Kullanicilar { get; set; }
        public List<DBUsersPanels> UserPanelList { get; internal set; }
        public List<PanelSettings> PanelList { get; internal set; }
        public List<DBUsersSirket> UserSirketList { get; internal set; }
        public List<Sirketler> SirketList { get; internal set; }
    }
}