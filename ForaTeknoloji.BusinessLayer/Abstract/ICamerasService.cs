using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ICamerasService
    {
        List<Cameras> GetAllCameras(Expression<Func<Cameras, bool>> filter = null);
        Cameras GetById(int Kamera_No);
        Cameras AddCamera(Cameras cameras);
        void DeleteCamera(Cameras cameras);
        Cameras UpdateCamera(Cameras cameras);
        List<CamerasComplex> GetAllCamerasComplex(Expression<Func<CamerasComplex, bool>> filter = null);
    }
}
