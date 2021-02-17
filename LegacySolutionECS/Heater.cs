using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class Heater : IHeater
    {
        public void TurnOn()
        {
            System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
        //heater is external depedency
        //IHeater
        //make fake heater
    }
}
