using System.Text.Json;
using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Data;

public class JsonFileDatabaseService : IDatabaseService
{
    private readonly string _filePath;

    public JsonFileDatabaseService(string filePath)
    {
        _filePath = filePath;
    }

    public List<Friend> LoadFriends()
    {
        EnsureFileExists();
        var json = File.ReadAllText(_filePath);
        
        if (string.IsNullOrEmpty(json))
            return default;
        
        return JsonSerializer.Deserialize<List<Friend>>(json);
    }
    
    public void SaveFriends(List<Friend> data)
    {
        EnsureFileExists();
        
        var json = JsonSerializer.Serialize(data);
        File.WriteAllText(_filePath, json);
    }

    private void EnsureFileExists()
    {
        if(!File.Exists(_filePath))
            File.WriteAllText(_filePath, string.Empty);
    }
}