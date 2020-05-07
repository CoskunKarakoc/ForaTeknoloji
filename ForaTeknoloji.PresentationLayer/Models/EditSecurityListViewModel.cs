using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class EditSecurityListViewModel
    {
        public DBUsers Kullanicilar { get; set; }
        public List<DBUsersPanels> UserPanelList { get; internal set; }
        public List<PanelSettings> PanelList { get; internal set; }
        public List<DBUsersSirket> UserSirketList { get; internal set; }
        public List<Sirketler> SirketList { get; internal set; }
        public List<DBUsersDepartman> UserDepartmanList { get; internal set; }
        public List<Departmanlar> DepartmanList { get; internal set; }
        public List<DBUsersAltDepartman> DBUserAltDepartman { get; internal set; }
        public List<AltDepartman> AltDepartmanListesi { get; internal set; }
        public List<Bolum> BolumListesi { get; internal set; }
        public List<DBUsersBolum> UserBolumList { get; internal set; }
    }
}