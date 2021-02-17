using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public interface ITempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
}
