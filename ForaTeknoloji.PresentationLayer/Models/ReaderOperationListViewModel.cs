using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ReaderOperationListViewModel
    {
        public List<ReaderSettingsNew> ReaderList { get; set; }
        public int? PanelModeli { get; set; }
    }
}