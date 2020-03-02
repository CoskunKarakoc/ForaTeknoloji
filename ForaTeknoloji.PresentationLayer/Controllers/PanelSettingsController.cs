using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.DataTransferObjects;
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
    public class PanelSettingsController : Controller
    {
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsService _readerSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IReaderSettingsNewService _settingsNewService;
        private ITaskListService _taskListService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IGroupsDetailNewService _groupsDetailNewService;
        private IReportService _reportService;
        private IAccessDatasService _accessDatasService;
        private IDBUsersService _dBUsersService;
        private IDoorStatusService _doorStatusService;
        private IReaderSettingsNewMSService _readerSettingsNewMSService;
        public DBUsers user;
        DBUsers permissionUser;

        public PanelSettingsController(IPanelSettingsService panelSettingsService, IReaderSettingsService readerSettingsService, IGlobalZoneService globalZoneService, IReaderSettingsNewService settingsNewService, ITaskListService taskListService, IDBUsersPanelsService dBUsersPanelsService, IGroupsDetailNewService groupsDetailNewService, IReportService reportService, IAccessDatasService accessDatasService, IDBUsersService dBUsersService, IDoorStatusService doorStatusService, IReaderSettingsNewMSService readerSettingsNewMSService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _panelSettingsService = panelSettingsService;
            _readerSettingsService = readerSettingsService;
            _globalZoneService = globalZoneService;
            _settingsNewService = settingsNewService;
            _taskListService = taskListService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _groupsDetailNewService = groupsDetailNewService;
            _reportService = reportService;
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
            _doorStatusService = doorStatusService;
            _readerSettingsNewMSService = readerSettingsNewMSService;
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }

        public ActionResult Settings(int? PanelID)
        {
            if (PanelID == null)
            {
                var list = _reportService.PanelListesi(user);
                if (list.Count == 0)
                    throw new Exception("Sistemde Kayıtlı Herhangi Bir Panel Bulunamadı!");

                PanelID = list.FirstOrDefault().Panel_ID;
            }

            List<int> interlock = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            PanelSettings selectedpanel = _reportService.PanelListesi(user).Find(x => x.Panel_ID == PanelID);
            var readers = _settingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == selectedpanel.Panel_ID).FirstOrDefault();
            if (readers == null)
            {

                if (selectedpanel.Panel_Model == (int)PanelModel.Panel_1010)
                {
                    var readerMS1010 = _readerSettingsNewMSService.GetAllReaderSettingsNew().FirstOrDefault(x => x.Panel_ID == selectedpanel.Panel_ID);
                    if (readerMS1010 == null)
                    {
                        ReaderSettingsNewMS readerSettingsNewMS = new ReaderSettingsNewMS
                        {
                            Seri_No = selectedpanel.Seri_No,
                            Sira_No = selectedpanel.Sira_No,
                            Panel_ID = selectedpanel.Panel_ID,
                            Panel_Name = selectedpanel.Panel_Name,
                            WKapi_ID = 1,
                            New_Device_ID = selectedpanel.Panel_ID,
                            WKapi_Kapi_Tipi = 1,
                            WKapi_Kapi_Kontrol_Modu = 0,
                            WKapi_Kapi_Gecis_Modu = 0,
                            RS485_Reader_Type = 0,
                            LCD_Row_Message = selectedpanel.Panel_Name,
                            WKapi_Keypad_Status = false,
                            WKapi_Keypad_Menu_Password = 0,
                            RS485_Reader_Status = false,
                            Wiegand_Reader_Status = false,
                            Wiegand_Reader_Type = 0,
                            Mifare_Reader_Status = false,
                            Mifare_Kart_Data_Type = 0,
                            UDP_Haberlesme = false,
                            Multiple_Clock_Mode_Counter_Usage = false,
                            Pass_Counter_Auto_Delete_Cancel = false,
                            Access_Counter_Kontrol = false,
                            Turnstile_Arm_Tracking = false,
                            Kart_ID_32_Bit_Clear = false
                        };
                        _readerSettingsNewMSService.AddReaderSettingsNew(readerSettingsNewMS);
                    }

                    for (int i = 1; i < 17; i++)
                    {
                        ReaderSettingsNew readerSettingsNew = new ReaderSettingsNew
                        {
                            Panel_ID = selectedpanel.Panel_ID,
                            Panel_Name = selectedpanel.Panel_Name,
                            Seri_No = selectedpanel.Seri_No,
                            Sira_No = selectedpanel.Sira_No,
                            WKapi_ID = i,
                            WKapi_Adi = "Kapi " + i,
                            WKapi_Aktif = false,
                            WKapi_Zorlama_Alarmi = false,
                            WKapi_Yangin_Modu = false,
                            WKapi_Sirali_Gecis_Ana_Kapi = false,
                            WKapi_Ana_Alarm_Rolesi = false,
                            WKapi_Acik_Sure_Alarmi = false,
                            WKapi_Acilma_Alarmi = false,
                            WKapi_Coklu_Onay = false,
                            WKapi_Lift_Aktif = false,
                            WKapi_Pin_Dogrulama = false,
                            WKapi_Panik_Buton_Alarmi = false,
                            WKapi_WIGType = 1,
                            WKapi_Acik_Sure = 20,
                            WKapi_Alarm_Modu = false,
                            WKapi_Gecis_Modu = 0,
                            WKapi_Harici_Alarm_Rolesi = 1,
                            WKapi_Itme_Gecikmesi = 1,
                            WKapi_Lokal_Bolge = 1,
                            WKapi_Role_No = i,
                            WKapi_User_Count = 1,
                            WKapi_Kapi_Tipi = 1,
                        };
                        _settingsNewService.AddReaderSettingsNew(readerSettingsNew);
                    }


                }
                else
                {
                    for (int i = 1; i < 17; i++)
                    {
                        ReaderSettingsNew readerSettingsNew = new ReaderSettingsNew
                        {
                            Panel_ID = selectedpanel.Panel_ID,
                            Panel_Name = selectedpanel.Panel_Name,
                            Seri_No = selectedpanel.Seri_No,
                            Sira_No = selectedpanel.Sira_No,
                            WKapi_ID = i,
                            WKapi_Adi = "Kapi " + i,
                            WKapi_Aktif = false,
                            WKapi_Zorlama_Alarmi = false,
                            WKapi_Yangin_Modu = false,
                            WKapi_Sirali_Gecis_Ana_Kapi = false,
                            WKapi_Ana_Alarm_Rolesi = false,
                            WKapi_Acik_Sure_Alarmi = false,
                            WKapi_Acilma_Alarmi = false,
                            WKapi_Coklu_Onay = false,
                            WKapi_Lift_Aktif = false,
                            WKapi_Pin_Dogrulama = false,
                            WKapi_Panik_Buton_Alarmi = false,
                            WKapi_WIGType = 1,
                            WKapi_Acik_Sure = 20,
                            WKapi_Alarm_Modu = false,
                            WKapi_Gecis_Modu = 0,
                            WKapi_Harici_Alarm_Rolesi = 1,
                            WKapi_Itme_Gecikmesi = 1,
                            WKapi_Lokal_Bolge = 1,
                            WKapi_Role_No = i,
                            WKapi_User_Count = 1,
                            WKapi_Kapi_Tipi = 1,
                        };
                        _settingsNewService.AddReaderSettingsNew(readerSettingsNew);
                    }
                }





            }
            ViewBag.Panel_Global_Bolge1 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge1);
            ViewBag.Panel_Global_Bolge2 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge2);
            ViewBag.Panel_Global_Bolge3 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge3);
            ViewBag.Panel_Global_Bolge4 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge4);
            ViewBag.Panel_Global_Bolge5 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge5);
            ViewBag.Panel_Global_Bolge6 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge6);
            ViewBag.Panel_Global_Bolge7 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge7);
            ViewBag.Panel_Global_Bolge8 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi", selectedpanel.Panel_Global_Bolge8);
            ViewBag.LocalInterlock_G1_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G1_1);
            ViewBag.LocalInterlock_G1_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G1_2);
            ViewBag.LocalInterlock_G2_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G2_1);
            ViewBag.LocalInterlock_G2_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G2_2);
            ViewBag.LocalInterlock_G3_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G3_1);
            ViewBag.LocalInterlock_G3_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G3_2);
            ViewBag.LocalInterlock_G4_1 = new SelectList(interlock, selectedpanel.LocalInterlock_G4_1);
            ViewBag.LocalInterlock_G4_2 = new SelectList(interlock, selectedpanel.LocalInterlock_G4_2);
            return View(selectedpanel);


        }
        [HttpPost]
        public ActionResult Settings(PanelSettings panel)
        {
            if (ModelState.IsValid)
            {
                var updatePanel = _panelSettingsService.UpdatePanelSetting(panel);
                _accessDatasService.AddOperatorLog(133, user.Kullanici_Adi, 0, 0, panel.Panel_ID, 0);
                var readers = _settingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == updatePanel.Panel_ID);
                if (readers == null)
                {
                    if (updatePanel.Panel_Model == (int)PanelModel.Panel_1010)
                    {
                        for (int i = 1; i < 17; i++)
                        {
                            ReaderSettingsNew readerSettingsNew = new ReaderSettingsNew
                            {
                                Panel_ID = updatePanel.Panel_ID,
                                Panel_Name = updatePanel.Panel_Name,
                                Seri_No = updatePanel.Seri_No,
                                Sira_No = updatePanel.Sira_No,
                                WKapi_ID = i,
                                WKapi_Adi = "Kapı " + i,
                                WKapi_Aktif = false,
                                WKapi_Zorlama_Alarmi = false,
                                WKapi_Yangin_Modu = false,
                                WKapi_Sirali_Gecis_Ana_Kapi = false,
                                WKapi_Ana_Alarm_Rolesi = false,
                                WKapi_Acik_Sure_Alarmi = false,
                                WKapi_Acilma_Alarmi = false,
                                WKapi_Coklu_Onay = false,
                                WKapi_Lift_Aktif = false,
                                WKapi_Pin_Dogrulama = false,
                                WKapi_Panik_Buton_Alarmi = false,
                                WKapi_WIGType = 1,
                                WKapi_Acik_Sure = 1,
                                WKapi_Alarm_Modu = false,
                                WKapi_Gecis_Modu = 0,
                                WKapi_Harici_Alarm_Rolesi = 1,
                                WKapi_Itme_Gecikmesi = 1,
                                WKapi_Lokal_Bolge = 1,
                                WKapi_Role_No = i,
                                WKapi_User_Count = 1,
                                WKapi_Kapi_Tipi = 1,
                            };
                            _settingsNewService.AddReaderSettingsNew(readerSettingsNew);
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 17; i++)
                        {
                            ReaderSettingsNew readerSettingsNew = new ReaderSettingsNew
                            {
                                Panel_ID = updatePanel.Panel_ID,
                                Panel_Name = updatePanel.Panel_Name,
                                Seri_No = updatePanel.Seri_No,
                                Sira_No = updatePanel.Sira_No,
                                WKapi_ID = i,
                                WKapi_Adi = "Kapı " + i,
                                WKapi_Aktif = false,
                                WKapi_Zorlama_Alarmi = false,
                                WKapi_Yangin_Modu = false,
                                WKapi_Sirali_Gecis_Ana_Kapi = false,
                                WKapi_Ana_Alarm_Rolesi = false,
                                WKapi_Acik_Sure_Alarmi = false,
                                WKapi_Acilma_Alarmi = false,
                                WKapi_Coklu_Onay = false,
                                WKapi_Lift_Aktif = false,
                                WKapi_Pin_Dogrulama = false,
                                WKapi_Panik_Buton_Alarmi = false,
                                WKapi_WIGType = 1,
                                WKapi_Acik_Sure = 1,
                                WKapi_Alarm_Modu = false,
                                WKapi_Gecis_Modu = 0,
                                WKapi_Harici_Alarm_Rolesi = 1,
                                WKapi_Itme_Gecikmesi = 1,
                                WKapi_Lokal_Bolge = 1,
                                WKapi_Role_No = i,
                                WKapi_User_Count = 1,
                                WKapi_Kapi_Tipi = 1,
                            };
                            _settingsNewService.AddReaderSettingsNew(readerSettingsNew);
                        }
                    }
                }
                return RedirectToAction("Settings", new { @PanelID = panel.Panel_ID });
            }

            return View(panel);
        }

        public ActionResult PanelSelectedSettings()
        {
            var model = _reportService.PanelListesi(user);
            if (model.Count == 0)
            {
                throw new Exception("Sistemde Kayıtlı Herhangi Bir Panel Bulunamadı!");
            }
            return PartialView("PanelSelectedSettings", model);
        }

        public ActionResult Delete(int? PanelID)
        {
            var deletePanel = _panelSettingsService.GetById((int)PanelID);
            if (deletePanel != null)
            {
                if (deletePanel.Panel_Model == (int)PanelModel.Panel_1010)
                    _readerSettingsNewMSService.DeleteReaderSettingsNewByPanelID((int)PanelID);

                deletePanel = ClearPanelSettings.ClearPanel(deletePanel);

                _panelSettingsService.UpdatePanelSetting(deletePanel);

                _settingsNewService.DeleteReaderSettingsNewByPanelID((int)PanelID);

                var doorstatus = _doorStatusService.GetAllDoorStatus().FirstOrDefault(x => x.Panel_ID == PanelID);

                if (doorstatus != null)
                    _doorStatusService.DeleteDoorStatus(doorstatus);

                _accessDatasService.AddOperatorLog(132, user.Kullanici_Adi, 0, 0, PanelID, 0);

                return RedirectToAction("Settings");
            }
            throw new Exception("Silmek istenen kayıt veritabanında yok!");
        }

        public ActionResult SendToPanel(int? Panel)
        {
            try
            {
                TaskList taskList = new TaskList
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
                TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                _accessDatasService.AddOperatorLog(134, user.Kullanici_Adi, 0, 0, Panel, 0);
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
            }
            return RedirectToAction("Settings", new { @PanelID = Panel });
        }

        public ActionResult Create()
        {
            List<int> interlock = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            ViewBag.Panel_Global_Bolge1 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge2 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge3 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge4 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge5 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge6 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge7 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.Panel_Global_Bolge8 = new SelectList(_globalZoneService.GetAllGlobalZones(), "Global_Bolge_No", "Global_Bolge_Adi");
            ViewBag.LocalInterlock_G1_1 = new SelectList(interlock);
            ViewBag.LocalInterlock_G1_2 = new SelectList(interlock);
            ViewBag.LocalInterlock_G2_1 = new SelectList(interlock);
            ViewBag.LocalInterlock_G2_2 = new SelectList(interlock);
            ViewBag.LocalInterlock_G3_1 = new SelectList(interlock);
            ViewBag.LocalInterlock_G3_2 = new SelectList(interlock);
            ViewBag.LocalInterlock_G4_1 = new SelectList(interlock);
            ViewBag.LocalInterlock_G4_2 = new SelectList(interlock);

            return View(new PanelSettings());
        }

        [HttpPost]
        public ActionResult Create(PanelSettings panelSettings, string MacAdress)
        {
            if (ModelState.IsValid)
            {
                panelSettings.Sira_No = panelSettings.Panel_ID;
                panelSettings.Seri_No = int.Parse(MacAdress, System.Globalization.NumberStyles.HexNumber);
                var panel = _panelSettingsService.GetAllPanelSettings().Find(x => x.Panel_ID == panelSettings.Panel_ID && x.Sira_No == panelSettings.Sira_No);
                if (panel != null && panel.Panel_IP1 != 0)
                {
                    throw new Exception("Sistemde aynı panel numarasına ait panel var!");
                }
                else
                {

                    var defaultPanel = _panelSettingsService.GetAllPanelSettings().Find(x => x.Sira_No == panelSettings.Panel_ID);
                    panelSettings.Kayit_No = defaultPanel.Kayit_No;
                    _panelSettingsService.UpdatePanelSetting(panelSettings);
                    _accessDatasService.AddOperatorLog(130, user.Kullanici_Adi, 0, 0, panelSettings.Panel_ID, 0);
                    return RedirectToAction("Settings", "PanelSettings");
                }
            }
            return View(panelSettings);
        }

        public ActionResult ReceiveFromPanel(int? PanelID)
        {
            if (PanelID != null)
            {
                try
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
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
                return RedirectToAction("Settings", new { @PanelID = PanelID });
            }
            throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
        }

        public ActionResult AlarmClear(int? PanelID)
        {
            if (permissionUser.SysAdmin == false)
                throw new Exception("Bu işlem için yetkiniz yok!");

            if (PanelID != null)
            {
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                        Gorev_Kodu = (int)CommandConstants.CMD_ERS_ALARMFIRE_STATUS,
                        IntParam_1 = (int)PanelID,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = PanelID,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);

                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
                return RedirectToAction("Settings", new { @PanelID = PanelID });

            }
            throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
        }

        public ActionResult PanelDate(int Panel)
        {
            try
            {
                TaskList taskList = new TaskList
                {
                    Deneme_Sayisi = 1,
                    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                    Gorev_Kodu = (int)CommandConstants.CMD_SND_RTC,
                    IntParam_1 = (int)Panel,
                    Kullanici_Adi = user.Kullanici_Adi,
                    Panel_No = Panel,
                    Tablo_Guncelle = true,
                    Tarih = DateTime.Now
                };
                TaskList taskListReceive = _taskListService.AddTaskList(taskList);
            }
            catch (Exception)
            {
                throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
            }
            return RedirectToAction("Settings", new { @PanelID = Panel });
        }

        public int CheckStatus(int GrupNo = -1)
        {
            if (GrupNo != -1)
            {
                return _taskListService.GetByGrupNo(GrupNo).Durum_Kodu;
            }
            return 3;
        }

    }
}