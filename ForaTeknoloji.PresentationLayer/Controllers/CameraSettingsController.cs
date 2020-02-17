using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class CameraSettingsController : Controller
    {
        private ICamerasService _camerasService;
        private ICameraTypesService _cameraTypesService;
        private IPanelSettingsService _panelSettingsService;
        private IAccessDatasService _accessDatasService;
        private IProgInitService _progInitService;
        public DBUsers user;
        public CameraSettingsController(ICamerasService camerasService, ICameraTypesService cameraTypesService, IPanelSettingsService panelSettingsService, IAccessDatasService accessDatasService, IProgInitService progInitService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _camerasService = camerasService;
            _cameraTypesService = cameraTypesService;
            _panelSettingsService = panelSettingsService;
            _accessDatasService = accessDatasService;
            _progInitService = progInitService;
        }


        // GET: CameraSettings
        public ActionResult Index()
        {
            var cameras = _camerasService.GetAllCamerasComplex();
            return View(cameras);
        }



        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Cameras cameras = _camerasService.GetById(id);
                if (cameras == null)
                {
                    return RedirectToAction("Index");
                }
                _camerasService.DeleteCamera(cameras);
                _accessDatasService.AddOperatorLog(152, user.Kullanici_Adi, cameras.Kamera_No, 0, 0, 0);
                RouteValueCheck();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            List<int> kapiListesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Cameras cameras = _camerasService.GetById((int)id);
            if (cameras == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kamera_Tipi = new SelectList(_cameraTypesService.GetAllCameraTypes(), "Kamera_Tipi", "Adi", cameras.Kamera_Tipi);
            ViewBag.Panel_ID = new SelectList(_panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0), "Panel_ID", "Panel_Name", cameras.Panel_ID);
            ViewBag.Kapi_ID = new SelectList(kapiListesi, cameras.Kapi_ID);
            return View(cameras);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cameras cameras)
        {
            if (ModelState.IsValid)
            {
                _camerasService.UpdateCamera(cameras);
                _accessDatasService.AddOperatorLog(151, user.Kullanici_Adi, cameras.Kamera_No, 0, 0, 0);
                RouteValueCheck();
                return RedirectToAction("Index");
            }
            return View(cameras);
        }


        public ActionResult Create()
        {
            List<int> kapiListesi = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            int MaxID;
            if (_camerasService.GetAllCameras().Count == 0)
                MaxID = 0;
            else
                MaxID = _camerasService.GetAllCameras().Max(x => x.Kamera_No);

            var Kameralar = _cameraTypesService.GetAllCameraTypes();
            var Paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            var model = new CameraAddListViewModel
            {
                Kamera_No = MaxID + 1,
                Kamera_Tipi = Kameralar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Kamera_Tipi.ToString()
                }),
                Panel_ID = Paneller.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Kapi_ID = kapiListesi
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cameras cameras)
        {
            if (ModelState.IsValid)
            {
                _camerasService.AddCamera(cameras);
                _accessDatasService.AddOperatorLog(150, user.Kullanici_Adi, cameras.Kamera_No, 0, 0, 0);
                RouteValueCheck();
                return RedirectToAction("Index");
            }
            return View(cameras);
        }


        private void RouteValueCheck()
        {
            var entity = _progInitService.GetAllProgInit().FirstOrDefault();
            if (entity != null)
            {
                if (entity.RouteValue == "" || entity.RouteValue == null)
                {
                    entity.RouteValue = Server.MapPath("~/Canli_Images");
                    _progInitService.UpdateProgInit(entity);
                }
            }
            else
            {
                ProgInit progInit = new ProgInit();
                progInit.RouteValue = Server.MapPath("~/Canli_Images");
                _progInitService.AddProgInit(progInit);
            }
        }






    }
}