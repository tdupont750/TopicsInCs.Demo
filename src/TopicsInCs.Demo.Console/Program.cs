using TopicsInCs.Demo.Data;
using TopicsInCs.Demo.Social;

namespace TopicsInCs.Demo.Console;

public static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            PrintUsage();
            return 0;
        }
        
        try
        {
            var databaseService = new JsonFileDatabaseService<List<Friend>>("demo.json");
            var friendListService = new FriendListService(databaseService);
            var exitCode = ExecuteCommand(friendListService, args);
            System.Console.WriteLine($"ExitCode: {exitCode}");  
            return exitCode;
        }
        catch (Exception e)
        {
            System.Console.Error.WriteLine(e.Message);
            return 1;
        }
    }

    private static void PrintUsage()
    {
        System.Console.WriteLine("Usage:");
        System.Console.WriteLine("  add <first-name> <last-name>");
        System.Console.WriteLine("  remove <first-name> <last-name>");
        System.Console.WriteLine("  list");
    }

    private static int ExecuteCommand(FriendListService friendListService, string[] args)
    {
        switch (args[0].ToLower())
        {
            case "add":
                var addArgs = GetNameArguments(args);
                var addIsSuccess = friendListService.Add(addArgs.FirstName, addArgs.LastName);
                return addIsSuccess ? 0 : 1;
            
            case "remove":
                var removeArgs = GetNameArguments(args);
                var removeIsSuccess = friendListService.Remove(removeArgs.FirstName, removeArgs.LastName);
                return removeIsSuccess ? 0 : 1;
            
            case "list":
                var friends = friendListService.List();
                foreach (var friend in friends)
                {
                    System.Console.WriteLine(friend.ToString());
                }
                return 0;
            
            default:
                System.Console.Error.WriteLine("Unknown command.");
                return 1;
        }
    }
    
    private static (string FirstName, string LastName) GetNameArguments(string[] args)
    {
        if (args.Length < 3)
        {
            throw new ArgumentException("Two arguments required.");
        }
        
        return (args[1], args[2]);
    }
}