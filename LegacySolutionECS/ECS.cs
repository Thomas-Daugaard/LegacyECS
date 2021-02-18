using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class ECS
    {
        //Property injection
        private int _threshold;

        private int _windowThreshold = 25; //Window extension
        public int _WindowThreshold //Window extension
        {
            get
            {
                return _windowThreshold;
            }
            set
            {
                _windowThreshold = _WindowThreshold;
            }
        }  


        public ITempSensor _tempSensor { private get; set; }
        public IHeater _heater { private get; set; }
        public IWindow _Window { private get; set; }  //Window extension

        //Constructor injection
        public ECS(int thr)
        {
            SetThreshold(thr);
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
            {
                _heater.TurnOn();
                _Window.close(); //Window extension
            }
            else
            {
                _heater.TurnOff();

                if (t > _WindowThreshold)
                {
                    _Window.open();  //Window extension    
                }
                
            }
                

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
