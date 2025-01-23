using TopicsInCs.Demo.Tests;

namespace TopicsInCs.Demo.Web.Tests;

public class FriendControllerTests
{
    [Fact]
    public async Task Add()
    {
        // Arrange
        var databaseService = new InMemoryFriendsListDatabaseService();
        await using var app = Program.BuildWebApplication([], "http://localhost:5000", databaseService);
        await app.StartAsync();
        using var httpClient = new HttpClient();
        
        // Act
        using var result = await httpClient.PostAsync(
            "http://localhost:5000/friends/Add?firstName=Bob&lastName=McBob",
            new StringContent(string.Empty));
        
        
        // Assert
        Assert.True(result.IsSuccessStatusCode);
        
        // Dispose
        await app.StopAsync();
    }
}