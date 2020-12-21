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
        public JsonResult Login(string Name, string Pwd)
        {
            return Json(bll.Login(Name,Pwd), JsonRequestBehavior.AllowGet);
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
        public JsonResult Getproject(string Name="", int PageIndex=1, int PageSize=2)
        {
            return Json(bll.Getproject(Name, PageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
        //根据项目的ID获取一条项目信息
        public JsonResult GetProjects(int Id)
        {
            return Json(bll.GetProjects(Id),JsonRequestBehavior.AllowGet);
        }
        //获取参与人的信息
        public JsonResult GetProjectsQuery(int Id=0)
        {
            return Json(bll.GetProjectsQuery(Id),JsonRequestBehavior.AllowGet);
        }
        //获取项目参与人下载文件权限
        public JsonResult GetProject_Players(int Id)
        {
            return Json(bll.GetProject_Players(Id),JsonRequestBehavior.AllowGet);
        }
        //获取员工姓名，员工部门，员工编号的下拉框
        public JsonResult Get_Emps(string Name="")
        {
            return Json(bll.Get_Emps(Name), JsonRequestBehavior.AllowGet);
        }

        #region 分配参与人信息
        //Del修改项目的参与人
        public JsonResult UpDelProjectPlayer(int pid)
        {
            return Json(bll.UpDelProjectPlayer(pid), JsonRequestBehavior.AllowGet);
        }
        //删除项目的参与人
        public void DelProjectPlayer(project_player P)
        {
            bll.DelProjectPlayer(P);
        }
        //添加项目的参与人
        public void AddlProjectPlayer(project_player P)
        {
            bll.AddlProjectPlayer(P);
        }
        #endregion

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
        public JsonResult PostProject(project P)
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

        public long PostProject_Employees(project_emp P)
        {
            return bll.PostProject_Employees(P);
        }
        #endregion

        #region 显示员工信息
        //public JsonResult Getproject_Employees(string Name="", int PageIndex=1, int PageSize=10)
        //{
        //    return Json(bll.Getproject_player(Name, PageIndex, PageSize), JsonRequestBehavior.AllowGet);
        //}
        #endregion
        #endregion

        #region 参与人
        public ActionResult PostParticipants()
        {
            return View();
        }

        #endregion

        #region 项目功能模块
        //获取添加项目模块的项目名称
        public JsonResult GetProjectPid(int pid)
        {
            return Json(bll.GetProjectPid(pid), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowPostFunc()
        {
            return View();
        }
        public ActionResult FunCfileUpLoad()
        {
            HttpPostedFileBase Postfile = Request.Files[0];

            string Pathfile = "";
            if (Postfile.ContentLength > 0)
            {
                string fileName = Postfile.FileName;
                string extName = Path.GetExtension(fileName);
                string FullfileName = Guid.NewGuid().ToString() + extName;
                Postfile.SaveAs(Server.MapPath("~/file/") + FullfileName);
                Pathfile = "/file/" + FullfileName;
            }
            return Content(Pathfile);
        }
        #endregion
        #region 项目功能模块
        //获取项目模块添加页面的下拉框 -- 将参与人反填至下拉框
        public JsonResult GetFuncPlayer(int pid)
        {
            return Json(bll.GetFuncPlayer(pid), JsonRequestBehavior.AllowGet);
        }
        //查询数据库中项目编号是否重复
        public JsonResult GetFunCrepeat(string fno)
        {
            return Json(bll.GetFunCrepeat(fno), JsonRequestBehavior.AllowGet);
        }
        //添加项目模块
        public JsonResult PostFunc(Project_func P)
        {
            return Json(bll.PostFunc(P),JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}