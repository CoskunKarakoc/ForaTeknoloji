using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class UserDoorToWatchListViewModel
    {
        public IEnumerable<SelectListItem> Panel_ID { get; internal set; }
        public string Kullanici_Adi { get; internal set; }
    }
}