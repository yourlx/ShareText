using ShareText.WebApi.Models;

namespace ShareText.WebApi.Services;

public interface INotesService
{
    Task<Guid> CreateNoteAsync(CreateNoteDto createNoteDto);

    Task<Note> GetNoteAsync(Guid id);
}