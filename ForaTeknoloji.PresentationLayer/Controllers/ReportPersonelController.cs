using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class ReportPersonelController : Controller
    {
        private IUserService _userService;
        private ISirketService _sirketService;
        private IDepartmanService _departmanService;
        private IBloklarService _bloklarService;
        private IVisitorsService _visitorsService;
        private IGroupsDetailService _groupsDetailService;
        private IPanelSettingsService _panelSettingsService;
        private IGlobalZoneService _globalZoneService;
        private IGroupMasterService _groupMasterService;
        public ReportPersonelController(ISirketService sirketService, IDepartmanService departmanService, IBloklarService bloklarService, IVisitorsService visitorsService, IGroupsDetailService groupsDetailService, IPanelSettingsService panelSettingsService, IGlobalZoneService globalZoneService, IGroupMasterService groupMasterService, IUserService userService)
        {
            _userService = userService;
            _sirketService = sirketService;
            _departmanService = departmanService;
            _bloklarService = bloklarService;
            _visitorsService = visitorsService;
            _groupsDetailService = groupsDetailService;
            _panelSettingsService = panelSettingsService;
            _globalZoneService = globalZoneService;
            _groupMasterService = groupMasterService;
        }
        // GET: ReportPersonel
        public ActionResult Index()
        {
            var panel = _panelSettingsService.GetAllPanelSettings();
            var groupsdetail = _groupsDetailService.GetAllGroupsDetail();
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar();
            var bloklar = _bloklarService.GetAllBloklar();
            var sirketler = _sirketService.GetAllSirketler();
            var groupMaster = _groupMasterService.GetAllGroupsMaster();
            var visitors = _visitorsService.GetAllVisitors();
            var liste = _userService.GetReportPersonelLists(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null, null, null);
            var model = new ReportPersonelViewModel
            {
                ReportPersonel = liste,
                Paneller = panel.Select(a => new SelectListItem
                {
                    Text = a.Panel_Name,
                    Value = a.Panel_ID.ToString()
                }),
                Groupsdetail = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Kayit_No.ToString()
                }),
                Global_Bolge_Adi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                Departmanlar = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Bloklar = bloklar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Blok_No.ToString()
                }),
                Sirketler = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupMaster.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Visitors = visitors.Select(a => new SelectListItem
                {
                    Text = a.Adi + " " + a.Soyadi,
                    Value = a.ID.ToString()
                })

            };
            return View(model);

        }
        [HttpPost]
        public ActionResult Index(bool? Kapi1, bool? Kapi2, bool? Kapi3, bool? Kapi4, bool? Kapi5, bool? Kapi6, bool? Kapi7, bool? Kapi8, bool? Günlük, bool? Tümü, int? Sirketler, int? Departmanlar, int? Bloklar, bool? TümPanel, int? Panel, int? Groupsdetail, int? Daire, DateTime? Tarih1, DateTime? Tarih2, DateTime? Saat1, DateTime? Saat2, string KapiYon, string Plaka = null, string Kullanici = null, string Kayit = null)
        {
            var liste = _userService.GetReportPersonelLists(Kapi1, Kapi2, Kapi3, Kapi4, Kapi5, Kapi6, Kapi7, Kapi8, Günlük, Tümü, Sirketler, Departmanlar, Bloklar, TümPanel, Panel, Groupsdetail, Daire, Tarih1, Tarih2, Saat1, Saat2, KapiYon, Plaka, Kullanici, Kayit);
            return View();
        }

        //EXCELL EXPORT
        public void PersonelRaporları()
        {


        }
    }
}