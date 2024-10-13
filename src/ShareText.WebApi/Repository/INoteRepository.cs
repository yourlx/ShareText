using ShareText.WebApi.Models;

namespace ShareText.WebApi.Repository;

public interface INoteRepository
{
    Task<Guid> CreateNoteAsync(Note note);

    Task<Note> GetNoteAsync(Guid id);
}