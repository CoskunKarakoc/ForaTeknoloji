using System.Collections.Generic;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class WatchIndexViewModel
    {
        public List<WatchEntityComplex> ComplexAccessDatas { get; internal set; }
        public WatchEntityComplex LastRecordWatch { get; internal set; }
        public WatchParameters WatchParam { get; internal set; }
    }
}