using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Shared.Interfaces
{
    public interface IJONSerializer
    {
        T Deserialize<T>(string text);

        string Serialize<T>(T obj);
    }
}
