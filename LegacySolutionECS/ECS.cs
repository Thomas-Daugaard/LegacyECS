using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class ECS
    {
        //Property injection
        private int _threshold;
        public ITempSensor _tempSensor { private get; set; }
        public IHeater _heater { private get; set; }

        //Constructor injection
        public ECS(int thr)
        {
            SetThreshold(thr);
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
