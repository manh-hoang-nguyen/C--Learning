using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhyMvvm.Model
{
    public class ListOfFriends
    {
        [JsonProperty("data")]
        public List<Friend> Data
        {
            get;
            set;
        }
    }
}