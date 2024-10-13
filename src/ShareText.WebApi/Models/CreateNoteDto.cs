namespace ShareText.WebApi.Models;

public class CreateNoteDto
{
    public string Content { get; init; }

    public int ExpireInMinutes { get; init; }
}