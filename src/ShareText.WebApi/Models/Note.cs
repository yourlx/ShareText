namespace ShareText.WebApi.Models;

public class Note
{
    public Guid Id { get; set; }

    public string Content { get; set; }

    public DateTime ExpirationTime { get; set; }
}