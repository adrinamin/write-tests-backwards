using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoboFriend.Core.Model;

namespace RoboFriend.Application.Services
{
    public class RoboFactory : IRoboFactory
    {
        public Robo CreateRoboFriend()
        {
            return new Robo();
        }
    }
}
