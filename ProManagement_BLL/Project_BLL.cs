using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProManagement_Model;
using ProManagement_DAL;

namespace ProManagement_BLL
{
    public class Project_BLL
    {
        Project_DAL dal = new Project_DAL();
        //显示项目的方法
        public Page<project> Getproject(string Name, int PageIndex, int PageSize)
        {
            return dal.Getproject(Name, PageIndex, PageSize);
        }
        //根据项目的ID获取一条项目信息
        public project GetProjects(int Id)
        {
            return dal.GetProjects(Id);
        }
        //获取参与人的信息
        public List<project_emp> GetProjectsQuery(int Id)
        {
            return dal.GetProjectsQuery(Id);
        }
        //获取项目参与人下载文件权限
        public List<project_player> GetProject_Players(int Id)
        {
            return dal.GetProject_Players(Id);
        }
        //获取员工姓名，员工部门，员工编号的下拉框
        public List<project_player> Get_Emps(string Name)
        {
            return dal.Get_Emps(Name);
        }
        //Del修改项目的参与人
        public int UpDelProjectPlayer(int pid)
        {
            return dal.UpDelProjectPlayer(pid);
        }
        //删除项目的参与人
        public void DelProjectPlayer(project_player P)
        {
             dal.DelProjectPlayer(P);
        }
        //添加项目的参与人
        public void AddlProjectPlayer(project_player P)
        {
            dal.AddlProjectPlayer(P);
        }

        public int Login(string Name, string Pwd)
        {
            return dal.Login(Name,Pwd);
        }
        public List<project_type> GetProject_Type()
        {
            return dal.GetProject_Type();
        }
        public List<project_emp> GetProject_emp()
        {
            return dal.GetProject_emp();
        }
        public List<project_dept> GetProject_dept()
        {
            return dal.GetProject_dept();
        }
        public int PostProject(project P)
        {
            return dal.PostProject(P);
        }

        //添加员工信息
        public long PostProject_Employees(project_emp P)
        {
            return dal.PostProject_Employees(P);
        }
        //public Page<project_player> Getproject_player(string Name, int PageIndex, int PageSize)
        //{
        //    return dal.Getproject_player(Name, PageIndex, PageSize);
        //}
        //public long Getproject_player(project_player P)
        //{
        //    return dal.Getproject_player(P);
        //}
    }
}
