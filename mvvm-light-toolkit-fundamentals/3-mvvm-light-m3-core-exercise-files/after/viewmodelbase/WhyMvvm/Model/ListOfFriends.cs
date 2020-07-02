using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
