using System;

namespace RoboFriend.Application.Services
{
    public class RoboService : IRoboService
    {
        private readonly IConversationHandler conversationHandler;

        public RoboService(IConversationHandler conversationHandler)
        {
            this.conversationHandler = conversationHandler ?? throw new ArgumentNullException(nameof(conversationHandler));
        }

        public string Walk(string robotName, string distance)
        {
            var distanceWithUnit = $"{distance}m";
            this.conversationHandler.Talk($"{robotName} walked {distanceWithUnit} meters");
            return distanceWithUnit;
        }
    }
}
