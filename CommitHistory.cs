
using System;
using System.Text.Json;

namespace LinkedLists
{
 public class CommitMessage
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public CommitMessage(string author, string message)
        {
            this.Author = author;
            this.Message = message;
            this.Timestamp = DateTime.Now;
        }
    }

    public class Commit
{
    public CommitMessage Message { get; set; }
    public Commit Prev { get; set; }
    public Commit Next { get; set; }

    public Commit(CommitMessage message)
    {
        this.Message = message;
        this.Prev = null;
        this.Next = null;
    }
}

public class CommitHistory
{
    private Commit head;
    private Commit tail;

    public CommitHistory()
    {
        this.head = null;
        this.tail = null;
    }

    public void AddCommit(CommitMessage message)
    {
        Commit newCommit = new Commit(message);
        if (this.head == null)
        {
            this.head = newCommit;
            this.tail = newCommit;
        }
        else
        {
            this.tail.Next = newCommit;
            newCommit.Prev = this.tail;
            this.tail = newCommit;
        }
    }

    public void PrintHistory()
    {
        Commit current = this.head;
        while (current != null)
        {
            Console.WriteLine($"Author: {current.Message.Author}, Message: {current.Message.Message}, Timestamp: {current.Message.Timestamp}");
            current = current.Next;
        }
    }

    public void SaveToFile(string filePath)
    {
        List<CommitMessage> commitMessages = new List<CommitMessage>();
        Commit current = this.head;
        while (current != null)
        {
            commitMessages.Add(current.Message);
            current = current.Next;
        }
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(commitMessages, options);
        File.WriteAllText(filePath, json);
    }

    public void LoadFromFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        List<CommitMessage> commitMessages = JsonSerializer.Deserialize<List<CommitMessage>>(json);
        this.head = null;
        this.tail = null;
        foreach (CommitMessage message in commitMessages)
        {
            this.AddCommit(message);
        }
    }
}


}