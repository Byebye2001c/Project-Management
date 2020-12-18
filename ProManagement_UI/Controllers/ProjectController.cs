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

        #region 登录
        public ActionResult LoginEmp()
        {
            return View();
        }
        public JsonResult Login(string Account, string Password)
        {
            return Json(bll.Login(Account, Password), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 绑定下拉框方法
        public JsonResult GetProject_Type()
        {
            return Json(bll.GetProject_Type(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject_emp()
        {
            return Json(bll.GetProject_emp(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject_dept()
        {
            return Json(bll.GetProject_dept(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 项目信息及主界面显示
        public ActionResult ShowProject()
        {
            return View();
        }
        public JsonResult Getproject(string Name="", int PageIndex=1, int PageSize=10)
        {
            return Json(bll.Getproject(Name, PageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
        #region 添加项目信息
        public ActionResult AddProject()
        {
            return View();
        }
        public ActionResult fileUpLoad()
        {
            HttpPostedFileBase Postfile = Request.Files[0];

            string Pathfile = "";
            if (Postfile.ContentLength > 0)
            {
                string fileName = Postfile.FileName;
                string extName = Path.GetFileName(fileName);
                string FullfileName = Guid.NewGuid().ToString() + extName;
                string NewName = Path.Combine(Server.MapPath("~/file/"), FullfileName);
                Postfile.SaveAs(NewName);
                Pathfile = "/file/" + FullfileName;
            }
            return Content(Pathfile);
        }
        public JsonResult PostProject(project_list P)
        {
            return Json(bll.PostProject(P));
        }
        #endregion
        #endregion

        #region 员工信息

        #region 添加员工信息
        public ActionResult Addemployees()
        {
            return View();
        }
        public ActionResult PicUpLoad()
        {
            HttpPostedFileBase Postfile = Request.Files[0];

            string Pathfile = "";
            if (Postfile.ContentLength > 0)
            {
                string fileName = Postfile.FileName;
                string extName = Path.GetFileName(fileName);
                string FullfileName = Guid.NewGuid().ToString() + extName;
                string NewName = Path.Combine(Server.MapPath("~/Img/"), FullfileName);
                Postfile.SaveAs(NewName);
                Pathfile = "/Img/" + FullfileName;
            }
            return Content(Pathfile);
        }
        public JsonResult PostProject_Employees(Project_Employees P)
        {
            return Json(bll.PostProject_Employees(P));
        }
        #endregion

        #region 显示员工信息
        public JsonResult Getproject_Employees(string Name="", int PageIndex=1, int PageSize=10)
        {
            return Json(bll.Getproject_Employees(Name, PageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
        #endregion
        #endregion
    }
}