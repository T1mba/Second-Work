using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_timba.Model
{
     public interface IDataProvider
    {
        IEnumerable<Abiturent> GetAbiturents();
        IEnumerable<AbiturentNapravlenie> GetAbiturentNapravlenies();
      
    }
   
   
}
