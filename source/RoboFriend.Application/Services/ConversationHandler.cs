using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboFriend.Application.Services
{
    public class ConversationHandler : IConversationHandler
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Talk(string message)
        {
            Console.WriteLine(message);
        }
    }
}
