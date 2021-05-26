using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_timba.Model
{
    public class Abiturent
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Klass { get; set; }
        public string Napravlenie { get; set; }
        public double Ball { get; set; }
        public DateTime DataEnd { get; set; }


        public String DateEndString {
            get {
                return DataEnd.ToLongDateString();
            }
        }
      


    }
}
