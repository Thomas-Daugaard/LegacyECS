using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.IO;
using LegacySolutionECS.Test.Unit.Fakes;
using NUnit.Framework.Constraints;

namespace LegacySolutionECS.Test.Unit
{
    [TestFixture]
    public class FakeECSTests
    {
        private ECS uut;
        private int threshold;
        private StringWriter output = new StringWriter();

        [SetUp]
        public void Setup()
        {
            Console.SetOut(output);
            threshold = 20;
            uut = new ECS(threshold);
        }


        // Test SelfTest()
        [Test]
        public void RunSelfTest_ReturnsTrue()
        {
            // Arrange
            uut._heater = new FakeHeater();
            uut._tempSensor = new FakeTempSensor();

            // Act and assert
        }

        // Test GetCurTemp()
        [Test]
        public void GetCurTemp_TemperatureInCorrectRange()
        {
            // Arrange
            uut._tempSensor = new FakeTempSensor();

            // Act and assert
        }

        // Test Regulate()
        [Test]
        public void Regulate_SetThresholdAboveMaxTempRange_HeaterTurnsOn()
        {
            // Arrange
            uut._heater = new FakeHeater();
            uut._tempSensor = new FakeTempSensor();

            // Act and Assert
        }

        [Test]
        public void Regulate_SetThresholdBelowMinTempRange_HeaterTurnsOff()
        {
            // Arrange
            uut._heater = new FakeHeater();
            uut._tempSensor = new FakeTempSensor();

            // Act and assert
        }
    }
}