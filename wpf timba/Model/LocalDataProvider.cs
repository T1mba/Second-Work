using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_timba.Model
{
    public class LocalDataProvider : IDataProvider
    {
        public IEnumerable<AbiturentNapravlenie> GetAbiturentNapravlenies()
        {
            return new AbiturentNapravlenie[]
            {
                new AbiturentNapravlenie{ Title = "Программист"},
                new AbiturentNapravlenie { Title = "Парикмахер"}
            };
        }




        public IEnumerable<Abiturent> GetAbiturents()
        {
            return new Abiturent[]
            {
                new Abiturent{Name = "Антон Владимирович Усепов", Age = 16, Klass = 9, Napravlenie = "Парикмахер", Ball = 3.60, DataEnd = new DateTime(2021, 1, 15)},
                new Abiturent {Name = "Игимбаев Тимур Ернарович", Age = 17, Klass = 11, Napravlenie = "Программист", Ball = 4.05, DataEnd = new DateTime(2019, 2, 20)},
                new Abiturent { Name = "Шарапова Екатерина Александровна", Age=18, Klass = 11, Napravlenie = "Программист", Ball = 4.65, DataEnd = new DateTime(2019, 11, 25)}
            };
            
        }

        
        }
    
    
    
}
