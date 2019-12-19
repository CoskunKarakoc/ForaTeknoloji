using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class TaskTableListViewModel
    {
        public IEnumerable<SelectListItem> Panel { get; set; }
        public IEnumerable<SelectListItem> Durum { get; set; }
        public IEnumerable<SelectListItem> Gorev { get; set; }
        public List<TaskStatusWatch> Liste { get; internal set; }
    }
}