using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class OperatorKapiController : Controller
    {
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IDBUsersKapiService _dBUsersKapiService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        public OperatorKapiController(IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService, IDBUsersKapiService dBUsersKapiService, IDBUsersPanelsService dBUsersPanelsService)
        {
            _panelSettingsService = panelSettingsService;
            _readerSettingsNewService = readerSettingsNewService;
            _dBUsersKapiService = dBUsersKapiService;
            _dBUsersPanelsService = dBUsersPanelsService;
        }



        // GET: OperatorKapi
        public ActionResult Index(string KullaniciAdi)
        {
            var model = new OperatorKapiViewModel
            {
                KullaniciAdi = KullaniciAdi
            };

            return View(model);
        }



        public ActionResult ReaderList(string kullaniciAdi)
        {
            List<int> userReaderID = new List<int>();
            List<ReaderSettingsNew> readerList = new List<ReaderSettingsNew>();
            foreach (var readerID in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userReaderID.Add((int)readerID.Kapi_Kayit_No);
            }

            foreach (var reader in _readerSettingsNewService.GetAllReaderSettingsNew(x => !userReaderID.Contains(x.Kayit_No)))
            {
                var panelModel = _panelSettingsService.GetById((int)reader.Panel_ID).Panel_Model;
                if (panelModel == (int)PanelModel.Panel_1010)
                {
                    if (reader.WKapi_ID == 1)
                    {
                        readerList.Add(reader);
                    }
                }
                else if (panelModel == (int)PanelModel.Panel_301)
                {
                    if (reader.WKapi_ID <= 8)
                    {
                        readerList.Add(reader);
                    }
                }
                else if (panelModel == (int)PanelModel.Panel_302)
                {
                    if (reader.WKapi_ID <= 2)
                    {
                        readerList.Add(reader);
                    }
                }
                else
                {
                    if (reader.WKapi_ID <= 4)
                    {
                        readerList.Add(reader);
                    }
                }
            }

            return Json(readerList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserReaderID(string kullaniciAdi)
        {
            List<int> userReaderID = new List<int>();
            List<ReaderSettingsNew> readerList = new List<ReaderSettingsNew>();
            foreach (var readerID in _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == kullaniciAdi))
            {
                userReaderID.Add((int)readerID.Kapi_Kayit_No);
            }

            foreach (var reader in _readerSettingsNewService.GetAllReaderSettingsNew(x => userReaderID.Contains(x.Kayit_No)))
            {
                var panelModel = _panelSettingsService.GetById((int)reader.Panel_ID).Panel_Model;
                if (panelModel == (int)PanelModel.Panel_1010)
                {
                    if (reader.WKapi_ID == 1)
                    {
                        readerList.Add(reader);
                    }
                }
                else if (panelModel == (int)PanelModel.Panel_301)
                {
                    if (reader.WKapi_ID <= 8)
                    {
                        readerList.Add(reader);
                    }
                }
                else if (panelModel == (int)PanelModel.Panel_302)
                {
                    if (reader.WKapi_ID <= 2)
                    {
                        readerList.Add(reader);
                    }
                }
                else
                {
                    if (reader.WKapi_ID <= 4)
                    {
                        readerList.Add(reader);
                    }
                }
            }
            return Json(readerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddReader(int ReaderNo, string kullaniciAdi)
        {
            var reader = _readerSettingsNewService.GetByFilter(x => x.Kayit_No == ReaderNo);
            var addedDBUserReader = new DBUsersKapi
            {
                Kullanici_Adi = kullaniciAdi,
                Kapi_Kayit_No = ReaderNo,
                Panel_No = reader.Panel_ID
            };
            _dBUsersKapiService.AddDBUsersKapi(addedDBUserReader);
            if (!_dBUsersPanelsService.GetAllDBUsersPanels().Any(x => x.Panel_No == reader.Panel_ID && x.Kullanici_Adi == kullaniciAdi))
            {
                var addDBUsersPanel = new DBUsersPanels
                {
                    Kullanici_Adi = kullaniciAdi,
                    Panel_No = reader.Panel_ID
                };
                _dBUsersPanelsService.AddDBUsersPanels(addDBUsersPanel);
            }

            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveKapi(int ReaderNo, string kullaniciAdi)
        {
            var deletedDBUsersKapi = _dBUsersKapiService.GetByQuery(x => x.Kapi_Kayit_No == ReaderNo && x.Kullanici_Adi == kullaniciAdi);
            _dBUsersKapiService.DeleteDBUsersKapi(deletedDBUsersKapi);
            var userPanelList = _dBUsersKapiService.GetAllDBUsersKapi(x => x.Kullanici_Adi == kullaniciAdi).Select(a => a.Panel_No).Distinct().ToList();
            foreach (var dBUsersPanels in _dBUsersPanelsService.GetAllDBUsersPanels(x => !userPanelList.Contains(x.Panel_No) && x.Kullanici_Adi == kullaniciAdi))
            {
                _dBUsersPanelsService.DeleteDBUsersPanels(dBUsersPanels);
            }
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }





    }
}