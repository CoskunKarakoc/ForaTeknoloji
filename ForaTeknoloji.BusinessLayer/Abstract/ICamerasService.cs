using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ICamerasService
    {
        List<Cameras> GetAllCameras();
        Cameras GetById(int id);
        Cameras AddCamera(Cameras cameras);
        void DeleteCamera(Cameras cameras);
        Cameras UpdateCamera(Cameras cameras);
    }
}
