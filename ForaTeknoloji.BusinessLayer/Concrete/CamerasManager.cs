using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<Cameras> GetAllCameras(Expression<Func<Cameras, bool>> filter = null)
        {
            return filter == null ? _camerasDal.GetList() : _camerasDal.GetList(filter);
        }

        public List<CamerasComplex> GetAllCamerasComplex(Expression<Func<CamerasComplex, bool>> filter = null)
        {
            return filter == null ? _camerasDal.GetComplexCameras() : _camerasDal.GetComplexCameras(filter);
        }

        public Cameras GetById(int Kamera_No)
        {
            return _camerasDal.Get(x => x.Kamera_No == Kamera_No);
        }

        public Cameras UpdateCamera(Cameras cameras)
        {
            return _camerasDal.Update(cameras);
        }
    }
}
