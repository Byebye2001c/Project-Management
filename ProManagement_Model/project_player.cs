using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProManagement_Model
{
    public class project_player
    {
        public int id { get; set; }
        public int pid { get; set; }
        public string eid { get; set; }
        public bool can_download { get; set; }
        public string ename { get; set; }
        public int eno { get; set; }
        public string tname { get; set; }
    }
}
