using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.IO;
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
            uut.SetThreshold(46);

            // Act
            uut.Regulate();

            // Assert
            Assert.That(output.ToString(), Is.EqualTo("Heater is on\r\n"));
        }

        [Test]
        public void Regulate_SetThresholdBelowMinTempRange_HeaterTurnsOff()
        {
            // Arrange
            uut._heater = new Heater();
            uut._tempSensor = new TempSensor();
            uut.SetThreshold(-6);

            // Flush output
            output = new StringWriter();
            Console.SetOut(output);

            // Act
            uut.Regulate();

            // Assert
            Assert.That(output.ToString(), Is.EqualTo("Heater is off\r\n"));
        }
    }
}