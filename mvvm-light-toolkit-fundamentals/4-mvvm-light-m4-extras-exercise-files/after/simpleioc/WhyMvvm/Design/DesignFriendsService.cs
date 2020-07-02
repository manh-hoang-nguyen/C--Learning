using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhyMvvm.Model;

namespace WhyMvvm.Design
{
    public class DesignFriendsService : IFriendsService
    {
        public Task<IEnumerable<Friend>> Refresh()
        {
            var result = new List<Friend>();

            for (int index = 0; index < 10; index++)
            {
                result.Add(
                    new Friend
                    {
                        FirstName = "FirstName" + index,
                        LastName = "LastName" + index,
                        Id = index,
                        PictureUri = new Uri("http://www.galasoft.ch/logo/LogoHead128.png")
                    });
            }

            return Task.FromResult((IEnumerable<Friend>)result);
        }

        public Task<string> Save(Friend updatedFriend)
        {
            throw new NotImplementedException();
        }
    }
}