using System.Collections.Generic;
using System.Linq;

namespace SuperCoolLibrary.CoolStuff.NameCheckers
{
    public class GameOfThronesChecker : ICheckNames
    {
        public bool CheckName(string name)
        {
            var list = new List<string>
            {
                "Jon", "Eddard", "Stannis", "Jamie"
            };

            return list.Any(x => x.ToLowerInvariant() == name.ToLowerInvariant());
        }

        public string FriendlyName => "Game of Thrones";
    }
}
