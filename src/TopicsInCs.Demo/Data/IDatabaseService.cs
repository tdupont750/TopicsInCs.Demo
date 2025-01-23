namespace TopicsInCs.Demo.Data;

public interface IDatabaseService<T>
{
    T Load();
    
    void Save(T data);
}