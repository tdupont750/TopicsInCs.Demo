using TopicsInCs.Demo.Data;
using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Tests;

public class InMemoryFriendsListDatabaseService : IDatabaseService
{
    public List<Friend> DatabaseObject { get; private set; }

    public InMemoryFriendsListDatabaseService()
    {
        DatabaseObject = new List<Friend>();
    }

    public List<Friend> LoadFriends()
    {
        return DatabaseObject;
    }

    public void SaveFriends(List<Friend> data)
    {
        DatabaseObject = data;
    }
}