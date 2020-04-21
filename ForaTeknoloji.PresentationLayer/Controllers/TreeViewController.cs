using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    public class TreeViewController : Controller
    {

        private IDepartmanService _departmanService;
        private IAltDepartmanService _altDepartmanService;
        private IBolumService _bolumService;
        private IPanelSettingsService _panelSettingsService;
        private IReaderSettingsNewService _readerSettingsNewService;

        public TreeViewController(IDepartmanService departmanService, IAltDepartmanService altDepartmanService, IBolumService bolumService, IPanelSettingsService panelSettingsService, IReaderSettingsNewService readerSettingsNewService)
        {
            _departmanService = departmanService;
            _altDepartmanService = altDepartmanService;
            _bolumService = bolumService;
            _panelSettingsService = panelSettingsService;
            _readerSettingsNewService = readerSettingsNewService;
        }


        // GET: TreeView
        public ActionResult Index()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            //Ana Root
            foreach (Departmanlar type in _departmanService.GetAllDepartmanlar())
            {
                nodes.Add(new TreeViewNode { id = type.Departman_No.ToString(), parent = "#", text = type.Adi });
            }
            //SubRoot
            foreach (AltDepartman subType in _altDepartmanService.GetAllAltDepartman())
            {
                nodes.Add(new TreeViewNode { id = subType.Departman_No.ToString() + "-" + subType.Alt_Departman_No.ToString(), parent = subType.Departman_No.ToString(), text = subType.Adi });
            }
            //Serialize to JSON string.
            ViewBag.Json = (new JavaScriptSerializer()).Serialize(nodes);
            return View();
        }

        [HttpPost]
        public ActionResult Index(string selectedItems)
        {
            List<TreeViewNode> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewNode>>(selectedItems);
            return RedirectToAction("Index");
        }


        public ActionResult DoorTrigger()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            //Ana Root
            foreach (PanelSettings type in _panelSettingsService.GetAllPanelSettings(x => x.Panel_IP1 != 0 && x.Panel_TCP_Port != 0))
            {
                nodes.Add(new TreeViewNode { id = type.Panel_ID.ToString(), parent = "#", text = type.Panel_Name });
            }
            //SubRoot
            foreach (ReaderSettingsNew subType in _readerSettingsNewService.GetAllReaderSettingsNew())
            {
                nodes.Add(new TreeViewNode { id = subType.Panel_ID.ToString() + "-" + subType.WKapi_ID.ToString(), parent = subType.Panel_ID.ToString(), text = subType.WKapi_Adi });
            }
            //Serialize to JSON string.
            ViewBag.Json = (new JavaScriptSerializer()).Serialize(nodes);
            return View();
        }

        [HttpPost]
        public ActionResult DoorTrigger(string selectedItems)
        {
            List<TreeViewNode> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewNode>>(selectedItems);
            return RedirectToAction("DoorTrigger");
        }





    }



}