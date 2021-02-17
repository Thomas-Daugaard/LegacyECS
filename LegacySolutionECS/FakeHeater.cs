using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class FakeHeater : IHeater
    {
        public void TurnOn()
        {

        }
        public void TurnOff()
        {

        }
        public bool RunSelfTest()
        {
            return true;
        }
    }
}
