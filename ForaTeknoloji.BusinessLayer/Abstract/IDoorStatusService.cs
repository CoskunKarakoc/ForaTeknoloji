using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDoorStatusService
    {
        List<DoorStatus> GetAllDoorStatus(Expression<Func<DoorStatus, bool>> filter = null);
        DoorStatus GetById(int Kayit_No);
        DoorStatus AddDoorStatus(DoorStatus doorStatus);
        void DeleteDoorStatus(DoorStatus doorStatus);
        DoorStatus UpdateDoorStatus(DoorStatus doorStatus);
        List<ComplexDoorStatus> ComplexDoorStatuses();
    }
}
