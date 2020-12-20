using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProManagement_Model
{
    public class project
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int tid { get; set; }
        public string tname { get; set; }
        public DateTime add_time { get; set; }
        public string add_times
        {
            get
            {
                return add_time.ToString("yyyy-MM-dd");
            }
        }
        public DateTime end_time_plan { get; set; }
        public string end_time_plans
        {
            get
            {
                return end_time_plan.ToString("yyyy-MM-dd");
            }
        }
        public int principal { get; set; }
        public string ename { get; set; }
        public string players { get; set; }
        public string file_url { get; set; }
        public bool can_download { get; set; }

    }
}
