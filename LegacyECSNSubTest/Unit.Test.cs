using NUnit.Framework;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;
using LegacySolutionECS;

namespace LegacyECSNSubTest
{
    [TestFixture]
    public class Tests
    {
        private ECS _uut;
        private IHeater _heater;
        private ITempSensor _sensor;
        private IWindow _window;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _sensor = Substitute.For<ITempSensor>();
            _window = Substitute.For<IWindow>();
            _uut = new ECS(25, _heater, _sensor, _window);
        }

        [Test]
        public void RunSelfTest_Success_SelftestApproved()
        {
            _heater.RunSelfTest().Returns(true);
            _sensor.RunSelfTest().Returns(true);
            _window.RunSelfTest().Returns(true);
            Assert.IsTrue(_uut.RunSelfTest());
        }

        [Test]
        public void RunSelfTest_HeaterFails_SelfTestFails()
        {
            _heater.RunSelfTest().Returns(false);
            _sensor.RunSelfTest().Returns(true);
            _window.RunSelfTest().Returns(true);
            Assert.IsFalse(_uut.RunSelfTest());
        }

        [Test]
        public void RunSelfTest_SensorFails_SelfTestFails()
        {
            _heater.RunSelfTest().Returns(true);
            _sensor.RunSelfTest().Returns(false);
            _window.RunSelfTest().Returns(true);
            Assert.IsFalse(_uut.RunSelfTest());
        }

        [Test]
        public void RunSelfTest_WindowFails_SelfTestFails()
        {
            _heater.RunSelfTest().Returns(true);
            _sensor.RunSelfTest().Returns(true);
            _window.RunSelfTest().Returns(false);
            Assert.IsFalse(_uut.RunSelfTest());
        }

        [Test]
        public void RegulateTemp_BelowThreshold_HeaterTurnOn()
        {
            _sensor.GetTemp().Returns(10);
            _uut.Regulate();
            _heater.Received(1).TurnOn();
        }

        [Test]
        public void RegulateTemp_OverThreshold_HeaterTurnOff()
        {
            _sensor.GetTemp().Returns(40);
            _uut.Regulate();
            _heater.Received(1).TurnOff();
        }
    }
}