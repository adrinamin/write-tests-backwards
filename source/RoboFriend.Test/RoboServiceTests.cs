using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using RoboFriend.Application.Services;

namespace RoboFriend.Test
{
    [TestClass]
    public class RoboServiceTests
    {
        [TestMethod]
        public void WalkShouldReturnTheExpectedDistanceWithCorrectUnit()
        {
            string expectedDistanceWithUnit = "10m";
            string inputDistance = "10";

            var conversationHandler = new Mock<IConversationHandler>();

            var roboService = new RoboService(conversationHandler.Object);
            string robotName = "Robi";
            var talkedRobotDistance = roboService.Walk(robotName, inputDistance);
            Assert.AreEqual(expectedDistanceWithUnit, talkedRobotDistance);
        }
    }
}
