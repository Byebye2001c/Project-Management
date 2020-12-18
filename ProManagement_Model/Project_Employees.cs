using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProManagement_Model
{
    public class Project_Employees
    {
        public int project_EmployeesId { get; set; }
        public string EmployeesName { get; set; }
        public DateTime Birthday { get; set; }
        public string Native { get; set; }
        public bool Gender { get; set; }
        public string GraduateSchool { get; set; }
        public string Record { get; set; }
        public bool Marriage { get; set; }
        public string Inpost { get; set; }
        public DateTime UpEmpDate { get; set; }
        public DateTime EndEmpDate { get; set; }
        public DateTime Departuredate { get; set; }
        public bool Theobtainmentofdate { get; set; }
        public int Employeestel { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Tips { get; set; }
        public string PersonalImgUrl { get; set; }


        public string Birthdays
        {
            get
            {
                return Birthday.ToString("yyyy-MM-dd");
            }
        }
        public string UpEmpDates
        {
            get
            {
                return UpEmpDate.ToString("yyyy-MM-dd");
            }
        }
        public string EndEmpDates
        {
            get
            {
                return EndEmpDate.ToString("yyyy-MM-dd");
            }
        }
        public string Departuredates
        {
            get
            {
                return Departuredate.ToString("yyyy-MM-dd");
            }
            set { }
        }
    }
}
