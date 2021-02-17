﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class FakeTempSensor : ITempSensor
    {
        public int GetTemp()
        {
            return 0;
        }
        public bool RunSelfTest()
        {
            return true;
        }
    }
}
