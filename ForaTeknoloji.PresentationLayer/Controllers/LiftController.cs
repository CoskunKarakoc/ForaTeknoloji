using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Common;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class LiftController : Controller
    {
        private IFloorNamesService _floorNamesService;
        private ILiftGroupsService _liftGroupsService;
        private ITaskListService _taskListService;
        private FloorNames tempFloor;
        private DBUsers user;
        private PanelSettings PanelSettings;
        public LiftController(IFloorNamesService floorNamesService, ILiftGroupsService liftGroupsService, ITaskListService taskListService)
        {
            PanelSettings = CurrentSession.Panel;
            user = CurrentSession.User;
            if (user == null)
            {
                user = new DBUsers();
            }
            _floorNamesService = floorNamesService;
            _liftGroupsService = liftGroupsService;
            _taskListService = taskListService;

        }

        // AGG Listesi
        public ActionResult LiftGroups(int Status = -1)
        {
            var model = new LiftGroupsListViewModel
            {
                LiftGroup = _liftGroupsService.GetAllLiftGroups(),
                StatusControl = Status
            };

            return View(model);
        }

        //AGG Ekleme
        public ActionResult Create()
        {
            int MaxID;
            if (_liftGroupsService.GetAllLiftGroups().Count == 0)
                MaxID = 0;
            else
                MaxID = _liftGroupsService.GetAllLiftGroups().Max(x => x.Asansor_Grup_No);
            var model = new LiftGroupsAddViewModel
            {
                Asansor_Grup_No = MaxID + 1,
                FloorName = _floorNamesService.GetAllFloorNames()
            };
            return View(model);
        }
        [HttpPost]//AGG Ekleme
        public ActionResult Create(LiftGroups liftGroups)
        {
            if (ModelState.IsValid)
            {
                _liftGroupsService.AddLiftGroup(liftGroups);
                return RedirectToAction("LiftGroups", "Lift");
            }
            return View(liftGroups);
        }

        //AGG Güncelleme
        public ActionResult Edit(int? Asansor_Grup_No)
        {
            if (Asansor_Grup_No == null)
            {
                throw new Exception("Upss! Yanlış giden birşeyler var.");
            }
            var entity = _liftGroupsService.GetById((int)Asansor_Grup_No);
            if (entity == null)
            {
                throw new Exception("Kriterlere Uygun Kayıt Bulunamadı!");
            }
            else
            {
                var floornames = _floorNamesService.GetAllFloorNames();
                var model = new LiftEditViewModel
                {
                    LiftGroup = entity,
                    FloorName = floornames
                };
                return View(model);
            }


        }

        //AGG Güncelleme
        [HttpPost]
        public ActionResult Edit(LiftGroups liftGroups)
        {
            if (ModelState.IsValid)
            {
                _liftGroupsService.UpdateLiftGroup(liftGroups);
                return RedirectToAction("LiftGroups", "Lift");
            }
            return View(liftGroups);
        }



        //AGG listelemede ki Kat İsimleri
        public ActionResult FloorNamesList()
        {
            return Json(_floorNamesService.GetAllFloorNames(), JsonRequestBehavior.AllowGet);
        }

        //Panelden AGG Silme
        public ActionResult PanelRemove(int? id)
        {
            if (id != null)
            {
                if (PanelSettings == null)
                    return RedirectToAction("Orientation", "Home");

                try
                {
                    TaskList taskList = new TaskList
                    {
                        Deneme_Sayisi = 1,
                        Durum_Kodu = 1,
                        Gorev_Kodu = (int)CommandConstants.CMD_ERS_LIFTGROUP,
                        IntParam_1 = (int)id,
                        Kullanici_Adi = user.Kullanici_Adi,
                        Panel_No = PanelSettings.Panel_ID,
                        Tablo_Guncelle = true,
                        Tarih = DateTime.Now
                    };
                    TaskList taskListReceive = _taskListService.AddTaskList(taskList);
                    Thread.Sleep(2000);
                    var Durum = CheckStatus(taskListReceive.Grup_No);
                    if (Durum == 2)
                        return RedirectToAction("LiftGroups", new { @Status = 2 });
                    else if (Durum == 1)
                        return RedirectToAction("LiftGroups", new { @Status = 1 });
                    else
                        return RedirectToAction("LiftGroups", new { @Status = 3 });
                }
                catch (Exception)
                {
                    return RedirectToAction("LiftGroups", new { @Status = 3 });
                }
            }
            return RedirectToAction("LiftGroups", new { @Status = 3 });
        }

        //Veritabanından AGG Silme
        public ActionResult DatabaseRemove(int? id)
        {
            if (id != null)
            {
                var entity = _liftGroupsService.GetById((int)id);
                if (entity != null)
                {
                    _liftGroupsService.DeleteLiftGroup(new LiftGroups { Asansor_Grup_No = (int)id });
                    return RedirectToAction("LiftGroups");
                }
            }
            throw new Exception("Upps! Yanlış giden birşeyler var.");
        }

        //Kat İsimlerini Gösteren Sayfa
        public ActionResult FloorNames()
        {
            var floors = _floorNamesService.GetAllFloorNames();
            return View(floors);
        }

        [HttpPost]//Kat İsimlerini Güncelleme
        public ActionResult FloorNamesEdit(FloorNames floorNames)
        {
            if (ModelState.IsValid)
            {
                _floorNamesService.UpdateFloorName(floorNames);
                return RedirectToAction("FloorNames");
            }
            return RedirectToAction("FloorNames");
        }

        //Tüm Kat İsimlerini Silme
        public ActionResult AllNameRemove()
        {

            for (int i = 1; i <= 128; i++)
            {
                tempFloor = new FloorNames { Kat_No = i, Kat_Adi = "" };
                _floorNamesService.UpdateFloorName(tempFloor);
            }

            return RedirectToAction("FloorNames");
        }

        //Tüm Kat İsimlerini Sıralı Doldurma
        public ActionResult AllNameAdd()
        {
            for (int i = 1; i <= 128; i++)
            {
                tempFloor = new FloorNames { Kat_No = i, Kat_Adi = "Kat " + i };
                _floorNamesService.UpdateFloorName(tempFloor);
            }
            return RedirectToAction("FloorNames");
        }

        //Get Task Status
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