using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProManagement_Model
{
    public class Project_func
    {
        public int fid { get; set; }
        public string fno { get; set; }
        public string func_name { get; set; }
        public string fun_explain { get; set; }
        public int fun_principal { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string func_level { get; set; }
        public string file_url { get; set; }
        public string start_dates
        {
            get
            {
                return start_date.ToString("yyyy-MM-dd");
            }
        }
        public string end_dates
        {
            get
            {
                return end_date.ToString("yyyy-MM-dd");
            }
        }
    }
}
