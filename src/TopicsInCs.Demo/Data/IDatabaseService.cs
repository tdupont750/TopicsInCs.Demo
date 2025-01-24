using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Data;

public interface IDatabaseService
{
    List<Friend> LoadFriends();
    
    void SaveFriends(List<Friend> data);
}