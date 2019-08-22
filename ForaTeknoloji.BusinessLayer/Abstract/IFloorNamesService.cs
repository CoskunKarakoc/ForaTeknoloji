using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IFloorNamesService
    {

        List<FloorNames> GetAllFloorNames();
        FloorNames GetById(int id);
        FloorNames AddFloorName(FloorNames floorNames);
        void DeleteFloorName(FloorNames floorNames);
        FloorNames UpdateFloorName(FloorNames floorNames);
    }
}
