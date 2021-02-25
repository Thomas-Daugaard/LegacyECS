﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class ECS
    {
        //Property injection
        private int _threshold;
        private IHeater _heater;
        private IWindow _Window;
        private ITempSensor _tempSensor;

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


        //Constructor injection
        public ECS(int thr, IHeater heater, ITempSensor tempSensor, IWindow window)
        {
            SetThreshold(thr);
            _heater = heater;
            _tempSensor = tempSensor;
            _Window = window;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
            {
                _heater.TurnOn();
            }
            else
            {
                _heater.TurnOff();
            }

            if (t > _WindowThreshold)
            {
                _Window.open();  //Window extension    
            }
            else
            {
                _Window.close(); //Window extension
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
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest() && _Window.RunSelfTest();
        } // Lavet ændring
    }
}
