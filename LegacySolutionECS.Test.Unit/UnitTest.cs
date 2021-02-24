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
        private IHeater _Iheater;

        [SetUp]
        public void Setup()
        {
            Console.SetOut(output);
            threshold = 20;
            uut = new ECS(threshold);
            _Iheater = Substitute.For<IHeater>();
            uut._heater = _Iheater;
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
            uut._Window = new Window();
            uut._tempSensor = new FakeTempSensor();
            uut.SetThreshold(21);

            // Act
            uut.Regulate();
            _Iheater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_SetThresholdBelowMinTempRange_HeaterTurnsOff()
        {
            // Arrange
            uut._Window = new Window();
            uut._tempSensor = new FakeTempSensor();
            uut.SetThreshold(19);

            // Act
            uut.Regulate();

            // Assert
            _Iheater.Received(1).TurnOff();
        }
    }
}