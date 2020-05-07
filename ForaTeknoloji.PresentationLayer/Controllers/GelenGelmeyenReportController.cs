using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class GelenGelmeyenReportController : Controller
    {
        private IUserService _userService;
        private IDepartmanService _departmanService;
        private ISirketService _sirketService;
        private IVisitorsService _visitorsService;
        private IGlobalZoneService _globalZoneService;
        private IReportService _reportService;
        private IGroupMasterService _groupMasterService;
        private IAltDepartmanService _altDepartmanService;
        private IUnvanService _unvanService;
        private IBolumService _bolumService;
        private IProgInitService _progInitService;
        private IBirimService _birimService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private IDBUsersBolumService _dBUsersBolumService;
        public DBUsers user = CurrentSession.User;
        public DateTime DefaultTarih1;
        public DateTime DefaultTarih2;
        List<int> dbDepartmanList;
        List<int> dbPanelList;
        List<int> dbSirketList;
        List<int> dbAltDepartmanList;
        List<int> dbBolumList;
        public GelenGelmeyenReportController(IUserService userService, IDepartmanService departmanService, ISirketService sirketService, IGroupsDetailService groupsDetailService, IVisitorsService visitorsService, IGlobalZoneService globalZoneService, IReportService reportService, IGroupMasterService groupMasterService, IAltDepartmanService altDepartmanService, IUnvanService unvanService, IBolumService bolumService, IProgInitService progInitService, IBirimService birimService, IDBUsersDepartmanService dBUsersDepartmanService, IDBUsersSirketService dBUsersSirketService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, IDBUsersBolumService dBUsersBolumService)
        {
            //user = CurrentSession.User;
            //if (user == null)
            //{
            //    user = new DBUsers();
            //}

            _userService = userService;
            _departmanService = departmanService;
            _sirketService = sirketService;
            _groupMasterService = groupMasterService;
            _visitorsService = visitorsService;
            _globalZoneService = globalZoneService;
            _altDepartmanService = altDepartmanService;
            _unvanService = unvanService;
            _bolumService = bolumService;
            _reportService = reportService;
            _progInitService = progInitService;
            _birimService = birimService;
            _dBUsersBolumService = dBUsersBolumService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            DefaultTarih1 = DateTime.Now;
            DefaultTarih2 = DateTime.Now;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            dbDepartmanList = new List<int>();
            dbPanelList = new List<int>();
            dbSirketList = new List<int>();
            dbAltDepartmanList = new List<int>();
            dbBolumList = new List<int>();
            foreach (var dbUserDepartmanNo in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Departman_No))
            {
                dbDepartmanList.Add((int)dbUserDepartmanNo);
            }
            foreach (var dbUserPanelNo in _dBUsersPanelsService.GetAllDBUsersPanels(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Panel_No))
            {
                dbPanelList.Add((int)dbUserPanelNo);
            }
            foreach (var dbUserSirketNo in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Sirket_No))
            {
                dbSirketList.Add((int)dbUserSirketNo);
            }
            foreach (var dbUserAltDepartmanNo in _dBUsersAltDepartmanService.GetAllDBUsersAltDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Alt_Departman_No))
            {
                dbAltDepartmanList.Add((int)dbUserAltDepartmanNo);
            }
            foreach (var dbUserBolumNo in _dBUsersBolumService.GetAllDBUsersBolum(x => x.Kullanici_Adi == user.Kullanici_Adi).Select(a => a.Bolum_No))
            {
                dbBolumList.Add((int)dbUserBolumNo);
            }
            _reportService.GetPanelList(user == null ? new DBUsers { } : user);
            _reportService.GetSirketList(user == null ? new DBUsers { } : user);
            _reportService.GetDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetAltDepartmanList(user == null ? new DBUsers { } : user);
            _reportService.GetBolumList(user == null ? new DBUsers { } : user);
        }





        public ActionResult Gelenler(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_Gelenlers(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No));// _sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No)); // _departmanService.GetByKullaniciAdi(user.Kullanici_Adi);
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var kullanici = _reportService.GetPersonelLists(null, CurrentSession.User);
            var model = new GelenGelmeyen_GelenlerListViewModel
            {
                Gelenler = nesne,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                }),
                Kullanıcı = kullanici
            };
            TempData["Gelenler"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            return View(model);
        }




        public ActionResult Gelmeyenler(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_Gelmeyens(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var kullanici = _reportService.GetPersonelLists(null, CurrentSession.User);
            var model = new GelenGelmeyen_GelmeyenlerListViewModel
            {
                Gelmeyenler = nesne,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                }),
                Saat = _progInitService.GetAllProgInit().FirstOrDefault().EndlessReportTime,
                ReportByHour = _progInitService.GetAllProgInit().FirstOrDefault().ReportByHour,
                Kullanıcı = kullanici
            };
            TempData["Gelmeyenler"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi, parameters.Baslangic_Saati, parameters.Bitis_Saati);
            return View(model);
        }



        public ActionResult PasifKullanici(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_PasifKullanicis(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new GelenGelmeyen_PasifListViewModel
            {
                Pasif = nesne,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            TempData["Pasif"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi);
            return View(model);
        }




        public ActionResult ToplamIcerdeKalma(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var usersComplex = _reportService.GetPersonelLists(null, CurrentSession.User);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new GelenGelmeyen_ToplamIcerdeKalmaListViewModel
            {
                ToplamIcerdeKalma = nesne,
                KullaniciComplex = usersComplex,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            TempData["Toplam"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            return View(model);
        }



        public ActionResult IlkGirisSonCikis(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_IlkGirisSonCikis(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var usersComplex = _reportService.GetPersonelLists(null, CurrentSession.User);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new GelenGelmeyen_IlkGirisSonCikisListViewModel
            {
                IlkGirisSonCikis = nesne,
                KullaniciComplex = usersComplex,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            TempData["IlkGirisSonCikis"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            return View(model);
        }


        public ActionResult TopluGirisSayisi(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_TopluGirisSayisi(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var usersComplex = _reportService.GetPersonelLists(null, CurrentSession.User);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new GelenGelmeyen_TopluGirisSayisiListViewModel
            {
                TopluGirisSayisi = nesne,
                KullaniciComplex = usersComplex,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            TempData["TopluGirisSayisi"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            return View(model);
        }



        public ActionResult GecGelenErkenCikan(GelenGelmeyenReportParameters parameters)
        {
            var nesne = _reportService.GelenGelmeyen_GecGelenErkenCikan(parameters, CurrentSession.User);
            var sirketler = _sirketService.GetAllSirketler(x => dbSirketList.Contains(x.Sirket_No)); //_sirketService.GetByKullaniciAdi(user.Kullanici_Adi);
            var globalBolgeAdi = _globalZoneService.GetAllGlobalZones();
            var departmanlar = _departmanService.GetAllDepartmanlar(x => dbDepartmanList.Contains(x.Departman_No));
            var altdepartmanlar = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == parameters.Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
            var unvanlar = _unvanService.GetAllUnvan();
            var bolumler = _bolumService.GetAllBolum(x => x.Alt_Departman_No == parameters.AltDepartman && x.Departman_No == parameters.Departman);
            var groupsdetail = _groupMasterService.GetAllGroupsMaster();
            var usersComplex = _reportService.GetPersonelLists(null, CurrentSession.User);
            var birimler = _birimService.GetAllBirim(x => x.Departman_No == parameters.Departman && x.Alt_Departman_No == parameters.AltDepartman && x.Bolum_No == parameters.Bolum);
            var model = new GelenGelmeyen_IlkGirisSonCikisListViewModel
            {
                IlkGirisSonCikis = nesne,
                KullaniciComplex = usersComplex,
                Departman = departmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Departman_No.ToString()
                }),
                Sirket = sirketler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Sirket_No.ToString()
                }),
                Gecis_Grubu = groupsdetail.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Global_Kapi_Bolgesi = globalBolgeAdi.Select(a => new SelectListItem
                {
                    Text = a.Global_Bolge_Adi,
                    Value = a.Global_Bolge_No.ToString()
                }),
                AltDepartman = altdepartmanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Alt_Departman_No.ToString()
                }),
                Unvan = unvanlar.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Unvan_No.ToString()
                }),
                Bolum = bolumler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Bolum_No.ToString()
                }),
                Birim_No = birimler.Select(a => new SelectListItem
                {
                    Text = a.Adi,
                    Value = a.Birim_No.ToString()
                })
            };
            TempData["GecGelenErkenCikan"] = nesne;
            TempData["DateAndTime"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            TempData["DateAndTimeView"] = ReportParamatersDateAndTime.ParametersDateAndTimeBindForReport(parameters.Baslangic_Tarihi, parameters.Bitis_Tarihi);
            return View(model);
        }









        public ActionResult ComplexUser()
        {
            List<EfUserDal.ComplexUser> liste = new List<EfUserDal.ComplexUser>();
            liste = _userService.GetAllUsersWithOuther(x => dbSirketList.Contains((int)x.Sirket_No) && dbDepartmanList.Contains((int)x.Departman_No) && dbAltDepartmanList.Contains((int)x.Alt_Departman_No));
            return Json(liste, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AltDepartmanListesi(int? Departman)
        {
            if (Departman != 0 && Departman != null)
            {
                var list = _altDepartmanService.GetAllAltDepartman(x => x.Departman_No == Departman && dbAltDepartmanList.Contains(x.Alt_Departman_No));
                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectAltDepartman = list.Select(a => new SelectListItem
                    {
                        Text = a.Adi,
                        Value = a.Alt_Departman_No.ToString()
                    });
                    return Json(selectAltDepartman, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Alt Departman Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BolumListesi(int? AltDepartman)
        {
            if (AltDepartman != null && AltDepartman != 0)
            {

                var list = _bolumService.GetAllBolum(x => x.Alt_Departman_No == AltDepartman);
                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectBolum = list.Select(a => new SelectListItem
                    {
                        Text = a.Adi,
                        Value = a.Bolum_No.ToString()
                    });
                    return Json(selectBolum, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Bölüm Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BirimListesi(int? AltDepartman, int? Bolum)
        {
            if (AltDepartman != null && AltDepartman != 0 && Bolum != null && Bolum != 0)
            {

                var list = _birimService.GetAllBirim(x => x.Alt_Departman_No == AltDepartman && x.Bolum_No == Bolum);
                if (list.Count == 0)
                {
                    List<SelectListItem> defaultValuee = new List<SelectListItem>();
                    defaultValuee.Add(new SelectListItem { Text = "Birim Seçiniz...", Value = 0.ToString() });
                    return Json(defaultValuee, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var selectBirim = list.Select(a => new SelectListItem
                    {
                        Text = a.Adi,
                        Value = a.Birim_No.ToString()
                    });
                    return Json(selectBirim, JsonRequestBehavior.AllowGet);
                }

            }
            List<SelectListItem> defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Birim Seçiniz...", Value = 0.ToString() });
            return Json(defaultValue, JsonRequestBehavior.AllowGet);
        }







        [HttpPost]
        public ActionResult ReportTime(DateTime? Report_Time, bool? ReportByHour)
        {
            if (Report_Time != null)
            {
                var entity = _progInitService.GetAllProgInit().FirstOrDefault();
                entity.EndlessReportTime = Report_Time;
                entity.ReportByHour = ReportByHour;
                _progInitService.UpdateProgInit(entity);
                return RedirectToAction("Gelmeyenler");
            }
            return RedirectToAction("Gelmeyenler");

        }


        //Gelenler Excell
        public void GelenlerExcell()
        {
            List<GelenGelmeyen_Gelenler> liste = new List<GelenGelmeyen_Gelenler>();
            liste = TempData["Gelenler"] as List<GelenGelmeyen_Gelenler>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_Gelenlers(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }

            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Gelen Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Alt Departman";
            worksheet.Cells["I6"].Value = "Bölüm";
            worksheet.Cells["J6"].Value = "Birim";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:K6"].Style.Font.Size = 13;
            worksheet.Cells["A6:K6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Grup_Adi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Gelmeyenler Excell
        public void GelmeyenlerExcell()
        {
            List<GelenGelmeyen_Gelmeyen> liste = new List<GelenGelmeyen_Gelmeyen>();
            liste = TempData["Gelmeyenler"] as List<GelenGelmeyen_Gelmeyen>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_Gelmeyens(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Gelmeyen Kullanıcı Listesi";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Alt Departman";
            worksheet.Cells["I6"].Value = "Bölüm";
            worksheet.Cells["J6"].Value = "Birim";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:K6"].Style.Font.Size = 13;
            worksheet.Cells["A6:K6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Grup_Adi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Toplam İçerde Kalma Excell
        public void ToplamIcerdeKalmaExcell()
        {
            List<GelenGelmeyen_ToplamIcerdeKalma> liste = new List<GelenGelmeyen_ToplamIcerdeKalma>();
            liste = TempData["Toplam"] as List<GelenGelmeyen_ToplamIcerdeKalma>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_ToplamIcerdeKalmas(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Toplam İçerde Kalma Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Şirket";
            worksheet.Cells["F6"].Value = "Departman";
            worksheet.Cells["G6"].Value = "Grup";
            worksheet.Cells["H6"].Value = "Tarih Değeri";
            worksheet.Cells["I6"].Value = "Toplam Saat";
            worksheet.Cells["J6"].Value = "Toplam Dakika";
            worksheet.Cells["K6"].Value = "Toplam Saniye";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:K6"].Style.Font.Size = 13;
            worksheet.Cells["A6:K6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Tarih_Degeri;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Toplam_Saat;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Toplam_Dakika;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Toplam_Saniye;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Pasi Kullanıcı Excell
        public void PasifKullaniciExcell()
        {
            List<GelenGelmeyen_PasifKullanici> liste = new List<GelenGelmeyen_PasifKullanici>();
            liste = TempData["Pasif"] as List<GelenGelmeyen_PasifKullanici>;

            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_PasifKullanicis(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Pasif Kullanıcı Raporları";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Tc Kimlik No";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Alt Departman";
            worksheet.Cells["I6"].Value = "Bölüm";
            worksheet.Cells["J6"].Value = "Birim";
            worksheet.Cells["K6"].Value = "Geçiş Grubu";
            worksheet.Cells["L6"].Value = "Global Bölge Adı";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:L6"].Style.Font.Size = 13;
            worksheet.Cells["A6:L6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.TCKimlik;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Global_Bolge_Adi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //İlk Giriş Son Çıkış
        public void IlkGirisSonCikisExcell()
        {
            List<GelenGelmeyen_IlkGirisSonCikis> liste = new List<GelenGelmeyen_IlkGirisSonCikis>();
            liste = TempData["IlkGirisSonCikis"] as List<GelenGelmeyen_IlkGirisSonCikis>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_IlkGirisSonCikis(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "İlk Giriş Son Çıkış";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Şirket";
            worksheet.Cells["F6"].Value = "Departman";
            worksheet.Cells["G6"].Value = "Alt Departman";
            worksheet.Cells["H6"].Value = "Bölüm";
            worksheet.Cells["I6"].Value = "Birim";
            worksheet.Cells["J6"].Value = "Grup";
            worksheet.Cells["K6"].Value = "Tarih Değeri";
            worksheet.Cells["L6"].Value = "İlk Kayıt";
            worksheet.Cells["M6"].Value = "Son Kayıt";
            worksheet.Cells["N6"].Value = "Fark";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:N6"].Style.Font.Size = 13;
            worksheet.Cells["A6:N6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Tarih_Degeri;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Ilk_Kayit;
                worksheet.Cells[string.Format("M{0}", rowStart)].Value = item.Son_Kayit;
                worksheet.Cells[string.Format("N{0}", rowStart)].Value = item.Fark;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Geç Gelen Erken Cikan
        public void GecGelenErkenCikanExcell()
        {
            List<GelenGelmeyen_IlkGirisSonCikis> liste = new List<GelenGelmeyen_IlkGirisSonCikis>();
            liste = TempData["GecGelenErkenCikan"] as List<GelenGelmeyen_IlkGirisSonCikis>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_IlkGirisSonCikis(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Geç Gelen Erken Çıkan";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Şirket";
            worksheet.Cells["F6"].Value = "Departman";
            worksheet.Cells["G6"].Value = "Alt Departman";
            worksheet.Cells["H6"].Value = "Bölüm";
            worksheet.Cells["I6"].Value = "Birim";
            worksheet.Cells["J6"].Value = "Grup";
            worksheet.Cells["K6"].Value = "Tarih Değeri";
            worksheet.Cells["L6"].Value = "İlk Kayıt";
            worksheet.Cells["M6"].Value = "Son Kayıt";
            worksheet.Cells["N6"].Value = "Fark";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:N6"].Style.Font.Size = 13;
            worksheet.Cells["A6:N6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.SirketAdi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.DepartmanAdi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.AltDepartmanAdi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.BolumAdi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Tarih_Degeri;
                worksheet.Cells[string.Format("L{0}", rowStart)].Value = item.Ilk_Kayit;
                worksheet.Cells[string.Format("M{0}", rowStart)].Value = item.Son_Kayit;
                worksheet.Cells[string.Format("N{0}", rowStart)].Value = item.Fark;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

        //Toplu Giris Sayısı
        public void TopluGirisSayisiExcell()
        {

            List<GelenGelmeyen_TopluGiris> liste = new List<GelenGelmeyen_TopluGiris>();
            liste = TempData["TopluGirisSayisi"] as List<GelenGelmeyen_TopluGiris>;
            if (liste == null || liste.Count == 0)
            {
                liste = _reportService.GelenGelmeyen_TopluGirisSayisi(new GelenGelmeyenReportParameters(), CurrentSession.User);
            }
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells["A1"].Value = "Toplu Giriş Sayısı";
            worksheet.Cells["A3"].Value = "Tarih";
            worksheet.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}  {0:hh: mm ss}", DateTimeOffset.Now);
            worksheet.Cells["A4"].Value = "Rapor Tarih Aralığı";
            worksheet.Cells["B4"].Value = TempData["DateAndTime"].ToString();
            worksheet.Cells["A6"].Value = "ID";
            worksheet.Cells["B6"].Value = "Kart ID";
            worksheet.Cells["C6"].Value = "Adı";
            worksheet.Cells["D6"].Value = "Soyadı";
            worksheet.Cells["E6"].Value = "Grup Adı";
            worksheet.Cells["F6"].Value = "Şirket";
            worksheet.Cells["G6"].Value = "Departman";
            worksheet.Cells["H6"].Value = "Alt Departman";
            worksheet.Cells["I6"].Value = "Bölüm";
            worksheet.Cells["J6"].Value = "Birim";
            worksheet.Cells["K6"].Value = "Giriş Sayısı";
            worksheet.Cells["A1"].Style.Font.Size = 13;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A6:K6"].Style.Font.Size = 13;
            worksheet.Cells["A6:K6"].Style.Font.Bold = true;
            worksheet.Cells["A:AZ"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Cells["A:AZ"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            int rowStart = 7;
            foreach (var item in liste)
            {
                worksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                worksheet.Cells[string.Format("B{0}", rowStart)].Value = item.Kart_ID;
                worksheet.Cells[string.Format("C{0}", rowStart)].Value = item.Adi;
                worksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Soyadi;
                worksheet.Cells[string.Format("E{0}", rowStart)].Value = item.Grup_Adi;
                worksheet.Cells[string.Format("F{0}", rowStart)].Value = item.Sirket_Adi;
                worksheet.Cells[string.Format("G{0}", rowStart)].Value = item.Departman_Adi;
                worksheet.Cells[string.Format("H{0}", rowStart)].Value = item.Alt_Departman_Adi;
                worksheet.Cells[string.Format("I{0}", rowStart)].Value = item.Bolum_Adi;
                worksheet.Cells[string.Format("J{0}", rowStart)].Value = item.BirimAdi;
                worksheet.Cells[string.Format("K{0}", rowStart)].Value = item.Giris_Sayisi;
                rowStart++;
            }
            worksheet.Cells[string.Format("A{0}", rowStart + 3)].Value = "Toplam Kayıt=" + liste.Count();
            worksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-dispositon", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
        }

    }
}