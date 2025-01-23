using System.Text.Json;

namespace TopicsInCs.Demo.Data;

public class JsonFileDatabaseService<T> : IDatabaseService<T>
{
    private readonly string _filePath;

    public JsonFileDatabaseService(string filePath)
    {
        _filePath = filePath;
    }

    public T Load()
    {
        EnsureFileExists();
        var json = File.ReadAllText(_filePath);
        
        if (string.IsNullOrEmpty(json))
            return default;
        
        return JsonSerializer.Deserialize<T>(json);
    }
    
    public void Save(T data)
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