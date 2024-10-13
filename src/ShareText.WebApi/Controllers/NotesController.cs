using Microsoft.AspNetCore.Mvc;
using ShareText.WebApi.Exceptions;
using ShareText.WebApi.Models;
using ShareText.WebApi.Services;

namespace ShareText.WebApi.Controllers;

[ApiController]
[Route("api/v1/notes")]
public class NotesController(INotesService notesService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto request)
    {
        try
        {
            var createdNote = await notesService.CreateNoteAsync(request);
            return Ok(createdNote);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error!");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNote(Guid id)
    {
        try
        {
            var note = await notesService.GetNoteAsync(id);
            return Ok(note);
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error!");
        }
    }
}