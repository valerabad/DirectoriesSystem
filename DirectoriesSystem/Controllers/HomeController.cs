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

            Folder curFolder = db.Folder.FirstOrDefault(s => @"/" + s.Path == curPath.Replace("%20", " "));
            if (curFolder != null)
            {
                ViewBag.ReferRoot = null;
                ViewBag.folderTitle = curFolder.Name;
                ViewBag.Host = "http://" + host;
                List<Folder> childFoldersList = curFolder.Children;
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
                    }
                }             
            }

            return View("Index");
        }       
      
    }
}