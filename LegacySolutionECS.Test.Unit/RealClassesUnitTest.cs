using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.IO;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework.Constraints;

namespace LegacySolutionECS.Test.Unit
{
    [TestFixture]
    public class RealECSTests
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
            uut._heater = new Heater();
            uut._tempSensor = new TempSensor();

            // Act and assert
            Assert.That(uut.RunSelfTest(), Is.True);
        }

        // Test Threshold
        [Test]
        public void SetThreshold_GetThresholdReturnsCorrectValue()
        {
            // Arrange
            uut.SetThreshold(14);

            // Act and assert
            Assert.That(uut.GetThreshold(), Is.EqualTo(14));
        }

        // Test GetCurTemp()
        [Test]
        public void GetCurTemp_TemperatureInCorrectRange()
        {
            // Arrange
            uut._tempSensor = new TempSensor();

            // Act and assert
            Assert.That(uut.GetCurTemp(), Is.InRange(-5, 45));
        }

        // Test Regulate()
        [Test]
        public void Regulate_SetThresholdAboveMaxTempRange_HeaterTurnsOn()
        {
            // Arrange
            uut._heater = new Heater();
            uut._tempSensor = new TempSensor();
            uut._Window = new Window();
            uut.SetThreshold(46);

            // Act
            uut.Regulate();

            // Assert
            Assert.That(output.ToString(), Contains.Substring("Heater is on\r\nWindow is closed\n\r\n"));
        }

        //[Test]
        //public void Regulate_SetThresholdBelowMinTempRange_HeaterTurnsOff()
        //{
        //    // Arrange
        //    uut._heater = new Heater();
        //    uut._tempSensor = new TempSensor();
        //    uut._Window = new Window();
        //    uut.SetThreshold(-6);

        //    // Flush output
        //    output = new StringWriter();
        //    Console.SetOut(output);

        //    // Act
        //    uut.Regulate();

        //    // Assert
        //    Assert.That(output.ToString(), Is.EqualTo("Heater is off\r\nWindow is open\n\r\n"));
        //}

        //[Test]
        //public void Regulate_SetLowWindowThreshold_WindowOpned()
        //{
        //    // Arrange
        //    uut._heater = new Heater();
        //    uut._tempSensor = new TempSensor();
        //    uut._Window = new Window();

        //    uut._WindowThreshold = 1;

        //    // Act
        //    uut.Regulate();

        //    // Assert
        //    Assert.That(output.ToString(), Contains.Substring("Window is open\n\r\n"));

        //}
    }
}