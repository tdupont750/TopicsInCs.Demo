using TopicsInCs.Demo.Data;
using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Tests;

public class InMemoryFriendsListDatabaseService : IDatabaseService<List<Friend>>
{
    public List<Friend> DatabaseObject { get; private set; }

    public InMemoryFriendsListDatabaseService()
    {
        DatabaseObject = new List<Friend>();
    }

    public List<Friend> Load()
    {
        return DatabaseObject;
    }

    public void Save(List<Friend> data)
    {
        DatabaseObject = data;
    }
}