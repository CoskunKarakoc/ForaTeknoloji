using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class CamerasManager : ICamerasService
    {
        private ICamerasDal _camerasDal;
        public CamerasManager(ICamerasDal camerasDal)
        {
            _camerasDal = camerasDal;
        }
        public Cameras AddCamera(Cameras cameras)
        {
            return _camerasDal.Add(cameras);
        }

        public void DeleteCamera(Cameras cameras)
        {
            _camerasDal.Delete(cameras);
        }

        public List<Cameras> GetAllCameras()
        {
            return _camerasDal.GetList();
        }

        public Cameras GetById(int id)
        {
            return _camerasDal.Get(x => x.Kamera_No == id);
        }

        public Cameras UpdateCamera(Cameras cameras)
        {
            return _camerasDal.Update(cameras);
        }
    }
}
