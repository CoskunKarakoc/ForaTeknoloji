using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class PanelController : Controller
    {
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IReportService _reportService;
        private IAccessDatasService _accessDatasService;
        private ITaskListService _taskListService;
        private IReaderSettingsNewMSService _readerSettingsNewMSService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersKapiService _dBUsersKapiService;
        public DBUsers user = CurrentSession.User;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbDoorList;
        List<int> dbSirketList;
        public PanelController(IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService, IDBUsersPanelsService dBUsersPanelsService, IReportService reportService, IAccessDatasService accessDatasService, ITaskListService taskListService, IReaderSettingsNewMSService readerSettingsNewMSService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersKapiService dBUsersKapiService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}
            _panelSettingsService = panelSettingsService;
            _readerSettingsNewService = readerSettingsNewService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _reportService = reportService;
            _accessDatasService = accessDatasService;
            _taskListService = taskListService;
            _readerSettingsNewMSService = readerSettingsNewMSService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
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
            };
        }


        public ActionResult ReaderEdit(int PanelID, int id = -1)
        {
            if (id != -1)
            {
                List<int> role = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                List<int> lokalBolge = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
                List<int> userCount = new List<int> { 2, 3, 4, 5, 6 };
                var model = _readerSettingsNewService.GetByKapiANDPanel(id, PanelID);
                ViewBag.WKapi_Role_No = new SelectList(role, model.WKapi_Role_No);
                ViewBag.WKapi_Lokal_Bolge = new SelectList(lokalBolge, model.WKapi_Lokal_Bolge);
                ViewBag.WKapi_User_Count = new SelectList(userCount, model.WKapi_User_Count);
                ViewBag.WKapi_Harici_Alarm_Rolesi = new SelectList(role, model.WKapi_Harici_Alarm_Rolesi);
                return View(model);
            }
            return RedirectToAction("ReaderList");
        }

        [HttpPost]
        public ActionResult ReaderEdit(ReaderSettingsNew readerSettingsNew)
        {
            if (ModelState.IsValid)
            {
                _readerSettingsNewService.UpdateReaderSettingsNew(readerSettingsNew);
                return RedirectToAction("ReaderList", new { PanelID = readerSettingsNew.Panel_ID });
            }
            return View(readerSettingsNew);
        }


        public ActionResult ReaderList(int? PanelID)
        {
            ReaderFill();

            if (user.SysAdmin == false)
                throw new Exception("Yetkisiz Erişim!");


            if (_panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0).Count == 0)
                throw new Exception("Sistemde kayıtlı panel bulunamadı");
            List<ReaderSettingsNew> okuyucular = new List<ReaderSettingsNew>();
            if (PanelID == null)
            {
                PanelID = _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0).OrderBy(x => x.Kayit_No).FirstOrDefault().Panel_ID;
                okuyucular = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID && dbDoorList.Contains(x.Kayit_No)).OrderBy(x => x.WKapi_ID).ToList();
            }
            else
            {
                okuyucular = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID && dbDoorList.Contains(x.Kayit_No)).OrderBy(x => x.WKapi_ID).ToList();
            }
            if (okuyucular == null)
                throw new Exception("Bu panele ait okuyucu bulunmamaktadır.");
            var panelModel = _panelSettingsService.GetAllPanelSettings().FirstOrDefault(x => x.Panel_ID == PanelID).Panel_Model;
            var model = new ReaderEditViewModel
            {
                Paneller = _panelSettingsService.GetAllPanelSettings(x => x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0), // _reportService.PanelListesi(user),
                Okuyucular = okuyucular.OrderBy(x => x.WKapi_ID).ToList(),
                Panel_ID = PanelID,
                PanelModel = panelModel
            };



            return View(model);
        }


        public ActionResult SendToPanel(int? Panel)
        {
            try
            {
                //TaskList taskList = new TaskList
                //{
                //    Deneme_Sayisi = 1,
                //    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                //    Gorev_Kodu = (int)CommandConstants.CMD_SND_GENERALSETTINGS,
                //    IntParam_1 = (int)Panel,
                //    Kullanici_Adi = user.Kullanici_Adi,
                //    Panel_No = Panel,
                //    Tablo_Guncelle = true,
                //    Tarih = DateTime.Now
                //};
                //TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                #region FortigatePanelAyarları
                if (_panelSettingsService.GetById((int)Panel).Panel_Model == (int)PanelModel.Panel_1010)
                {
                    TaskList taskListms = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_SND_GENERALSETTINGS,
                        IntParam_1 = (int)Panel,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = Panel,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceiveMS = _taskListService.AddTaskList(taskListms);
                }
                else
                {
                    TaskList taskList3 = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_SND_GENERALSETTINGS_3,
                        IntParam_1 = (int)Panel,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = Panel,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive3 = _taskListService.AddTaskList(taskList3);
                    TaskList taskList2 = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_SND_GENERALSETTINGS_2,
                        IntParam_1 = (int)Panel,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = Panel,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive2 = _taskListService.AddTaskList(taskList2);
                    TaskList taskList1 = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_SND_GENERALSETTINGS_1,
                        IntParam_1 = (int)Panel,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = Panel,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive1 = _taskListService.AddTaskList(taskList1);
                }

                #endregion
                _accessDatasService.AddOperatorLog(134, user.Kullanici_Adi, 0, 0, Panel, 0);
            }
            catch (Exception)
            {
                throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
            }
            return RedirectToAction("ReaderList", new { @PanelID = Panel });
        }

        public ActionResult ReceiveFromPanel(int? PanelID)
        {
            if (PanelID != null)
            {
                try
                {
                    //TaskList taskList = new TaskList
                    //{
                    //    Deneme_Sayisi = 1,
                    //    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                    //    Gorev_Kodu = (int)CommandConstants.CMD_RCV_GENERALSETTINGS,
                    //    IntParam_1 = (int)PanelID,
                    //    Kullanici_Adi = user.Kullanici_Adi,
                    //    Panel_No = PanelID,
                    //    Tablo_Guncelle = true,
                    //    Tarih = DateTime.Now
                    //};
                    //TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    #region FortigatePanelAyarlarıAlma
                    if (_panelSettingsService.GetById((int)PanelID).Panel_Model == (int)PanelModel.Panel_1010)
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_RCV_GENERALSETTINGS,
                            IntParam_1 = (int)PanelID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = PanelID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    else
                    {

                        TaskList taskList1 = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_RCV_GENERALSETTINGS_1,
                            IntParam_1 = (int)PanelID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = PanelID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive1 = _taskListService.AddTaskList(taskList1);
                        TaskList taskList2 = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_RCV_GENERALSETTINGS_2,
                            IntParam_1 = (int)PanelID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = PanelID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive2 = _taskListService.AddTaskList(taskList2);
                        TaskList taskList3 = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_RCV_GENERALSETTINGS_3,
                            IntParam_1 = (int)PanelID,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = PanelID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive3 = _taskListService.AddTaskList(taskList3);
                    }
                    #endregion
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
                return RedirectToAction("ReaderList", new { @PanelID = PanelID });
            }
            throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
        }


        public ActionResult AllReaderActive(int? PanelID)
        {
            if (PanelID != null)
            {
                var readers = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID);
                foreach (var reader in readers)
                {
                    reader.WKapi_Aktif = true;
                    _readerSettingsNewService.UpdateReaderSettingsNew(reader);
                }
                return RedirectToAction("ReaderList", new { @PanelID = PanelID });
            }
            throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
        }



        public ActionResult ReaderEditMS(int Wid, int MSPanelID)
        {
            var entity = _readerSettingsNewMSService.GetByKapiANDPanel(Wid, MSPanelID);
            var readerSettings = _readerSettingsNewService.GetByKapiANDPanel(Wid, MSPanelID);
            var model = new ReaderEditMS1010ViewModel
            {
                ReaderSettingsNewMSEntity = entity,
                ReaderSettingsEntity = readerSettings
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ReaderEditMS(ReaderSettingsNewMS readerSettingsNewMS, bool? WKapi_Aktif, string WKapi_Adi)
        {

            if (ModelState.IsValid)
            {
                _readerSettingsNewMSService.UpdateReaderSettingsNew(readerSettingsNewMS);
                var updatedReader = _readerSettingsNewService.GetByKapiANDPanel(1, (int)readerSettingsNewMS.Panel_ID);
                updatedReader.WKapi_Aktif = WKapi_Aktif;
                updatedReader.WKapi_Adi = WKapi_Adi;
                _readerSettingsNewService.UpdateReaderSettingsNew(updatedReader);
                return RedirectToAction("ReaderList", new { PanelID = readerSettingsNewMS.Panel_ID });

            }
            return View(readerSettingsNewMS);
        }

        private void ReaderFill()
        {
            var PanelList = _panelSettingsService.GetAllPanelSettings(x => x.Panel_ID != 0 && x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            foreach (var item in PanelList)
            {
                var entity = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == item.Panel_ID).OrderBy(x => x.WKapi_ID).ToList();
                if (entity == null || entity.Count == 0)
                {
                    for (int i = 1; i < 17; i++)
                    {
                        ReaderSettingsNew readerSettingsNew = new ReaderSettingsNew
                        {
                            Panel_ID = item.Panel_ID,
                            Panel_Name = item.Panel_Name,
                            Seri_No = item.Seri_No,
                            Sira_No = item.Sira_No,
                            WKapi_Acik_Sure = 20,
                            WKapi_Adi = "Kapi " + i,
                            WKapi_Alarm_Modu = false,
                            WKapi_Gecis_Modu = 1,
                            WKapi_Harici_Alarm_Rolesi = 1,
                            WKapi_ID = i,
                            WKapi_Itme_Gecikmesi = 1,
                            WKapi_Kapi_Tipi = 1,
                            WKapi_Lokal_Bolge = 1,
                            WKapi_Role_No = i,
                            WKapi_User_Count = 2,
                            WKapi_WIGType = 1,
                            WKapi_Acik_Sure_Alarmi = false,
                            WKapi_Acilma_Alarmi = false,
                            WKapi_Aktif = false,
                            WKapi_Ana_Alarm_Rolesi = false,
                            WKapi_Coklu_Onay = false,
                            WKapi_Lift_Aktif = false,
                            WKapi_Panik_Buton_Alarmi = false,
                            WKapi_Pin_Dogrulama = false,
                            WKapi_Yangin_Modu = false,
                            WKapi_Sirali_Gecis_Ana_Kapi = false,
                            WKapi_Zorlama_Alarmi = false
                        };
                        _readerSettingsNewService.AddReaderSettingsNew(readerSettingsNew);
                    }
                }
            }
        }



    }
}