using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace wpf_timba.Model
{
    [Serializable]
    [DataContract]

    public class JSONDataProvider : IDataProvider
    {
        private List<Abiturent> AbiturientList = new List<Abiturent>();

        public JSONDataProvider(String fileName)
        {
            var Serializer = new DataContractJsonSerializer(typeof(Abiturent[]));
            using (var StreamWriter = new StreamWriter(fileName))
            {
                Serializer.WriteObject(
                        StreamWriter.BaseStream,
                       // Преобразуем список (List) объектов в МАССИВ
                       AbiturientList.ToArray()
   );
            }
        }



public IEnumerable<AbiturentNapravlenie> GetAbiturentNapravlenies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Abiturent> GetAbiturents()
        {
            throw new NotImplementedException();
        }
    }
    


}
