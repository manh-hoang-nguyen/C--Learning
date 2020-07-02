using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhyMvvm.Model
{
    public interface IFriendsService
    {
        Task<IEnumerable<Friend>> Refresh();
        Task<string> Save(Friend updatedFriend);
    }
}