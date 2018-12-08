using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Services {
    public class JSONSerializer : IJSONSerializer {
        public T Deserialize<T>(string text) {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public string Serialize<T>(T obj) {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
