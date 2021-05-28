using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_timba.Model
{
    public class DataProvider : IDataProvider
    {
        private List<Abiturent> AbiturientList = new List<Abiturent>();

        public DataProvider(String fileName)
        {

            using (TextFieldParser parser = new TextFieldParser(fileName)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    //метод ReadFields разбивает исходную строку на массив строк
                    string[] fields = parser.ReadFields();
                    AbiturientList.Add(
                        new Abiturent {
                            Name = fields[0], 
                            Age = int.Parse(fields[1]),
                            Klass = int.Parse(fields[2]),
                            Napravlenie = fields[3],
                            Ball = Double.Parse(fields[4]),
                            DataEnd = DateTime.Parse(fields[5])
                        }
                        );
                   
                }
            }
        }
    

        public IEnumerable<AbiturentNapravlenie> GetAbiturentNapravlenies()
        {
            return new AbiturentNapravlenie[]
            {
                 new AbiturentNapravlenie{ Title = "Коммерция"},
                new AbiturentNapravlenie { Title = "Парикмахер"}
            };
        }

        public IEnumerable<Abiturent> GetAbiturents()
        {

            return AbiturientList;
        }
    }
}
