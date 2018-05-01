using System;
using System.IO;
using Newtonsoft.Json;

namespace BasisForDeveloper.ConfigurationDefinition
{
    public class InstanceConfiguration<T>
        where T : ConfigurationFile
    {
        private static InstanceConfiguration<T> Data;
        private T _ConfigurationFile;

        private InstanceConfiguration()
        {
            StreamReader input = new StreamReader("Config/Config.json");
            String file = input.ReadToEnd();
            _ConfigurationFile = JsonConvert.DeserializeObject<T>(file);
            input.Close();
        }

        public static T Config {
            get
            {
                if(Data == null)
                {
                    Data = new InstanceConfiguration<T>();
                }
                return Data._ConfigurationFile;
            }
        }
    }
}
