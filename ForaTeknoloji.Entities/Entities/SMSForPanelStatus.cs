using ForaTeknoloji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("SMSForPanelStatus")]
    public partial class SMSForPanelStatus : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Phone Number")]
        [StringLength(50)]
        public string Phone_Number { get; set; }
    }
}
