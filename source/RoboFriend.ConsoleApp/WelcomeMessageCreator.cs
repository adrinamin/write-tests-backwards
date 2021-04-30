using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoboFriend.Application.Services;

namespace RoboFriend.ConsoleApp
{
    internal class WelcomeMessageCreator : IWelcomeMessageCreator
    {
        private readonly IConversationHandler conversationHandler;

        public WelcomeMessageCreator(IConversationHandler conversationHandler)
        {
            this.conversationHandler = conversationHandler ?? throw new ArgumentNullException(nameof(conversationHandler));
        }

        public void CreateWelcomeMessage()
        {
            this.conversationHandler.Talk("Hey! Welcome to RoboFriend!\n" +
                "Let's create your RoboFriend. You just need to answer a couple of questions.\n" +
                "So let's go!");
        }
    }
}
