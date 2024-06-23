
using LinkedLists;
public class App
{
    public static void Main(string[] args)
    {
        CommitHistory history = new CommitHistory();
        history.AddCommit(new CommitMessage("Mustafa", "Initial commit"));
        history.AddCommit(new CommitMessage("Ali", "Added README"));
        history.AddCommit(new CommitMessage("Hassan", "Fixed bugs"));
        history.AddCommit(new CommitMessage("Mustafa", "Implemented new feature"));

        Console.WriteLine("Commit History:");
        history.PrintHistory();

        string filePath = "commitHistory.json";
        history.SaveToFile(filePath);

        CommitHistory newHistory = new CommitHistory();
        newHistory.LoadFromFile(filePath);

        Console.WriteLine("\nLoaded Commit History:");
        newHistory.PrintHistory();
    }
}