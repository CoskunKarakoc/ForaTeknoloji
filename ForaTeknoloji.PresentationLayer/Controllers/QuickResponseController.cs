using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class QuickResponseController : Controller
    {
        private IVisitorsService _visitorsService;
        private IUserService _userService;
        private IGroupMasterService _groupMasterService;
        private ITaskListService _taskListService;
        private IPanelSettingsService _panelSettingsService;
        private IDBUsersPanelsService _dBUsersPanelsService;
        private IDBUsersService _dBUsersService;
        private IDBUsersDepartmanService _dBUsersDepartmanService;
        private IDBUsersSirketService _dBUsersSirketService;
        private IReportService _reportService;
        private IAccessDatasService _accessDatasService;
        private IDBUsersAltDepartmanService _dBUsersAltDepartmanService;
        private ISirketService _sirketService;
        private IDepartmanService _departmanService;
        private IAltDepartmanService _altDepartmanService;
        private DBUsers user = CurrentSession.User;
        private DBUsers permissionUser;
        private List<int> PanelListesi;
        public QuickResponseController(IVisitorsService visitorsService, IUserService userService, IGroupMasterService groupMasterService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService, IDBUsersSirketService dBUsersSirketService, IDBUsersDepartmanService dBUsersDepartmanService, IReportService reportService, IAccessDatasService accessDatasService, IDBUsersAltDepartmanService dBUsersAltDepartmanService, ISirketService sirketService, IDepartmanService departmanService, IAltDepartmanService altDepartmanService)
        {

            _visitorsService = visitorsService;
            _accessDatasService = accessDatasService;
            _dBUsersService = dBUsersService;
            _reportService = reportService;
            _userService = userService;
            _groupMasterService = groupMasterService;
            _taskListService = taskListService;
            _panelSettingsService = panelSettingsService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            _dBUsersAltDepartmanService = dBUsersAltDepartmanService;
            _sirketService = sirketService;
            _departmanService = departmanService;
            _altDepartmanService = altDepartmanService;
            PanelListesi = new List<int>();
            foreach (var item in _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != null && x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0 && x.Panel_ID != 0))
            {
                PanelListesi.Add((int)item.Panel_ID);
            }
            permissionUser = _dBUsersService.GetAllDBUsers().Find(x => x.Kullanici_Adi == user.Kullanici_Adi);
        }

        // GET: Visitor
        public ActionResult Index()
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Ziyaretci_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Yetkisiz erişim!");
            }

            var model = new VisitorListViewModel
            {
                Visitor = _visitorsService.GetAllVisitors().OrderByDescending(x => x.Kayit_No).ToList(),
                PanelListesi = _reportService.PanelListesi(user)
            };
            return View(model);

        }
        [HttpGet]
        public ActionResult Liste()
        {
            var model = _visitorsService.GetAllVisitors().OrderByDescending(x => x.Kayit_No).ToList();
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        }






        public ActionResult Create()
        {
            Random random = new Random();
            long rndKartID = 0;
            while (true)
            {
                rndKartID = LongRandom.Random(1000000000, 3999999999, random);
                if (_visitorsService.GetByKartId(rndKartID.ToString()) != null)
                {

                }
                else
                {
                    break;
                }
            }
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            encoder.QRCodeVersion = 4;
            Bitmap bitmap = encoder.Encode(rndKartID.ToString());
            var kartID = DecodeBitmap(bitmap);
            TempData["bitmap"] = bitmap;
            var GecisGrubu = _groupMasterService.GetAllGroupsMaster();
            var model = new QuicResponseViewModel
            {
                QRCode = kartID,
                Grup_No = GecisGrubu.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                })
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(Visitors visitors)
        {
            if (ModelState.IsValid)
            {
                visitors.Saat = DateTime.Now;
                int MaxID;
                if (_userService.GetAllUsers().Count == 0)
                    MaxID = 0;
                else
                    MaxID = _userService.GetAllUsers().Max(x => x.ID);


                var userEntity = new Users
                {
                    Adi = "Ziyaretci_" + visitors.Adi,
                    Soyadi = "Ziyaretci_" + visitors.Soyadi,
                    ID = MaxID + 1,
                    Kart_ID = visitors.Kart_ID,
                    Grup_No = visitors.Grup_No,
                    Visitor_Grup_No = visitors.Grup_No,
                    Aciklama = "QR Kodlu Sistem Ziyaretçisi",
                    Kullanici_Tipi = 1,
                    TCKimlik = visitors.TCKimlik,
                    Telefon = visitors.Telefon,
                    Resim = "BaseUser.jpg",
                    Plaka = visitors.Plaka,
                    Sirket_No = _sirketService.GetAllSirketler().FirstOrDefault().Sirket_No,
                    Departman_No = _departmanService.GetAllDepartmanlar().FirstOrDefault().Departman_No,
                    Alt_Departman_No = _altDepartmanService.GetAllAltDepartman().FirstOrDefault().Alt_Departman_No
                };
                visitors.UseUserGroup = true;
                visitors.ID = MaxID + 1;
                var addedUser = _userService.AddUsers(userEntity);
                var addedVisitor = _visitorsService.AddVisitor(visitors);
                Send(PanelListesi, CommandConstants.CMD_SND_USER, addedUser.ID);
                _accessDatasService.AddOperatorLog(320, permissionUser.Kullanici_Adi, addedVisitor.Kayit_No, 0, 0, 0);
                return RedirectToAction("PrintQRCode", new { KartID = visitors.Kart_ID });
            }
            return View(visitors);
        }

        public ActionResult PrintQRCode(long? KartID)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            encoder.QRCodeVersion = 4;
            Bitmap bitmap = encoder.Encode(KartID.ToString());
            var kartID = DecodeBitmap(bitmap);
            TempData["bitmap"] = bitmap;
            var model = new QuicResponseViewModel
            {
                QRCode = kartID
            };
            return View(model);
        }


        public ActionResult Edit(int? id)
        {
            var visitors = _visitorsService.GetAllVisitors().Find(x => x.Kayit_No == id);
            if (visitors.Resim == null)
                visitors.Resim = "BaseUser.jpg";
            ViewBag.Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", visitors.Grup_No);
            var model = new VisitorEditViewModel
            {
                Ziyaretci = visitors,
                GrupAdi = null,
                Personel = null,
                Personeller = _reportService.GetPersonelLists(null, CurrentSession.User),
                VisitorCardList = null
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(Visitors entity)
        {

            if (ModelState.IsValid)
            {
                var visitor = _visitorsService.GetById((int)entity.Kayit_No);
                var userVisitor = _userService.GetAllUsers().FirstOrDefault(x => x.Kart_ID == visitor.Kart_ID);
                if (visitor != null)
                {
                    if (entity.ID != null)
                        entity.UseUserGroup = true;
                    else
                        entity.UseUserGroup = false;

                    _visitorsService.UpdateVisitor(entity);
                    if (entity.Kart_ID != visitor.Kart_ID || entity.Grup_No != visitor.Grup_No)
                        Send(PanelListesi, CommandConstants.CMD_SND_USER, userVisitor.ID);

                    _accessDatasService.AddOperatorLog(321, permissionUser.Kullanici_Adi, entity.Kayit_No, 0, 0, 0);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }

        public ActionResult Delete(int id = -1)
        {

            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Ziyaretçi silmeye yetkiniz yok!");
            }


            if (id != -1)
            {
                Visitors visitor = _visitorsService.GetById(id);
                Users deleteUsers = _userService.GetAllUsers().FirstOrDefault(x => x.Kart_ID == visitor.Kart_ID);
                if (visitor != null)
                {
                    _visitorsService.DeleteVisitor(visitor);
                    _userService.DeleteUsers(deleteUsers);
                    foreach (var item in _reportService.PanelListesi(user))
                    {
                        TaskList taskList = new TaskList
                        {
                            Deneme_Sayisi = 1,
                            Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            Gorev_Kodu = (int)CommandConstants.CMD_ERS_USER,
                            IntParam_1 = id,
                            Kullanici_Adi = user.Kullanici_Adi,
                            Panel_No = item.Panel_ID,
                            Tablo_Guncelle = true,
                            Tarih = DateTime.Now
                        };
                        TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    }
                    _accessDatasService.AddOperatorLog(322, permissionUser.Kullanici_Adi, visitor.Kayit_No, 0, 0, 0);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult PrintImage(string QRCode)
        {
            long rndKartID = 0;
            long.TryParse(QRCode, out rndKartID);
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            encoder.QRCodeVersion = 4;
            Bitmap bitmap = encoder.Encode(rndKartID.ToString());
            var bitmapBytes = BitmapToBytes(bitmap);
            return File(bitmapBytes, "image/jpeg");
        }



        public ActionResult Image()
        {
            Bitmap bitmap = TempData["bitmap"] as Bitmap;
            var bitmapBytes = BitmapToBytes(bitmap);
            return File(bitmapBytes, "image/jpeg");
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private string DecodeBitmap(Bitmap bitmap)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            string result = decoder.Decode(new QRCodeBitmapImage(bitmap));
            return result;
        }


        public void Send(List<int> PanelList, CommandConstants OprKod, int UserID = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Bu işleme yetkiniz yok!");
            }


            if (UserID != -1)
            {
                try
                {
                    if (OprKod == CommandConstants.CMD_SNDALL_USER)
                    {
                        foreach (var panel in PanelList)
                        {
                            TaskList taskListRemove = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_USER,
                                IntParam_1 = 1,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.sp_AddTaskList(taskListRemove);
                            TaskList maxUser = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = panel,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.sp_AddTaskList(maxUser);
                            _reportService.SendAllUserTask(2620, DateTime.Now, 1, permissionUser.Kullanici_Adi, panel);
                            //foreach (var userID in userListe)
                            //{
                            //    TaskList taskList = new TaskList
                            //    {
                            //        Deneme_Sayisi = 1,
                            //        Durum_Kodu = (int)PanelStatusCode.Beklemede,
                            //        Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
                            //        IntParam_1 = userID,
                            //        Kullanici_Adi = user.Kullanici_Adi,
                            //        Panel_No = panel,
                            //        Tablo_Guncelle = true,
                            //        Tarih = DateTime.Now
                            //    };
                            //    _taskListService.sp_AddTaskList(taskList);
                            //    _accessDatasService.AddOperatorLog(103, permissionUser.Kullanici_Adi, userID, 0, 0, 0);
                            //}

                        }
                    }
                    else if (OprKod == CommandConstants.CMD_ERSALL_USER)
                    {
                        foreach (var item in PanelList)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_ERSALL_USER,
                                IntParam_1 = 1,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.sp_AddTaskList(taskList);
                        }
                    }
                    else
                    {
                        foreach (var item in PanelList)
                        {
                            if (OprKod == CommandConstants.CMD_SND_USER)
                            {
                                TaskList maxUser = new TaskList
                                {
                                    Deneme_Sayisi = 1,
                                    Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                    Gorev_Kodu = (int)CommandConstants.CMD_SND_MAXUSERID,
                                    IntParam_1 = _userService.GetAllUsers().Max(x => x.ID),
                                    Kullanici_Adi = user.Kullanici_Adi,
                                    Panel_No = item,
                                    Tablo_Guncelle = true,
                                    Tarih = DateTime.Now
                                };
                                _taskListService.sp_AddTaskList(maxUser);
                            }
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)OprKod,
                                IntParam_1 = UserID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            _taskListService.sp_AddTaskList(taskList);
                            _accessDatasService.AddOperatorLog(103, permissionUser.Kullanici_Adi, UserID, 0, 0, 0);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }
        }




    }
}