using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RoboFriend.Core.Model
{
    [ExcludeFromCodeCoverage]
    public class Robo
    {
        public string Name { get; set; }

        public IList<string> Attributes { get; set; }
    }
}
