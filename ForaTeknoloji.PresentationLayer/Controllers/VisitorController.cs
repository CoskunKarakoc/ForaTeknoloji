using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfUserDal;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class VisitorController : Controller
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
        private DBUsers user;
        private DBUsers permissionUser;
        public VisitorController(IVisitorsService visitorsService, IUserService userService, IGroupMasterService groupMasterService, ITaskListService taskListService, IPanelSettingsService panelSettingsService, IDBUsersPanelsService dBUsersPanelsService, IDBUsersService dBUsersService, IDBUsersSirketService dBUsersSirketService, IDBUsersDepartmanService dBUsersDepartmanService, IReportService reportService, IAccessDatasService accessDatasService)
        {
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _visitorsService = visitorsService;
            _userService = userService;
            _groupMasterService = groupMasterService;
            _taskListService = taskListService;
            _panelSettingsService = panelSettingsService;
            _dBUsersPanelsService = dBUsersPanelsService;
            _dBUsersService = dBUsersService;
            _dBUsersDepartmanService = dBUsersDepartmanService;
            _dBUsersSirketService = dBUsersSirketService;
            _reportService = reportService;
            _accessDatasService = accessDatasService;
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
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Ziyaretci_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Ziyaretci_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Ziyaretçi eklemeye yetkiniz yok!");
            }



            var Grup = _groupMasterService.GetAllGroupsMaster();
            var Personel = _userService.GetAllUsers();
            var Ziyaretci = _userService.GetAllUsers(x => x.Kullanici_Tipi == 1);
            var model = new CreateVisitorViewModel
            {
                Grup_No = Grup.Select(a => new SelectListItem
                {
                    Text = a.Grup_Adi,
                    Value = a.Grup_No.ToString()
                }),
                Personeller = Personel,
                Ziyaretciler = Ziyaretci,
                ComplexPersoneller = ModalUser(),
                VisitorCardList = CardModelUser()
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Visitors visitors, HttpPostedFileBase ProfileImage)
        {



            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"visitor_{visitors.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
                visitors.Resim = filename;
            }

            if (ProfileImage == null)
                visitors.Resim = "BaseUser.jpg";


            if (ModelState.IsValid)
            {
                visitors.Saat = DateTime.Now;
                var addedVisitor = _visitorsService.AddVisitor(visitors);
                _accessDatasService.AddOperatorLog(320, permissionUser.Kullanici_Adi, addedVisitor.Kayit_No, 0, 0, 0);
                return RedirectToAction("Index");
            }

            return View(visitors);
        }


        public ActionResult Edit(int? id)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Ziyaretçi düzenlemeye yetkiniz yok!");
            }



            if (id == null)
                throw new Exception("Upps! Yanlış giden birşeyler var.");

            Visitors visitors = _visitorsService.GetAllVisitors().Find(x => x.Kayit_No == id);
            Users users = new Users();
            if (visitors.Resim == null)
                visitors.Resim = "BaseUser.jpg";
            if (visitors.ID != null)
            {
                users = _userService.GetAllUsers().FirstOrDefault(x => x.ID == visitors.ID);
            }
            else
            {
                return RedirectToAction("Editt", new { id = visitors.Kayit_No });
            }
            if (visitors == null)
                return HttpNotFound();

            var model = new VisitorEditViewModel
            {
                Ziyaretci = visitors,
                GrupAdi = _groupMasterService.GetById((int)visitors.Grup_No).Grup_Adi,
                Personel = users,
                Personeller = ModalUser(),
                VisitorCardList = CardModelUser()
            };

            ViewBag.Grup_No = new SelectList(_groupMasterService.GetAllGroupsMaster(), "Grup_No", "Grup_Adi", visitors.Grup_No);
            ViewBag.Tarih = visitors.Tarih;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visitors entity, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"visitor_{entity.Kayit_No}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
                entity.Resim = filename;
            }
            if (ProfileImage == null && entity.Resim == null)
                entity.Resim = "BaseUser.jpg";


            if (ModelState.IsValid)
            {
                var visitor = _visitorsService.GetById((int)entity.Kayit_No);
                if (visitor != null)
                {
                    if (entity.ID != null)
                        entity.UseUserGroup = true;
                    else
                        entity.UseUserGroup = false;

                    _visitorsService.UpdateVisitor(entity);
                    _accessDatasService.AddOperatorLog(321, permissionUser.Kullanici_Adi, entity.Kayit_No, 0, 0, 0);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }

        public ActionResult Editt(int? id)
        {
            var visitors = _visitorsService.GetAllVisitors().Find(x => x.Kayit_No == id);
            if (visitors.Resim == null)
                visitors.Resim = "BaseUser.jpg";

            var model = new VisitorEditViewModel
            {
                Ziyaretci = visitors,
                GrupAdi = null,
                Personel = null,
                Personeller = ModalUser(),
                VisitorCardList = CardModelUser()
            };
            return View(model);
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
                if (visitor != null)
                {
                    _visitorsService.DeleteVisitor(visitor);
                    _accessDatasService.AddOperatorLog(322, permissionUser.Kullanici_Adi, visitor.Kayit_No, 0, 0, 0);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Send(List<int> PanelList, int VisitorID = -1)
        {
            if (permissionUser.SysAdmin == false)
            {
                if (permissionUser.Grup_Islemleri == (int)SecurityCode.Sadece_Izleme || permissionUser.Grup_Islemleri == (int)SecurityCode.Yetkisiz)
                    throw new Exception("Ziyaretçi göndermeye yetkiniz yok!");
            }
            if (VisitorID != -1)
            {
                try
                {

                    foreach (var item in PanelList)
                    {
                        var panelModel = _panelSettingsService.GetById(item);
                        if (panelModel.Panel_Model != (int)PanelModel.Panel_1010)
                        {
                            TaskList taskList = new TaskList
                            {
                                Deneme_Sayisi = 1,
                                Durum_Kodu = (int)PanelStatusCode.Beklemede,
                                Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
                                IntParam_1 = VisitorID,
                                Kullanici_Adi = user.Kullanici_Adi,
                                Panel_No = item,
                                Tablo_Guncelle = true,
                                Tarih = DateTime.Now
                            };
                            TaskList taskReceive = _taskListService.AddTaskList(taskList);
                            _accessDatasService.AddOperatorLog(323, permissionUser.Kullanici_Adi, VisitorID, 0, item, 0);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Upss! Yanlış Giden Birşeyler Var.");
                }
            }
            return RedirectToAction("Index");
        }

        public List<Users> CardModelUser()
        {

            List<Users> liste = new List<Users>();
            List<Users> userList = _userService.GetAllUsers().Where(x => x.Kullanici_Tipi == 1).ToList();
            if (permissionUser.SysAdmin == true)
            {
                return userList;
            }
            else
            {
                foreach (var sirket in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi))
                {
                    foreach (var departman in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi))
                    {
                        foreach (var user in userList)
                        {
                            if (user.Sirket_No == sirket.Sirket_No && user.Departman_No == departman.Departman_No)
                            {
                                liste.Add(user);
                            }
                        }
                    }
                }
                return liste.OrderByDescending(x => x.Kayit_No).ToList();
            }
        }

        public List<ComplexUser> ModalUser()
        {

            List<ComplexUser> liste = new List<ComplexUser>();
            List<ComplexUser> userList = _userService.GetAllUsersWithOuther();
            if (permissionUser.SysAdmin == true)
            {
                return userList;
            }
            else
            {
                foreach (var sirket in _dBUsersSirketService.GetAllDBUsersSirket(x => x.Kullanici_Adi == user.Kullanici_Adi))
                {
                    foreach (var departman in _dBUsersDepartmanService.GetAllDBUsersDepartman(x => x.Kullanici_Adi == user.Kullanici_Adi))
                    {
                        foreach (var user in userList)
                        {
                            if (user.Sirket_No == sirket.Sirket_No && user.Departman_No == departman.Departman_No)
                            {
                                liste.Add(user);
                            }
                        }
                    }
                }
                return liste.OrderByDescending(x => x.Kayit_No).ToList();
            }
        }

    }
}