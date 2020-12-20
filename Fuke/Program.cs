using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fuke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> list = new List<dynamic>();
            list.Add(new { id = 1, text= "Option 1.1" });
            list.Add(new { id = 2, text = "Option 1.2" });

            var db = new { text="Group 1",children = list };

            List<dynamic> listTo = new List<dynamic>();

            listTo.Add(new { id = 1, text = "Option 2.1" });
            listTo.Add(new { id = 2, text = "Option 2.2" });

            var dbto = new { text = "Group 2", children = listTo };

            var js = JsonConvert.SerializeObject(db);
            var js2 = JsonConvert.SerializeObject(db);

            List<dynamic> listAc = new List<dynamic>();

            listAc.Add(new { more = true });

            var jsc = js + js2;          

            var jsd = new { results = jsc , pagination =listAc };

            var jscc = JsonConvert.SerializeObject(jsd);

            Console.WriteLine(jscc);
            Console.ReadKey();


        }
    }
}
