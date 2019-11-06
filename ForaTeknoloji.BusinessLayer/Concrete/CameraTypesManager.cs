using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class CameraTypesManager : ICameraTypesService
    {
        private ICameraTypesDal _cameraTypesDal;
        public CameraTypesManager(ICameraTypesDal cameraTypesDal)
        {
            _cameraTypesDal = cameraTypesDal;
        }

        public CameraTypes AddCameraType(CameraTypes cameraTypes)
        {
            return _cameraTypesDal.Add(cameraTypes);
        }

        public void DeleteCameraType(CameraTypes cameraTypes)
        {
            _cameraTypesDal.Delete(cameraTypes);
        }

        public List<CameraTypes> GetAllCameraTypes(Expression<Func<CameraTypes, bool>> filter = null)
        {
            return filter == null ? _cameraTypesDal.GetList() : _cameraTypesDal.GetList(filter);
        }

        public CameraTypes GetById(int Kamera_Tipi)
        {
            return _cameraTypesDal.Get(x => x.Kamera_Tipi == Kamera_Tipi);
        }

        public CameraTypes UpdateCameraType(CameraTypes cameraTypes)
        {
            return _cameraTypesDal.Update(cameraTypes);
        }
    }
}
