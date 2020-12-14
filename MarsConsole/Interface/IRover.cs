using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsConsole.Interface
{
    public interface IRover
    {
        string Process();

        string Process(string movementData);
        void ProcessInPutData(int maxXValue, int maxYValue);
    }
}
