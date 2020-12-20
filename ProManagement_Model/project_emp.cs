using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProManagement_Model
{
    public class project_emp
    {
        public int eid { get; set; }
        public string eno { get; set; }
        public string ename { get; set; }
        public DateTime birth_date { get; set; }
        public string native { get; set; }
        public bool gender { get; set; }
        public string graduate_institution { get; set; }
        public string education { get; set; }
        public bool is_marry { get; set; }
        public string job { get; set; }
        public DateTime qualified_date { get; set; }
        public DateTime dimission_date { get; set; }
        public DateTime job_date { get; set; }
        public bool is_qualified { get; set; }
        public int phone { get; set; }
        public int dept_Id { get; set; }
        public string ps { get; set; }
        public string id_photo_url { get; set; }
    }
}
