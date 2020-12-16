using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProManagement_Model
{
    public class project_list
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDates
        {
            get
            {
                return StartDate.ToString("yyyy-MM-dd");
            }
        }
        public DateTime PlanEndDate { get; set; }
        public string PlanEndDates
        {
            get
            {
                return PlanEndDate.ToString("yyyy-MM-dd");
            }
        }
        public int EmpId { get; set; }
        public string AName { get; set; }
        public int TypeId { get; set; }
        public string CName { get; set; }

        public string EmpIn { get; set; }
        public string AccessUrl { get; set; }


    }
}
