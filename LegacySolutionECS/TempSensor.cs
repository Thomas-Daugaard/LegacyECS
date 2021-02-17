using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
        //heater is external depedency
        //ITempSensor
        //make fake TempSensor
    }
}
