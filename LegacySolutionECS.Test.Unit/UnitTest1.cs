using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.IO;
using NUnit.Framework.Constraints;

namespace LegacySolutionECS.Test.Unit
{
    [TestFixture]
    public class ECSTests
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

        [Test]
        public void RunSelfTest_ReturnsTrue()
        {
            Assert.That(uut.RunSelfTest(), Is.True);
        }

        [Test]
        public void SetThreshold_GetThresholdReturnsCorrectValue()
        {
            // Arrange
            uut.SetThreshold(14);

            // Act and assert
            Assert.That(uut.GetThreshold(), Is.EqualTo(14));
        }

        [Test]
        public void GetCurTemp_TemperatureInCorrectRange()
        {
            Assert.That(uut.GetCurTemp(), Is.InRange(-5, 45));
        }

        [Test]
        public void Regulate_SetThresholdAboveMaxTempRange_HeaterTurnsOn()
        {
            // Arrange
            uut.SetThreshold(46);

            // Act
            uut.Regulate();

            Assert.That(output.ToString(), Is.EqualTo("Heater is on\r\n"));
        }

        [Test]
        public void Regulate_SetThresholdBelowMinTempRange_HeaterTurnsOff()
        {
            // Arrange
            uut.SetThreshold(-6);

            // Act
            uut.Regulate();

            Assert.That(output.ToString(), Is.EqualTo("Heater is off\r\n"));
        }
    }
}