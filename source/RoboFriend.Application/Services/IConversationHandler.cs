namespace RoboFriend.Application.Services
{
    public interface IConversationHandler
    {
        void Talk(string message);

        string Read();
    }
}
