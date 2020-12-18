using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProManagement_Model;

namespace ProManagement_DAL
{
    public class Project_DAL
    {
        Dbhelper db = new Dbhelper();
        Page<project_list> Pager = new Page<project_list>();
        public Page<project_list> Getproject(string Name, int PageIndex, int PageSize)
        {
            string sql = @"SELECT B.Id,B.Name,B.StartDate,B.PlanEndDate,A.Name AS AName,C.Name AS CName,B.EmpIn,B.AccessUrl FROM project_emp A
                        JOIN project_list B ON A.Id = B.empId
                        JOIN project_type C ON B.typeId = C.Id WHERE 1 =1";
            string RowSql = @"SELECT * FROM project_emp A
                        JOIN project_list B ON A.Id = B.empId
                        JOIN project_type C ON B.typeId = C.Id WHERE 1 =1 ";
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $" AND B.Name LIKE '%{Name}%'";
                RowSql += $" AND B.Name LIKE '%{Name}%'";
            }
            sql += $" ORDER BY B.Id OFFSET {(PageIndex - 1) * PageSize} ROW FETCH NEXT {PageSize} ROW ONLY";
            List<project_list> list = db.GetData<project_list>(sql);
            List<project_list> RowList = db.GetData<project_list>(RowSql);
            Pager.RowCount = RowList.Count();
            Pager.PageCount = Convert.ToInt32(Math.Ceiling(Pager.RowCount * 1.0 / PageSize));
            Pager.PageIndex = PageIndex;
            Pager.PageSize = PageSize;
            Pager.Data = list;

            return Pager;
        }

        public int Login(string Account, string Password)
        {
            string sql = $"SELECT Count(1) FROM project_emp WHERE Account = '{Account}' AND [Password] = '{Password}' ";
            return db.ExecuteScalar(sql);
        }
        public List<project_type> GetProject_Type()
        {
            string sql = "SELECT * FROM dbo.project_type";
            return db.GetData<project_type>(sql);
        }
        public List<project_emp> GetProject_emp()
        {
            string sql = "SELECT * FROM dbo.project_emp";
            return db.GetData<project_emp>(sql);
        }
        public List<Project_dept> GetProject_dept()
        {
            string sql = "SELECT * FROM project_dept";
            return db.GetData<Project_dept>(sql);
        }
        public int PostProject(project_list P)
        {
            string sql = $@"INSERT INTO dbo.project_list(Name,StartDate,PlanEndDate,EmpId,TypeId,EmpIn,AccessUrl) VALUES ('{P.Name}','{P.StartDates}','{P.PlanEndDates}',{P.EmpId},{P.TypeId},'{P.EmpIn}','{P.AccessUrl}')";

            return db.ExecuteNonQuery(sql);
        }
        public long PostProject_Employees(Project_Employees P)
        {
            if (Convert.ToInt32(P.Departuredates.ToString().Substring(0,1)) <= 0)
            {
                P.Departuredates = "null";
            }
            string sql = $@"INSERT INTO dbo.Project_Employees
                        (
                            EmployeesName,
                            Birthday,
                            Native,
                            Gender,
                            GraduateSchool,
                            Record,
                            Marriage,
                            Inpost,
                            UpEmpDate,
                            EndEmpDate,
                            Departuredate,
                            Theobtainmentofdate,
                            Employeestel,
                            DeptId,
                            Tips,
                            PersonalImgUrl
                        )
                        VALUES
                        (   N'{P.EmployeesName}',
                            '{P.Birthdays}',
                            N'{P.Native}',
                            {(P.Gender == true ? 1:0)},
                            N'{P.GraduateSchool}',
                            N'{P.Record}',
                            {(P.Marriage == true ? 1:0)},
                            N'{P.Inpost}',
                            '{P.UpEmpDates}',
                            '{P.EndEmpDates}',
                            {P.Departuredates},
                            {(P.Theobtainmentofdate == true ? 1:0)},
                            {P.Employeestel},
                            {P.DeptId},
                            N'{P.Tips}',
                            N'{P.PersonalImgUrl}'
                            )";
            return db.ExecuteNonQuery(sql);
        }
    }
}
