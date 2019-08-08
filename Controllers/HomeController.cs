using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DirectoriesSystem.Models;

namespace DirectoriesSystem.Controllers
{
    public class HomeController : Controller
    {
        FolderContext db = new FolderContext();
        public ActionResult Index()
        {
            string curPath = HttpContext.Request.Url.LocalPath;
            string host = HttpContext.Request.Url.Authority;


            Folder f1 = db.Folder.FirstOrDefault(s => @"/" + s.Path == curPath.Replace("%20", " "));
            if (f1 != null)
            {
                ViewBag.ReferRoot = null;
                ViewBag.folderTitle = f1.Name;
                List<Folder> childFoldersList = f1.Children;
                ViewBag.childFoldersList = childFoldersList;

            }
            else
            {
                if (curPath == "/" || curPath == "/Home/Index")
                {
                    Folder f = db.Folder.FirstOrDefault();
                    if (f != null)
                    {

                        ViewBag.folderTitle = f.Name;
                        ViewBag.ReferRoot = "http://" + host + @"/" + f.Path.Replace(" ", "%20");
                        //List<Folder> childFoldersList = f.Children;
                        //ViewBag.childFoldersList = childFoldersList;
                    }
                }
                // Folder f = db.Folder.FirstOrDefault();

            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(string url)
        {
            return View();
        }

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}