using TopicsInCs.Demo.Data;
using TopicsInCs.Demo.Social;

public static class Program
{
    public static int Main(string[] args)
    {
        var url = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")
                  ?? $"http://*:{Environment.GetEnvironmentVariable("PORT") ?? "5000"}";
        
        using var app = BuildWebApplication(args, url);
        
        app.UseSwagger();
        app.UseSwaggerUI();
    
        app.Run();

        return 0;
    }
    
    public static WebApplication BuildWebApplication(
        string[] args,
        string url,
        IDatabaseService<List<Friend>> databaseService = null)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services
            .AddControllers()
            .AddApplicationPart(typeof(Program).Assembly)
            .AddControllersAsServices();

        // Create JsonFileDatabaseService if one was not passed in
        if (databaseService == null)
            databaseService = new JsonFileDatabaseService<List<Friend>>("data.json");
        
        // Register our IDatabaseService
        builder.Services.AddSingleton(databaseService);

        // Register our FriendListService
        builder.Services.AddSingleton<FriendListService>();

        if (!string.IsNullOrWhiteSpace(url))
            builder.WebHost.UseUrls(url);
        
        // Build App
        var app = builder.Build();
        
        // Add controllers via reflection
        app.MapControllers();
        
        return app;
    }
}