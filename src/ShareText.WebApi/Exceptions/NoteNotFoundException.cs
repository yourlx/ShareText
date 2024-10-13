namespace ShareText.WebApi.Exceptions;

public class NoteNotFoundException : Exception
{
    public NoteNotFoundException()
    {
    }

    public NoteNotFoundException(string message) : base(message)
    {
    }

    public NoteNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}