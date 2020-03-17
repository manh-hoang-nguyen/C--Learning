using System.Collections.Generic;
using System.Linq;

namespace SuperCoolLibrary.CoolStuff.NameCheckers
{
    public class ScoobyDooNameChecker : ICheckNames
    {
        public bool CheckName(string name)
        {
            var list = new List<string>
            {
                "Fred", "Daphne", "Velma", "Shaggy", "Scooby"
            };

            return list.Any(x => x.ToLowerInvariant() == name.ToLowerInvariant());
        }

        public string FriendlyName => "Scooby Doo";
    }
}
