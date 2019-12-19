using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IFloorNamesService
    {
        List<FloorNames> GetAllFloorNames(Expression<Func<FloorNames, bool>> filter = null);
        FloorNames GetById(int Kat_No);
        FloorNames AddFloorName(FloorNames floorNames);
        void DeleteFloorName(FloorNames floorNames);
        FloorNames UpdateFloorName(FloorNames floorNames);
        FloorNames GetByFloorName(string Kat_Adi);
    }
}
