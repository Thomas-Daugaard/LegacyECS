using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public interface IHeater
    {
        void TurnOn();
        void TurnOff();
        //test test

        bool RunSelfTest();
    }
}
