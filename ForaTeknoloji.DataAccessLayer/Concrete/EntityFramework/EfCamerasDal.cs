using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfCamerasDal : EfEntityRepositoryBase<Cameras, ForaContext>, ICamerasDal
    {
        public List<CamerasComplex> GetComplexCameras(Expression<Func<CamerasComplex, bool>> filter = null)
        {
            using (var context = new ForaContext())
            {

                var query = context.Cameras
                    .Join(context.PanelSettings,
                    cam => cam.Panel_ID,
                    pan => pan.Panel_ID,
                    (cam, pan) => new CamerasComplex
                    {
                        Kayit_No = cam.Kayit_No,
                        Kamera_No = cam.Kamera_No,
                        Kamera_Adi = cam.Kamera_Adi,
                        Kamera_Tipi = cam.Kamera_Tipi,
                        IP_Adres = cam.IP_Adres,
                        TCP_Port = cam.TCP_Port,
                        UDP_Port = cam.UDP_Port,
                        Kamera_Admin = cam.Kamera_Admin,
                        Kamera_Password = cam.Kamera_Password,
                        Aciklama = cam.Aciklama,
                        Geciste_Resim_Kayit = cam.Geciste_Resim_Kayit,
                        Geciste_Video_Kayit = cam.Geciste_Video_Kayit,
                        Antipassback_Resim_Kayit = cam.Antipassback_Resim_Kayit,
                        Antipassback_Video_Kayit = cam.Antipassback_Video_Kayit,
                        Engellenen_Resim_Kayit = cam.Engellenen_Resim_Kayit,
                        Engellenen_Video_Kayit = cam.Engellenen_Video_Kayit,
                        Tanimsiz_Resim_Kayit = cam.Tanimsiz_Resim_Kayit,
                        Tanimsiz_Video_Kayit = cam.Tanimsiz_Video_Kayit,
                        Panel_ID = cam.Panel_ID,
                        Kapi_ID = cam.Kapi_ID,
                        Panel_Name = pan.Panel_Name
                    });

                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }

        }





    }
}
