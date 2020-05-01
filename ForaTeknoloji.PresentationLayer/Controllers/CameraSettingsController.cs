using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
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
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IDBUsersKapiService _dBUsersKapiService;
        public DBUsers user;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbDoorList;
        List<int> dbSirketList;
        public CameraSettingsController(ICamerasService camerasService, ICameraTypesService cameraTypesService, IPanelSettingsService panelSettingsService, IAccessDatasService accessDatasService, IProgInitService progInitService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService, IReaderSettingsNewService readerSettingsNewService, IDBUsersKapiService dBUsersKapiService)
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
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            _readerSettingsNewService = readerSettingsNewService;
            _dBUsersKapiService = dBUsersKapiService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbDoorList = new List<int>();
            dbSirketList = new List<int>();
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanList.Add((int)dbUserDepartmanNo);
            }
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserDoorNo in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Kapi_Kayit_No))
            {
                dbDoorList.Add((int)dbUserDoorNo);
            }
            foreach (var dbUserSirketNo in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Sirket_No))
            {
                dbSirketList.Add((int)dbUserSirketNo);
            }
        }


        // GET: CameraSettings
        public ActionResult Index()
        {
            var cameras = _camerasService.GetAllCamerasComplex(x => dbPanelList.Contains((int)x.Panel_ID));
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
            List<ReaderSettingsNew> kapiListesi = new List<ReaderSettingsNew>();
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Cameras cameras = _camerasService.GetById((int)id);
            if (cameras == null)
            {
                return HttpNotFound();
            }
            var panelModel = _panelSettingsService.GetById((int)cameras.Panel_ID).Panel_Model;
            if (panelModel == (int)PanelModel.Panel_301)
                kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == cameras.Panel_ID && x.WKapi_ID <= 8 && dbDoorList.Contains(x.Kayit_No));
            else if (panelModel == (int)PanelModel.Panel_302)
                kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == cameras.Panel_ID && x.WKapi_ID <= 2 && dbDoorList.Contains(x.Kayit_No));
            else if (panelModel == (int)PanelModel.Panel_304)
                kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == cameras.Panel_ID && x.WKapi_ID <= 4 && dbDoorList.Contains(x.Kayit_No));
            else
                kapiListesi = _readerSettingsNewService.GetAllReaderSettingsNew(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID == cameras.Panel_ID && x.WKapi_ID <= 1 && dbDoorList.Contains(x.Kayit_No));

            ViewBag.Kamera_Tipi = new SelectList(_cameraTypesService.GetAllCameraTypes(), "Kamera_Tipi", "Adi", cameras.Kamera_Tipi);
            ViewBag.Panel_ID = new SelectList(_panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && dbPanelList.Contains((int)x.Panel_ID)), "Panel_ID", "Panel_Name", cameras.Panel_ID);
            ViewBag.Kapi_ID = new SelectList(kapiListesi, "WKapi_ID", "WKapi_Adi", cameras.Kapi_ID);
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
            List<int> kapiListesi = new List<int> { };
            int MaxID;
            if (_camerasService.GetAllCameras().Count == 0)
                MaxID = 0;
            else
                MaxID = _camerasService.GetAllCameras().Max(x => x.Kamera_No);

            var Kameralar = _cameraTypesService.GetAllCameraTypes();
            var Paneller = _panelSettingsService.GetAllPanelSettings(x => dbPanelList.Contains((int)x.Panel_ID) && x.Panel_ID != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            ViewBag.Kapi_ID = new SelectList(kapiListesi);
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



        public ActionResult KapiListesi(int? Paneller)
        {
            if (Paneller != 0 && Paneller != null)
            {
                var panelModel = _panelSettingsService.GetById((int)Paneller).Panel_Model;
                List<ReaderSettingsNew> list = new List<ReaderSettingsNew>();
                if (panelModel == (int)PanelModel.Panel_301)
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 8 && dbDoorList.Contains(x.Kayit_No));
                else if (panelModel == (int)PanelModel.Panel_302)
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 2 && dbDoorList.Contains(x.Kayit_No));
                else if (panelModel == (int)PanelModel.Panel_304)
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 4 && dbDoorList.Contains(x.Kayit_No));
                else
                    list = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == Paneller && x.WKapi_ID <= 1 && dbDoorList.Contains(x.Kayit_No));

                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Kapı Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectKapi = list.Select(a => new SelectListItem
                    {
                        Text = a.WKapi_Adi,
                        Value = a.WKapi_ID.ToString()
                    });
                    return Json(selectKapi, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
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