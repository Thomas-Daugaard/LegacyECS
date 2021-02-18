using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.IO;
using LegacySolutionECS.Test.Unit.Fakes;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;
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
            uut.RunSelfTest();
        }

        // Test GetCurTemp()
        [Test]
        public void GetCurTemp_TemperatureCorrect()
        {
            // Arrange
            uut._tempSensor = new FakeTempSensor();

            // Act and assert
            Assert.That(uut.GetCurTemp(), Is.EqualTo(20));
        }

        // Test Regulate()
        [Test]
        public void Regulate_SetThresholdAboveMaxTempRange_HeaterTurnsOn()
        {
            // Arrange
            uut._heater = new FakeHeater();
            uut._tempSensor = new FakeTempSensor();
            uut.SetThreshold(21);

            var heater = Substitute.For<IHeater>();

            // Act
            uut.Regulate();

            // Assert
            Assert.That(heater.TurnOn().Received(1));
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