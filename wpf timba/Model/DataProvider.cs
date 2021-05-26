using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_timba.Model
{
    public class DataProvider : IDataProvider
    {
        public DataProvider(fileNme: String) { 
        }

        public IEnumerable<AbiturentNapravlenie> GetAbiturentNapravlenies()
        {
            
        }

        public IEnumerable<Abiturent> GetAbiturents()
        {
            throw new NotImplementedException();
        }
    }
}
