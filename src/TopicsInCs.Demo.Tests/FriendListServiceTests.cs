using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Tests;

public class FriendListServiceTests
{
    [Fact]
    public void CanAddOne()
    {
        // Arrange
        var databaseService = new InMemoryFriendsListDatabaseService();
        var friendListService = new FriendListService(databaseService);

        // Act
        var addIsSuccess = friendListService.Add("Bob", "Bobsky");

        // Assert
        Assert.True(addIsSuccess);
        Assert.Equal(1, databaseService.DatabaseObject.Count);
    }
    
    [Fact]
    public void CanAddTwo()
    {
        // Arrange
        var databaseService = new InMemoryFriendsListDatabaseService();
        var friendListService = new FriendListService(databaseService);

        // Act
        var addIsSuccess1 = friendListService.Add("Bob", "Bobsky");
        var addIsSuccess2 = friendListService.Add("Bob", "McBob");
        
        // Assert
        Assert.True(addIsSuccess1);
        Assert.True(addIsSuccess2);
        Assert.Equal(2, databaseService.DatabaseObject.Count);
    }
    
    [Fact]
    public void CannotAddDuplicate()
    {
        // Arrange
        var databaseService = new InMemoryFriendsListDatabaseService();
        var friendListService = new FriendListService(databaseService);

        // Act
        var addIsSuccess1 = friendListService.Add("Bob", "Bobsky");
        var addIsSuccess2 = friendListService.Add("Bob", "Bobsky");
        
        // Assert
        Assert.True(addIsSuccess1);
        Assert.False(addIsSuccess2);
        Assert.Equal(1, databaseService.DatabaseObject.Count);
    }
    
    [Fact]
    public void CanRemoveExisting()
    {
        // Arrange
        var databaseService = new InMemoryFriendsListDatabaseService();
        var friendListService = new FriendListService(databaseService);
        
        databaseService.DatabaseObject.Add(new Friend("Bob", "Bobsky"));

        // Act
        var removeIsSuccess = friendListService.Remove("Bob", "Bobsky");

        // Assert
        Assert.True(removeIsSuccess);
        Assert.Equal(0, databaseService.DatabaseObject.Count);
    }
    
    
    [Fact]
    public void CannotRemoveNonExisting()
    {
        // Arrange
        var databaseService = new InMemoryFriendsListDatabaseService();
        var friendListService = new FriendListService(databaseService);
        
        databaseService.DatabaseObject.Add(new Friend("Bob", "Bobsky"));
        
        // Act
        var removeIsSuccess = friendListService.Remove("Bob", "McBob");

        // Assert
        Assert.False(removeIsSuccess);
        Assert.Equal(1, databaseService.DatabaseObject.Count);
    }
}