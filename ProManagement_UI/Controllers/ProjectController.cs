using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProManagement_BLL;
using ProManagement_Model;
using System.IO;

namespace ProManagement_UI.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        Project_BLL bll = new Project_BLL();
        public ActionResult LoginEmp()
        {
            return View();
        }
        public ActionResult ShowProject()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }
        public ActionResult Addtest()
        {
            return View();
        }

        public JsonResult Getproject(string Name="", int PageIndex=1, int PageSize=3)
        {
            return Json(bll.Getproject(Name, PageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(string Account, string Password)
        {
            return Json(bll.Login(Account, Password), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject_Type()
        {
            return Json(bll.GetProject_Type(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject_emp()
        {
            return Json(bll.GetProject_emp(), JsonRequestBehavior.AllowGet);
        }
        //public JsonResult fileUpLoad()
        //{
        //    HttpPostedFileBase Postfile = Request.Files[0];

        //    string Pathfile = "";
        //    if (Postfile.ContentLength > 0)
        //    {
        //        string fileName = Postfile.FileName;
        //        string extName = Path.GetFileName(fileName);
        //        string FullfileName = Guid.NewGuid().ToString() + extName;
        //        string NewName = Path.Combine(Server.MapPath(""),FullfileName);
        //        Postfile.SaveAs(NewName);
        //        Pathfile = "";
        //    }
        //}
        public int PostProject(project_list P)
        {
            return bll.PostProject(P);
        }
    }
}