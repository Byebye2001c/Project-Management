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
        public Page<project_list> Getproject(string Name, int PageIndex, int PageSize)
        {
            return dal.Getproject(Name, PageIndex, PageSize);
        }
        public int Login(string Account, string Password)
        {
            return dal.Login(Account, Password);
        }
        public List<project_type> GetProject_Type()
        {
            return dal.GetProject_Type();
        }
        public List<project_emp> GetProject_emp()
        {
            return dal.GetProject_emp();
        }
        public int PostProject(project_list P)
        {
            return dal.PostProject(P);
        }
    }
}
