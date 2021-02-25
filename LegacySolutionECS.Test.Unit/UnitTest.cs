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
        private IHeater _heater;

        [SetUp]
        public void Setup()
        {

        }

        // Test SelfTest()
        [Test]
        public void RunSelfTest_ReturnsTrue()
        {

        }

        // Test GetCurTemp()
        [Test]
        public void GetCurTemp_TemperatureCorrect()
        {

        }

        // Test Regulate()
        [Test]
        public void Regulate_SetThresholdAboveMaxTempRange_HeaterTurnsOn()
        {
            // Arrange

            uut.SetThreshold(21);

            // Act
            uut.Regulate();

        }

        [Test]
        public void Regulate_SetThresholdBelowMinTempRange_HeaterTurnsOff()
        {

        }
    }
}