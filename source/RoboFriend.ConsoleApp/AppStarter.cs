using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging;

using RoboFriend.Application.Services;
using RoboFriend.Core.Model;

namespace RoboFriend.ConsoleApp
{
    internal class AppStarter : IAppStarter
    {
        private readonly IWelcomeMessageCreator welcomeMessageCreator;
        private readonly IConversationHandler conversationHandler;
        private readonly IRoboFactory roboFactory;
        private readonly IRoboService roboService;

        public AppStarter(
            IWelcomeMessageCreator welcomeMessageCreator, 
            IConversationHandler conversationHandler,
            IRoboFactory roboFactory,
            IRoboService roboService)
        {
            this.welcomeMessageCreator = welcomeMessageCreator ?? throw new ArgumentNullException(nameof(welcomeMessageCreator));
            this.conversationHandler = conversationHandler ?? throw new ArgumentNullException(nameof(conversationHandler));
            this.roboFactory = roboFactory ?? throw new ArgumentNullException(nameof(roboFactory));
            this.roboService = roboService ?? throw new ArgumentNullException(nameof(roboService));
        }

        public void RunApp()
        {
            welcomeMessageCreator.CreateWelcomeMessage();
            conversationHandler.Talk("So what's your name?");
            var name = conversationHandler.Read();
            conversationHandler.Talk("Hi " + name + "! Let's create your robot!");
            conversationHandler.Talk("So we need some information here. What's the name of your robot?");
            var robotName = conversationHandler.Read();
            conversationHandler.Talk("What are his attributes? You can write multiple ones, by seprating them with a comma.");
            var attributestring = conversationHandler.Read();
            var attributes = !attributestring.Contains(",")
                ? new List<string>() { attributestring }
                : attributestring.Split(",").ToList();
            var robo = InitializeRobot(robotName, attributes);

            conversationHandler.Talk("Great! Your new robot is created:\n" +
                "name: " + robo.Name + "\n" +
                "attributes: ");

            foreach (var attribute in robo.Attributes)
            {
                conversationHandler.Talk("-> " + attribute);
            }

            conversationHandler.Talk("If you want to let your robot walk just type in the distance");
            string distance = conversationHandler.Read();
            if (distance == "0")
            {
                return;
            }

            this.roboService.Walk(robo.Name, distance);
        }

        private Robo InitializeRobot(string robotName, List<string> attributes)
        {
            var robo = this.roboFactory.CreateRoboFriend();

            robo.Name = robotName;
            robo.Attributes = attributes;

            return robo;
        }
    }
}
