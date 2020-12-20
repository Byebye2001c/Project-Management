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
        Page<project> Pager = new Page<project>();
        Page<project_player> project_player = new Page<project_player>();
        project InsertPlayer = new project();

        #region 项目操作
        public Page<project> Getproject(string Name, int PageIndex, int PageSize)
        {
            string sql = @"SELECT A.pid,A.pname,B.tname,A.add_time,A.end_time_plan,C.ename,A.players,A.file_url FROM dbo.project A
                                JOIN dbo.project_type B ON B.tid = A.tid
                                JOIN dbo.project_emp C ON A.principal = C.eid WHERE 1 = 1";
            string RowSql = @"SELECT A.pid,A.pname,B.tname,A.add_time,A.end_time_plan,C.ename,A.players,A.file_url FROM dbo.project A
                                JOIN dbo.project_type B ON B.tid = A.tid
                                JOIN dbo.project_emp C ON A.principal = C.eid WHERE 1 = 1";
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $" and A.pname LIKE '%{Name}%'";
                RowSql += $" and A.pname LIKE '%{Name}%'";
            }
            sql += $" ORDER BY A.pid OFFSET {(PageIndex - 1) * PageSize} ROW FETCH NEXT {PageSize} ROW ONLY";
            List<project> list = db.GetData<project>(sql);
            List<project> RowList = db.GetData<project>(RowSql);
            Pager.RowCount = RowList.Count();
            
            for (int i = 0; i < Pager.RowCount; i++)
            {
                if (list[i].players.Contains(','))
                {
                    var ids = list[i].players.Split(',');
                    var html = "";
                    foreach (var item in ids)
                    {
                        html += FullPlayers(item).Trim() + ',';
                    }
                    html = html.Substring(0, html.Length - 1);
                    list[i].players = html;
                }
                else
                {
                    list[i].players = FullPlayers(list[i].players);
                }
                
            }
            Pager.PageCount = Convert.ToInt32(Math.Ceiling(Pager.RowCount * 1.0 / PageSize));
            Pager.PageIndex = PageIndex;
            Pager.PageSize = PageSize;
            Pager.Data = list;

            return Pager;
        }
        public string  FullPlayers(string player)
        {
            string sql = $"SELECT ename FROM project_emp WHERE eid = {player}";
            project list = db.GetData<project>(sql).FirstOrDefault();
            return list.ename;            
        }
        //根据项目的ID获取一条项目信息
        public project GetProjects(int Id)
        {
            string sql = $@"SELECT A.pid,A.pname,B.tname,A.add_time,A.end_time_plan,C.ename,A.players,A.file_url FROM dbo.project A
                                JOIN dbo.project_type B ON B.tid = A.tid
                                JOIN dbo.project_emp C ON A.principal = C.eid WHERE pid = {Id}";
            project list =  db.GetData<project>(sql).FirstOrDefault();
            var Newconversion = list.players.Split(',');
            string NewPlayer = "";
            foreach (var item in Newconversion)
            {
                NewPlayer += Getconversion(item);
            }
            list.players = NewPlayer;
            return list;
        }
        public string Getconversion(string Ids)
        {
            string sql = $"SELECT * FROM dbo.project_emp WHERE eid IN ({Ids})";
            project_emp NewPlay = db.GetData<project_emp>(sql).FirstOrDefault();
            string NewPlayer = NewPlay.ename;
            return NewPlayer;
        }
        # region 获取参与人的信息
        //获取参与人的信息
        public List<project_emp> GetProjectsQuery(int Id)
        {
            string sql = $"SELECT * FROM dbo.project where pid = {Id}";
            project Ids = db.GetData<project>(sql).FirstOrDefault();
            return GetProject_EmpsQuery(Ids.players);
        }
        public List<project_emp> GetProject_EmpsQuery(string ids)
        {
            string sql = $"SELECT * FROM dbo.project_emp WHERE  eid IN ({ids})";
            return db.GetData<project_emp>(sql);
        }
        #endregion
        //获取项目参与人下载文件权限
        public List<project_player> GetProject_Players(int Id)
        {
            string sql = $"SELECT * FROM dbo.project_player WHERE pid = {Id}";
            return db.GetData<project_player>(sql);
        }
        //获取员工姓名，员工部门，员工编号的下拉框
        public List<project_player> Get_Emps(string Name)
        {
            string sql = @"SELECT A.eid,A.ename,A.eno,B.tname FROM project_emp A
                            JOIN project_type B ON A.dept_Id = B.tid WHERE 1 = 1";
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $" AND  ename LIKE '%{Name}%'";
            }
            return db.GetData<project_player>(sql);
        }
        //添加项目
        public int PostProject(project P)
        {
            string sql = $"INSERT INTO dbo.project VALUES ('{P.pname}','{P.tid}','{P.add_time}','{P.end_time_plan}',{P.principal},'{P.players}','{P.file_url}')";
            string sqls = $"SELECT * FROM project WHERE pname = '{P.pname}' AND file_url = '{P.file_url}'";
            int Pas = db.ExecuteNonQuery(sql);
            project AddsPlayer = db.GetData<project>(sqls).FirstOrDefault();
            InsertPlayer = AddsPlayer;
            AddPlayer();
            return Pas;
        }
        public void AddPlayer()
        {
            if (InsertPlayer.players.Contains(','))
            {
                var sqls = InsertPlayer.players.Split(',');
                foreach (var item in sqls)
                {
                    db.ExecuteNonQuery($"insert into project_player values ({InsertPlayer.pid},{item},{1})");
                }
                
            }
            else
            {
                db.ExecuteNonQuery($"insert into project_player values ({InsertPlayer.pid},{InsertPlayer.players},{1})");
            }
        }
        //Del修改项目的参与人
        public int UpDelProjectPlayer(int pid)
        {
            string sqls = $"SELECT * FROM project WHERE pid = {pid}";
            project sqla = db.GetData<project>(sqls).FirstOrDefault();
            if (sqla.players.Contains(','))
            {
                var Newfull = sqla.players.Split(',');
                return Newfull.Count();
            }
            return 1;
        }
        //删除项目的参与人
        public void DelProjectPlayer(project_player P)
        {
            string sqla = $"UPDATE project SET players = '{P.eid}' WHERE pid = {P.pid}";
            db.ExecuteNonQuery(sqla);
            string sqls = $"DELETE FROM dbo.project_player WHERE eid in ({P.eid}) AND pid in ({P.pid})";
            db.ExecuteNonQuery(sqls);
        }
        //添加项目的参与人
        public void AddlProjectPlayer(project_player P)
        {
            
            string sqla = $"UPDATE project SET players = '{P.eid}' WHERE pid = {P.pid}";
            db.ExecuteNonQuery(sqla);
            string eid = P.eid.Substring(P.eid.Length-1,1);
            string sqls = $"insert into project_player values ({P.pid},{eid},{(P.can_download == true ? 1:0)})";
            db.ExecuteNonQuery(sqls);
        }

        #endregion

        #region 登录
        public int Login(string Name, string Pwd)
        {
            string sql = $"SELECT * FROM dbo.project_admin WHERE user_name = '{Name}' AND user_pwd = '{Pwd}'  ";
            return db.ExecuteScalar(sql);
        }
        #endregion 

        #region 绑定下拉框信息部分
        //获取部门分类下拉框
        public List<project_type> GetProject_Type()
        {
            string sql = "SELECT * FROM dbo.project_type";
            return db.GetData<project_type>(sql);
        }
        //获取员工分类下拉框
        public List<project_emp> GetProject_emp()
        {
            string sql = "SELECT * FROM dbo.project_emp";
            return db.GetData<project_emp>(sql);
        }
        //获取项目类型分类的下拉狂
        public List<project_dept> GetProject_dept()
        {
            string sql = "SELECT * FROM project_dept";
            return db.GetData<project_dept>(sql);
        }
        #endregion

        #region 员工操作
        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public Page<project_player> Getproject_player(string Name, int PageIndex, int PageSize)
        {
            string sql = @"SELECT A.project_EmployeesId,A.EmployeesName,A.Birthday,A.Native,A.Gender,A.GraduateSchool,
                        A.Record,A.Marriage,A.Inpost,A.UpEmpDate,A.EndEmpDate,A.Departuredate,A.Theobtainmentofdate,
                        A.Employeestel,B.DeptName,A.Tips,A.PersonalImgUrl FROM dbo.Project_Employees A
                       JOIN dbo.project_dept B ON B.DeptId = A.DeptId WHERE 1 = 1";
            string RowSql = @"SELECT A.project_EmployeesId,A.EmployeesName,A.Birthday,A.Native,A.Gender,A.GraduateSchool,
                        A.Record,A.Marriage,A.Inpost,A.UpEmpDate,A.EndEmpDate,A.Departuredate,A.Theobtainmentofdate,
                        A.Employeestel,B.DeptName,A.Tips,A.PersonalImgUrl FROM dbo.Project_Employees A
                       JOIN dbo.project_dept B ON B.DeptId = A.DeptId WHERE 1 = 1";
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $" AND A.EmployeesName LIKE '%{Name}%'";
                RowSql += $" AND A.EmployeesName LIKE '%{Name}%'";
            }
            sql += $" ORDER BY A.project_EmployeesId OFFSET {(PageIndex - 1) * PageSize} ROW FETCH NEXT {PageSize} ROW ONLY";
            List<project_player> list = db.GetData<project_player>(sql);
            List<project_player> RowList = db.GetData<project_player>(RowSql);
            project_player.RowCount = RowList.Count();
            project_player.PageCount = Convert.ToInt32(Math.Ceiling(Pager.RowCount * 1.0 / PageSize));
            project_player.PageIndex = PageIndex;
            project_player.PageSize = PageSize;
            project_player.Data = list;

            return project_player;
        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        /// 
        //添加员工信息
        public long PostProject_Employees(project_emp P)
        {
            string sql = $@"INSERT INTO dbo.project_emp VALUES ( '{""}',N'{P.ename}', '{P.birth_date}', N'{P.native}',{(P.gender == true ? 1:0)}, N'{P.graduate_institution}', N'{P.education}', {(P.is_marry == true ? 1:0)}, N'{P.job}','{P.qualified_date}', '{P.dimission_date}', '{P.job_date}', {(P.is_qualified == true ? 1:0)}, {P.phone},{P.dept_Id}, N'{P.ps}', N'{P.id_photo_url}' )";
            return db.ExecuteNonQuery(sql);
        }
        #endregion


    }
}
