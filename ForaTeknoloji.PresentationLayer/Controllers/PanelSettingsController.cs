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

        public DBUsers user;
        public PanelSettingsController(IPanelSettingsService panelSettingsService, IReaderSettingsService readerSettingsService, IGlobalZoneService globalZoneService, IReaderSettingsNewService settingsNewService, ITaskListService taskListService, IDBUsersPanelsService dBUsersPanelsService, IGroupsDetailNewService groupsDetailNewService, IReportService reportService)
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
                var readers = _settingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == updatePanel.Panel_ID);
                if (readers == null)
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
                            WKapi_Role_No = 1,
                            WKapi_User_Count = 1,
                            WKapi_Kapi_Tipi = 1,
                        };
                        _settingsNewService.AddReaderSettingsNew(readerSettingsNew);
                    }
                }
                return RedirectToAction("Settings");
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
            var entity = _panelSettingsService.GetById((int)PanelID);
            if (entity != null)
            {
                entity.Seri_No = 0;
                entity.Panel_ID = 0;
                entity.Panel_Name = "";
                entity.Panel_Model = null;
                entity.Panel_Expansion = null;
                entity.Panel_Expansion_2 = null;
                entity.Kontrol_Modu = 0;
                entity.Lokal_APB = null;
                entity.Lokal_APB1 = false;
                entity.Lokal_APB2 = false;
                entity.Lokal_APB3 = false;
                entity.Lokal_APB4 = false;
                entity.Lokal_APB5 = false;
                entity.Lokal_APB6 = false;
                entity.Lokal_APB7 = false;
                entity.Lokal_APB8 = false;
                entity.Global_APB = false;
                entity.Global_Bolge_No = null;
                entity.Global_Capacity_Control = false;
                entity.Global_Access_Count_Control = false;
                entity.Global_MaxIn_Count_Control = false;
                entity.Global_Sequental_Access_Control = null;
                entity.Panel_Same_Tag_Block = null;
                entity.Panel_Same_Tag_Block_Type = null;
                entity.Panel_Same_Tag_Block_HourMinSec = null;
                entity.Status_Data_Update = null;
                entity.Status_Data_Update_Type = null;
                entity.Status_Data_Update_Time = null;
                entity.Panel_M1_Role = 0;
                entity.Panel_M2_Role = 0;
                entity.Panel_M3_Role = 0;
                entity.Panel_M4_Role = 0;
                entity.Panel_M5_Role = 0;
                entity.Panel_M6_Role = 0;
                entity.Panel_M7_Role = 0;
                entity.Panel_M8_Role = 0;
                entity.Panel_Alarm_Role = 0;
                entity.Panel_Alarm_Mode_Role_Ok = false;
                entity.Panel_Alarm_Mode = false;
                entity.Panel_Fire_Mode_Role_Ok = false;
                entity.Panel_Fire_Mode = false;
                entity.Panel_Door_Alarm_Role_Ok = null;
                entity.Panel_Alarm_Broadcast_Ok = null;
                entity.Panel_Fire_Broadcast_Ok = null;
                entity.Panel_Door_Alarm_Broadcast_Ok = null;
                entity.Panel_Global_Bolge1 = 1;
                entity.Panel_Global_Bolge2 = 1;
                entity.Panel_Global_Bolge3 = 1;
                entity.Panel_Global_Bolge4 = 1;
                entity.Panel_Global_Bolge5 = 1;
                entity.Panel_Global_Bolge6 = 1;
                entity.Panel_Global_Bolge7 = 1;
                entity.Panel_Global_Bolge8 = 1;
                entity.Panel_Local_Capacity1 = false;
                entity.Panel_Local_Capacity_Clear1 = false;
                entity.Panel_Local_Capacity_Value1 = 0;
                entity.Panel_Local_Capacity2 = false;
                entity.Panel_Local_Capacity_Clear2 = false;
                entity.Panel_Local_Capacity_Value2 = 0;
                entity.Panel_Local_Capacity3 = false;
                entity.Panel_Local_Capacity_Clear3 = false;
                entity.Panel_Local_Capacity_Value3 = 0;
                entity.Panel_Local_Capacity4 = false;
                entity.Panel_Local_Capacity_Clear4 = false;
                entity.Panel_Local_Capacity_Value4 = 0;
                entity.Panel_Local_Capacity5 = false;
                entity.Panel_Local_Capacity_Clear5 = false;
                entity.Panel_Local_Capacity_Value5 = 0;
                entity.Panel_Local_Capacity6 = false;
                entity.Panel_Local_Capacity_Clear6 = false;
                entity.Panel_Local_Capacity_Value6 = 0;
                entity.Panel_Local_Capacity7 = false;
                entity.Panel_Local_Capacity_Clear7 = false;
                entity.Panel_Local_Capacity_Value7 = 0;
                entity.Panel_Local_Capacity8 = false;
                entity.Panel_Local_Capacity_Clear8 = false;
                entity.Panel_Local_Capacity_Value8 = 0;
                entity.Panel_GW1 = 0;
                entity.Panel_GW2 = 0;
                entity.Panel_GW3 = 0;
                entity.Panel_GW4 = 0;
                entity.Panel_IP1 = 0;
                entity.Panel_IP2 = 0;
                entity.Panel_IP3 = 0;
                entity.Panel_IP4 = 0;
                entity.Panel_TCP_Port = 0;
                entity.Panel_Subnet1 = 0;
                entity.Panel_Subnet2 = 0;
                entity.Panel_Subnet3 = 0;
                entity.Panel_Subnet4 = 0;
                entity.Panel_Remote_IP1 = null;
                entity.Panel_Remote_IP2 = null;
                entity.Panel_Remote_IP3 = null;
                entity.Panel_Remote_IP4 = null;
                entity.Lift_Capacity = null;
                entity.Interlock_Active = null;
                entity.Same_Door_Multiple_Reader = null;
                entity.Global_Zone_Interlock_Active = null;
                entity.Panel_Button_Detector = null;
                entity.Panel_Button_Detector_Time = null;
                entity.Offline_Antipassback = false;
                entity.Offline_Blocked_Request = false;
                entity.Offline_Undefined_Transition = false;
                entity.Offline_Manuel_Operations = false;
                entity.Offline_Button_Triggering = false;
                entity.Offline_Scheduled_Transactions = false;
                entity.LocalInterlock_G1_1 = null;
                entity.LocalInterlock_G1_2 = null;
                entity.LocalInterlock_G2_1 = null;
                entity.LocalInterlock_G2_2 = null;
                entity.LocalInterlock_G3_1 = null;
                entity.LocalInterlock_G3_2 = null;
                entity.LocalInterlock_G4_1 = null;
                entity.LocalInterlock_G4_2 = null;
                entity.DHCP_Enabled = false;
                entity.Hastane_Aktif = null;
                entity.Hastane_IP1 = null;
                entity.Hastane_IP2 = null;
                entity.Hastane_IP3 = null;
                entity.Hastane_IP4 = null;
                entity.Hastane_Server_TCP_Port = null;
                entity.Hastane_Lokal_TCP_Port = null;
                entity.Hastane_Acil_Durum_Yesil_Kod = null;
                entity.Hastane_Yesil_Kod_Suresi = null;
                _panelSettingsService.UpdatePanelSetting(entity);
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
                    Durum_Kodu = 1,
                    Gorev_Kodu = (int)CommandConstants.CMD_SND_GENERALSETTINGS,
                    IntParam_1 = (int)Panel,
                    Kullanici_Adi = user.Kullanici_Adi,
                    Panel_No = Panel,
                    Tablo_Guncelle = true,
                    Tarih = DateTime.Now
                };
                TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                Thread.Sleep(2500);
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
                        Durum_Kodu = 1,
                        Gorev_Kodu = (int)CommandConstants.CMD_RCV_GENERALSETTINGS,
                        IntParam_1 = (int)PanelID,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = PanelID,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
                return RedirectToAction("Settings", new { @PanelID = PanelID });
            }
            throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
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