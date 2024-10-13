using ShareText.WebApi.Exceptions;
using ShareText.WebApi.Models;
using ShareText.WebApi.Repository;

namespace ShareText.WebApi.Services;

public class NotesService(INoteRepository noteRepository) : INotesService
{
    public async Task<Guid> CreateNoteAsync(CreateNoteDto createNoteDto)
    {
        try
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                Content = createNoteDto.Content,
                ExpirationTime = DateTime.UtcNow.AddMinutes(createNoteDto.ExpireInMinutes),
            };
            return await noteRepository.CreateNoteAsync(note);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Note> GetNoteAsync(Guid id)
    {
        try
        {
            var note = await noteRepository.GetNoteAsync(id);
            return note;
        }
        catch (NoteNotFoundException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}