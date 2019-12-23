using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IDoorStatusDal : IEntityRepository<DoorStatus>
    {
        List<ComplexDoorStatus> ComplexDoorStatus();
    }
}
