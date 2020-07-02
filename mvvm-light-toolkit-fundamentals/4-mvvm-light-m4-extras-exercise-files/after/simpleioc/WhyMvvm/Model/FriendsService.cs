using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WhyMvvm.Model
{
    public class FriendsService : IFriendsService
    {
        private const string UrlBase = "http://www.galasoft.ch/labs/friends/handle.ashx?code={0}&{1}={2}&seed={3}";

        public async Task<IEnumerable<Friend>> Refresh()
        {
            var client = new HttpClient();

            var uri = new Uri(
                string.Format(
                    UrlBase,
                    Constants.Code,
                    Constants.QueryKeyAction,
                    Constants.ActionGet,
                    DateTime.Now.Ticks));

            string json = await client.GetStringAsync(uri);

            var result = JsonConvert.DeserializeObject<ListOfFriends>(json);
            return result.Data;
        }

        public async Task<string> Save(Friend updatedFriend)
        {
            var client = new HttpClient();

            var uri = new Uri(
                string.Format(
                    UrlBase,
                    Constants.Code,
                    Constants.QueryKeyAction,
                    Constants.ActionSave,
                    DateTime.Now.Ticks));

            var json = JsonConvert.SerializeObject(updatedFriend);

            try
            {
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(uri, content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception)
            {
                return "0";
            }
        }
    }
}