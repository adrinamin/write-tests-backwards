using Autofac;

using RoboFriend.Application.Services;

namespace RoboFriend.Infrastructure
{
    public class RoboFriendModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ConversationHandler>().As<IConversationHandler>();
            builder.RegisterType<RoboFactory>().As<IRoboFactory>();
            builder.RegisterType<RoboService>().As<IRoboService>();
        }
    }
}
