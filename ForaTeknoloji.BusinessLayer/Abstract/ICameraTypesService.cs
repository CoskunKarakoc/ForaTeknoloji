using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ICameraTypesService
    {
        List<CameraTypes> GetAllCameraTypes(Expression<Func<CameraTypes, bool>> filter = null);
        CameraTypes GetById(int Kamera_Tipi);
        CameraTypes AddCameraType(CameraTypes cameraTypes);
        void DeleteCameraType(CameraTypes cameraTypes);
        CameraTypes UpdateCameraType(CameraTypes cameraTypes);
    }
}
