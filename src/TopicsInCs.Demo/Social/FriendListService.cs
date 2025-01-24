using TopicsInCs.Demo.Data;

namespace TopicsInCs.Demo.Social;

public class FriendListService
{
    private readonly IDatabaseService _databaseService;

    public FriendListService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public bool Add(string friendToAddFirstName, string friendToAddLastName)
    {
        var allFriends = LoadAll();
        
        foreach (var friend in allFriends)
        {
            if (friend.FirstName == friendToAddFirstName 
                && friend.LastName == friendToAddLastName)
            {
                return false;
            }
        }
        
        var friendToAdd = new Friend(friendToAddFirstName, friendToAddLastName);
        allFriends.Add(friendToAdd);
        SaveAll(allFriends);
        return true;
    }

    public bool Remove(string friendToRemoveFirstName, string friendToRemoveLastName)
    {
        var allFriends = LoadAll();
        
        foreach (var friend in allFriends)
        {
            if (friend.FirstName == friendToRemoveFirstName 
                && friend.LastName == friendToRemoveLastName)
            {
                allFriends.Remove(friend);
                SaveAll(allFriends);
                return true;
            }
        }

        return false;
    }

    public List<Friend> List()
    {
        return LoadAll();
    }

    private List<Friend> LoadAll()
    {
        var allFriends = _databaseService.LoadFriends();
        
        if (allFriends == null)
            return new List<Friend>();
        
        return allFriends;
    }

    private void SaveAll(List<Friend> friends)
    {
        _databaseService.SaveFriends(friends);
    }
}