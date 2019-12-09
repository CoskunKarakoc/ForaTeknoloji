using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class PanelController : Controller
    {
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsNewService _readerSettingsNewService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        public DBUsers user;
        public PanelController(IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService, IDBUsersPanelsService dBUsersPanelsService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _panelSettingsService = panelSettingsService;
            _readerSettingsNewService = readerSettingsNewService;
            _dBUsersPanelsService = dBUsersPanelsService;
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
            if (UserPanelList().Count == 0)
                throw new Exception("Sistemde kayıtlı panel bulunamadı");
            List<ReaderSettingsNew> okuyucular = new List<ReaderSettingsNew>();
            if (PanelID == null)
            {
                PanelID = UserPanelList().FirstOrDefault().Panel_ID;
                okuyucular = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID).OrderBy(x => x.WKapi_ID).ToList();
            }
            else
            {
                okuyucular = _readerSettingsNewService.GetAllReaderSettingsNew(x => x.Panel_ID == PanelID).OrderBy(x => x.WKapi_ID).ToList();
            }
            if (okuyucular == null)
                throw new Exception("Bu panele ait okuyucu bulunmamaktadır.");

            var model = new ReaderEditViewModel
            {
                Paneller = UserPanelList(),
                Okuyucular = okuyucular.OrderBy(x => x.WKapi_ID).ToList(),
                Panel_ID = PanelID
            };



            return View(model);
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
                            WKapi_Alarm_Modu = 1,
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


        private List<PanelSettings> UserPanelList()
        {
            List<PanelSettings> panels = new List<PanelSettings>();
            if (user.SysAdmin == true)
            {
                panels = _panelSettingsService.GetAllPanelSettings(x => x.Seri_No != 0 && x.Seri_No != null && x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0);
            }
            else
            {
                foreach (var item in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi))
                {
                    var panel = _panelSettingsService.GetByQuery(x => x.Seri_No != 0 && x.Seri_No != null && x.Panel_TCP_Port != 0 && x.Panel_IP1 != 0 && x.Panel_IP2 != 0 && x.Panel_IP3 != 0 && x.Panel_IP4 != 0 && x.Panel_ID == item.Panel_No);
                    if (panel != null)
                        panels.Add(panel);
                }
            }

            return panels;
        }
    }
}