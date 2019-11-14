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
        private PanelSettings PanelSettings;
        private DBUsers user;
        public VisitorController(IVisitorsService visitorsService, IUserService userService, IGroupMasterService groupMasterService, ITaskListService taskListService)
        {
            PanelSettings = CurrentSession.Panel;
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _visitorsService = visitorsService;
            _userService = userService;
            _groupMasterService = groupMasterService;
            _taskListService = taskListService;
        }



        // GET: Visitor
        public ActionResult Index(string Search, int Status = -1)
        {
            if (Search != null && Search != "")
            {
                var model = new VisitorListViewModel
                {
                    Visitor = _visitorsService.GetAllVisitors(x => x.Adi.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.TCKimlik.Contains(Search.Trim()) || x.Telefon.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Ziyaret_Sebebi.Contains(Search.Trim())),
                    StatusControl = Status
                };

                return View(model);
            }
            else
            {
                var model = new VisitorListViewModel
                {
                    Visitor = _visitorsService.GetAllVisitors(),
                    StatusControl = Status
                };
                return View(model);
            }
        }


        public ActionResult Create()
        {

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
                ComplexPersoneller = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList()
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

            if (ModelState.IsValid)
            {
                _visitorsService.AddVisitor(visitors);
                return RedirectToAction("Index");
            }

            return View(visitors);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Upps! Yanlış giden birşeyler var.");
            }
            Visitors visitors = _visitorsService.GetById((int)id);
            if (visitors.Resim == null)
                visitors.Resim = "BaseUser.jpg";
            Users users = _userService.GetById((int)visitors.User_ID);
            if (visitors == null)
            {
                return HttpNotFound();
            }
            var model = new VisitorEditViewModel
            {
                Ziyaretci = visitors,
                Personel = users,
                Personeller = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList()
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
                string filename = $"visitor_{entity.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
                entity.Resim = filename;
            }
            if (ModelState.IsValid)
            {
                var visitor = _visitorsService.GetById((int)entity.ID);
                if (visitor != null)
                {
                    _visitorsService.UpdateVisitor(entity);
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }


        public ActionResult Delete(int id = -1)
        {
            if (id != -1)
            {
                Visitors visitor = _visitorsService.GetById(id);
                if (visitor != null)
                {
                    _visitorsService.DeleteVisitor(visitor);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Send(int VisitorID = -1)
        {
            if (VisitorID != -1)
            {
                if (PanelSettings == null)
                    return RedirectToAction("Orientation", "Home");
                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = (int)CommandConstants.CMD_SND_USER,
                        IntParam_1 = VisitorID,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = PanelSettings.Panel_ID,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("Index", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("Index", new { @Status = 1 });
                    else
                        return RedirectToAction("Index", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", new { @Status = 3 });
                }
            }
            return RedirectToAction("Index", new { @Status = 3 });
        }


        public ActionResult Personeller(string Search)
        {
            List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser> liste = new List<DataAccessLayer.Concrete.EntityFramework.EfUserDal.ComplexUser>();

            if (Search != null && Search != "")
            {
                liste = _userService.GetAllUsersWithOuther(x => x.Adi.Contains(Search.Trim()) || x.Kart_ID.Contains(Search.Trim()) || x.Soyadi.Contains(Search.Trim()) || x.Plaka.Contains(Search.Trim()) || x.Sirket.Contains(Search.Trim()) || x.Departman.Contains(Search.Trim()) || x.Blok.Contains(Search.Trim()) || x.Gecis_Grubu.Contains(Search.Trim())).OrderBy(x => x.Kayit_No).ToList();
            }
            else
            {
                liste = _userService.GetAllUsersWithOuther().OrderBy(x => x.Kayit_No).ToList();
            }

            return Json(liste, JsonRequestBehavior.AllowGet);

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